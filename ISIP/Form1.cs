using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

// Used for generating sine waveforms
using MathNet.Numerics;
// Used for FFT
using MathNet.Numerics.IntegralTransforms;

// Used for complex numbers
using System.Numerics;
// Used for Charts
using System.Windows.Forms.DataVisualization.Charting;




namespace ISIP {
	public partial class Form1:Form {

		int numSamples = 1000;
		int sampleRate = 2000;
		static int magSecond;
		static int magThird;
		static double PHSecond;
		static double PHThird;

		Complex[] samples;

		public Form1() {
			InitializeComponent();
		}

		public double[] GetFracData() {
			string path = "C:/Users/paul.uhrich/OneDrive - Peloton Computer Enterprises Ltd/Frac Data/Data Smoothing/Bonavista Energy Corporation - 102_02-34-033-04W5/ISIPTest.csv";
			string[] values = System.IO.File.ReadAllLines(path);
			int count = values.Length;
			double[] data = new double[count];
			for ( int i = 0; i < values.Length; i++ ) {
				data[i] = Convert.ToDouble( values[i] );
			}
			return data;
		}

		public void PlotWaveForm() {

			chart1.Series["Waveform"].Points.Clear();
			chart1.Series["Second Harmonic"].Points.Clear();
			chart1.Series["Third Harmonic"].Points.Clear();

			// Generate fundamenta, 2nd and 3rd harmonic waveforms using MathNet Libraries
			double[] fundamental = Generate.Sinusoidal(numSamples, sampleRate, 60, 10.0);
			//double[] second = Generate.Sinusoidal(numSamples, sampleRate, 120, secondHarm, 0.0, secondPH);
			//double[] third = Generate.Sinusoidal(numSamples, sampleRate, 180, thirdHarm, 0.0, thirdPH);
			double[] ISIPData = GetFracData();
			double[] second = Generate.Sinusoidal(numSamples, sampleRate, 120, 5.0);
			double[] third = Generate.Sinusoidal(numSamples, sampleRate, 180, 2.0);

			if ( !checkBox3.Checked ) {
				samples = new Complex[numSamples];

				for ( int i = 0; i < numSamples; i++ ) {
					samples[i] = new Complex( fundamental[i] + second[i] + third[i], 0 );
				}

				// Plot composite waveform
				// Each sample represents a time of 1/ sampling rate
				for ( int i = 0; i < samples.Length / 5; i++ ) {
					double time = ((i+1.0)/numSamples/2);

					chart1.Series["Waveform"].LegendText = "WaveForm";
					chart1.Series["Waveform"].ChartType = SeriesChartType.Line;

					chart1.ChartAreas["ChartArea1"].AxisX.TitleFont = new Font( "Arial", 14.0f );
					chart1.ChartAreas["ChartArea1"].AxisX.Title = "Seconds";

					if ( checkBox1.Checked ) {
						chart1.Series["Second Harmonic"].Points.AddXY
							( time, second[i] );
					}

					if ( checkBox2.Checked ) {
						chart1.Series["Third Harmonic"].Points.AddXY
							( time, third[i] );
					}

					if ( checkBox4.Checked ) {
						chart1.Series["First Harmonic"].Points.AddXY
							( time, fundamental[i] );
					}

					chart1.Series["Waveform"].Points.AddXY
						( time, samples[i].Real );

				}
			} else {

				chart1.Series["Waveform"].LegendText = "ISIP Data";
				chart1.Series["Waveform"].ChartType = SeriesChartType.Line;

				chart1.ChartAreas["ChartArea1"].AxisX.TitleFont = new Font( "Arial", 14.0f );
				chart1.ChartAreas["ChartArea1"].AxisX.Title = "Seconds";

				samples = new Complex[numSamples];

				for ( int i = 0; i < ISIPData.Length; i++ ) {
					samples[i] = new Complex( ISIPData[i], 0 );
				}

				for ( int i = 0; i < samples.Length; i++ ) {
					double time = i;
					chart1.Series["Waveform"].Points.AddXY
						( time, samples[i].Real );
				}



			}


		}

