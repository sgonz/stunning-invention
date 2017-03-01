
using System;



namespace Filters
{
	public interface IFilterParameter
	{
		string Name { get; }
	}


	public class NumericFilterParam : IFilterParameter
	{
		private string name = "None";

		public double min;
		public double max;
		public double inc;
		public double val;
		
		public NumericFilterParam(string name)
		{
			this.name = name;
			this.inc = 1.0;
			this.min = -100.0;
			this.max = 100.0;
			this.val = 0.0;
		}

		public NumericFilterParam(	string name,
									double min,
									double inc,
									double max) : this(name)
		{
			// Verify that inc, min, and max are valid
			this.inc = (inc > 0 ? inc : 1.0);
			this.min = min;
			this.max = (min < max ? max : min + inc);


			// Initialize the parameter to 0, unless that falls
			//   outside of min/max
			if (min < 0 && 0 < max)
			{
				val = 0;
			}
			else
			{
				val = min;
			}
		}

		public string Name { get { return name; } }


		public double Min		{ get { return min; } }
		public double Max		{ get { return max; } }
		public double Increment { get { return inc; } }

		public double Value
		{
			set { val = value; }
			get { return val; }
		}
	}


}


