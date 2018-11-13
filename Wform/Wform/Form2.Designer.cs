namespace Wform
{
	partial class Form2
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
			this.button1 = new System.Windows.Forms.Button();
			this.dataGV = new System.Windows.Forms.DataGridView();
			this.button2 = new System.Windows.Forms.Button();
			this.richTB = new System.Windows.Forms.RichTextBox();
			this.richTB2 = new System.Windows.Forms.RichTextBox();
			this.selectedColumnButton = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dataGV)).BeginInit();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(12, 210);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(161, 23);
			this.button1.TabIndex = 0;
			this.button1.Text = "Read File";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// dataGV
			// 
			this.dataGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGV.Location = new System.Drawing.Point(12, 249);
			this.dataGV.Name = "dataGV";
			this.dataGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.ColumnHeaderSelect;
			this.dataGV.Size = new System.Drawing.Size(500, 189);
			this.dataGV.TabIndex = 1;
			
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(12, 12);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(179, 23);
			this.button2.TabIndex = 2;
			this.button2.Text = "Select";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// richTB
			// 
			this.richTB.Location = new System.Drawing.Point(12, 50);
			this.richTB.Name = "richTB";
			this.richTB.Size = new System.Drawing.Size(500, 134);
			this.richTB.TabIndex = 3;
			this.richTB.Text = "";
			// 
			// richTB2
			// 
			this.richTB2.Location = new System.Drawing.Point(543, 249);
			this.richTB2.Name = "richTB2";
			this.richTB2.Size = new System.Drawing.Size(329, 189);
			this.richTB2.TabIndex = 4;
			this.richTB2.Text = "";
			// 
			// selectedColumnButton
			// 
			this.selectedColumnButton.Location = new System.Drawing.Point(630, 209);
			this.selectedColumnButton.Name = "selectedColumnButton";
			this.selectedColumnButton.Size = new System.Drawing.Size(124, 23);
			this.selectedColumnButton.TabIndex = 5;
			this.selectedColumnButton.Text = "Load";
			this.selectedColumnButton.UseVisualStyleBackColor = true;
			this.selectedColumnButton.Click += new System.EventHandler(this.selectedColumnButton_Click);
			// 
			// Form2
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(896, 450);
			this.Controls.Add(this.selectedColumnButton);
			this.Controls.Add(this.richTB2);
			this.Controls.Add(this.richTB);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.dataGV);
			this.Controls.Add(this.button1);
			this.Name = "Form2";
			this.Text = "Form2";
			((System.ComponentModel.ISupportInitialize)(this.dataGV)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.DataGridView dataGV;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.RichTextBox richTB;
		private System.Windows.Forms.RichTextBox richTB2;
		private System.Windows.Forms.Button selectedColumnButton;
	}
}