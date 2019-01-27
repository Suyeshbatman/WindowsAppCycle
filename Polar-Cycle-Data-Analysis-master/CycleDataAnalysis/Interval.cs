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
using System.Globalization;


namespace CycleDataAnalysis
{
	public partial class Interval : MetroFramework.Forms.MetroForm
	{
		public Interval()
		{
			InitializeComponent();
		}

		/// <summary>
		/// these are the variables declaration
		/// utilized for the calculation 
		/// </summary>

		DateTime myDateTime;
		string fileData;
		public string filename;
		string lengthValue, startTimeValue, intervalValue;

		int count = 0;
		IDictionary<string, string> param = new Dictionary<string, string>();
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
		/// <summary>
		/// declaring variables utlized for graph
		/// the get set variables
		/// </summary>
		public static double[] graphHeartRate { get; set; }
		public static double[] graphSpeed { get; set; }
		public static double[] graphCadence { get; set; }
		public static double[] graphAltitude { get; set; }
		public static double[] graphPower { get; set; }

		int timeArrCount = 0;
		public static List<TimeSpan> totalTime = new List<TimeSpan>();
		TimeSpan startTime, endTime;

		// advance matrix 
		/// <summary>
		/// these are the vatiable declarations
		/// utilized for the list values so that the 
		/// calculation of intervals can be done easily
		/// </summary>
		public static List<List<double>> intervalValues = new List<List<double>>();
		public static List<double> powerData = new List<double>(); // used in interval detection as well 
		public static List<double> intervalDetectionData = new List<double>(); // interval detection 
		public static List<double> powerInterval = new List<double>(); // interval detection 
		public static double threholdValueGlobal;  // interval detection 
		List<double> powerDataSlt = new List<double>();


		/// <summary>
		/// the declaration for the advanced matrix 
		/// these values are stored here and later called from the 
		/// advaced matrix form 
		/// </summary>
		public static double ftpGlobal { get; set; }
		public static double ifGlobal { get; set; }
		public static double tssGlobal { get; set; }
		public static double avgPowerGlobal { get; set; }
		public static double normalizationPowerGlobal { get; set; }

		List<double> movAvgPow4 = new List<double>();
		List<double> movAvg = new List<double>();
		List<double> movAvgPow4Slt = new List<double>();
		List<double> movAvgSlt = new List<double>();

		double movAvgCount;
		OpenFileDialog open = new OpenFileDialog();

		FolderBrowserDialog fd = new FolderBrowserDialog();
		string[] fdata;


		/// <summary>
		/// the method that has been called for 
		/// button that opens file dialog
		/// to open a file and store the data in data grid view 
		/// </summary>
		private void btnLoadHRM_Click(object sender, EventArgs e)
		{
			

		}

		/// <summary>
		/// when the rows in the datagridview is selected,
		/// this event is called automatically
		/// it calls multiple other functions defined later in 
		/// this same program to do many calculations and 
		/// also open the chunking input form 
		/// and after that chunked data's calculations too
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		



		string dateFinal;

		/// <summary>
		/// definition of the girdviewSelect function 
		/// the selected values are stored and processed here 
		/// </summary>
		/// 
		public void grdViewSelect()
		{
			//for counting the selected rows 
			//int grdCount = dataGridView1.SelectedRows.Count;
			Int32 grdCount = dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Selected);
			System.Console.WriteLine(grdCount);

			//to store the datas in array variables 
			//variable declaration
			double[] hr = new double[grdCount];
			double[] sp = new double[grdCount];
			double[] cd = new double[grdCount];
			double[] al = new double[grdCount];
			double[] po = new double[grdCount];

			int i = 0;

