namespace CycleDataAnalysis
{
	partial class CompareFiles
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
			this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
			this.fname2 = new MetroFramework.Controls.MetroLabel();
			this.fname1 = new MetroFramework.Controls.MetroLabel();
			this.metroButton3 = new MetroFramework.Controls.MetroButton();
			this.metroButton2 = new MetroFramework.Controls.MetroButton();
			this.metroButton1 = new MetroFramework.Controls.MetroButton();
			this.metroPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// metroPanel1
			// 
			this.metroPanel1.Controls.Add(this.fname2);
			this.metroPanel1.Controls.Add(this.fname1);
			this.metroPanel1.Controls.Add(this.metroButton3);
			this.metroPanel1.Controls.Add(this.metroButton2);
			this.metroPanel1.Controls.Add(this.metroButton1);
			this.metroPanel1.HorizontalScrollbarBarColor = true;
			this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
			this.metroPanel1.HorizontalScrollbarSize = 10;
			this.metroPanel1.Location = new System.Drawing.Point(15, 79);
			this.metroPanel1.Name = "metroPanel1";
			this.metroPanel1.Size = new System.Drawing.Size(702, 187);
			this.metroPanel1.TabIndex = 0;
			this.metroPanel1.VerticalScrollbarBarColor = true;
			this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
			this.metroPanel1.VerticalScrollbarSize = 10;
			this.metroPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.metroPanel1_Paint);
			// 
			// fname2
			// 
			this.fname2.AutoSize = true;
			this.fname2.Location = new System.Drawing.Point(527, 104);
			this.fname2.Name = "fname2";
			this.fname2.Size = new System.Drawing.Size(0, 0);
			this.fname2.TabIndex = 6;
			this.fname2.Click += new System.EventHandler(this.fname2_Click);
			// 
			// fname1
			// 
			this.fname1.AutoSize = true;
			this.fname1.Location = new System.Drawing.Point(58, 104);
			this.fname1.Name = "fname1";
			this.fname1.Size = new System.Drawing.Size(0, 0);
			this.fname1.TabIndex = 5;
			// 
			// metroButton3
			// 
			this.metroButton3.Location = new System.Drawing.Point(274, 118);
			this.metroButton3.Name = "metroButton3";
			this.metroButton3.Size = new System.Drawing.Size(122, 23);
			this.metroButton3.TabIndex = 4;
			this.metroButton3.Text = "Compare Files";
			this.metroButton3.Click += new System.EventHandler(this.metroButton3_Click);
			// 
			// metroButton2
			// 
			this.metroButton2.Location = new System.Drawing.Point(508, 66);
			this.metroButton2.Name = "metroButton2";
			this.metroButton2.Size = new System.Drawing.Size(102, 23);
			this.metroButton2.TabIndex = 3;
			this.metroButton2.Text = "Select File";
			this.metroButton2.Click += new System.EventHandler(this.metroButton2_Click);
			// 
			// metroButton1
			// 
			this.metroButton1.Location = new System.Drawing.Point(44, 66);
			this.metroButton1.Name = "metroButton1";
			this.metroButton1.Size = new System.Drawing.Size(106, 23);
			this.metroButton1.TabIndex = 2;
			this.metroButton1.Text = "Select File";
			this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
			// 
			// CompareFiles
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(729, 308);
			this.Controls.Add(this.metroPanel1);
			this.Name = "CompareFiles";
			this.Text = "CompareFiles";
			this.metroPanel1.ResumeLayout(false);
			this.metroPanel1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private MetroFramework.Controls.MetroPanel metroPanel1;
		private MetroFramework.Controls.MetroButton metroButton3;
		private MetroFramework.Controls.MetroButton metroButton2;
		private MetroFramework.Controls.MetroButton metroButton1;
		private MetroFramework.Controls.MetroLabel fname2;
		private MetroFramework.Controls.MetroLabel fname1;
	}
}