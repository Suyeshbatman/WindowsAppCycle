namespace Wform
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
			this.txtRich = new System.Windows.Forms.RichTextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// txtRich
			// 
			this.txtRich.Location = new System.Drawing.Point(78, 71);
			this.txtRich.Name = "txtRich";
			this.txtRich.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
			this.txtRich.Size = new System.Drawing.Size(648, 316);
			this.txtRich.TabIndex = 0;
			this.txtRich.Text = "";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(78, 12);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(98, 44);
			this.button1.TabIndex = 1;
			this.button1.Text = "Read";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.txtRich);
			this.Name = "Form1";
			this.Text = "Form1";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.RichTextBox txtRich;
		private System.Windows.Forms.Button button1;
	}
}

