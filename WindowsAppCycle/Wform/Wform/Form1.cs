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
			string filePath = @"C:\Users\My computer\Desktop\Data for Assignment\ASEB Data\Exercises2009_Duncan Mullier\09072501.hrm"; // agadi @ lagayo vane pachi single \ halle pugcha. if @ halena vane double \\ halna parcha


			if (File.Exists(filePath))
			{
				processFile(filePath);
			}
			else
			{
				txtRich.Text = "File not found.";
			}
		}

		public void processFile(string filePath)
		{
			// string oneline;
			//int lineNo = 1;
			try
			{
				/* // Reading all the text using ReadAllText Method
                string fileContent = File.ReadAllText(filePath);
                txtDisplay.Text = fileContent;
                */


				//Reading all the text and display in textbox by using ReadAllLines
				string[] filelines = File.ReadAllLines(filePath);
				string data = "";
				int x = 0;
				int y = 0;
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
				}
				txtRich.Text = x + data;

				/*
                StreamReader sr = new StreamReader(filePath);
                string data = "";
                while ((oneline = sr.ReadLine()) != null)
                {
                    string[] words = oneline.Split(' ');
                    for(int x = 0; x < words.Length; x++)
                    {
                        data += words[x] + "\r\n";
                    }
                }
                txtDisplay.Text = data;
                */
			}
			catch
			{
				txtRich.Text = "Exception Raised";
			}
		}

		
	}
}
