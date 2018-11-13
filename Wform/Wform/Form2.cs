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
	public partial class Form2 : Form
	{
		public Form2()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
		

			Stream myStream = null;
			OpenFileDialog openFileDialog1 = new OpenFileDialog();

			openFileDialog1.InitialDirectory = @"C:\Users\My computer\Desktop\Data for Assignment\ASEB Data\Exercises2009_Duncan Mullier\"; // your directory is also not defined properly
			openFileDialog1.Filter = "hrm files (*.hrm)|*.hrm|All files (*.*)|*.*";// have a look to filter as well
			openFileDialog1.FilterIndex = 2;
			openFileDialog1.RestoreDirectory = true;
			if (openFileDialog1.ShowDialog() == DialogResult.OK)
			{
				try
				{
					if ((myStream = openFileDialog1.OpenFile()) != null)
					{
						using (myStream)
						{
							string filename = openFileDialog1.FileName;
							using (var reader = File.OpenText(filename)) // you need not to use '@filename' instead use just 'filename'
							{
								string line;
								int x = 0;
								int y = 0;
								string data = "";
								while ((line = reader.ReadLine()) != null)
								{
									string[] parts = line.Split(' ');

									dataGridView1.Columns.Add("colname", "name");
									dataGridView1.Columns.Add("a", "b");
									dataGridView1.Columns.Add("c", "d");
									dataGridView1.Columns.Add("e", "f");
									dataGridView1.Columns.Add("g", "h");
									dataGridView1.Columns.Add("i", "j");

									

									

									dataGridView1.Rows.Add();
									//dataGridView1.DataSource = table;
								}
							}
						}
					}
				}

				catch  // you need to add the catch block if yo are using try block
				{
				}
			}
		}
	}
}