			try
			{
				//store all the selected datas in the variables 
				//store the data in the array
				//for calculation purposes 
				System.Console.WriteLine(i);
				foreach (DataGridViewRow row in dataGridView1.Rows)
				{
					hr[i] = Convert.ToDouble(row.Cells[1].Value);
					sp[i] = Convert.ToDouble(row.Cells[2].Value);
					cd[i] = Convert.ToDouble(row.Cells[3].Value);
					al[i] = Convert.ToDouble(row.Cells[4].Value);
					po[i] = Convert.ToDouble(row.Cells[5].Value);
					System.Console.WriteLine(i);
					i++;
				}

				// graph data fetch to global 
				//get global values to te graph values 
				graphHeartRate = hr;
				graphSpeed = sp;
				graphPower = po;
				graphAltitude = al;
				graphCadence = cd;

				//declaration of variables 
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

				//more variables for smode 
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

					//calculating the moving average 
					movingAverage30 /= 30;

					//calculate power for moving average 
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

					//set time for calculating the duration 
					startTime = totalTime.First();
					endTime = totalTime.Last();

					//variables declaratoions
					//calculate the time duration 
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
			//exceptional handling
			catch (Exception ex)
			{
				//commented for test
				//MessageBox.Show("Some errors ocurred \n " + ex);
			}

		}

		private void OpenFile_Load(object sender, EventArgs e)
		{

		}





		/// <summary>
		/// the definition of the file reader function 
		/// reads file from the data uploaded 
		///
		/// </summary>
		/// <param name="data"></param>

