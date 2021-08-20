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
		string path;

		Complex[] samples;

		public Form1() {
			InitializeComponent();
		}

		public double[] GetFracData() {
			// Get data from files 
			string[] values = System.IO.File.ReadAllLines(path);
			// Get the number of samples,  we are assuming that we are 1 sample per second. ie, 1hz. 
			numSamples = values.Length;
			sampleRate = 1;
			// convert the data from string value in the file,  to doubles for ingestion. 
			double[] data = new double[numSamples];
			for ( int i = 0; i < values.Length; i++ ) {
				data[i] = Convert.ToDouble( values[i] );
			}
			// return the double array.
			return data;
		}

		public void PlotWaveForm() {

			// Clear the chart in case there is something there. 
			chart1.Series["Waveform"].Points.Clear();
			chart1.Series["Second Harmonic"].Points.Clear();
			chart1.Series["Third Harmonic"].Points.Clear();

			// If we are getting the frac data,  lets get that
			double[] ISIPData = checkBox3.Checked ? GetFracData() : null;

			// Otherwise we are testing, and we can just generate some curves
			// Generate fundamenta, 2nd and 3rd harmonic waveforms using MathNet Libraries
			double[] fundamental = Generate.Sinusoidal(numSamples, sampleRate, 60, 10.0);
			double[] second = Generate.Sinusoidal(numSamples, sampleRate, 120, 5.0);
			double[] third = Generate.Sinusoidal(numSamples, sampleRate, 180, 2.0);

			// IF we are just teseting,  then make a aggreage waveform. 
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
				// Otherwise we are taking real data,  and lets use that 
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
				//double mag = (2.0/numSamples)*(Math.Abs(Math.Sqrt(Math.Pow(samples[i].Real,2)+Math.Pow(samples[i].Imaginary,2))));

				double magnitude = 2*samples[i].Magnitude/numSamples;

				// Determine how many Hz represented by each sample
				double hzPerSample = sampleRate / numSamples;

				chart2.Series["Frequency"].ChartType = SeriesChartType.Column;

				chart2.Series["Frequency"].Points.AddXY
					( hzPerSample * i, magnitude );

			}


		}

		public void PlotIFFT() {
			chart3.Series["Result"].Points.Clear();

			// "Forward" Fourier converts time => Frequency
			Fourier.Inverse( samples, FourierOptions.Matlab );

			for ( int i = 0; i < samples.Length / ( checkBox3.Checked ? 1 : 5 ); i++ ) {
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

				double magnitude = 2*samples[i].Magnitude/numSamples;

				// Determine how many Hz represented by each sample
				double hzPerSample = sampleRate / numSamples;

				chart2.Series["FilteredFrequency"].ChartType = SeriesChartType.Column;

				chart2.Series["FilteredFrequency"].Points.AddXY
					( hzPerSample * i, magnitude );

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

		private void btnGetData_Click( object sender, EventArgs e ) {

			if ( openFileDialog1.ShowDialog() == DialogResult.OK ) {
				tbFilePath.Text = openFileDialog1.FileName;
				path = openFileDialog1.FileName;
			}
		}
	}
}
