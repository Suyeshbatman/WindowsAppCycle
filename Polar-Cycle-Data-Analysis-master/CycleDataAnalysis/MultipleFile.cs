using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CycleDataAnalysis
{
	public partial class MultipleFile : MetroFramework.Forms.MetroForm
	{
		/// <summary>
		/// variable declarations to carry out all the processes for the multiple file selection
		/// 
		/// </summary>
		string dateFinal;
		double ftpGlobal;
		double ifGlobal;
		double tssGlobal;
		double avgPowerGlobal;
		double normalizationPowerGlobal;
		List<double> powerData = new List<double>();
		double averagePower;
		//int timeArrCount = 0;
		//public static List<TimeSpan> totalTime = new List<TimeSpan>();
		TimeSpan startTime, endTime;
		string lengthValue;
		double totalDistance;
		double averageSpeed;
		IDictionary<string, string> param = new Dictionary<string, string>();
		public static double maxSpeed { get; set; }
		public static double averageSpeedMiles { get; set; }
		public static double maxSpeedMiles { get; set; }
		public static double averageHeartRate { get; set; }
		public static double maxHeartRate { get; set; }
		public static double minHeartRate { get; set; }
		public static double maxPower { get; set; }
		public static double averageAltitude { get; set; }
		public static double maxAltitude { get; set; }
		public static double averageAltitudeMile { get; set; }
		public static double maxAltitudeMile { get; set; }
		public static double totalDistanceMiles { get; set; }
		List<double> powerDataSlt = new List<double>();


		/// <summary>
		/// variable declarations for the calculaton of movn power
		/// </summary>
		List<double> movAvgPow4 = new List<double>();
		List<double> movAvg = new List<double>();
		List<double> movAvgPow4Slt = new List<double>();
		List<double> movAvgSlt = new List<double>();

		double movAvgCount;

		List<string> files = new List<string>();
		/// <summary>
		/// the consructor ffor the module 
		/// accepts file names to be compared as a parameter 
		/// stores the names n the filenames list of string type 
		/// </summary>
		/// <param name="file"></param>
		public MultipleFile(List<string> file)
		{
			InitializeComponent();
			this.files = file;
		}
		/// <summary>
		/// wen the form loads, the following takes place
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void MultipleFile_Load(object sender, EventArgs e)
		{
			int i = 1;
			try
			{
				//fetch data from file and fill the TAbles according to the values 
				//in the given fies 
				foreach (string file in files)
				{
					if (i == 1)
					{
						fileReader(i, file, dataGridView1);
						mainSummary(i, dataGridView1);
					}
					else if (i == 2)
					{
						fileReader(i, file, dataGridView2);
						mainSummary(i, dataGridView2);
					}

					i++;

				}

				// If the two gridview have the same number of column and row :

				for (int k = 0; k < dataGridView1.Rows.Count; k++)
				{
					var row1 = dataGridView1.Rows[k].Cells.Count;
					//int d1 = dataGridViewfile1.Rows[k].Cells[j].Value;
					// var row2 = src2.Rows[k].ItemArray;

					for (int j = 1; j <= 6; j++)
					{
						string d1 = dataGridView1.Rows[k].Cells[j].Value.ToString();
						int g1 = Convert.ToInt32(d1);
						string d2 = dataGridView2.Rows[k].Cells[j].Value.ToString();
						int g2 = Convert.ToInt32(d2);
						if (g1 > g2)
						{
							dataGridView1.Rows[k].Cells[j].Style.BackColor = Color.Blue;
							dataGridView2.Rows[k].Cells[j].Style.BackColor = Color.Orange;
						}
						else if (g1 < g2)
						{
							dataGridView2.Rows[k].Cells[j].Style.BackColor = Color.Blue;
							dataGridView1.Rows[k].Cells[j].Style.BackColor = Color.Orange;

						}
						else if (g1 == g2)
						{
							dataGridView1.Rows[k].Cells[j].Style.BackColor = Color.Yellow;
							dataGridView2.Rows[k].Cells[j].Style.BackColor = Color.Yellow;
						}
					}
				}


			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}

		}
		string fileData;
		string startTimeValue, intervalValue;
		int count = 0;
		int timeArrCount = 0;
		public static List<TimeSpan> totalTime = new List<TimeSpan>();
		public static string smode { get; set; }

		/// <summary>
		/// the method that gets called when the form loads
		/// takes te data from the datagrieview
		/// stores it in te array variables 
		/// and calculates the summary of the files for the sake of comparison process
		/// </summary>
		/// <param name="fileNumber"></param>
		/// <param name="dataGridViewfile1"></param>
		private void mainSummary(int fileNumber, DataGridView dataGridViewfile1)
		{

			try
			{
				int grdCount = dataGridViewfile1.Rows.Count;
				double[] hr = new double[grdCount];
				double[] sp = new double[grdCount];
				double[] cd = new double[grdCount];
				double[] al = new double[grdCount];
				double[] po = new double[grdCount];


				int i = 0;
				foreach (DataGridViewRow row in dataGridViewfile1.Rows)
				{
					hr[i] = Convert.ToDouble(row.Cells[1].Value);
					sp[i] = Convert.ToDouble(row.Cells[2].Value);
					cd[i] = Convert.ToDouble(row.Cells[3].Value);
					al[i] = Convert.ToDouble(row.Cells[4].Value);
					po[i] = Convert.ToDouble(row.Cells[5].Value);


					i++;
				}
				// chunkDataSummary();
				calculate(fileNumber, hr, sp, cd, al, po);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}


		public void grdViewSelect()
		{
			int grdCount = dataGridView1.SelectedRows.Count;

			double[] hr = new double[grdCount];
			double[] sp = new double[grdCount];
			double[] cd = new double[grdCount];
			double[] al = new double[grdCount];
			double[] po = new double[grdCount];

			int i = 0;
			try
			{
				//foreach (DataGridViewRow row in dataGridViewfile1.Rows)
				//{
				//hr[i] = Convert.ToDouble(row.Cells[1].Value);
				//sp[i] = Convert.ToDouble(row.Cells[2].Value);
				//cd[i] = Convert.ToDouble(row.Cells[3].Value);
				//al[i] = Convert.ToDouble(row.Cells[4].Value);
				//po[i] = Convert.ToDouble(row.Cells[5].Value);

				//  i++;
				//}


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


				for (int j = 0; j < hr.Count(); j++)
				{


					count = grdCount;

					if (speed == '1')
					{

						// cadence 

						arrayCadence[j] = cd[j];


						// average speed 

						speedTotal = sp.Sum();
						averageSpeed = (speedTotal / count) * 0.1;
						averageSpeedMiles = averageSpeed / 1.6;



						// maximum speed  

						arraySpeed[j] = sp[j];
					}
					else
					{
						averageSpeed = 0;
						averageSpeedMiles = 0;
						arraySpeed[j] = 0;

					}

					if (hrcc == '1')
					{
						// average heart rate 
						heartRateTotal = hr.Sum();
						averageHeartRate = hr.Average();
						// maximum heart rate
						arrayHeartRate[j] = hr[j];
					}
					else
					{
						averageHeartRate = 0;
						arrayHeartRate[j] = 0;
					}
					if (power == '1')
					{
						// average power 
						powerTotal = po.Sum();
						averagePower = powerTotal / count;

						// maximum power 
						arrayPower[j] = po[j];
						powerDataSlt.Add(po[j]);
					}
					else
					{
						averagePower = 0;
						arrayPower[j] = 0;
					}
					if (altitude == '1')
					{
						// average altitude 
						altitudeTotal = al.Sum();
						averageAltitude = altitudeTotal / count;
						averageAltitudeMile = averageAltitude / 0.3048;
						// maximum altitude 
						arrayAltitude[j] = al[j];
					}
					else
					{
						averageAltitude = 0;
						averageAltitudeMile = 0;
						arrayAltitude[j] = 0;
					}
				}

				// normalization power 

				// calculation of moving average 
				int value = powerDataSlt.Count();
				// movAvgCount = value;
				//  MessageBox.Show(value.ToString());

				for (int x = 0; x < value; x++)
				{
					double movingAverage30 = 0;
					for (int j = 0; j < 30; j++)
					{
						int index = x + j;
						index %= value;
						movingAverage30 += Convert.ToDouble(powerData[index]);
					}

					movingAverage30 /= 30;

					double movAvgPow = Math.Pow(movingAverage30, 4);
					movAvgPow4Slt.Add(movAvgPow);
					movAvgSlt.Add(movingAverage30);

				}


				// MessageBox.Show(movAvgCount.ToString());
				movAvgCount = movAvgPow4.Count();
				if (movAvgPow4Slt != null)
				{
					double movAvgPow4Sum = movAvgPow4Slt.Sum();
					double powerSlt = movAvgPow4Sum / movAvgCount;
					double normalizationPower = Math.Round(Math.Pow(powerSlt, 1.0 / 4), 2);
					double movingAverageSum = movAvgSlt.Sum();
					double movingAverageValue = movingAverageSum / movAvgCount; // moving average value 
																				// movingAverageGlobal = movingAverageValue;  
					normalizationPowerGlobal = normalizationPower;
					// ftp value 

					double ftpData = (1.0 / 95) * avgPowerGlobal;
					ftpGlobal = Math.Round(avgPowerGlobal - ftpData, 2);
					ifGlobal = normalizationPowerGlobal / ftpGlobal;
					// for tss 

					startTime = totalTime.First();
					endTime = totalTime.Last();
					double startTimeSec = startTime.TotalSeconds;
					double endTimeSec = endTime.TotalSeconds;
					double totalTimeDurationSec = endTimeSec - startTimeSec;

					double tssGlobalOne = normalizationPowerGlobal * ifGlobal * totalTimeDurationSec; // sec value left  
					double tssGlobalTwo = ftpGlobal * 3600;
					double tssGlobalThree = tssGlobalOne / tssGlobalTwo;
					double tssGlobalFour = tssGlobalThree * 100;
					tssGlobal = tssGlobalFour;
					// calculating tss 
					// MessageBox.Show(ftpData.ToString()); 

					// string totalTimeDuration = TimeSpan.FromDays(totalTimeDurationSec).ToString(@"dd\:hh\:mm");


				}

				// max speed 

				maxSpeed = arraySpeed.Max() * 0.1;
				maxSpeedMiles = (maxSpeed) / 1.6;

				//max heart rate 
				maxHeartRate = arrayHeartRate.Max();


				// min heart rate 
				//minHeartRate = arrayHeartRate.Min();
				minHeartRate = double.MaxValue;
				foreach (double valueHR in hr)
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


			}
			catch (Exception ex)
			{
				MessageBox.Show("Some errors ocurred \n " + ex);
			}
		}

		public void chunkDataSections(int fileNumberHere, int ChunkSection, double[] hr, double[] sp, double[] cd, double[] al, double[] po)
		{
			try
			{
				// int chunkValue = new ChunkData().sendChunkValue();

				int chunkStart = 0;
				int countVal = 0;
				int countHR = 0;
				int ChunkDivision = hr.Length / ChunkSection;
				while (chunkStart < ChunkSection)
				{
					double[] heartChunkValue = new double[ChunkDivision];
					double[] sp1 = new double[ChunkDivision];
					double[] cd1 = new double[ChunkDivision];
					double[] al1 = new double[ChunkDivision];
					double[] po1 = new double[ChunkDivision];

					int i = 0;
					for (int k = countVal; k < ChunkDivision + countVal; k++)
					{
						heartChunkValue[i] = hr[k];
						sp1[i] = sp[k];
						cd1[i] = cd[k];
						al1[i] = al[k];
						po1[i] = po[k];
						countHR++;
						i++;

					}
					countVal = countHR;
					chunkStart++;
					calculate(fileNumberHere, heartChunkValue, sp1, cd1, al1, po1);

				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void calculate(int fileno, double[] hr, double[] sp, double[] cd, double[] al, double[] po)
		{
			int count = hr.Length;
			double maxhr = hr.Max();
			double avgHR = hr.Average();
			double minHR = hr.Min();
			double maxsp = sp.Max();
			double avgsp = sp.Average();
			double maxal = al.Max();
			double avgal = al.Average();
			double maxpo = po.Max();
			double avgpo = po.Average();


			try
			{
				if (fileno == 1)
				{
					avgHeartRatef1.Text = avgHR.ToString();
					maxHeartRate1.Text = maxhr.ToString();
					minHRf1.Text = minHR.ToString();
					f1sp.Text = avgsp.ToString();
					maxspf1.Text = maxsp.ToString();

					apf1.Text = avgpo.ToString();
					avgaf1.Text = avgal.ToString();
					maxaf1.Text = maxal.ToString();
					maxpf1.Text = maxpo.ToString();
				}
				else if (fileno == 2)
				{
					avgHeartRatef2.Text = avgHR.ToString();
					maxhrf2.Text = maxhr.ToString();
					minHRf2.Text = minHR.ToString();
					f2sp.Text = avgsp.ToString();
					maxspf2.Text = maxsp.ToString();

					apf2.Text = avgpo.ToString();
					avgaf2.Text = avgal.ToString();
					maxaf2.Text = maxal.ToString();
					maxpf2.Text = maxpo.ToString();

				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
			plusMinus();
		}

		

		private void metroLabel4_Click(object sender, EventArgs e)
		{

		}

		private void metroLabel8_Click(object sender, EventArgs e)
		{

		}

		private void metroLabel12_Click(object sender, EventArgs e)
		{

		}

		private void lblMovAvgf1pm_Click(object sender, EventArgs e)
		{

		}

		

		private void metroLabel51_Click(object sender, EventArgs e)
		{

		}

		private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{

		}

		public void plusMinus()
		{
			if (Convert.ToDouble(lblMovAvgf1.Text) > Convert.ToDouble(lblMovAvgf2.Text))
			{
				metroLabel11.Text = "+";
				metroLabel20.Text = "-";
			}
			else if (Convert.ToDouble(lblMovAvgf1.Text) < Convert.ToDouble(lblMovAvgf2.Text))
			{
				metroLabel11.Text = "-";
				metroLabel20.Text = "+";
			}
			else
			{
				metroLabel11.Text = "=";
				metroLabel20.Text = "=";
			}

			if (Convert.ToDouble(lblNorPowf1.Text) > Convert.ToDouble(lblNorPowf2.Text))
			{
				metroLabel12.Text = "+";
				metroLabel19.Text = "-";
			}
			else if (Convert.ToDouble(lblNorPowf1.Text) < Convert.ToDouble(lblNorPowf2.Text))
			{
				metroLabel12.Text = "-";
				metroLabel19.Text = "+";
			}
			else
			{
				metroLabel12.Text = "=";
				metroLabel19.Text = "=";
			}

			if (Convert.ToDouble(lblFuncThresf1.Text) > Convert.ToDouble(lblFuncThresf2.Text))
			{
				metroLabel13.Text = "+";
				metroLabel18.Text = "-";
			}
			else if (Convert.ToDouble(lblFuncThresf1.Text) < Convert.ToDouble(lblFuncThresf2.Text))
			{
				metroLabel13.Text = "-";
				metroLabel18.Text = "+";
			}
			else
			{
				metroLabel13.Text = "=";
				metroLabel18.Text = "=";
			}

			if (Convert.ToDouble(lblIntensiFacf1.Text) > Convert.ToDouble(lblIntensiFacf2.Text))
			{
				metroLabel14.Text = "+";
				metroLabel17.Text = "-";
			}
			else if (Convert.ToDouble(lblIntensiFacf1.Text) < Convert.ToDouble(lblIntensiFacf2.Text))
			{
				metroLabel14.Text = "-";
				metroLabel17.Text = "+";
			}
			else
			{
				metroLabel14.Text = "=";
				metroLabel17.Text = "=";
			}

			if (Convert.ToDouble(lblTrainiStresf1.Text) > Convert.ToDouble(lblTrainiStresf2.Text))
			{
				metroLabel15.Text = "+";
				metroLabel16.Text = "-";
			}
			else if (Convert.ToDouble(lblTrainiStresf1.Text) < Convert.ToDouble(lblTrainiStresf2.Text))
			{
				metroLabel15.Text = "-";
				metroLabel16.Text = "+";
			}
			else
			{
				metroLabel15.Text = "=";
				metroLabel16.Text = "=";
			}

			if (Convert.ToDouble(td1.Text) > Convert.ToDouble(td2.Text))
			{
				td1pm.Text = "+";
				td2pm.Text = "-";
			}
			else if (Convert.ToDouble(td1.Text) < Convert.ToDouble(td2.Text))
			{
				td1pm.Text = "-";
				td2pm.Text = "+";
			}
			else
			{
				td1pm.Text = "=";
				td2pm.Text = "=";
			}

			if (Convert.ToDouble(f1sp.Text) > Convert.ToDouble(f2sp.Text))
			{
				f1sppm.Text = "+";
				f2sppm.Text = "-";
			}
			else if (Convert.ToDouble(f1sp.Text) < Convert.ToDouble(f2sp.Text))
			{
				f1sppm.Text = "-";
				f2sppm.Text = "+";
			}
			else
			{
				f1sppm.Text = "=";
				f2sppm.Text = "=";
			}

			if (Convert.ToDouble(maxspf1.Text) > Convert.ToDouble(maxspf2.Text))
			{
				maxspf1pm.Text = "+";
				maxspf2pm.Text = "-";
			}
			else if (Convert.ToDouble(maxspf1.Text) < Convert.ToDouble(maxspf2.Text))
			{
				maxspf1pm.Text = "-";
				maxspf2pm.Text = "+";
			}
			else
			{
				maxspf1pm.Text = "=";
				maxspf2pm.Text = "=";
			}

			if (Convert.ToDouble(avgHeartRatef1.Text) > Convert.ToDouble(avgHeartRatef2.Text))
			{
				avgHeartRatef1pm.Text = "+";
				avgHeartRatef2pm.Text = "-";
			}
			else if (Convert.ToDouble(avgHeartRatef1.Text) < Convert.ToDouble(avgHeartRatef2.Text))
			{
				avgHeartRatef1pm.Text = "-";
				avgHeartRatef2pm.Text = "+";
			}
			else
			{
				avgHeartRatef1pm.Text = "=";
				avgHeartRatef2pm.Text = "=";
			}

			if (Convert.ToDouble(maxHeartRate1.Text) > Convert.ToDouble(maxhrf2.Text))
			{
				maxHeartRate1pm.Text = "+";
				maxhrf2pm.Text = "-";
			}
			else if (Convert.ToDouble(maxHeartRate1.Text) < Convert.ToDouble(maxhrf2.Text))
			{
				maxHeartRate1pm.Text = "-";
				maxhrf2pm.Text = "+";
			}
			else
			{
				maxHeartRate1pm.Text = "=";
				maxhrf2pm.Text = "=";
			}

			if (Convert.ToDouble(minHRf1.Text) > Convert.ToDouble(minHRf2.Text))
			{
				minHRf1pm.Text = "+";
				minHRf2pm.Text = "-";
			}
			else if (Convert.ToDouble(minHRf1.Text) < Convert.ToDouble(minHRf2.Text))
			{
				minHRf1pm.Text = "-";
				minHRf2pm.Text = "+";
			}
			else
			{
				minHRf1pm.Text = "=";
				minHRf2pm.Text = "=";
			}
			if (Convert.ToDouble(apf1.Text) > Convert.ToDouble(apf2.Text))
			{
				apf1pm.Text = "+";
				apf2pm.Text = "-";
			}
			else if (Convert.ToDouble(apf1.Text) < Convert.ToDouble(apf2.Text))
			{
				apf1pm.Text = "-";
				apf2pm.Text = "+";
			}
			else
			{
				apf1pm.Text = "=";
				apf2pm.Text = "=";
			}

			if (Convert.ToDouble(maxpf1.Text) > Convert.ToDouble(maxpf2.Text))
			{
				maxpf1pm.Text = "+";
				maxpf2pm.Text = "-";
			}
			else if (Convert.ToDouble(maxpf1.Text) < Convert.ToDouble(maxpf2.Text))
			{
				maxpf1pm.Text = "-";
				maxpf2pm.Text = "+";
			}
			else
			{
				maxpf1pm.Text = "=";
				maxpf2pm.Text = "=";
			}

			if (Convert.ToDouble(avgaf1.Text) > Convert.ToDouble(avgaf2.Text))
			{
				avgaf1pm.Text = "+";
				avgaf2pm.Text = "-";
			}
			else if (Convert.ToDouble(avgaf1.Text) < Convert.ToDouble(avgaf2.Text))
			{
				avgaf1pm.Text = "-";
				avgaf2pm.Text = "+";
			}
			else
			{
				avgaf1pm.Text = "=";
				avgaf2pm.Text = "=";
			}

			if (Convert.ToDouble(maxaf1.Text) > Convert.ToDouble(maxaf2.Text))
			{
				maxaf1pm.Text = "+";
				maxaf2pm.Text = "-";
			}
			else if (Convert.ToDouble(maxaf1.Text) < Convert.ToDouble(maxaf2.Text))
			{
				maxaf1pm.Text = "-";
				maxaf2pm.Text = "+";
			}
			else
			{
				maxaf1pm.Text = "=";
				maxaf2pm.Text = "=";
			}

		}
		public void fileReader(int fileValue, string data, DataGridView dataGridViewfile1)
		{
			try
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
							// lblStartTime.Text = item;
							startTimeValue = item;
						}
					}

					if (fileData.Contains("Length"))
					{
						string length = fileData;
						string[] arrayInterval = length.Split('=');
						foreach (String itemLength in arrayInterval)
						{
							lengthValue = itemLength;

						}
					}
					if (fileData.Contains("Interval"))
					{
						string interval = fileData;
						string[] arrayInterval = interval.Split('=');
						foreach (String itemLength in arrayInterval)
						{
							intervalValue = itemLength;
							// lblInterval.Text = itemLength;
						}
					}

					if (fileData.Contains("SMode"))
					{
						string smodeValue = fileData;
						string[] arraySmode = smodeValue.Split('=');
						foreach (String itemSmode in arraySmode)
						{

							smode = itemSmode;
						}
					}
					//}
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
				// double altitudeTotal = 0;
				double[] arraySpeed = new double[500000];
				double[] arrayHeartRate = new double[500000];
				double[] arrayPower = new double[500000];
				double[] arrayAltitude = new double[500000];
				double[] arrayCadence = new double[500000];
				string[] arrayLength = new string[500000];
				string[] arrayStartTime = new string[500000];
				// double intervalResult = 0;




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
					timeArrCount++;
					double interval = double.Parse(intervalValue);

					//sec = sec + interval ; 

					intervalTwo = intervalTwo + interval;


					dataGridViewfile1.Rows.Add();
					// dataGridView1.Rows[i].Cells[0].Value = dateFinal+"   |   "+ hour + ":" + minute + ":" + sec;
					DateTime timer = DateTime.ParseExact(startTimeValue, "HH:mm:ss.FFF", CultureInfo.InvariantCulture);
					dataGridViewfile1.Rows[i].Cells[0].Value = dateFinal + " | " + timer.AddSeconds(intervalTwo).TimeOfDay;
					//totalTime[i] = timer.AddSeconds(intervalTwo).TimeOfDay; 
					totalTime.Add(timer.AddSeconds(intervalTwo).TimeOfDay);

					// int clm = 0;
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
						dataGridViewfile1.Rows[i].Cells[1].Value = hrData[i][0];
					}
					else if (hrcc == '0')
					{
						dataGridViewfile1.Rows[i].Cells[1].Value = 0;
					}
					if (speed == '1')
					{
						dataGridViewfile1.Rows[i].Cells[2].Value = hrData[i][1];
					}
					else if (speed == '0')
					{
						dataGridViewfile1.Rows[i].Cells[2].Value = 0;
					}
					if (cadence == '1')
					{
						dataGridViewfile1.Rows[i].Cells[3].Value = hrData[i][2];
					}
					else if (cadence == '0')
					{
						dataGridViewfile1.Rows[i].Cells[3].Value = 0;
					}

					if (altitude == '1')
					{
						dataGridViewfile1.Rows[i].Cells[4].Value = hrData[i][3];
					}
					else if (altitude == '0')
					{
						dataGridViewfile1.Rows[i].Cells[4].Value = 0;
					}
					if (power == '1')
					{
						dataGridViewfile1.Rows[i].Cells[5].Value = hrData[i][4];
						powerData.Add(Convert.ToDouble(hrData[i][4]));
					}

					else if (power == '0')
					{
						dataGridViewfile1.Rows[i].Cells[5].Value = 0;
					}
					if (powerLRBalance == '1')
					{
						dataGridViewfile1.Rows[i].Cells[6].Value = hrData[i][5];
						double val = Convert.ToDouble(hrData[i][5]); // calculation of PI and LRB
						double pi = val / 256;
						double lrb = val % 256;
						double rb = 100 - lrb;
						dataGridViewfile1.Rows[i].Cells[7].Value = Math.Round(pi, 0);
						dataGridViewfile1.Rows[i].Cells[8].Value = "L" + lrb + "- R" + rb;
					}
					else if (powerLRBalance == '0')
					{
						dataGridViewfile1.Rows[i].Cells[6].Value = 0;
					}
					if (speed == '1')
					{

						// cadence 

						arrayCadence[i] = int.Parse(hrData[i][2]);


						// average speed 

						speedTotal = speedTotal + int.Parse(hrData[i][1]);
						averageSpeed = (speedTotal / count) * 0.1;
						// averageSpeedMiles = averageSpeed / 1.6;



						// maximum speed  

						arraySpeed[i] = int.Parse(hrData[i][1]);
					}
					else
					{
						averageSpeed = 0;
						//averageSpeedMiles = 0;
						arraySpeed[i] = 0;

					}

					if (hrcc == '1')
					{
						// average heart rate 
						heartRateTotal = heartRateTotal + int.Parse(hrData[i][0]);
						// averageHeartRate = heartRateTotal / count;
						// maximum heart rate
						arrayHeartRate[i] = int.Parse(hrData[i][0]);
					}
					else
					{
						// averageHeartRate = 0;
						arrayHeartRate[i] = 0;
					}
					if (power == '1')
					{
						// average power 
						powerTotal = powerTotal + int.Parse(hrData[i][4]);
						averagePower = powerTotal / count;
						avgPowerGlobal = Math.Round(averagePower, 2);
						// maximum power 
						arrayPower[i] = int.Parse(hrData[i][4]);
					}
					else
					{
						averagePower = 0;
						arrayPower[i] = 0;
					}
				}
				// normalization power 

				// calculation of moving average 
				int value = powerData.Count();
				// movAvgCount = value;
				//  MessageBox.Show(value.ToString());
				for (int x = 0; x < value; x++)
				{
					double movingAverage30 = 0;
					for (int j = 0; j < 30; j++)
					{
						int index = x + j;
						index %= value;
						movingAverage30 += Convert.ToDouble(powerData[index]);
					}

					movingAverage30 /= 30;

					double movAvgPow = Math.Pow(movingAverage30, 4);
					movAvgPow4.Add(movAvgPow);
					movAvg.Add(movingAverage30);

				}
				// MessageBox.Show(movAvgCount.ToString());
				movAvgCount = movAvgPow4.Count();
				if (movAvgPow4 != null)
				{
					double movAvgPow4Sum = movAvgPow4.Sum();
					double power1 = movAvgPow4Sum / movAvgCount;
					double normalizationPower = Math.Round(Math.Pow(power1, 1.0 / 4), 2);
					double movingAverageSum = movAvg.Sum();
					double movingAverageValue = movingAverageSum / movAvgCount; // moving average value 
																				// movingAverageGlobal = movingAverageValue;  
					normalizationPowerGlobal = normalizationPower;
					// ftp value 
					double ftpData = 0.95 * avgPowerGlobal;
					ftpGlobal = ftpData;
					ifGlobal = normalizationPowerGlobal / ftpGlobal;
					// for tss 

					startTime = totalTime.First();
					endTime = totalTime.Last();
					double startTimeSec = startTime.TotalSeconds;
					double endTimeSec = endTime.TotalSeconds;
					TimeSpan length = TimeSpan.Parse(lengthValue);
					double lengthToSec = length.TotalSeconds;
					double totalTimeDurationSec = lengthToSec;

					double tssGlobalOne = normalizationPowerGlobal * ifGlobal * totalTimeDurationSec; // sec value left  
					double tssGlobalTwo = ftpGlobal * 3600;
					double tssGlobalThree = tssGlobalOne / tssGlobalTwo;
					double tssGlobalFour = tssGlobalThree * 100;
					tssGlobal = tssGlobalFour;   // calculating tss 
												 // MessageBox.Show(ftpData.ToString()); 



					double threholdPowVal = Math.Round((105 * ftpGlobal) / 100, 2);

					int intervalCountUp = 0;
					int intervalCountDown = 0;
					List<double> chk = new List<double>();

					for (int v = 0; v < powerData.Count; v++)
					{
						if (powerData[v] >= threholdPowVal)
						{
							intervalCountUp = v;
							chk.Add(v);

							// MessageBox.Show(intervalCountUp.ToString());
						}
						if (powerData[v] <= threholdPowVal)
						{
							intervalCountDown = v;
							chk.Add(v);

							// MessageBox.Show(intervalCountDown.ToString());
						}
					}

				}



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
					// totalDistanceMiles = Math.Round(totalDistanceProcessMiles, 2); ;

				}


				if (fileValue == 1)
				{
					td1.Text = totalDistance.ToString();
					lblMovAvgf1.Text = Math.Round(avgPowerGlobal, 2).ToString();
					lblNorPowf1.Text = Math.Round(normalizationPowerGlobal, 2).ToString();
					lblFuncThresf1.Text = Math.Round(ftpGlobal, 2).ToString();
					lblIntensiFacf1.Text = Math.Round(ifGlobal, 2).ToString();
					lblTrainiStresf1.Text = Math.Round(tssGlobal, 2).ToString();
				}
				else if (fileValue == 2)
				{
					td2.Text = totalDistance.ToString();
					lblMovAvgf2.Text = Math.Round(avgPowerGlobal, 2).ToString();
					lblNorPowf2.Text = Math.Round(normalizationPowerGlobal, 2).ToString();
					lblFuncThresf2.Text = Math.Round(ftpGlobal, 2).ToString();
					lblIntensiFacf2.Text = Math.Round(ifGlobal, 2).ToString();
					lblTrainiStresf2.Text = Math.Round(tssGlobal, 2).ToString();

				}

			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}

		}

	}
}
