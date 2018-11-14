namespace Dataanalysis
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
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.lblinterval = new System.Windows.Forms.Label();
			this.lblsmode = new System.Windows.Forms.Label();
			this.lbldate = new System.Windows.Forms.Label();
			this.lbllength = new System.Windows.Forms.Label();
			this.lblstartdate = new System.Windows.Forms.Label();
			this.lblmonitor = new System.Windows.Forms.Label();
			this.lblversion = new System.Windows.Forms.Label();
			this.btnopfile = new System.Windows.Forms.Button();
			this.btnseldata = new System.Windows.Forms.Button();
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.time_interval = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.heart_rate = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.speeds = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.cadences = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.altitudes = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Power_watt = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.power_balance = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.pending_index = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.left_right_balance = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.label19 = new System.Windows.Forms.Label();
			this.label18 = new System.Windows.Forms.Label();
			this.label17 = new System.Windows.Forms.Label();
			this.label16 = new System.Windows.Forms.Label();
			this.label15 = new System.Windows.Forms.Label();
			this.label14 = new System.Windows.Forms.Label();
			this.label13 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.calendar = new System.Windows.Forms.MonthCalendar();
			this.btngraph = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.lblinterval);
			this.groupBox1.Controls.Add(this.lblsmode);
			this.groupBox1.Controls.Add(this.lbldate);
			this.groupBox1.Controls.Add(this.lbllength);
			this.groupBox1.Controls.Add(this.lblstartdate);
			this.groupBox1.Controls.Add(this.lblmonitor);
			this.groupBox1.Controls.Add(this.lblversion);
			this.groupBox1.Location = new System.Drawing.Point(111, 58);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(200, 160);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Header";
			// 
			// lblinterval
			// 
			this.lblinterval.AutoSize = true;
			this.lblinterval.Location = new System.Drawing.Point(12, 104);
			this.lblinterval.Name = "lblinterval";
			this.lblinterval.Size = new System.Drawing.Size(42, 13);
			this.lblinterval.TabIndex = 6;
			this.lblinterval.Text = "Interval";
			// 
			// lblsmode
			// 
			this.lblsmode.AutoSize = true;
			this.lblsmode.Location = new System.Drawing.Point(9, 87);
			this.lblsmode.Name = "lblsmode";
			this.lblsmode.Size = new System.Drawing.Size(40, 13);
			this.lblsmode.TabIndex = 5;
			this.lblsmode.Text = "Smode";
			// 
			// lbldate
			// 
			this.lbldate.AutoSize = true;
			this.lbldate.Location = new System.Drawing.Point(9, 74);
			this.lbldate.Name = "lbldate";
			this.lbldate.Size = new System.Drawing.Size(30, 13);
			this.lbldate.TabIndex = 4;
			this.lbldate.Text = "Date";
			// 
			// lbllength
			// 
			this.lbllength.AutoSize = true;
			this.lbllength.Location = new System.Drawing.Point(9, 61);
			this.lbllength.Name = "lbllength";
			this.lbllength.Size = new System.Drawing.Size(40, 13);
			this.lbllength.TabIndex = 3;
			this.lbllength.Text = "Length";
			// 
			// lblstartdate
			// 
			this.lblstartdate.AutoSize = true;
			this.lblstartdate.Location = new System.Drawing.Point(9, 48);
			this.lblstartdate.Name = "lblstartdate";
			this.lblstartdate.Size = new System.Drawing.Size(52, 13);
			this.lblstartdate.TabIndex = 2;
			this.lblstartdate.Text = "StartDate";
			// 
			// lblmonitor
			// 
			this.lblmonitor.AutoSize = true;
			this.lblmonitor.Location = new System.Drawing.Point(9, 35);
			this.lblmonitor.Name = "lblmonitor";
			this.lblmonitor.Size = new System.Drawing.Size(42, 13);
			this.lblmonitor.TabIndex = 1;
			this.lblmonitor.Text = "Monitor";
			// 
			// lblversion
			// 
			this.lblversion.AutoSize = true;
			this.lblversion.Location = new System.Drawing.Point(9, 20);
			this.lblversion.Name = "lblversion";
			this.lblversion.Size = new System.Drawing.Size(42, 13);
			this.lblversion.TabIndex = 0;
			this.lblversion.Text = "Version";
			// 
			// btnopfile
			// 
			this.btnopfile.Location = new System.Drawing.Point(1, 3);
			this.btnopfile.Name = "btnopfile";
			this.btnopfile.Size = new System.Drawing.Size(151, 37);
			this.btnopfile.TabIndex = 1;
			this.btnopfile.Text = "OpenFile";
			this.btnopfile.UseVisualStyleBackColor = true;
			this.btnopfile.Click += new System.EventHandler(this.btnopfile_Click);
			// 
			// btnseldata
			// 
			this.btnseldata.Location = new System.Drawing.Point(175, 4);
			this.btnseldata.Name = "btnseldata";
			this.btnseldata.Size = new System.Drawing.Size(136, 36);
			this.btnseldata.TabIndex = 2;
			this.btnseldata.Text = "Select Data";
			this.btnseldata.UseVisualStyleBackColor = true;
			// 
			// listBox1
			// 
			this.listBox1.FormattingEnabled = true;
			this.listBox1.Location = new System.Drawing.Point(1, 58);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(101, 160);
			this.listBox1.TabIndex = 3;
			this.listBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listBox1_MouseClick);
			// 
			// dataGridView1
			// 
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.time_interval,
            this.heart_rate,
            this.speeds,
            this.cadences,
            this.altitudes,
            this.Power_watt,
            this.power_balance,
            this.pending_index,
            this.left_right_balance});
			this.dataGridView1.Location = new System.Drawing.Point(1, 240);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.Size = new System.Drawing.Size(477, 176);
			this.dataGridView1.TabIndex = 4;
			// 
			// time_interval
			// 
			this.time_interval.HeaderText = "Time Interval";
			this.time_interval.Name = "time_interval";
			// 
			// heart_rate
			// 
			this.heart_rate.HeaderText = "Heart Rate";
			this.heart_rate.Name = "heart_rate";
			// 
			// speeds
			// 
			this.speeds.HeaderText = "Speed";
			this.speeds.Name = "speeds";
			// 
			// cadences
			// 
			this.cadences.HeaderText = "Cadence";
			this.cadences.Name = "cadences";
			// 
			// altitudes
			// 
			this.altitudes.HeaderText = "Altitude";
			this.altitudes.Name = "altitudes";
			// 
			// Power_watt
			// 
			this.Power_watt.HeaderText = "Power(Watt)";
			this.Power_watt.Name = "Power_watt";
			// 
			// power_balance
			// 
			this.power_balance.HeaderText = "Power Balance";
			this.power_balance.Name = "power_balance";
			// 
			// pending_index
			// 
			this.pending_index.HeaderText = "Pending Index";
			this.pending_index.Name = "pending_index";
			// 
			// left_right_balance
			// 
			this.left_right_balance.HeaderText = "Left Right Balance";
			this.left_right_balance.Name = "left_right_balance";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.label19);
			this.groupBox2.Controls.Add(this.label18);
			this.groupBox2.Controls.Add(this.label17);
			this.groupBox2.Controls.Add(this.label16);
			this.groupBox2.Controls.Add(this.label15);
			this.groupBox2.Controls.Add(this.label14);
			this.groupBox2.Controls.Add(this.label13);
			this.groupBox2.Controls.Add(this.label12);
			this.groupBox2.Controls.Add(this.label11);
			this.groupBox2.Controls.Add(this.label10);
			this.groupBox2.Controls.Add(this.label9);
			this.groupBox2.Controls.Add(this.label8);
			this.groupBox2.Location = new System.Drawing.Point(563, 12);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(200, 404);
			this.groupBox2.TabIndex = 5;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Summary Data";
			// 
			// label19
			// 
			this.label19.AutoSize = true;
			this.label19.Location = new System.Drawing.Point(10, 348);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(85, 13);
			this.label19.TabIndex = 11;
			this.label19.Text = "Average Altitude";
			// 
			// label18
			// 
			this.label18.AutoSize = true;
			this.label18.Location = new System.Drawing.Point(10, 323);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(86, 13);
			this.label18.TabIndex = 10;
			this.label18.Text = "Minimum Altitude";
			// 
			// label17
			// 
			this.label17.AutoSize = true;
			this.label17.Location = new System.Drawing.Point(10, 294);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(89, 13);
			this.label17.TabIndex = 9;
			this.label17.Text = "Maximum Altitude";
			// 
			// label16
			// 
			this.label16.AutoSize = true;
			this.label16.Location = new System.Drawing.Point(10, 265);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(80, 13);
			this.label16.TabIndex = 8;
			this.label16.Text = "Average Power";
			// 
			// label15
			// 
			this.label15.AutoSize = true;
			this.label15.Location = new System.Drawing.Point(10, 237);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(81, 13);
			this.label15.TabIndex = 7;
			this.label15.Text = "Minimum Power";
			// 
			// label14
			// 
			this.label14.AutoSize = true;
			this.label14.Location = new System.Drawing.Point(10, 206);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(84, 13);
			this.label14.TabIndex = 6;
			this.label14.Text = "Maximum Power";
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Location = new System.Drawing.Point(10, 177);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(81, 13);
			this.label13.TabIndex = 5;
			this.label13.Text = "Average Speed";
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(10, 150);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(82, 13);
			this.label12.TabIndex = 4;
			this.label12.Text = "Minimum Speed";
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(10, 120);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(83, 13);
			this.label11.TabIndex = 3;
			this.label11.Text = "Maximun Speed";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(10, 93);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(102, 13);
			this.label10.TabIndex = 2;
			this.label10.Text = "Average Heart Rate";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(10, 65);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(103, 13);
			this.label9.TabIndex = 1;
			this.label9.Text = "Minimum Heart Rate";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(7, 34);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(106, 13);
			this.label8.TabIndex = 0;
			this.label8.Text = "Maximum Heart Rate";
			// 
			// calendar
			// 
			this.calendar.Location = new System.Drawing.Point(324, 58);
			this.calendar.Name = "calendar";
			this.calendar.TabIndex = 6;
			this.calendar.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateChanged);
			// 
			// btngraph
			// 
			this.btngraph.Location = new System.Drawing.Point(496, 267);
			this.btngraph.Name = "btngraph";
			this.btngraph.Size = new System.Drawing.Size(55, 106);
			this.btngraph.TabIndex = 7;
			this.btngraph.Text = "Load Graph";
			this.btngraph.UseVisualStyleBackColor = true;
			this.btngraph.Click += new System.EventHandler(this.btngraph_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.btngraph);
			this.Controls.Add(this.calendar);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.dataGridView1);
			this.Controls.Add(this.listBox1);
			this.Controls.Add(this.btnseldata);
			this.Controls.Add(this.btnopfile);
			this.Controls.Add(this.groupBox1);
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label lblinterval;
		private System.Windows.Forms.Label lblsmode;
		private System.Windows.Forms.Label lbldate;
		private System.Windows.Forms.Label lbllength;
		private System.Windows.Forms.Label lblstartdate;
		private System.Windows.Forms.Label lblmonitor;
		private System.Windows.Forms.Label lblversion;
		private System.Windows.Forms.Button btnopfile;
		private System.Windows.Forms.Button btnseldata;
		private System.Windows.Forms.ListBox listBox1;
		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.MonthCalendar calendar;
		private System.Windows.Forms.DataGridViewTextBoxColumn time_interval;
		private System.Windows.Forms.DataGridViewTextBoxColumn heart_rate;
		private System.Windows.Forms.DataGridViewTextBoxColumn speeds;
		private System.Windows.Forms.DataGridViewTextBoxColumn cadences;
		private System.Windows.Forms.DataGridViewTextBoxColumn altitudes;
		private System.Windows.Forms.DataGridViewTextBoxColumn Power_watt;
		private System.Windows.Forms.DataGridViewTextBoxColumn power_balance;
		private System.Windows.Forms.DataGridViewTextBoxColumn pending_index;
		private System.Windows.Forms.DataGridViewTextBoxColumn left_right_balance;
		private System.Windows.Forms.Button btngraph;
	}
}

