
using System;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;

using Filters;
using GraphInterface;


namespace GraphForm
{
	public partial class GraphingPanel : Panel, IGraph
	{
		private List<DataPoint> dataPoints;
		private ScaleType scaleType;
		private DataPoint minAxis;
		private DataPoint maxAxis;

		private DataPoint prevPoint = null;

		public GraphingPanel()
		{
			InitializeComponent();
			
			dataPoints = new List<DataPoint>();
			scaleType = ScaleType.AUTOSCALE;

			minAxis = new Point2D(-10.0, -10.0);
			maxAxis = new Point2D(10.0, 10.0);

			BackColor = Color.White;
		}

		public void ClearDataPoints()
		{
			dataPoints.Clear();
		}

		public void AddDataPoint(DataPoint pt)
		{
			dataPoints.Add(pt);
		}

		public void SetScaleType(ScaleType type)
		{
			// Only allow autoscaling for now
		}

		public void SetMinMaxAxis(DataPoint min, DataPoint max)
		{
			minAxis = min;
			maxAxis = max;
		}

		public double GetMinRange()
		{
			return ((Point2D)minAxis).X;
		}

		public double GetMaxRange()
		{
			return ((Point2D)maxAxis).X;
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);

			DrawAxis(e.Graphics);
			Draw(e.Graphics);

//			System.Console.WriteLine("OnPaint() was called");
		}

		private void Draw(Graphics g)
		{
			// NOTE: redraw == false is not supported at this time

			if (scaleType == ScaleType.AUTOSCALE)
			{
				// Assume everything is a 2D point
				prevPoint = null;
				for (int i = 0; i < dataPoints.Count; i++)
				{
					Point2D pt = (Point2D)dataPoints[i];
					DrawNextPoint(g, pt);
				}
			}
		}

		private void DrawAxis(Graphics g)
		{
			Pen axisPen = new Pen(Color.LightGray, 1);

			double minX = ((Point2D)minAxis).X;
			double maxX = ((Point2D)maxAxis).X;
			double minY = ((Point2D)minAxis).Y;
			double maxY = ((Point2D)maxAxis).Y;

			// Dump panel information
//			System.Console.WriteLine("Panel: " + this.Width + "x" + this.Height);
//			System.Console.WriteLine("X-Axis: " + minX + " - " + maxX);
//			System.Console.WriteLine("Y-Axis: " + minY + " - " + maxY);

			// X-Axis
			DrawLineOnPanel(g, axisPen, new Point2D(minX, 0), new Point2D(maxX, 0));

			// Y-Axis
			DrawLineOnPanel(g, axisPen, new Point2D(0, minY), new Point2D(0, maxY));
		}

		private void DrawNextPoint(Graphics g, DataPoint pt)
		{
			if (prevPoint != null)
			{
				ConnectPoints(g, prevPoint, pt);
				prevPoint = pt;
			}
			else
			{
				prevPoint = pt;
			}
		}

		private void ConnectPoints(Graphics g, DataPoint p1, DataPoint p2)
		{
			Pen graphPen = new Pen(Color.Black, 1);
			Point2D pt1 = (Point2D)p1;
			Point2D pt2 = (Point2D)p2;

			DrawLineOnPanel(g, graphPen, pt1, pt2);
		}

		private void DrawLineOnPanel(Graphics g, Pen pen, Point2D p1, Point2D p2)
		{
			g.DrawLine(pen, Translate2DXToPanel(p1.X),
							Translate2DYToPanel(p1.Y),
							Translate2DXToPanel(p2.X),
							Translate2DYToPanel(p2.Y));

		}

		private int Translate2DXToPanel(double x)
		{
			int retval;
			Point2D min = (Point2D)minAxis;
			Point2D max = (Point2D)maxAxis;

			double ratio = (this.Width) / (max.X - min.X);
			double offset = (this.Width * (min.X/(max.X - min.X)));

			retval = (int)(ratio*x - offset);
			return retval;
		}

		private int Translate2DYToPanel(double y)
		{
			int retval;
			Point2D min = (Point2D)minAxis;
			Point2D max = (Point2D)maxAxis;

			double ratio = (this.Height) / (max.Y - min.Y);
			double offset = (this.Height * (max.Y/(max.Y - min.Y)));

			// NOTE: The y-coordinate zero begins at the TOP of the panel
			retval = (int)(offset - ratio*y);
			return retval;
		}
	}
}


