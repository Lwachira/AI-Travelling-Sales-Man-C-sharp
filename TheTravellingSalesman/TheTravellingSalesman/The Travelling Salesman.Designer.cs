namespace TheTravellingSalesman
{
    partial class TSPForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TSPForm));
            this.pb1 = new System.Windows.Forms.PictureBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnCircleTest = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnGenertate = new System.Windows.Forms.Button();
            this.lblGen = new System.Windows.Forms.Label();
            this.lblDistance = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbCrossOver = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.numCrossover = new System.Windows.Forms.NumericUpDown();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblDesiredDistance = new System.Windows.Forms.Label();
            this.tbDesiredDist = new System.Windows.Forms.TextBox();
            this.cbRandomCity = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbCityNum = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbPopSize = new System.Windows.Forms.TextBox();
            this.tbFileName = new System.Windows.Forms.TextBox();
            this.btnOpenFile = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.tbGenSize = new System.Windows.Forms.TextBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.btnStop = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cbSUS = new System.Windows.Forms.CheckBox();
            this.cbRoulette = new System.Windows.Forms.CheckBox();
            this.cbTournament = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbMutation = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.numMutation = new System.Windows.Forms.NumericUpDown();
            this.btnPause = new System.Windows.Forms.Button();
            this.openFile = new System.Windows.Forms.OpenFileDialog();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.pb1)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCrossover)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMutation)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // pb1
            // 
            this.pb1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pb1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pb1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pb1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pb1.ErrorImage = null;
            this.pb1.ImageLocation = "0,0";
            this.pb1.Location = new System.Drawing.Point(12, 12);
            this.pb1.Name = "pb1";
            this.pb1.Padding = new System.Windows.Forms.Padding(5);
            this.pb1.Size = new System.Drawing.Size(806, 558);
            this.pb1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pb1.TabIndex = 0;
            this.pb1.TabStop = false;
            this.pb1.Paint += new System.Windows.Forms.PaintEventHandler(this.pb1_Paint);
            // 
            // btnStart
            // 
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnStart.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnStart.Location = new System.Drawing.Point(2, 23);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(69, 23);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnCircleTest
            // 
            this.btnCircleTest.Location = new System.Drawing.Point(213, 148);
            this.btnCircleTest.Name = "btnCircleTest";
            this.btnCircleTest.Size = new System.Drawing.Size(75, 23);
            this.btnCircleTest.TabIndex = 3;
            this.btnCircleTest.Text = "Circle";
            this.btnCircleTest.UseVisualStyleBackColor = true;
            this.btnCircleTest.Click += new System.EventHandler(this.btnCircleTest_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 101);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Generate Cities";
            // 
            // btnGenertate
            // 
            this.btnGenertate.Location = new System.Drawing.Point(132, 148);
            this.btnGenertate.Name = "btnGenertate";
            this.btnGenertate.Size = new System.Drawing.Size(75, 23);
            this.btnGenertate.TabIndex = 0;
            this.btnGenertate.Text = "Generate";
            this.btnGenertate.UseVisualStyleBackColor = true;
            this.btnGenertate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // lblGen
            // 
            this.lblGen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblGen.AutoSize = true;
            this.lblGen.Location = new System.Drawing.Point(462, 29);
            this.lblGen.Name = "lblGen";
            this.lblGen.Size = new System.Drawing.Size(65, 13);
            this.lblGen.TabIndex = 4;
            this.lblGen.Text = "Generation: ";
            // 
            // lblDistance
            // 
            this.lblDistance.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDistance.AutoSize = true;
            this.lblDistance.Location = new System.Drawing.Point(670, 29);
            this.lblDistance.Name = "lblDistance";
            this.lblDistance.Size = new System.Drawing.Size(55, 13);
            this.lblDistance.TabIndex = 5;
            this.lblDistance.Text = "Distance: ";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.cmbCrossOver);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.numCrossover);
            this.groupBox3.Location = new System.Drawing.Point(858, 225);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(434, 123);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Crossover Options";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 38);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "Operators";
            // 
            // cmbCrossOver
            // 
            this.cmbCrossOver.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCrossOver.FormattingEnabled = true;
            this.cmbCrossOver.Items.AddRange(new object[] {
            "Random Point Crossover (Eww)",
            "Single Point Inversion Crossover (Eww)",
            "Two Point Inversion Crossover (Eww)",
            "New Random Point Crossover",
            "New Single Point Inversion Crossover",
            "New Two Point Inversion Crossover",
            "Order Based Crossover",
            "Partially Mapped Crossover"});
            this.cmbCrossOver.Location = new System.Drawing.Point(65, 35);
            this.cmbCrossOver.Name = "cmbCrossOver";
            this.cmbCrossOver.Size = new System.Drawing.Size(201, 21);
            this.cmbCrossOver.TabIndex = 16;
            this.cmbCrossOver.SelectedIndexChanged += new System.EventHandler(this.cmbCrossOver_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Crossover Rate";
            // 
            // numCrossover
            // 
            this.numCrossover.Location = new System.Drawing.Point(92, 87);
            this.numCrossover.Name = "numCrossover";
            this.numCrossover.Size = new System.Drawing.Size(40, 20);
            this.numCrossover.TabIndex = 9;
            this.numCrossover.Value = new decimal(new int[] {
            70,
            0,
            0,
            0});
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.lblDesiredDistance);
            this.groupBox2.Controls.Add(this.tbDesiredDist);
            this.groupBox2.Controls.Add(this.cbRandomCity);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.tbCityNum);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.tbPopSize);
            this.groupBox2.Controls.Add(this.tbFileName);
            this.groupBox2.Controls.Add(this.btnOpenFile);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.btnCircleTest);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.tbGenSize);
            this.groupBox2.Controls.Add(this.numericUpDown1);
            this.groupBox2.Controls.Add(this.btnGenertate);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(858, 35);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(434, 184);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "General Options";
            // 
            // lblDesiredDistance
            // 
            this.lblDesiredDistance.AutoSize = true;
            this.lblDesiredDistance.Location = new System.Drawing.Point(234, 70);
            this.lblDesiredDistance.Name = "lblDesiredDistance";
            this.lblDesiredDistance.Size = new System.Drawing.Size(111, 13);
            this.lblDesiredDistance.TabIndex = 14;
            this.lblDesiredDistance.Text = "Desired Route Length";
            // 
            // tbDesiredDist
            // 
            this.tbDesiredDist.Location = new System.Drawing.Point(371, 66);
            this.tbDesiredDist.Name = "tbDesiredDist";
            this.tbDesiredDist.Size = new System.Drawing.Size(43, 20);
            this.tbDesiredDist.TabIndex = 13;
            this.tbDesiredDist.Text = "625";
            this.tbDesiredDist.TextChanged += new System.EventHandler(this.tbDesiredDist_TextChanged);
            // 
            // cbRandomCity
            // 
            this.cbRandomCity.AutoSize = true;
            this.cbRandomCity.Checked = true;
            this.cbRandomCity.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbRandomCity.Location = new System.Drawing.Point(203, 125);
            this.cbRandomCity.Name = "cbRandomCity";
            this.cbRandomCity.Size = new System.Drawing.Size(94, 17);
            this.cbRandomCity.TabIndex = 12;
            this.cbRandomCity.Text = "Random Cities";
            this.cbRandomCity.UseVisualStyleBackColor = true;
            this.cbRandomCity.CheckedChanged += new System.EventHandler(this.cbRandomCity_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 127);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Number of Cities";
            // 
            // tbCityNum
            // 
            this.tbCityNum.Location = new System.Drawing.Point(132, 122);
            this.tbCityNum.Name = "tbCityNum";
            this.tbCityNum.Size = new System.Drawing.Size(36, 20);
            this.tbCityNum.TabIndex = 10;
            this.tbCityNum.Text = "20";
            this.tbCityNum.TextChanged += new System.EventHandler(this.tbCityNum_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 66);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Population Size";
            // 
            // tbPopSize
            // 
            this.tbPopSize.Location = new System.Drawing.Point(132, 63);
            this.tbPopSize.Name = "tbPopSize";
            this.tbPopSize.Size = new System.Drawing.Size(40, 20);
            this.tbPopSize.TabIndex = 8;
            this.tbPopSize.Text = "200";
            this.tbPopSize.TextChanged += new System.EventHandler(this.tbPopSize_TextChanged);
            // 
            // tbFileName
            // 
            this.tbFileName.Enabled = false;
            this.tbFileName.Location = new System.Drawing.Point(132, 93);
            this.tbFileName.Name = "tbFileName";
            this.tbFileName.Size = new System.Drawing.Size(137, 20);
            this.tbFileName.TabIndex = 7;
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.Location = new System.Drawing.Point(280, 91);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(65, 23);
            this.btnOpenFile.TabIndex = 6;
            this.btnOpenFile.Text = "Load File";
            this.btnOpenFile.UseVisualStyleBackColor = true;
            this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Amount of Generations";
            // 
            // tbGenSize
            // 
            this.tbGenSize.Location = new System.Drawing.Point(132, 37);
            this.tbGenSize.Name = "tbGenSize";
            this.tbGenSize.Size = new System.Drawing.Size(40, 20);
            this.tbGenSize.TabIndex = 1;
            this.tbGenSize.Text = "500";
            this.tbGenSize.TextChanged += new System.EventHandler(this.tbGenSize_TextChanged);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(371, 37);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(43, 20);
            this.numericUpDown1.TabIndex = 3;
            this.numericUpDown1.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(278, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Elite Percent";
            // 
            // btnStop
            // 
            this.btnStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnStop.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnStop.Location = new System.Drawing.Point(206, 23);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(69, 23);
            this.btnStop.TabIndex = 7;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.cbSUS);
            this.groupBox4.Controls.Add(this.cbRoulette);
            this.groupBox4.Controls.Add(this.cbTournament);
            this.groupBox4.Location = new System.Drawing.Point(858, 514);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(434, 119);
            this.groupBox4.TabIndex = 8;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Selection Options";
            // 
            // cbSUS
            // 
            this.cbSUS.AutoSize = true;
            this.cbSUS.Location = new System.Drawing.Point(227, 39);
            this.cbSUS.Name = "cbSUS";
            this.cbSUS.Size = new System.Drawing.Size(169, 17);
            this.cbSUS.TabIndex = 15;
            this.cbSUS.Text = "Stochastic Universal Sampling";
            this.cbSUS.UseVisualStyleBackColor = true;
            this.cbSUS.CheckedChanged += new System.EventHandler(this.cbSUS_CheckedChanged);
            // 
            // cbRoulette
            // 
            this.cbRoulette.AutoSize = true;
            this.cbRoulette.Checked = true;
            this.cbRoulette.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbRoulette.Location = new System.Drawing.Point(25, 39);
            this.cbRoulette.Name = "cbRoulette";
            this.cbRoulette.Size = new System.Drawing.Size(147, 17);
            this.cbRoulette.TabIndex = 13;
            this.cbRoulette.Text = "Roulette Wheel Selection";
            this.cbRoulette.UseVisualStyleBackColor = true;
            this.cbRoulette.CheckedChanged += new System.EventHandler(this.cbRoulette_CheckedChanged);
            // 
            // cbTournament
            // 
            this.cbTournament.AutoSize = true;
            this.cbTournament.Location = new System.Drawing.Point(25, 73);
            this.cbTournament.Name = "cbTournament";
            this.cbTournament.Size = new System.Drawing.Size(130, 17);
            this.cbTournament.TabIndex = 14;
            this.cbTournament.Text = "Tournament Selection";
            this.cbTournament.UseVisualStyleBackColor = true;
            this.cbTournament.CheckedChanged += new System.EventHandler(this.cbTournament_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.cmbMutation);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.numMutation);
            this.groupBox1.Location = new System.Drawing.Point(858, 368);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(434, 123);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Mutation Options";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 33);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 13);
            this.label9.TabIndex = 18;
            this.label9.Text = "Operators";
            // 
            // cmbMutation
            // 
            this.cmbMutation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMutation.FormattingEnabled = true;
            this.cmbMutation.Items.AddRange(new object[] {
            "Random Point Mutation",
            "Displacement Mutation ",
            "Inversion Displacement Mutation",
            "Inversion Mutation (New)",
            "Scrumbled Mutation (New)",
            "Insertion Mutation (New)"});
            this.cmbMutation.Location = new System.Drawing.Point(65, 30);
            this.cmbMutation.Name = "cmbMutation";
            this.cmbMutation.Size = new System.Drawing.Size(201, 21);
            this.cmbMutation.TabIndex = 17;
            this.cmbMutation.SelectedIndexChanged += new System.EventHandler(this.cmbMutation_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 75);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Mutation Rate";
            // 
            // numMutation
            // 
            this.numMutation.Location = new System.Drawing.Point(86, 67);
            this.numMutation.Name = "numMutation";
            this.numMutation.Size = new System.Drawing.Size(40, 20);
            this.numMutation.TabIndex = 5;
            this.numMutation.Value = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.numMutation.ValueChanged += new System.EventHandler(this.numMutation_ValueChanged);
            // 
            // btnPause
            // 
            this.btnPause.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPause.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnPause.Location = new System.Drawing.Point(101, 23);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(69, 23);
            this.btnPause.TabIndex = 14;
            this.btnPause.Text = "Pause";
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // openFile
            // 
            this.openFile.RestoreDirectory = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox5.Controls.Add(this.btnStart);
            this.groupBox5.Controls.Add(this.btnPause);
            this.groupBox5.Controls.Add(this.lblGen);
            this.groupBox5.Controls.Add(this.lblDistance);
            this.groupBox5.Controls.Add(this.btnStop);
            this.groupBox5.Location = new System.Drawing.Point(12, 587);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(806, 55);
            this.groupBox5.TabIndex = 15;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "groupBox5";
            // 
            // TSPForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1326, 654);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.pb1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TSPForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "The Travelling Salesman";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.TSPForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pb1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCrossover)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMutation)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pb1;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnGenertate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblGen;
        private System.Windows.Forms.Label lblDistance;
        private System.Windows.Forms.Button btnCircleTest;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numCrossover;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbGenSize;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox cbRoulette;
        private System.Windows.Forms.CheckBox cbTournament;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numMutation;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.OpenFileDialog openFile;
        private System.Windows.Forms.Button btnOpenFile;
        private System.Windows.Forms.TextBox tbFileName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbPopSize;
        private System.Windows.Forms.TextBox tbCityNum;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox cbRandomCity;
        private System.Windows.Forms.CheckBox cbSUS;
        private System.Windows.Forms.TextBox tbDesiredDist;
        private System.Windows.Forms.Label lblDesiredDistance;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.ComboBox cmbCrossOver;
        private System.Windows.Forms.ComboBox cmbMutation;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
    }
}

