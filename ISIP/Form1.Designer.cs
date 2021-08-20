
namespace ISIP {
	partial class Form1 {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose( bool disposing ) {
			if ( disposing && ( components != null ) ) {
				components.Dispose();
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea10 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
			System.Windows.Forms.DataVisualization.Charting.Legend legend10 = new System.Windows.Forms.DataVisualization.Charting.Legend();
			System.Windows.Forms.DataVisualization.Charting.Series series22 = new System.Windows.Forms.DataVisualization.Charting.Series();
			System.Windows.Forms.DataVisualization.Charting.Series series23 = new System.Windows.Forms.DataVisualization.Charting.Series();
			System.Windows.Forms.DataVisualization.Charting.Series series24 = new System.Windows.Forms.DataVisualization.Charting.Series();
			System.Windows.Forms.DataVisualization.Charting.Series series25 = new System.Windows.Forms.DataVisualization.Charting.Series();
			System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea11 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
			System.Windows.Forms.DataVisualization.Charting.Legend legend11 = new System.Windows.Forms.DataVisualization.Charting.Legend();
			System.Windows.Forms.DataVisualization.Charting.Series series26 = new System.Windows.Forms.DataVisualization.Charting.Series();
			System.Windows.Forms.DataVisualization.Charting.Series series27 = new System.Windows.Forms.DataVisualization.Charting.Series();
			System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea12 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
			System.Windows.Forms.DataVisualization.Charting.Legend legend12 = new System.Windows.Forms.DataVisualization.Charting.Legend();
			System.Windows.Forms.DataVisualization.Charting.Series series28 = new System.Windows.Forms.DataVisualization.Charting.Series();
			this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.checkBox2 = new System.Windows.Forms.CheckBox();
			this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.checkBox3 = new System.Windows.Forms.CheckBox();
			this.chart3 = new System.Windows.Forms.DataVisualization.Charting.Chart();
			this.button3 = new System.Windows.Forms.Button();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.button4 = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.checkBox4 = new System.Windows.Forms.CheckBox();
			this.button5 = new System.Windows.Forms.Button();
			this.rbHPF = new System.Windows.Forms.RadioButton();
			this.rbLPF = new System.Windows.Forms.RadioButton();
			((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.chart3)).BeginInit();
			this.SuspendLayout();
			// 
			// chart1
			// 
			chartArea10.Name = "ChartArea1";
			this.chart1.ChartAreas.Add(chartArea10);
			legend10.Name = "Legend1";
			this.chart1.Legends.Add(legend10);
			this.chart1.Location = new System.Drawing.Point(14, 25);
			this.chart1.Name = "chart1";
			series22.ChartArea = "ChartArea1";
			series22.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
			series22.Legend = "Legend1";
			series22.Name = "Waveform";
			series23.ChartArea = "ChartArea1";
			series23.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
			series23.Legend = "Legend1";
			series23.Name = "First Harmonic";
			series24.ChartArea = "ChartArea1";
			series24.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
			series24.Legend = "Legend1";
			series24.Name = "Second Harmonic";
			series25.ChartArea = "ChartArea1";
			series25.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
			series25.Legend = "Legend1";
			series25.Name = "Third Harmonic";
			this.chart1.Series.Add(series22);
			this.chart1.Series.Add(series23);
			this.chart1.Series.Add(series24);
			this.chart1.Series.Add(series25);
			this.chart1.Size = new System.Drawing.Size(2015, 501);
			this.chart1.TabIndex = 0;
			this.chart1.Text = "chart1";
			// 
			// checkBox1
			// 
			this.checkBox1.AutoSize = true;
			this.checkBox1.Location = new System.Drawing.Point(2488, 133);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(106, 29);
			this.checkBox1.TabIndex = 1;
			this.checkBox1.Text = "120Hz";
			this.checkBox1.UseVisualStyleBackColor = true;
			// 
			// checkBox2
			// 
			this.checkBox2.AutoSize = true;
			this.checkBox2.Location = new System.Drawing.Point(2670, 133);
			this.checkBox2.Name = "checkBox2";
			this.checkBox2.Size = new System.Drawing.Size(106, 29);
			this.checkBox2.TabIndex = 2;
			this.checkBox2.Text = "180Hz";
			this.checkBox2.UseVisualStyleBackColor = true;
			// 
			// chart2
			// 
			chartArea11.Name = "ChartArea1";
			this.chart2.ChartAreas.Add(chartArea11);
			legend11.Name = "Legend1";
			this.chart2.Legends.Add(legend11);
			this.chart2.Location = new System.Drawing.Point(12, 553);
			this.chart2.Name = "chart2";
			series26.ChartArea = "ChartArea1";
			series26.Legend = "Legend1";
			series26.Name = "Frequency";
			series27.ChartArea = "ChartArea1";
			series27.Legend = "Legend1";
			series27.Name = "FilteredFrequency";
			this.chart2.Series.Add(series26);
			this.chart2.Series.Add(series27);
			this.chart2.Size = new System.Drawing.Size(2013, 446);
			this.chart2.TabIndex = 3;
			this.chart2.Text = "chart2";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(2165, 602);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(459, 66);
			this.button1.TabIndex = 5;
			this.button1.Text = "FFT GOOOOOO!!!";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click_1);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(2314, 193);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(382, 81);
			this.button2.TabIndex = 6;
			this.button2.Text = "Draw Waves";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// checkBox3
			// 
			this.checkBox3.AutoSize = true;
			this.checkBox3.Location = new System.Drawing.Point(2314, 56);
			this.checkBox3.Name = "checkBox3";
			this.checkBox3.Size = new System.Drawing.Size(189, 29);
			this.checkBox3.TabIndex = 7;
			this.checkBox3.Text = "Use ISIP Data?";
			this.checkBox3.UseVisualStyleBackColor = true;
			this.checkBox3.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);
			// 
			// chart3
			// 
			chartArea12.Name = "ChartArea1";
			this.chart3.ChartAreas.Add(chartArea12);
			legend12.Name = "Legend1";
			this.chart3.Legends.Add(legend12);
			this.chart3.Location = new System.Drawing.Point(12, 1030);
			this.chart3.Name = "chart3";
			series28.ChartArea = "ChartArea1";
			series28.Legend = "Legend1";
			series28.Name = "Result";
			this.chart3.Series.Add(series28);
			this.chart3.Size = new System.Drawing.Size(2012, 393);
			this.chart3.TabIndex = 8;
			this.chart3.Text = "chart3";
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(2190, 1089);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(491, 93);
			this.button3.TabIndex = 9;
			this.button3.Text = "IFFT  GOOOOOOOOO!!!!!";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(2690, 602);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(428, 31);
			this.textBox1.TabIndex = 10;
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(2698, 777);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(420, 56);
			this.button4.TabIndex = 11;
			this.button4.Text = "Filter!";
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(2686, 548);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(242, 50);
			this.label1.TabIndex = 12;
			this.label1.Text = "Filter Value";
			// 
			// checkBox4
			// 
			this.checkBox4.AutoSize = true;
			this.checkBox4.Location = new System.Drawing.Point(2336, 133);
			this.checkBox4.Name = "checkBox4";
			this.checkBox4.Size = new System.Drawing.Size(94, 29);
			this.checkBox4.TabIndex = 13;
			this.checkBox4.Text = "60Hz";
			this.checkBox4.UseVisualStyleBackColor = true;
			// 
			// button5
			// 
			this.button5.Location = new System.Drawing.Point(2843, 25);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(317, 49);
			this.button5.TabIndex = 14;
			this.button5.Text = "Reset";
			this.button5.UseVisualStyleBackColor = true;
			this.button5.Click += new System.EventHandler(this.button5_Click);
			// 
			// rbHPF
			// 
			this.rbHPF.AutoSize = true;
			this.rbHPF.Location = new System.Drawing.Point(2698, 659);
			this.rbHPF.Name = "rbHPF";
			this.rbHPF.Size = new System.Drawing.Size(195, 29);
			this.rbHPF.TabIndex = 15;
			this.rbHPF.TabStop = true;
			this.rbHPF.Text = "High Pass Filter";
			this.rbHPF.UseVisualStyleBackColor = true;
			// 
			// rbLPF
			// 
			this.rbLPF.AutoSize = true;
			this.rbLPF.Location = new System.Drawing.Point(2913, 659);
			this.rbLPF.Name = "rbLPF";
			this.rbLPF.Size = new System.Drawing.Size(190, 29);
			this.rbLPF.TabIndex = 16;
			this.rbLPF.TabStop = true;
			this.rbLPF.Text = "Low Pass Filter";
			this.rbLPF.UseVisualStyleBackColor = true;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(3212, 1449);
			this.Controls.Add(this.rbLPF);
			this.Controls.Add(this.rbHPF);
			this.Controls.Add(this.button5);
			this.Controls.Add(this.checkBox4);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.button4);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.chart3);
			this.Controls.Add(this.checkBox3);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.chart2);
			this.Controls.Add(this.checkBox2);
			this.Controls.Add(this.checkBox1);
			this.Controls.Add(this.chart1);
			this.Name = "Form1";
			this.Text = "Form1";
			((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.chart3)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
		private System.Windows.Forms.CheckBox checkBox1;
		private System.Windows.Forms.CheckBox checkBox2;
		private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.CheckBox checkBox3;
		private System.Windows.Forms.DataVisualization.Charting.Chart chart3;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.CheckBox checkBox4;
		private System.Windows.Forms.Button button5;
		private System.Windows.Forms.RadioButton rbHPF;
		private System.Windows.Forms.RadioButton rbLPF;
	}
}

