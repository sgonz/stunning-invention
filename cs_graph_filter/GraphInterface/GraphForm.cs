
using System;
using System.Windows.Forms;
using System.Reflection;

using GraphInterface;
using Filters;

namespace GraphForm
{
	public partial class GraphingForm : Form
	{
		private System.Timers.Timer tickTimer;

		private StaticFilter filter;
		private NumericFilterParam a;

		private ScalingDynamicFilter df;
		private DynamicFilter mainFilter;

		public GraphingForm()
		{
			InitializeComponent();

			tickTimer = new System.Timers.Timer();
			tickTimer.Interval = 1000;
			tickTimer.Elapsed += OnTimedEvent;
			tickTimer.AutoReset = true;
			tickTimer.Enabled = true;


			mainFilter = new SinFilter();
//			filter = new ScalingFilter();
//			df = new ScalingDynamicFilter();
			filter = new StaticWrapperFilter(mainFilter);
//			a = .m;

			ReloadPoints();
		}



		private void Pnl_Paint(object sender, PaintEventArgs e)
		{
		}


		private void OnTimedEvent(Object obj, System.Timers.ElapsedEventArgs e)
		{
//			a.Value += 1;
			ReloadPoints();
			gPanel.Invalidate();
			Pnl_Paint(null, null);
		}

		public void ReloadPoints()
		{
			gPanel.ClearDataPoints();
			AddPoints(filter);
//			SetupParameters(filter.Filter);
			SetupParameters(mainFilter);
//			SetupParameters(null);
		}


		public void AddPoints(StaticFilter f)
		{
			double step = 0.2;
			double[] xPoints = new double[(int)(((gPanel.GetMaxRange() - gPanel.GetMinRange()) / step) + 1)];
			double[] yPoints;

			// Generate the input array
			for (int i = 0; i < xPoints.Length; i++)
			{
				xPoints[i] = i*step + gPanel.GetMinRange();
			}

			// Generate the output array
			yPoints = f.ProcessFilter(xPoints);

			// Add all of the calculated points
			for (int i = 0; i < xPoints.Length; i++)
			{
				gPanel.AddDataPoint(new Point2D(xPoints[i], yPoints[i]));
			}
		}


		public void SetupParameters(IFilter filterControl)
		{
			Console.WriteLine("Listing Properties:");
			foreach (FieldInfo field in filterControl.GetType().GetFields())
			{
				Console.WriteLine(field.ToString());
			}


		}





/*
		public void AddPoints()
		{
			if (filter.GetType().IsSubclassOf(typeof(StaticFilter)))
			{
				AddPointsStatically((StaticFilter)filter);
			}
			else if (filter.GetType().IsSubclassOf(typeof(DynamicFilter)))
			{
				AddPointsDynamically((DynamicFilter)filter);
			}

		}


		public void AddPointsDynamically(DynamicFilter f)
		{
			System.Console.WriteLine("Drawing Dynamic Filter");
			double step = 0.2;

			for (double x = gPanel.GetMinRange(); x < gPanel.GetMaxRange(); x += step)
			{
				double y = f.ProcessFilter(x);
//System.Console.WriteLine("Adding: " + x + ", " + y);
				gPanel.AddDataPoint(new Point2D(x, y));
//				gPanel.AddDataPoint(new Point2D(x, f.ProcessFilter(x)));
			}
		}

		public void AddPointsStatically(StaticFilter f)
		{
			System.Console.WriteLine("Drawing Static Filter");
			double step = 0.2;
			double[] xPoints = new double[(int)(((gPanel.GetMaxRange() - gPanel.GetMinRange()) / step) + 1)];
			double[] yPoints;

			// Generate the input array
			for (int i = 0; i < xPoints.Length; i++)
			{
				xPoints[i] = i*step + gPanel.GetMinRange();
			}

			// Generate the output array
			yPoints = f.ProcessFilter(xPoints);

			// Add all of the calculated points
			for (int i = 0; i < xPoints.Length; i++)
			{
//System.Console.WriteLine("Adding: " + xPoints[i] + ", " + yPoints[i]);
				gPanel.AddDataPoint(new Point2D(xPoints[i], yPoints[i]));
			}
		}
*/
	}
}

