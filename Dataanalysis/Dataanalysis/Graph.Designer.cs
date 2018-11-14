namespace Dataanalysis
{
	partial class Graph
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
			this.dataGV = new System.Windows.Forms.DataGridView();
			this.zedGraphControl2 = new ZedGraph.ZedGraphControl();
			this.btngraph = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dataGV)).BeginInit();
			this.SuspendLayout();
			// 
			// dataGV
			// 
			this.dataGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGV.Location = new System.Drawing.Point(35, 32);
			this.dataGV.Name = "dataGV";
			this.dataGV.Size = new System.Drawing.Size(721, 61);
			this.dataGV.TabIndex = 0;
			// 
			// zedGraphControl2
			// 
			this.zedGraphControl2.IsShowPointValues = false;
			this.zedGraphControl2.Location = new System.Drawing.Point(35, 154);
			this.zedGraphControl2.Name = "zedGraphControl2";
			this.zedGraphControl2.PointValueFormat = "G";
			this.zedGraphControl2.Size = new System.Drawing.Size(638, 277);
			this.zedGraphControl2.TabIndex = 1;
			// 
			// btngraph
			// 
			this.btngraph.Location = new System.Drawing.Point(35, 108);
			this.btngraph.Name = "btngraph";
			this.btngraph.Size = new System.Drawing.Size(75, 23);
			this.btngraph.TabIndex = 2;
			this.btngraph.Text = "Load Data";
			this.btngraph.UseVisualStyleBackColor = true;
			this.btngraph.Click += new System.EventHandler(this.btngraph_Click);
			// 
			// Graph
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.btngraph);
			this.Controls.Add(this.zedGraphControl2);
			this.Controls.Add(this.dataGV);
			this.Name = "Graph";
			this.Text = "Graph";
			this.Load += new System.EventHandler(this.Graph_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataGV)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		public System.Windows.Forms.DataGridView dataGV;
		private ZedGraph.ZedGraphControl zedGraphControl2;
		private System.Windows.Forms.Button btngraph;
	}
}