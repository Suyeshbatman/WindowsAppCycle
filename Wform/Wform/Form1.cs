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
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{

			bool flag = this.openFileDialog1.ShowDialog() != DialogResult.Cancel;
			if (flag)
			{
				string data = "";
				int a = 0;
				int b = 0;
				//int totalRows = 0;
				//int rows = 0;

				dataGridView1.ColumnCount = 6;
				dataGridView1.Columns[0].Name = "Heart Rates";
				dataGridView1.Columns[1].Name = "Speed";
				dataGridView1.Columns[2].Name = "Cadence";
				dataGridView1.Columns[3].Name = "Altitude";
				dataGridView1.Columns[4].Name = "Power";
				dataGridView1.Columns[5].Name = "Power Balance and Pedaling Index";

				StreamReader streamReader = new StreamReader(openFileDialog1.FileName);
				string[] filelines = File.ReadAllLines(openFileDialog1.FileName);
				foreach (string line in filelines)
				{
					if (line.Equals("[HRData]"))
					{
						a = b;
					}
					if (a > 0)
					{
						data += line + "\r\n";
					}
					b++;

					dataGridView1.AllowUserToAddRows = false;
					string text = "";
					for (text = streamReader.ReadLine(); text != null; text = streamReader.ReadLine())
					{



						string[] array = text.Split('\t');
						dataGridView1.Rows.Add(array);
					}
					//fileReading.Text = b + data;

					//int s = totalRows - rows;
					//string[] arrayData = new string[s];

					//string heart = "";
					//string speed = "";
					//string cadence = "";
					//string altitude = "";
					//string power = "";
					//string pbpi = "";
					//if (rows != 0)
					//{
					//    foreach (string line in filelines)
					//    {
					//        if (rows < b)
					//        {
					//            data += line + "\r\n";
					//            string[] words = line.Split('\t');
					//            for (int x = 0; x < words.Length; x++)
					//            {
					//                if (x == 0) heart = words[x];
					//                else if (x == 1) speed = words[x];
					//                else if (x == 2) cadence = words[x];
					//                else if (x == 3) altitude = words[x];
					//                else if (x == 4) power = words[x];
					//                else pbpi = words[x];
					//            }
					//            string[] row_val = new string[] { heart, speed, cadence, altitude, power, pbpi };
					//            dataView.Rows.Add(row_val);
					//        }
					//        else b++;
					//    }
					//}

					// fileReading.Text = data;
				}
			}
		}
	




		private void button2_Click(object sender, EventArgs e)
		{
			Form2 objForm2 = new Form2();
			objForm2.Show();
		}

		

		private void button3_Click(object sender, EventArgs e)
		{
			Form3 myform = new Form3();
			myform.Show();
		}

		

		private void button4_Click_1(object sender, EventArgs e)
		{
			Form4 myform1 = new Form4();
			myform1.Show();
		}
	}
}



