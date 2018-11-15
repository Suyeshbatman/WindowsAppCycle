using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.IO;
using System.Globalization;



namespace Dataanalysis
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		public DateTime SelectionStart { get; set; }
		string file_name, path;
		string file, getfilename;
		string dateCalc;
		string[] fdata;

		public static double averageSpeed { get; set; }
		public static double maxSpeed { get; set; }
		public static double averageSpeedMiles { get; set; }
		public static double maxSpeedMiles { get; set; }
		public static double averageHeartRate { get; set; }
		public static double maxHeartRate { get; set; }
		public static double minHeartRate { get; set; }
		public static double averagePower { get; set; }
		public static double maxPower { get; set; }
		public static double averageAltitude { get; set; }
		public static double maxAltitude { get; set; }
		public static double averageAltitudeMile { get; set; }
		public static double maxAltitudeMile { get; set; }
		public static double totalDistance { get; set; }
		public static double totalDistanceMiles { get; set; }
		public static string smode { get; set; }

		// graph 
		public static double[] graphHeartRate { get; set; }
		public static double[] graphSpeed { get; set; }
		public static double[] graphCadence { get; set; }
		public static double[] graphAltitude { get; set; }
		public static double[] graphPower { get; set; }

		string fileData, filename;
		string lengthValue, startTimeValue, intervalValue;

		int count = 0;

		private void listBox1_MouseClick(object sender, MouseEventArgs e)
		{
			string filename = listBox1.SelectedItem.ToString(); // name of the browsed file 
			string location = path;   // location of the browsed file
									  //string fileData, fileDataTwo;
									  //int count = 0;



			foreach (string item in fdata)
			{
				string data = item.Split('\\').Last();
				if (data == filename)
				{


					fileReader(item);
					SummaryCalculation();

				}
			}
		}

		private void SummaryCalculation()
		{

			#region Filling up the summary data
			// fetching all speed column data into array
			double[] columnDataOfSpeed = (from DataGridViewRow row in dataGridView1.Rows
										  where row.Cells["speeds"].FormattedValue.ToString() != string.Empty
										  select Convert.ToDouble(row.Cells["speeds"].FormattedValue)).ToArray();
			// fetching all heart rate column data into array
			double[] columnDataOfheartRate = (from DataGridViewRow row in dataGridView1.Rows
											  where row.Cells["heart_rate"].FormattedValue.ToString() != string.Empty
											  select Convert.ToDouble(row.Cells["heart_rate"].FormattedValue)).ToArray();
			// fetching all power column data into array
			double[] columnDataOfPower = (from DataGridViewRow row in dataGridView1.Rows
										  where row.Cells["Power_watt"].FormattedValue.ToString() != string.Empty
										  select Convert.ToDouble(row.Cells["Power_watt"].FormattedValue)).ToArray();
			// fetching all altitude column data into array
			double[] columnDataOfAltitude = (from DataGridViewRow row in dataGridView1.Rows
											 where row.Cells["altitudes"].FormattedValue.ToString() != string.Empty
											 select Convert.ToDouble(row.Cells["altitudes"].FormattedValue)).ToArray();

			//For Speed
			label11.Text = "Maximum Speed: " + columnDataOfSpeed.Max().ToString() + " " + "km/hr";               //displaying the maximum speed by calculating from datagridview
			label12.Text = "Minimum Speed: " + columnDataOfSpeed.Min().ToString() + " " + "km/hr";               //displaying the minimum speed by calculating from datagridview

			double averageSpeed = columnDataOfSpeed.Average();
			label13.Text = "Average Speed: " + Math.Round(averageSpeed, 3).ToString() + " " + "km/hr";           //displaying the average speed by calculating from datagridview

			//For Heart Rate
			label8.Text = "Max. Heart Rate: " + columnDataOfheartRate.Max().ToString() + " " + "bpm";            //displaying the maximum heart rate by calculating from datagridview
			label9.Text = "Min. Heart Rate: " + columnDataOfheartRate.Min().ToString() + " " + "bpm";              //displaying the minimum heart rate by calculating from datagridview

			double averageHeart = columnDataOfheartRate.Average();
			label10.Text = "Avg. Heart Rate: " + Math.Round(averageHeart, 3).ToString() + " " + "bpm";          //displaying the Average heart rate by calculating from datagridview

			//For Power
			label14.Text = "Maximum Power: " + columnDataOfPower.Max().ToString() + " " + "watts";               //displaying the maximum power by calculating from datagridview
			label15.Text = "Manimum Power: " + columnDataOfPower.Min().ToString() + " " + "watts";               //displaying the minimum power by calculating from datagridview

			double averagePower = columnDataOfPower.Average();
			label16.Text = "Average Power: " + Math.Round(averagePower).ToString() + " " + "watt";              //displaying the Average power by calculating from datagridview

			//For Altitude
			label17.Text = "Maximum Altitude: " + columnDataOfAltitude.Max().ToString() + " " + "meter";         //displaying the maximum altitude by calculating from datagridview
			label18.Text = "Minimum Altitude: " + columnDataOfAltitude.Min().ToString() + " " + "meter";         //displaying the minimum altitude by calculating from datagridview

			double averageAltitude = columnDataOfAltitude.Average();
			label19.Text = "Average Altitude: " + Math.Round(averageAltitude, 3).ToString() + " " + "meter";     //displaying the minimum altitude by calculating from datagridview

			#endregion
		}

		private void btngraph_Click(object sender, EventArgs e)
		{
			Graph g = new Graph();
			g.Show();
			/*
			g.dataGV.ColumnCount = 9;
			g.dataGV.Columns[0].Name = "Time Interval";
			g.dataGV.Columns[1].Name = "Heart Rate";
			g.dataGV.Columns[2].Name = "Speed";
			g.dataGV.Columns[3].Name = "Cadence"; 
			g.dataGV.Columns[4].Name = "Altitude";
			g.dataGV.Columns[5].Name = "Power(Watt)";
			g.dataGV.Columns[6].Name = "Power Balance";
			g.dataGV.Columns[7].Name = "Pedalling Index";
			g.dataGV.Columns[8].Name = "Left Right Balance";

			foreach (DataGridViewRow row in dataGridView1.Rows)
			{
				int n = g.dataGV.Rows.Add();

				g.dataGV.Rows[n].Cells[0].Value = row.Cells[0].Value;
				g.dataGV.Rows[n].Cells[1].Value = row.Cells[1].Value;
				g.dataGV.Rows[n].Cells[2].Value = row.Cells[2].Value;
				g.dataGV.Rows[n].Cells[3].Value = row.Cells[3].Value;
				g.dataGV.Rows[n].Cells[4].Value = row.Cells[4].Value;
				g.dataGV.Rows[n].Cells[5].Value = row.Cells[5].Value;
				g.dataGV.Rows[n].Cells[6].Value = row.Cells[6].Value;
				g.dataGV.Rows[n].Cells[7].Value = row.Cells[7].Value;
				g.dataGV.Rows[n].Cells[8].Value = row.Cells[8].Value;

				
			}
			*/

		}

		private void Form1_Load(object sender, EventArgs e)
		{

		}

		string dateStart = "1/23/2018";
		string dateFinal;
		

		public void fileReader(String data)
		{
			StreamReader fileReader = new StreamReader(data);

			while (!fileReader.EndOfStream)
			{
				fileData = fileReader.ReadLine();
				if (fileData.Contains("StartTime"))
				{
					string startTime = fileData;
					string[] arraStartTime = startTime.Split('=');
					foreach (String item in arraStartTime)
					{
						lblstartdate.Text = "Start time: " + item;
						startTimeValue = item;
					}
				}
				if (fileData.Contains("Interval"))
				{
					string interval = fileData;
					string[] arrayInterval = interval.Split('=');
					foreach (String itemInterval in arrayInterval)
					{
						interval = itemInterval;
					}
				}
				if (fileData.Contains("Weight"))
				{
					string weight = fileData;
					string[] arrayWeight = weight.Split('=');
					foreach (String itemWeight in arrayWeight)
					{
						//lblWeight.Text = itemWeight;
					}
				}
				if (fileData.Contains("Length"))
				{
					string length = fileData;
					string[] arrayInterval = length.Split('=');
					foreach (String itemLength in arrayInterval)
					{
						lengthValue = itemLength;
						lbllength.Text = "Length: " + lengthValue;

					}
				}
				if (fileData.Contains("Interval"))
				{
					string interval = fileData;
					string[] arrayInterval = interval.Split('=');
					foreach (String itemLength in arrayInterval)
					{
						intervalValue = itemLength;
						lblinterval.Text = "Interval: " + itemLength;
					}
				}
				if (fileData.Contains("Version"))
				{
					string version = fileData;
					string[] arrayVersion = version.Split('=');
					foreach (String itemVersion in arrayVersion)
					{

						lblversion.Text = "Version: " + itemVersion.ToString();
					}
				}
				if (fileData.Contains("Monitor"))
				{
					string monitor = fileData;
					string[] arrayMonitor = monitor.Split('=');
					foreach (String itemMonitor in arrayMonitor)
					{

						lblmonitor.Text = "Monitor: " + itemMonitor;
					}
				}
				if (fileData.Contains("ActiveLimit"))
				{
					string activeLimit = fileData;
					string[] arrayActiveLimit = activeLimit.Split('=');
					foreach (String itemActiveLimit in arrayActiveLimit)
					{

					}
				}
				if (fileData.Contains("MaxHR"))
				{
					string maxHr = fileData;
					string[] arrayMaxHr = maxHr.Split('=');
					foreach (String itemMaxHr in arrayMaxHr)
					{

						//txtMaxHr.Text = itemMaxHr;
					}
				}
				if (fileData.Contains("RestHR"))
				{
					string resetHr = fileData;
					string[] arrayResetHr = resetHr.Split('=');
					foreach (String itemResetHr in arrayResetHr)
					{

						// txtRestHr.Text = itemResetHr;
					}
				}
				if (fileData.Contains("StartDelay"))
				{
					string startDelay = fileData;
					string[] arrayStartDelay = startDelay.Split('=');
					foreach (String itemStartDelay in arrayStartDelay)
					{

						//txtStartDelay.Text = itemStartDelay;
					}
				}
				if (fileData.Contains("VO2max"))
				{
					string VO2max = fileData;
					string[] arrayVO2max = VO2max.Split('=');
					foreach (String itemVO2max in arrayVO2max)
					{

						//lblVersion.Text = itemVO2max;
					}
				}
				if (fileData.Contains("Date"))
				{
					string Date = fileData;
					string[] arrayDate = Date.Split('=');
					char[] diff = arrayDate[1].ToCharArray();
					foreach (String itemDate in arrayDate)
					{
						dateFinal = diff[0].ToString() + diff[1].ToString() + diff[2].ToString() + diff[3].ToString() + "/" + diff[4].ToString() + diff[5].ToString() + "/" + diff[6].ToString() + diff[7].ToString();
						lbldate.Text = "Date: " + dateFinal;
					}

				}
				if (fileData.Contains("SMode"))
				{
					string smodeValue = fileData;
					string[] arraySmode = smodeValue.Split('=');
					foreach (String itemSmode in arraySmode)
					{

						smode = itemSmode;
						lblsmode.Text = "Smode: " + smode;
					}
				}
			}

			List<List<string>> hrData = File.ReadLines(data)
									   .SkipWhile(line => line != "[HRData]")
									   .Skip(1)
									   .Select(line => line.Split().ToList())
									   .ToList();
			count = hrData.Count();

			double speedTotal = 0;
			double heartRateTotal = 0;
			double powerTotal = 0;
			double altitudeTotal = 0;
			double[] arraySpeed = new double[500000];
			double[] arrayHeartRate = new double[500000];
			double[] arrayPower = new double[500000];
			double[] arrayAltitude = new double[500000];
			double[] arrayCadence = new double[500000];
			string[] arrayLength = new string[500000];
			string[] arrayStartTime = new string[500000];
			double intervalResult = 0;

			// time interval 
			arrayStartTime = startTimeValue.Split(':');
			string hour = arrayStartTime[0];
			string minute = arrayStartTime[1];
			double sec = double.Parse(arrayStartTime[2]);
			double min = double.Parse(arrayStartTime[0]);
			double hrs = double.Parse(arrayStartTime[1]);
			double intervalTwo = 0;
			for (int i = 0; i < count; i++)
			{

				double interval = double.Parse(intervalValue);

				//sec = sec + interval ; 

				intervalTwo = intervalTwo + interval;


				dataGridView1.Rows.Add();
				// dataGridView1.Rows[i].Cells[0].Value = dateFinal+"   |   "+ hour + ":" + minute + ":" + sec;
				DateTime timer = DateTime.ParseExact(startTimeValue, "HH:mm:ss.FFF", CultureInfo.InvariantCulture);
				dataGridView1.Rows[i].Cells[0].Value = dateFinal + " | " + timer.AddSeconds(intervalTwo).TimeOfDay;

				char[] smodeData = smode.ToCharArray();
				char speed = smodeData[0];
				char cadence = smodeData[1];
				char altitude = smodeData[2];
				char power = smodeData[3];
				char powerLRBalance = smodeData[4];
				char PowerPIndex = smodeData[5];
				char hrcc = smodeData[6];
				char usEuroUnit = smodeData[7];
				char airPressure = smodeData[8];

				if (hrcc == '1')
				{
					dataGridView1.Rows[i].Cells[1].Value = hrData[i][0];
				}
				else if (hrcc == '0')
				{
					dataGridView1.Rows[i].Cells[1].Value = 0;
				}
				if (speed == '1')
				{
					dataGridView1.Rows[i].Cells[2].Value = hrData[i][1];
				}
				else if (speed == '0')
				{
					dataGridView1.Rows[i].Cells[2].Value = 0;
				}
				if (cadence == '1')
				{
					dataGridView1.Rows[i].Cells[3].Value = hrData[i][2];
				}
				else if (cadence == '0')
				{
					dataGridView1.Rows[i].Cells[3].Value = 0;
				}

				if (altitude == '1')
				{
					dataGridView1.Rows[i].Cells[4].Value = hrData[i][3];
				}
				else if (altitude == '0')
				{
					dataGridView1.Rows[i].Cells[4].Value = 0;
				}
				if (power == '1')
				{
					dataGridView1.Rows[i].Cells[5].Value = hrData[i][4];
					// calculation of moving average 
					int value = hrData[i][4].Count();
					for (int x = 0; x < value; x++)
					{
						double movingAverage30 = 0;
						for (int j = 0; j < 30; j++)
						{
							int index = x + j;
							index %= value;
							movingAverage30 += Convert.ToDouble(hrData[i][index]);

						}
						movingAverage30 /= 30;

						//MessageBox.Show(movingAverage30.ToString());
						// dgvMovingAverage.Rows.Add(movingAverage30);

						// normalized power calculation 

						TimeSpan time = timer.AddSeconds(intervalTwo).TimeOfDay;
						double timeParse = time.Hours * 60 + time.Minutes + time.Seconds / 60;
						double powerValue = Math.Pow(movingAverage30, 4);
						double np = Math.Sqrt(Math.Sqrt(timeParse * powerValue));
						// dataGridView1.Rows[i].Cells[9].Value = np;


					}
				}

				else if (power == '0')
				{
					dataGridView1.Rows[i].Cells[5].Value = 0;
				}
				if (powerLRBalance == '1')
				{
					dataGridView1.Rows[i].Cells[6].Value = hrData[i][5];
					double value = Convert.ToDouble(hrData[i][5]); // calculation of PI and LRB
					double pi = value / 256;
					double lrb = value % 256;
					double rb = 100 - lrb;
					dataGridView1.Rows[i].Cells[7].Value = Math.Round(pi, 0);
					dataGridView1.Rows[i].Cells[8].Value = "L" + lrb + "- R" + rb;
				}
				else if (powerLRBalance == '0')
				{
					dataGridView1.Rows[i].Cells[6].Value = 0;





				}
				if (speed == '1')
				{

					// cadence 

					arrayCadence[i] = int.Parse(hrData[i][2]);


					// average speed 

					speedTotal = speedTotal + int.Parse(hrData[i][1]);
					averageSpeed = (speedTotal / count) * 0.1;
					averageSpeedMiles = averageSpeed / 1.6;



					// maximum speed  

					arraySpeed[i] = int.Parse(hrData[i][1]);
				}
				else
				{
					averageSpeed = 0;
					averageSpeedMiles = 0;
					arraySpeed[i] = 0;

				}

				if (hrcc == '1')
				{
					// average heart rate 
					heartRateTotal = heartRateTotal + int.Parse(hrData[i][0]);
					averageHeartRate = heartRateTotal / count;
					// maximum heart rate
					arrayHeartRate[i] = int.Parse(hrData[i][0]);
				}
				else
				{
					averageHeartRate = 0;
					arrayHeartRate[i] = 0;
				}
				if (power == '1')
				{
					// average power 
					powerTotal = powerTotal + int.Parse(hrData[i][4]);
					averagePower = powerTotal / count;

					// maximum power 
					arrayPower[i] = int.Parse(hrData[i][4]);
				}
				else
				{
					averagePower = 0;
					arrayPower[i] = 0;
				}
				if (altitude == '1')
				{
					// average altitude 
					altitudeTotal = altitudeTotal + int.Parse(hrData[i][3]);
					averageAltitude = altitudeTotal / count;
					averageAltitudeMile = averageAltitude / 0.3048;
					// maximum altitude 
					arrayAltitude[i] = int.Parse(hrData[i][3]);
				}
				else
				{
					averageAltitude = 0;
					averageAltitudeMile = 0;
					arrayAltitude[i] = 0;
				}
			}
			maxSpeed = arraySpeed.Max() * 0.1;
			maxSpeedMiles = (maxSpeed) / 1.6;

			//max heart rate 
			maxHeartRate = arrayHeartRate.Max();


			// min heart rate 
			// minHeartRate = arrayHeartRate.Min();
			minHeartRate = double.MaxValue;


			foreach (double valueHR in arrayHeartRate)
			{
				double num = valueHR;
				if (num < minHeartRate)
					minHeartRate = num;
			}
			// max power 
			maxPower = arrayPower.Max();
			// max altitude 
			maxAltitude = arrayAltitude.Max();
			maxAltitudeMile = maxAltitude / 0.3048;

			// total distance covered 
			if (arrayLength != null)
			{
				arrayLength = lengthValue.Split(':');
				double hourDis = double.Parse(arrayLength[0]) * 3600;
				double minDis = double.Parse(arrayLength[1]) * 60;
				double secDis = double.Parse(arrayLength[2]);

				double length = hourDis + minDis + secDis;
				double lengthFinal = length / 3600;
				double totalDistanceProcess = averageSpeed * lengthFinal;
				double totalDistanceProcessMiles = (totalDistanceProcess) / 1.6;
				totalDistance = Math.Round(totalDistanceProcess, 2);
				totalDistanceMiles = Math.Round(totalDistanceProcessMiles, 2); ;

			}
			// graph data fetch to global 
			graphHeartRate = arrayHeartRate;
			graphSpeed = arraySpeed;
			graphPower = arrayPower;
			graphAltitude = arrayAltitude;
			graphCadence = arrayCadence;

		}
	




		private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
		{
			listBox1.Items.Clear();
			listBox1.Items.Add(calendar.SelectionStart.ToString());
			dateCalc = calendar.SelectionStart.ToString();

			// file value start 



			foreach (string itemData in fdata)
			{



				string value = itemData;


				StreamReader fileReaderFolder = new StreamReader(value);


				while (!fileReaderFolder.EndOfStream)
				{
					fileData = fileReaderFolder.ReadLine();
					if (fileData.Contains("Date"))
					{
						string startTime = fileData;
						string arraStartTime = startTime.Split('=').Last();
						string one = "";
						//var date = "11252017";
						var date = DateTime.ParseExact(arraStartTime, "yyyyMMdd", CultureInfo.InvariantCulture);

						if (date == DateTime.Parse(dateCalc))
						{
							listBox1.ClearSelected();
							listBox1.Items.Add(itemData.Split('\\').Last());

							path = itemData;

							listBox1.Update();
							//MessageBox.Show(one); 
						}

						//cldFolderView.AddBoldedDate(date);
						//cldFolderView.UpdateBoldedDates();

						//cldFolderView.SelectionStart = DateTime.Parse(startValue);
					}
				}
			}
		}

		private void btnopfile_Click(object sender, EventArgs e)
		{
			FolderBrowserDialog fd = new FolderBrowserDialog();
			if (fd.ShowDialog() == DialogResult.OK)
			{

				fdata = Directory.GetFiles(fd.SelectedPath);

				DateTime timeValue;
				string valueTwo = fdata[0];
				// start  to highlight the starting month in monthcalender

				StreamReader fileReaderFolderst = new StreamReader(valueTwo);
				while (!fileReaderFolderst.EndOfStream)
				{
					fileData = fileReaderFolderst.ReadLine();
					if (fileData.Contains("Date"))
					{
						string startTime = fileData;
						string arraStartTime = startTime.Split('=').Last();
						var dt = DateTime.ParseExact(arraStartTime, "yyyyMMdd", CultureInfo.InvariantCulture);
						dateStart = dt.ToString();
					}
				}
				// end 

				foreach (string itemData in fdata)
				{
					string value = itemData;


					StreamReader fileReaderFolder = new StreamReader(value);
					while (!fileReaderFolder.EndOfStream)
					{
						fileData = fileReaderFolder.ReadLine();
						if (fileData.Contains("Date"))
						{
							string startTime = fileData;
							string arraStartTime = startTime.Split('=').Last();
							//var date = "11252017";
							var date = DateTime.ParseExact(arraStartTime, "yyyyMMdd", CultureInfo.InvariantCulture);

							timeValue = date;

							calendar.AddBoldedDate(date);
							calendar.UpdateBoldedDates();

							calendar.SelectionStart = DateTime.Parse(dateStart);
						}
					}

				}
			}
		}

	

	}
}
