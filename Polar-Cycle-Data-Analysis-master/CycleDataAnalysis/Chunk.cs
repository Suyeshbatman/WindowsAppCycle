using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CycleDataAnalysis
{
	public partial class Chunk : Form
	{
		int ChunkNo;
		public int chunkGet { get; set; }
		string i;

		public Chunk()
		{
			InitializeComponent();
		}

		private void Chunk_Load(object sender, EventArgs e)
		{
			metroButton1.DialogResult = DialogResult.OK;
		}

		private void metroButton1_Click(object sender, EventArgs e)
		{
			try
			{
				this.chunkGet = Convert.ToInt32(metroComboBox1.Text);
				this.Hide();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void metroComboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				i = metroComboBox1.SelectedValue.ToString();
				ChunkNo = Convert.ToInt32(i);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
	}
}
