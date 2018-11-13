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

namespace Wform
{
	public partial class Form4 : Form
	{


		public Form4()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog1 = new OpenFileDialog();
			bool flag = this.openFileDialog1.ShowDialog() != DialogResult.Cancel;
			if (flag)
			{
				//DataTable dt = new DataTable();
				//dt.Columns.Add("Col A", typeof(string));
				//dt.Columns.Add("Col B", typeof(string));

				dataGridView4.Columns.Add("colname", "name");
				dataGridView4.Columns.Add("a", "b");
				dataGridView4.Columns.Add("c", "d");
				dataGridView4.Columns.Add("e", "f");
				dataGridView4.Columns.Add("g", "h");
				dataGridView4.Columns.Add("i", "j");

				try
				{
					StreamReader streamReader = new StreamReader(openFileDialog1.FileName);
					dataGridView4.AllowUserToAddRows = false;
					string text = "";
					for (text = streamReader.ReadLine(); text != null; text = streamReader.ReadLine())
					{
						string[] array = text.Split(new char[] { ':' });
						dataGridView4.Rows.Add(array);
					}
					streamReader.Close();
				}
				catch (Exception err)
				{
					MessageBox.Show("Error" + err.Message);
				}
				

				//dataGridView4.Text = dt;
			}
		}
	}
}


