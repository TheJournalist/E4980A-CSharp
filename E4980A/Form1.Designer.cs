﻿namespace E4980A
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.rbLog = new System.Windows.Forms.RadioButton();
            this.rbLinear = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbShort = new System.Windows.Forms.RadioButton();
            this.rbMedium = new System.Windows.Forms.RadioButton();
            this.rbLong = new System.Windows.Forms.RadioButton();
            this.nudStart = new System.Windows.Forms.NumericUpDown();
            this.nudEnd = new System.Windows.Forms.NumericUpDown();
            this.nudN = new System.Windows.Forms.NumericUpDown();
            this.btnStart = new System.Windows.Forms.Button();
            this.tbDevice = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbFlist = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.nudSamples = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.tbFilename = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.tbFilePath = new System.Windows.Forms.TextBox();
            this.btnPath = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudEnd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudN)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSamples)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(12, 329);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(380, 147);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            this.richTextBox1.WordWrap = false;
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.nudN);
            this.groupBox1.Controls.Add(this.nudEnd);
            this.groupBox1.Controls.Add(this.nudStart);
            this.groupBox1.Controls.Add(this.rbLinear);
            this.groupBox1.Controls.Add(this.rbLog);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 45);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(142, 123);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Frequency";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(23, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Start";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(23, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "End";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(23, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "N. points";
            // 
            // rbLog
            // 
            this.rbLog.AutoSize = true;
            this.rbLog.Checked = true;
            this.rbLog.Location = new System.Drawing.Point(26, 97);
            this.rbLog.Name = "rbLog";
            this.rbLog.Size = new System.Drawing.Size(39, 17);
            this.rbLog.TabIndex = 7;
            this.rbLog.TabStop = true;
            this.rbLog.Text = "log";
            this.rbLog.UseVisualStyleBackColor = true;
            this.rbLog.CheckedChanged += new System.EventHandler(this.rbLinear_CheckedChanged);
            // 
            // rbLinear
            // 
            this.rbLinear.AutoSize = true;
            this.rbLinear.Location = new System.Drawing.Point(81, 97);
            this.rbLinear.Name = "rbLinear";
            this.rbLinear.Size = new System.Drawing.Size(50, 17);
            this.rbLinear.TabIndex = 8;
            this.rbLinear.Text = "linear";
            this.rbLinear.UseVisualStyleBackColor = true;
            this.rbLinear.CheckedChanged += new System.EventHandler(this.rbLinear_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.nudSamples);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.rbLong);
            this.groupBox2.Controls.Add(this.rbMedium);
            this.groupBox2.Controls.Add(this.rbShort);
            this.groupBox2.Location = new System.Drawing.Point(160, 45);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(136, 123);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Sampling Time";
            // 
            // rbShort
            // 
            this.rbShort.AutoSize = true;
            this.rbShort.Checked = true;
            this.rbShort.Location = new System.Drawing.Point(25, 22);
            this.rbShort.Name = "rbShort";
            this.rbShort.Size = new System.Drawing.Size(50, 17);
            this.rbShort.TabIndex = 9;
            this.rbShort.TabStop = true;
            this.rbShort.Text = "Short";
            this.rbShort.UseVisualStyleBackColor = true;
            // 
            // rbMedium
            // 
            this.rbMedium.AutoSize = true;
            this.rbMedium.Location = new System.Drawing.Point(25, 48);
            this.rbMedium.Name = "rbMedium";
            this.rbMedium.Size = new System.Drawing.Size(62, 17);
            this.rbMedium.TabIndex = 10;
            this.rbMedium.Text = "Medium";
            this.rbMedium.UseVisualStyleBackColor = true;
            // 
            // rbLong
            // 
            this.rbLong.AutoSize = true;
            this.rbLong.Location = new System.Drawing.Point(25, 72);
            this.rbLong.Name = "rbLong";
            this.rbLong.Size = new System.Drawing.Size(49, 17);
            this.rbLong.TabIndex = 11;
            this.rbLong.Text = "Long";
            this.rbLong.UseVisualStyleBackColor = true;
            // 
            // nudStart
            // 
            this.nudStart.Location = new System.Drawing.Point(55, 19);
            this.nudStart.Minimum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nudStart.Name = "nudStart";
            this.nudStart.Size = new System.Drawing.Size(76, 20);
            this.nudStart.TabIndex = 4;
            this.nudStart.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nudStart.ValueChanged += new System.EventHandler(this.nudStart_ValueChanged);
            // 
            // nudEnd
            // 
            this.nudEnd.Location = new System.Drawing.Point(55, 46);
            this.nudEnd.Maximum = new decimal(new int[] {
            2000000,
            0,
            0,
            0});
            this.nudEnd.Name = "nudEnd";
            this.nudEnd.Size = new System.Drawing.Size(76, 20);
            this.nudEnd.TabIndex = 9;
            this.nudEnd.Value = new decimal(new int[] {
            2000000,
            0,
            0,
            0});
            this.nudEnd.ValueChanged += new System.EventHandler(this.nudStart_ValueChanged);
            // 
            // nudN
            // 
            this.nudN.Location = new System.Drawing.Point(78, 71);
            this.nudN.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudN.Name = "nudN";
            this.nudN.Size = new System.Drawing.Size(53, 20);
            this.nudN.TabIndex = 10;
            this.nudN.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.nudN.ValueChanged += new System.EventHandler(this.nudStart_ValueChanged);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(311, 265);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(81, 44);
            this.btnStart.TabIndex = 4;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // tbDevice
            // 
            this.tbDevice.Location = new System.Drawing.Point(82, 12);
            this.tbDevice.Name = "tbDevice";
            this.tbDevice.Size = new System.Drawing.Size(310, 20);
            this.tbDevice.TabIndex = 5;
            this.tbDevice.Text = "USB0::0x2A8D::0x2F01::MY46620088::0::INSTR";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Device ID";
            // 
            // tbFlist
            // 
            this.tbFlist.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbFlist.Location = new System.Drawing.Point(3, 16);
            this.tbFlist.Name = "tbFlist";
            this.tbFlist.Size = new System.Drawing.Size(374, 20);
            this.tbFlist.TabIndex = 7;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tbFlist);
            this.groupBox3.Location = new System.Drawing.Point(12, 174);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(380, 40);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Frequency List";
            // 
            // nudSamples
            // 
            this.nudSamples.Location = new System.Drawing.Point(77, 96);
            this.nudSamples.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudSamples.Name = "nudSamples";
            this.nudSamples.Size = new System.Drawing.Size(53, 20);
            this.nudSamples.TabIndex = 12;
            this.nudSamples.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 98);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "N. samples";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.tbFilename);
            this.groupBox4.Location = new System.Drawing.Point(12, 265);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(293, 40);
            this.groupBox4.TabIndex = 9;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Filename";
            // 
            // tbFilename
            // 
            this.tbFilename.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbFilename.Location = new System.Drawing.Point(3, 16);
            this.tbFilename.Name = "tbFilename";
            this.tbFilename.Size = new System.Drawing.Size(287, 20);
            this.tbFilename.TabIndex = 7;
            this.tbFilename.Text = "Measurement";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.tbFilePath);
            this.groupBox5.Location = new System.Drawing.Point(12, 220);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(293, 40);
            this.groupBox5.TabIndex = 10;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Path";
            // 
            // tbFilePath
            // 
            this.tbFilePath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbFilePath.Location = new System.Drawing.Point(3, 16);
            this.tbFilePath.Name = "tbFilePath";
            this.tbFilePath.Size = new System.Drawing.Size(287, 20);
            this.tbFilePath.TabIndex = 7;
            // 
            // btnPath
            // 
            this.btnPath.Location = new System.Drawing.Point(311, 233);
            this.btnPath.Name = "btnPath";
            this.btnPath.Size = new System.Drawing.Size(81, 23);
            this.btnPath.TabIndex = 11;
            this.btnPath.Text = "Select";
            this.btnPath.UseVisualStyleBackColor = true;
            this.btnPath.Click += new System.EventHandler(this.btnPath_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(411, 488);
            this.Controls.Add(this.btnPath);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbDevice);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.richTextBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "E4980A LCR Meter";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudEnd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudN)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSamples)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbLinear;
        private System.Windows.Forms.RadioButton rbLog;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbLong;
        private System.Windows.Forms.RadioButton rbMedium;
        private System.Windows.Forms.RadioButton rbShort;
        private System.Windows.Forms.NumericUpDown nudN;
        private System.Windows.Forms.NumericUpDown nudEnd;
        private System.Windows.Forms.NumericUpDown nudStart;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TextBox tbDevice;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbFlist;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.NumericUpDown nudSamples;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox tbFilename;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox tbFilePath;
        private System.Windows.Forms.Button btnPath;
    }
}