		public void fileReader(string data)
		{
			StreamReader fileReader = new StreamReader(data);


			try
			{
				while (!fileReader.EndOfStream)
				{
					fileData = fileReader.ReadLine();
					if (fileData.Contains("StartTime"))
					{
						string startTime = fileData;
						string[] arraStartTime = startTime.Split('=');
						foreach (String item in arraStartTime)
						{
							lblStartTime.Text = item;
							startTimeValue = item;
						}
					}
					if (fileData.Contains("Interval"))
					{
						string interval = fileData;
						string[] arrayInterval = interval.Split('=');
						foreach (String itemInterval in arrayInterval)
						{
							lblInterval.Text = itemInterval;
						}
					}
					if (fileData.Contains("Weight"))
					{
						string weight = fileData;
						string[] arrayWeight = weight.Split('=');
						foreach (String itemWeight in arrayWeight)
						{
							lblWeight.Text = itemWeight;
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
							lblInterval.Text = itemLength;
						}
					}
					if (fileData.Contains("Version"))
					{
						string version = fileData;
						string[] arrayVersion = version.Split('=');
						foreach (String itemVersion in arrayVersion)
						{

							lblVersion.Text = itemVersion;
						}
					}
					if (fileData.Contains("Monitor"))
					{
						string monitor = fileData;
						string[] arrayMonitor = monitor.Split('=');
						foreach (String itemMonitor in arrayMonitor)
						{

							lblMonitor.Text = itemMonitor;
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

							lblVersion.Text = itemVO2max;
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
							lblDate.Text = dateFinal;
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
				}

				List<List<string>> hrData = File.ReadLines(data)
										   .SkipWhile(line => line != "[HRData]")
										   .Skip(1)
										   .Select(line => line.Split().ToList())
										   .ToList();
				count = hrData.Count();

				//variable decarations 
				//calculation of rates 
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

				//calculation of timeinterval
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


					dataGridView1.Rows.Add();
					// dataGridView1.Rows[i].Cells[0].Value = dateFinal+"   |   "+ hour + ":" + minute + ":" + sec;
					DateTime timer = DateTime.ParseExact(startTimeValue, "HH:mm:ss.FFF", CultureInfo.InvariantCulture);
					dataGridView1.Rows[i].Cells[0].Value = dateFinal + " | " + timer.AddSeconds(intervalTwo).TimeOfDay;
					//totalTime[i] = timer.AddSeconds(intervalTwo).TimeOfDay; 
					totalTime.Add(timer.AddSeconds(intervalTwo).TimeOfDay);

					int clm = 0;
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
					if (speed == '1') // for speed 
					{
						lblsmSpeed.Text = "On";
					}
					else if (speed == '0')
					{
						lblsmSpeed.Text = "Off";
					}

					if (cadence == '1') // for cadence
					{
						lblsmCad.Text = "On";
					}
					else if (cadence == '0')
					{
						lblsmCad.Text = "Off";
					}

					if (altitude == '1') // for altitude
					{
						lblsmAltd.Text = "On";
					}
					else if (altitude == '0')
					{
						lblsmAltd.Text = "Off";
					}

					if (power == '1') // for power
					{
						lblsmPower.Text = "On";
					}
					else if (power == '0')
					{
						lblsmPower.Text = "Off";
					}

					if (powerLRBalance == '1') // for power Left Right Balance 
					{
						lblsmPowBal.Text = "On";
					}
					else if (powerLRBalance == '0')
					{
						lblsmPowBal.Text = "Off";
					}

					if (PowerPIndex == '1') // for Power Pedlling Index 
					{
						lblsmPowerIndex.Text = "On";
					}
					else if (PowerPIndex == '0')
					{
						lblsmPowerIndex.Text = "Off";
					}

					if (hrcc == '1') // for HR/CC Data 
					{
						lblsmHRCC.Text = "HR + Cycling Data";
					}
					else if (hrcc == '0')
					{
						lblsmHRCC.Text = "HR Data Only";
					}

					if (usEuroUnit == '1') // for us/euro unit
					{
						lblsmUS.Text = "US Unit";
					}
					else if (usEuroUnit == '0')
					{
						lblsmUS.Text = "Euro Unit";
					}

					if (airPressure == '1') // for Air Pressure
					{
						lblsmAir.Text = "On";
					}
					else if (airPressure == '0')
					{
						lblsmAir.Text = "Off";
					}
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
						powerData.Add(Convert.ToDouble(hrData[i][4]));
					}

					else if (power == '0')
					{
						dataGridView1.Rows[i].Cells[5].Value = 0;
					}
					if (powerLRBalance == '1')
					{
						dataGridView1.Rows[i].Cells[6].Value = hrData[i][5];
						double val = Convert.ToDouble(hrData[i][5]); // calculation of PI and LRB
						double pi = val / 256;
						double lrb = val % 256;
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
						avgPowerGlobal = Math.Round(averagePower, 2);
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
					double power = movAvgPow4Sum / movAvgCount;
					double normalizationPower = Math.Round(Math.Pow(power, 1.0 / 4), 2);
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

					// string totalTimeDuration = TimeSpan.FromDays(totalTimeDurationSec).ToString(@"dd\:hh\:mm");

					double threholdPowVal = Math.Round((105 * ftpGlobal) / 100, 2);
					// double thresholdPowResul = ftpGlobal - threholdPowVal;
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
					intervalDetaction();
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
			catch (Exception ex)
			{
				MessageBox.Show("Some errors ocurred \n " + ex);
			}

		}
		/// <summary>
		/// interval detection 
		/// function definition 
		/// definition of the intervaldetection function 
		/// </summary>
		public void intervalDetaction()
		{
			double threholdPowVal = Math.Round((105 * ftpGlobal) / 100, 2);
			int powerDown = 1;
			int powerUp = 1;
			double intervalValue = 0;
			try
			{
				foreach (double powerDataV in powerData)
				{
					if (threholdPowVal >= powerDataV)
					{
						powerDown = 1;
					}
					if (powerDown == 1)
					{
						if (threholdPowVal <= powerDataV)
							powerUp = 1;
					}
					if (powerUp == 1)
					{
						intervalValue++;
						powerUp = 0;
						powerDown = 0;
					}
					intervalDetectionData.Add(intervalValue);
					powerInterval.Add(powerDataV);
					threholdValueGlobal = threholdPowVal;

					//MessageBox.Show(intervalValue.ToString() + " "+threholdPowVal + " " + powerDataV);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Some errors ocurred \n " + ex);
			}


		}

		public void intervalDetactionSlt()
		{

			double threholdPowVal = Math.Round((105 * ftpGlobal) / 100, 2);
			int powerDown = 1;
			int powerUp = 1;
			double intervalValue = 0;
			try
			{

			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
			foreach (double powerDataV in powerData)
			{
				if (threholdPowVal >= powerDataV)
				{
					powerDown = 1;
				}
				if (powerDown == 1)
				{
					if (threholdPowVal <= powerDataV)
						powerUp = 1;
				}
				if (powerUp == 1)
				{
					intervalValue++;
					powerUp = 0;
					powerDown = 0;
				}
				intervalDetectionData.Add(intervalValue);
				powerInterval.Add(powerDataV);
				threholdValueGlobal = threholdPowVal;

				//MessageBox.Show(intervalValue.ToString() + " "+threholdPowVal + " " + powerDataV);
			}

		}

		private void metroButton1_Click(object sender, EventArgs e)
		{
			OpenFileDialog open = new OpenFileDialog();

			try
			{
				open.Filter = "hrm|*.hrm|All|*.*";
				if (open.ShowDialog() == DialogResult.OK)
				{
					filename = open.FileName; // name of the browsed file 
					string location = open.SafeFileName;  // location of the browsed file
					string fileData, fileDataTwo;
					int count = 0;
					fileReader(filename);
					intervaldetect();

				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Some errors ocurred \n " + ex);
			}
		}

		private void Interval_Load(object sender, EventArgs e)
		{
			
		}

		private void dataGridView1_MouseUp_1(object sender, MouseEventArgs e)
		{
			try
			{
				// new ChunkData().Show();
				//calling the function that stores selected values in the 
				//other forms 
				grdViewSelect();

				//by defauls sets the chunk to one division 
				int chunkDivision = 1;

				//calling the chunkData Form to take input from the user and store the result in 
				//a variable
				using (var form = new Chunk())
				{
					var result = form.ShowDialog();
					if (result == DialogResult.OK)
					{
						chunkDivision = form.chunkGet;
					}
				}

				//count the selected rows from the datagridview
				int grdCount = dataGridView1.SelectedRows.Count;

				//
				//store the counted data in array variables 
				//variable declarations
				double[] hr = new double[grdCount];
				double[] sp = new double[grdCount];
				double[] cd = new double[grdCount];
				double[] al = new double[grdCount];
				double[] po = new double[grdCount];

				int i = 0;
				//
				//storing the selected values in array forms 
				//helps later in doung the required calculations 
				foreach (DataGridViewRow row in dataGridView1.SelectedRows)
				{
					hr[i] = Convert.ToDouble(row.Cells[1].Value);
					sp[i] = Convert.ToDouble(row.Cells[2].Value);
					cd[i] = Convert.ToDouble(row.Cells[3].Value);
					al[i] = Convert.ToDouble(row.Cells[4].Value);
					po[i] = Convert.ToDouble(row.Cells[5].Value);


					i++;
				}

				//calls the summary chunk form 
				//shows all the summary details of the selected data 
				//takes variables as parameters to be able to calculate
				ChunkSummary ck = new ChunkSummary(chunkDivision, hr, sp, cd, al, po);
				ck.Show();
			}
			catch (Exception ex)
			{
				//throwing exception
				MessageBox.Show(ex.Message);
			}
		}

		public void intervaldetect()
		{
			int v = 0;

			try
			{
				lblThres.Text = Interval.threholdValueGlobal.ToString();

				//MessageBox.Show(mainDashboard.intervalDetectionData.Count().ToString()+" "+ mainDashboard.powerData.Count.ToString());

				for (int i = 0; i < Interval.intervalDetectionData.Count(); i++)
				{
					this.dataGridView3.ClearSelection();
					this.dataGridView3.Rows.Add();
					this.dataGridView3.Rows[i].Cells[0].Value = "Interval " + Interval.intervalDetectionData[i];

					this.dataGridView3.Rows[i].Cells[1].Value = Interval.powerInterval[i];

					// lst_interval.Items.Clear();

				}

				for (int j = 1; j <= Interval.intervalDetectionData.Last(); j++)
				{
					listBox1.Items.Add("Interval " + j);
				}

				detect();


			}
			catch (Exception ex)
			{
				MessageBox.Show("Some error Occurred: \n" + ex);
			}
		}

		private void listBox1_MouseClick(object sender, MouseEventArgs e)
		{

		}

		public void detect()
		{
			List<double> powerAv = new List<double>();

			foreach (DataGridViewRow row in dataGridView3.Rows)
			{
				// if (row.Cells[0].Value.ToString() == listBox1.SelectedItem.ToString())
				// {
				powerAv.Add(Convert.ToDouble(row.Cells[1].Value));
				double intervalAvg = powerAv.Average();
				lblAverage.Text = intervalAvg.ToString();
				//}


			}
		}
	}

}