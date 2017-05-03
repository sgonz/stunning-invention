
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

	public class StaticWrapperFilter : StaticFilter
	{
		private DynamicFilter filter;

		public DynamicFilter Filter { get { return filter; } }

		public StaticWrapperFilter(DynamicFilter df)
		{
			filter = df;
		}

		public override string Name { get { return "Static Wrapper Filter"; } }

		public override string ToString()
		{
			return "y = x";
		}

		public override double[] ProcessFilter(double[] dataIn)
		{
			double[] retval = new double[dataIn.Length];

			for (int i = 0; i < dataIn.Length; i++)
			{
				retval[i] = filter.ProcessFilter(dataIn[i]);
			}

			return retval;
		}
	}

	// y = f1(f2(x))
	public class StaticChainFilter : StaticFilter
	{
		private StaticFilter filter1;
		private StaticFilter filter2;

		public StaticFilter Filter1 { get { return filter1; } }
		public StaticFilter Filter2 { get { return filter2; } }

		public StaticChainFilter(StaticFilter f1, StaticFilter f2)
		{
			filter1 = f1;
			filter2 = f2;
		}

		public override string Name { get { return "Static Chain Filter"; } }

		public override string ToString()
		{
			return "y = f1(f2(x))";
		}

		public override double[] ProcessFilter(double[] dataIn)
		{
			double[] retval = new double[dataIn.Length];
			retval = filter1.ProcessFilter(filter2.ProcessFilter(dataIn));
			return retval;
		}
	}


	// y = f1(f2(x))
	public class DynamicChainFilter : DynamicFilter
	{
		private DynamicFilter filter1;
		private DynamicFilter filter2;

		public DynamicFilter Filter1 { get { return filter1; } }
		public DynamicFilter Filter2 { get { return filter2; } }

		public DynamicChainFilter(DynamicFilter f1, DynamicFilter f2)
		{
			filter1 = f1;
			filter2 = f2;
		}

		public override string Name { get { return "Dynamic Chain Filter"; } }

		public override string ToString()
		{
			return "y = f1(f2(x))";
		}

		public override double ProcessFilter(double dataIn)
		{
			return filter1.ProcessFilter(
				   filter2.ProcessFilter(dataIn));
		}
	}


	// Simple y = mx StaticFilter
	public class ScalingDynamicFilter : DynamicFilter
	{
		public NumericFilterParam m;

		public ScalingDynamicFilter()
		{
			m = new NumericFilterParam("m");
			m.Value = 1.0;
		}

		public override string Name { get { return "Scaling Dynamic Filter"; } }

		public override string ToString()
		{
			return "y = " + m.Value.ToString() + "*x";
		}


		public override double ProcessFilter(double dataIn)
		{
			return m.Value * dataIn;
		}
	}

	// Simple y = mx StaticFilter
	public class ScalingFilter : StaticFilter
	{
		public NumericFilterParam m;

		public ScalingFilter()
		{
			m = new NumericFilterParam("m");
			m.Value = 1.0;
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

	// y = a*sin(h*(x-b)) + k
	public class SinFilter : DynamicFilter
	{
		private readonly string NUM_FORMAT = "0.###";
		public NumericFilterParam a;
		public NumericFilterParam k;
		public NumericFilterParam h;
		public NumericFilterParam b;

		public SinFilter()
		{
			a = new NumericFilterParam("a");
			k = new NumericFilterParam("k");
			h = new NumericFilterParam("h");
			b = new NumericFilterParam("b");

			a.Value = 1.0;
			k.Value = 0.0;
			h.Value = 1.0;
			b.Value = 0.0;

 			a.min = -10.0;
 			a.max = 10.0;
 			a.inc = 0.01;
 
 			k.min = -10.0;
 			k.max = 10.0;
 			k.inc = 1.0;
 
 			h.min = -4.0;
 			h.max = 4.0;
 			h.inc = 0.50;
 
 			b.min = -10.0;
 			b.max = 10.0;
 			b.inc = 1.0;
		}

		public override string Name { get { return "Sine Wave Filter"; } }

		public override string ToString()
		{
			return "y = " + a.Value.ToString(NUM_FORMAT) +
						"*sin(" + h.Value.ToString(NUM_FORMAT) +
						"*(x-" + b.Value.ToString(NUM_FORMAT) + ")) + " +
						k.Value.ToString(NUM_FORMAT);
		}

		public override double ProcessFilter(double dataIn)
		{
			return a.Value * Math.Sin(h.Value*(dataIn - b.Value)) + k.Value;
		}

	}
}


