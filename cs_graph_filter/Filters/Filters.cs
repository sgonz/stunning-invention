
using System;



namespace Filters
{
	// Simple test StaticFilter that returns the input as output
	public class LinearStaticFilter : StaticFilter
	{
		public LinearStaticFilter()
		{
		}

		public override string Name { get { return "Linear Filter"; } }

		public override string ToString()
		{
			return "y = x";
		}


		public override double[] ProcessFilter(double[] dataIn)
		{
			return dataIn;
		}
	}

	// Simple test DynamicFilter that returns the input as output
	public class LinearDynamicFilter : DynamicFilter
	{
		public LinearDynamicFilter()
		{
		}

		public override string Name { get { return "Linear Filter"; } }

		public override string ToString()
		{
			return "y = x";
		}


		public override double ProcessFilter(double dataIn)
		{
			return dataIn;
		}
	}


	// Simple y = mx StaticFilter
	public class ScalingFilter : StaticFilter
	{
		public NumericFilterParam m;

		public ScalingFilter()
		{
			m = new NumericFilterParam("m");
		}

		public ScalingFilter(NumericFilterParam m)
		{
			this.m = m;
		}
		
		public override string Name { get { return "Scaling Filter"; } }

		public override string ToString()
		{
			return "y = " + m.Value.ToString() + "*x";
		}


		public override double[] ProcessFilter(double[] dataIn)
		{
			double[] retval = new double[dataIn.Length];

			for (int i = 0; i < dataIn.Length; i++)
			{
				retval[i] = m.Value * dataIn[i];
			}

			return retval;
		}
	}
}


