
using System;


using Filters;


namespace GraphInterface
{
	public enum ScaleType
	{
		UNDEFINED = 0,
		AUTOSCALE,
		FIXED,
	};


	public interface IGraph
	{
		void AddDataPoint(DataPoint pt);
		void SetScaleType(ScaleType type);

		void SetMinMaxAxis(DataPoint min, DataPoint max);

		double GetMinRange();
		double GetMaxRange();
	}



	public interface DataPoint
	{
	}

	public class Point1D : DataPoint
	{
		public double X { get; set; }

		public Point1D(double x)
		{
			X = x;
		}
	}

	public class Point2D : DataPoint
	{
		public double X { get; set; }
		public double Y { get; set; }

		public Point2D(double x, double y)
		{
			X = x;
			Y = y;
		}
	}

	public class Point3D : DataPoint
	{
		public double X { get; set; }
		public double Y { get; set; }
		public double Z { get; set; }

		public Point3D(double x, double y, double z)
		{
			X = x;
			Y = x;
			Z = z;
		}
	}
}