		public void PlotFFT() {

			chart2.Series["Frequency"].Points.Clear();

			// "Forward" Fourier converts time => Frequency
			Fourier.Forward( samples, FourierOptions.Matlab );

			// Plot the frequency Spectrum. Since it is a bidirectional bandwidth,
			// you only need the bottom 1/2 of the sampels
			chart2.ChartAreas["ChartArea1"].AxisX.Title = "Frequency";

			chart2.ChartAreas["ChartArea1"].AxisX.TitleFont = new Font( "Arial", 14.0f );
			chart2.ChartAreas["ChartArea1"].AxisX.MinorTickMark.Enabled = true;

			for ( int i = 1; i < samples.Length / 2; i++ ) {


				// Get the magnitude of each FFT sample;
				// = abs[sqrt(r2 + r2)]
				double mag = (2.0/numSamples)*(Math.Abs(Math.Sqrt(Math.Pow(samples[i].Real,2)+Math.Pow(samples[i].Imaginary,2))));

				double mag2 = 2*samples[i].Magnitude/numSamples;

				Complex test = 2*Complex.Conjugate(samples[2])*samples[2]/numSamples;



				// Determine how many Hz represented by each sample
				double hzPerSample = sampleRate / numSamples;

				chart2.Series["Frequency"].ChartType = SeriesChartType.Column;

				chart2.Series["Frequency"].Points.AddXY
					( hzPerSample * i, mag2 );

			}


		}

		public void PlotIFFT() {
			chart3.Series["Result"].Points.Clear();

			// "Forward" Fourier converts time => Frequency
			Fourier.Inverse( samples, FourierOptions.Matlab );

			for ( int i = 0; i < samples.Length / (checkBox3.Checked ? 1 : 5); i++ ) {
				double time = checkBox3.Checked ? i : ((i+1.0)/numSamples/2);

				chart3.Series["Result"].LegendText = "Result";
				chart3.Series["Result"].ChartType = SeriesChartType.Line;

				chart3.ChartAreas["ChartArea1"].AxisX.TitleFont = new Font( "Arial", 14.0f );
				chart3.ChartAreas["ChartArea1"].AxisX.Title = "Seconds";

				chart3.Series["Result"].Points.AddXY
					( time, samples[i].Real );

			}


		}

		public void FilterFFT( double filter ) {



			Complex[] filteredComplex = new Complex[numSamples];
			for ( int i = 0; i < numSamples; i++ ) {
				if ( rbHPF.Checked ) {
					if ( 2 * samples[i].Magnitude / numSamples < filter ) {
						samples[i] = 0;
					}
				} else if ( rbLPF.Checked ) {
					if ( 2 * samples[i].Magnitude / numSamples > filter ) {
						samples[i] = 0;
					}
				}

			}

			for ( int i = 1; i < samples.Length / 2; i++ ) {


				// Get the magnitude of each FFT sample;
				// = abs[sqrt(r2 + r2)]

				double mag2 = 2*samples[i].Magnitude/numSamples;

				// Determine how many Hz represented by each sample
				double hzPerSample = sampleRate / numSamples;

				chart2.Series["FilteredFrequency"].ChartType = SeriesChartType.Column;

				chart2.Series["FilteredFrequency"].Points.AddXY
					( hzPerSample * i, mag2 );

			}
		}

		public void Reset() {
			chart1.Series["Waveform"].Points.Clear();
			chart1.Series["First Harmonic"].Points.Clear();
			chart1.Series["Second Harmonic"].Points.Clear();
			chart1.Series["Third Harmonic"].Points.Clear();
			chart2.Series["Frequency"].Points.Clear();
			chart2.Series["FilteredFrequency"].Points.Clear();
			chart3.Series["Result"].Points.Clear();
		}


		private void button2_Click( object sender, EventArgs e ) {
			PlotWaveForm();
		}

		private void button1_Click_1( object sender, EventArgs e ) {
			PlotFFT();
		}

		private void checkBox3_CheckedChanged( object sender, EventArgs e ) {
			numSamples = checkBox3.Checked ? 64 : 1000;
			sampleRate = checkBox3.Checked ? 1 : 2000;
		}

		private void button3_Click( object sender, EventArgs e ) {
			PlotIFFT();
		}

		private void button4_Click( object sender, EventArgs e ) {
			// Filter button
			double filter = Convert.ToDouble(textBox1.Text);
			FilterFFT( filter );
		}

		private void button5_Click( object sender, EventArgs e ) {
			Reset();
		}
	}
}
