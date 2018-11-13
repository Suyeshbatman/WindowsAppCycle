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
	public partial class Form3 : Form
	{


		public string Value { get; private set; }

		public Form3()
		{
			InitializeComponent();
		}

		public void button1_Click(object sender, EventArgs e)
		{
			
			//DataTable table = new DataTable();
			Stream myStream = null;
			OpenFileDialog openFileDialog1 = new OpenFileDialog();

			openFileDialog1.InitialDirectory = @"C:\Users\My computer\Desktop\Data for Assignment\ASEB Data\Exercises2009_Duncan Mullier\"; // your directory is also not defined properly
			openFileDialog1.Filter = "hrm files (*.hrm)|*.hrm|All files (*.*)|*.*";// have a look to filter as well
			openFileDialog1.FilterIndex = 2;
			openFileDialog1.RestoreDirectory = true;

			TextReader reader1 = new StreamReader(@"C:\Users\My computer\Desktop\Data for Assignment\ASEB Data\Exercises2009_Duncan Mullier\");
			string contents = reader1.ReadToEnd();
			string[] myArray = { contents };


			if (openFileDialog1.ShowDialog() == DialogResult.OK)
			{
				try
				{
					if ((myStream = openFileDialog1.OpenFile()) != null)
					{
						using (myStream)
						{
							string filename = openFileDialog1.FileName;
							if (File.Exists(contents))
							{
								processFile(contents);
							}
							else
							{
								dataGridView2.Text = "File Not Found";
							}
							
								using (var reader = File.OpenText(filename)) // you need not to use '@filename' instead use just 'filename'
							{
								string line;
								while ((line = reader.ReadLine()) != null)
								{
									string[] parts = line.Split(' ');
									//table.Rows.Add(parts[0], parts[1], parts[2], parts[3], parts[4], parts[5], parts[6], parts[7]);
								}
								//dataGridView2.DataSource = table;
							}
						}
					}
				}

				catch (Exception ex) // you need to add the catch block if yo are using try block
				{
				}
			}

		}

		public void processFile(string contents)
		{
			TextReader reader2 = new StreamReader(@"C:\Users\My computer\Desktop\Data for Assignment\ASEB Data\Exercises2009_Duncan Mullier\09072501.hrm");

			string contents1 = reader2.ReadToEnd();
			string[] myArray = { contents };


			foreach (string gotya in myArray)
			{
				string[] values = gotya.Split(' ');

				dataGridView2.Columns.Add("colname", "name");
				dataGridView2.Columns.Add("a", "b");
				dataGridView2.Columns.Add("c", "d");
				dataGridView2.Columns.Add("e", "f");
				dataGridView2.Columns.Add("g", "h");
				dataGridView2.Columns.Add("i", "j");

				int i = 0;
				int j = 0;

				string data = "";
				int x = 0;
				int y = 0;
				string[] filelines = File.ReadAllLines(contents);
				foreach (string line in filelines)
				{
					if (line.Equals("[HRData]"))
					{
						x = y;
					}
					if (x > 0)
					{
						data += line + "\r\n";
					}

					y++;

					dataGridView2.Rows.Add();
					//dataGridView2.Rows[i].Cells[j].Value = value;
					j++;

				}
				i++;
			}
		}
	}
}

	

