using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CycleDataAnalysis
{
	public partial class ChunkSummary : Form
	{

		double[] hr, sp, cd, al, po;

		int count;
		int ChunkDivision;
		int chunkNumber = 0;

		public ChunkSummary(int chunkNumber, double[] hr, double[] sp, double[] cd, double[] al, double[] po)
		{
			InitializeComponent();
			this.hr = hr;
			this.sp = sp;
			this.cd = cd;
			this.al = al;
			this.po = po;
			count = hr.Length;
			this.chunkNumber = chunkNumber;
			ChunkDivision = count / chunkNumber;
		}

		private void metroLabel10_Click(object sender, EventArgs e)
		{

		}

		private void maxsp2_Click(object sender, EventArgs e)
		{

		}

		private void ChunkSummary_Load(object sender, EventArgs e)
		{
			metroTabControl1.TabPages[2].Visible = false;
			metroTabControl1.TabPages[3].Visible = false;
			chunkSectionsSummary();
		}
		public void chunkSectionsSummary()
		{
			// int chunkValue = new ChunkData().sendChunkValue();

			int chunkStart = 0;
			int countVal = 0;
			int countHR = 0;
			try
			{
				while (chunkStart < chunkNumber)
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
					//  if(heartChunkValue.Length<ChunkDivison)
					calculateData(chunkStart, heartChunkValue, sp1, cd1, al1, po1);

				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}

		}
		private void calculateData(int chunkNo, double[] hr, double[] sp, double[] cd, double[] al, double[] po)
		{
			//put logic here for km/miles
			double maxhr = hr.Max();
			double avgHR = hr.Sum() / ChunkDivision;
			double min = hr.Min();

			double maxsp = sp.Max();
			double avgsp = sp.Sum() / ChunkDivision;

			double avgal = al.Sum() / ChunkDivision;
			double maxal = al.Max();

			double avpo = po.Sum() / ChunkDivision;
			double maxpo = po.Max();

			switch (chunkNo)
			{
				case 1:
					{
						avghr1.Text = avgHR.ToString();
						maxhr1.Text = maxhr.ToString();
						minhr1.Text = min.ToString();
						as1.Text = avgsp.ToString();
						ms1.Text = maxsp.ToString();
						aa1.Text = avgal.ToString();
						ma1.Text = maxal.ToString();
						ap1.Text = avpo.ToString();
						mp1.Text = maxpo.ToString();
						// td1.Text=
						break;
					}
				case 2:
					{
						avghr2.Text = avgHR.ToString();
						maxhr2.Text = maxhr.ToString();
						minhr2.Text = min.ToString();


						as2.Text = avgsp.ToString();
						ms2.Text = maxsp.ToString();
						aa2.Text = avgal.ToString();
						ma2.Text = maxal.ToString();
						ap2.Text = avpo.ToString();
						mp2.Text = maxpo.ToString();
						break;
					}
				case 3:
					{
						metroTabControl1.TabPages[2].Visible = true;
						avghr3.Text = avgHR.ToString();
						maxhr3.Text = maxhr.ToString();
						minhr3.Text = min.ToString();

						as3.Text = avgsp.ToString();
						ms3.Text = maxsp.ToString();
						aa3.Text = avgal.ToString();
						ma3.Text = maxal.ToString();
						ap3.Text = avpo.ToString();
						mp3.Text = maxpo.ToString();
						break;
					}
				case 4:
					{
						metroTabControl1.TabPages[3].Visible = true;
						avghr4.Text = avgHR.ToString();
						maxhr4.Text = maxhr.ToString();
						minhr4.Text = min.ToString();

						as4.Text = avgsp.ToString();
						ms4.Text = maxsp.ToString();
						aa4.Text = avgal.ToString();
						ma4.Text = maxal.ToString();
						ap4.Text = avpo.ToString();
						mp4.Text = maxpo.ToString();
						break;

					}
			}

		}
	}
}
