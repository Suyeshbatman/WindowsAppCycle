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
		public Graph()
		{
			InitializeComponent();
		}

		private void plotGraph()
		{
			GraphPane myPane = zedGraphControl1.GraphPane;

			// Set the Titles
			myPane.Title.Text = "Polar Cycle";
			myPane.XAxis.Title.Text = "Year";
			myPane.YAxis.Title.Text = "Times";
			myPane.Title.FontSpec.FontColor = Color.Crimson;

			PointPairList speed = new PointPairList();
			PointPairList cadence = new PointPairList();
			PointPairList altitude = new PointPairList();
			PointPairList heart_rate = new PointPairList();
			PointPairList power = new PointPairList();

			myPane.XAxis.Scale.Min = 1;
			myPane.XAxis.Scale.Max = 4000;

			myPane.YAxis.Scale.Min = 1;
			myPane.YAxis.Scale.Max = 650;

			double[] hr = Form1.graphHeartRate;
			double[] sp = Form1.graphSpeed;
			double[] cd = Form1.graphCadence;
			double[] alt = Form1.graphAltitude;
			double[] pwr = Form1.graphPower;

			for (int i = 0; i < hr.Length; i++)
			{
				heart_rate.Add(i, hr[i]);
				speed.Add(i, sp[i]);
				cadence.Add(i, cd[i]);
				altitude.Add(i, alt[i]);
				power.Add(i, pwr[i]);
			}

			LineItem hrCurve = myPane.AddCurve("Heart Rate",
				  heart_rate, Color.Red, SymbolType.None);

			LineItem spCurve = myPane.AddCurve("Speed",
				  speed, Color.Crimson, SymbolType.None);

			LineItem cdCurve = myPane.AddCurve("Cadence",
				  cadence, Color.DarkBlue, SymbolType.None);

			LineItem altCurve = myPane.AddCurve("Altitude",
				altitude, Color.Yellow, SymbolType.None);

			LineItem pwCurve = myPane.AddCurve("Power",
				  power, Color.DarkOrchid, SymbolType.None);

			zedGraphControl1.AxisChange();

		}

		private void Graph_Load(object sender, EventArgs e)
		{
			plotGraph();
		}
	}
}
