using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;

namespace Dataanalysis
{
	public partial class Graph : Form
	{
		//Form1 hrdata = new Form1();

		
		//List<hrdata> hr = new List<hrdata>();
		public Graph()
		{
			InitializeComponent();
		}



		private void Graph_Load(object sender, EventArgs e)
		{
			plotGraph();
			SetSize();
		}

		private int[] buildHeartRateData()
		{
			int[] HeartRate = new int[100];
			for (int i = 0; i < 10; i++)
			{
				HeartRate[i] = (i + 1) * 100;
			}
			return HeartRate;
		}

		private int[] buildSpeedData()
		{
			int[] Speed = new int[100];
			for (int i = 0; i < 10; i++)
			{
				Speed[i] = (i + 1) * 100;
			}
			return Speed;
		}

		


		private void plotGraph()
		{
			GraphPane myPane = zedGraphControl2.GraphPane;

			// Set the Titles
			myPane.Title = "Team A vs Team B Goal Analysis for 2014/2015 Season";
			myPane.XAxis.Title = "Year";
			myPane.YAxis.Title = "No of Goals";
			/* myPane.XAxis.Scale.MajorStep = 50;
			 myPane.YAxis.Scale.Mag = 0;
			 myPane.XAxis.Scale.Max = 1000;*/

			PointPairList HeartRatePairList = new PointPairList();
			PointPairList SpeedPairList = new PointPairList();
			//PointPairList CadencePairList = new PointPairList();
			//PointPairList PowerPairList = new PointPairList();
			//PointPairList AltitudePairList = new PointPairList();
			
			int[] HeartRate = buildHeartRateData();
			int[] Speed = buildSpeedData();
			//int[] Cadence = buildCadenceData();
			//int[] Power = buildPowerData();
			//int[] Altitude = buildAltitudeData();


			for (int i = 0; i < 10; i++)
			{
				HeartRatePairList.Add(i, HeartRate[i]);
				SpeedPairList.Add(i, Speed[i]);
				//CadencePairList.Add(i, Cadence[i]);
				//PowerPairList.Add(i, Power[i]);
				//AltitudePairList.Add(i, Altitude[i]);
				
			}

			LineItem HeartRateCurve = myPane.AddCurve("Heart Rate",
				   HeartRatePairList, Color.Red, SymbolType.Diamond);

			LineItem SpeedCurve = myPane.AddCurve("Speed",
				  SpeedPairList, Color.Blue, SymbolType.Circle);

			//LineItem CadenceCurve = myPane.AddCurve("Cadence",
				//   CadencePairList, Color.Yellow, SymbolType.Square);

			//LineItem PowerCurve = myPane.AddCurve("Power",
				//  PowerPairList, Color.Green, SymbolType.Star);

			//LineItem AltitudeCurve = myPane.AddCurve("Altitude",
				//   AltitudePairList, Color.DarkOrange, SymbolType.Triangle);

			
			zedGraphControl2.AxisChange();
		}



		private void SetSize()
		{
			zedGraphControl2.Location = new Point(0, 0);
			zedGraphControl2.IsShowPointValues = true;
			zedGraphControl2.Size = new Size(this.ClientRectangle.Width - 20, this.ClientRectangle.Height - 50);

		}








		private void btngraph_Click(object sender, EventArgs e)
		{
			
		}

		

		private void chart1_Click(object sender, EventArgs e)
		{
			
		}
	}
}
