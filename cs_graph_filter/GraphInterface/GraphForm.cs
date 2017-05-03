
using System;
using System.Windows.Forms;
using System.Reflection;

using GraphInterface;
using Filters;

namespace GraphForm
{
	public partial class GraphingForm : Form
	{
		private readonly int X_OFFSET = 10;
		private readonly int Y_OFFSET = 20;
		private readonly int Y_LBL_SHIFT = 20;
		private readonly int Y_SLIDER_SHIFT = 50;
		private readonly int X_BUFFER = 5;
		private readonly int LABEL_WIDTH = 30;
		private readonly int SLIDER_WIDTH = 100;

		private System.Timers.Timer tickTimer;

		private StaticFilter filter;
		private DynamicFilter mainFilter;
//		private NumericFilterParam a;
//		private ScalingDynamicFilter df;

		private TrackBar aBar;

		public GraphingForm()
		{
			InitializeComponent();

			tickTimer = new System.Timers.Timer();
			tickTimer.Interval = 1000;
			tickTimer.Elapsed += OnTimedEvent;
			tickTimer.AutoReset = true;
			tickTimer.Enabled = false;

			aBar = null;

			mainFilter = new SinFilter();
//			filter = new ScalingFilter();
//			df = new ScalingDynamicFilter();
			filter = new StaticWrapperFilter(mainFilter);

			UpdateForm();
		}



		private void Pnl_Paint(object sender, PaintEventArgs e)
		{
		}


		private void OnTimedEvent(Object obj, System.Timers.ElapsedEventArgs e)
		{
//			a.Value += 1;
Console.WriteLine("Bar Val:" + aBar.Value);
			aBar.Value += 100;
			ReloadPoints();
//			gPanel.Invalidate();
//			Pnl_Paint(null, null);
		}

		public void ReloadPoints()
		{
			gPanel.ClearDataPoints();
			AddPoints(filter);

			gPanel.Invalidate();
			Pnl_Paint(null, null);

//			SetupParameters(filter.Filter);
//			SetupParameters(mainFilter);
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
			int yOffset = Y_OFFSET;

			AddGrpParameters(filterControl, ref yOffset);

			// Account for switching from label shifts to slider shifts
			yOffset += Y_SLIDER_SHIFT - Y_LBL_SHIFT;

			foreach (FieldInfo field in filterControl.GetType().GetFields())
			{
				AddFilterParameter((IFilterParameter)field.GetValue(filterControl), ref yOffset);
			}


		}


		private void AddGrpParameters(IFilter filterControl, ref int yOffset)
		{
			Label LblName = new Label();
			Label LblFormula = new Label();
			LblName.Name = "FilterName";
			LblName.Text = filterControl.Name;
			LblFormula.Name = "FilterFormula";
			LblFormula.Text = filterControl.ToString();

			LblName.Location = new System.Drawing.Point(X_OFFSET, yOffset);
			LblName.Width = GrpParameters.Width - 2*X_OFFSET;
			yOffset += Y_LBL_SHIFT;
			LblFormula.Location = new System.Drawing.Point(X_OFFSET + X_BUFFER, yOffset);
			LblFormula.Width = GrpParameters.Width - X_BUFFER - 2*X_OFFSET;
			yOffset += Y_LBL_SHIFT;

			GrpParameters.Tag = filterControl;

			GrpParameters.Controls.Add(LblName);
			GrpParameters.Controls.Add(LblFormula);
		}

		private void AddFilterParameter(IFilterParameter p, ref int yOffset)
		{
			if (p.GetType() == typeof(NumericFilterParam))
			{
				AddSliderBar((NumericFilterParam)p, ref yOffset);
			}
		}


		private void AddSliderBar(NumericFilterParam p, ref int yOffset)
		{
			Label l = new Label();
//			SliderBar slider = new SilderBar();
			DecimalTrackBar slider = new DecimalTrackBar();


			l.Location = new System.Drawing.Point(X_OFFSET, yOffset);
			l.Width = LABEL_WIDTH;
			slider.Location = new System.Drawing.Point(X_OFFSET + LABEL_WIDTH + X_BUFFER, yOffset);
			slider.Width = SLIDER_WIDTH;


			// Need to find a floating point slider
			slider.Value		= p.Value;
			slider.Minimum		= p.Min;
			slider.Maximum		= p.Max;
			slider.Increment	= p.Increment;

			l.Text = p.Name;
			slider.Tag = p;
			slider.ValueChanged += new System.EventHandler(Parameter_ValueChanged);

			GrpParameters.Controls.Add(l);
			GrpParameters.Controls.Add(slider);

if (aBar == null)
aBar = slider;
			yOffset += Y_SLIDER_SHIFT;
		}


		private void Parameter_ValueChanged(object sender, EventArgs e)
		{
			Control c = (Control)sender;
			IFilterParameter fp;


			// Sanity check
//			if (c.Tag.GetType().IsSubclassOf(typeof(IFilterParameter)))
			if (c.Tag.GetType() == typeof(NumericFilterParam))
			{
				fp = (IFilterParameter)c.Tag;
				fp.Value = ((DecimalTrackBar)c).Value;
//				Console.WriteLine("TrackBar: " + ((DecimalTrackBar)c).Value);
//				Console.WriteLine("New value: " + fp.Value);
				
				ReloadPoints();
			}

			UpdateGrpParameters();
		}


		private void UpdateGrpParameters()
		{
			// Find the filter formula and update its values
			foreach (Control c in GrpParameters.Controls)
			{
				if (c.Name == "FilterFormula")
				{
					c.Text = ((IFilter)GrpParameters.Tag).ToString();
				}
			}
		}


		private void UpdateForm()
		{
			ReloadPoints();
			SetupParameters(mainFilter);
		}
	}
}

