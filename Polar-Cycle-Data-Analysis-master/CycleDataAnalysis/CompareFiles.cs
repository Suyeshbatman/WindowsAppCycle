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


namespace CycleDataAnalysis
{
	public partial class CompareFiles : MetroFramework.Forms.MetroForm
	{
		public CompareFiles()
		{
			InitializeComponent();
		}
		string fn1, fn2;
		List<string> filenames = new List<string>();

		private void metroButton2_Click(object sender, EventArgs e)
		{
			OpenFileDialog open = new OpenFileDialog();

			open.Filter = "hrm|*.hrm|All|*.*";
			if (open.ShowDialog() == DialogResult.OK)
			{
				fn2 = open.FileName; // name of the browsed file 

			}
			if (fn2.Equals(fn1))
			{
				MessageBox.Show("Cannot insert two files of same name try again.");
			}
			else
			{
				filenames.Add(fn2);
				fname2.Text = Path.GetFileName(fn2);
				fname2.Visible = true;
				metroButton3.Enabled = true;
			}
		}

		private void metroPanel1_Paint(object sender, PaintEventArgs e)
		{

		}

		private void metroButton1_Click(object sender, EventArgs e)
		{

			OpenFileDialog open = new OpenFileDialog();

			open.Filter = "hrm|*.hrm|All|*.*";
			if (open.ShowDialog() == DialogResult.OK)
			{
				fn1 = open.FileName; // name of the browsed file 

			}
			filenames.Add(fn1);
			fname1.Text = Path.GetFileName(fn1);
			fname1.Visible = true;
		}

		private void metroButton3_Click(object sender, EventArgs e)
		{
			MultipleFile mf = new MultipleFile(filenames);
			mf.Show();
		}

		private void fname2_Click(object sender, EventArgs e)
		{

		}
	}
}
