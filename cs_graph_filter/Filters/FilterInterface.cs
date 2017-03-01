
using System;



namespace Filters
{
	public interface IFilter
	{
		string Name { get; }
	}


	public abstract class StaticFilter : IFilter
	{
		public abstract string Name { get; }
		public abstract double[] ProcessFilter(double[] dataIn);
	}

	public abstract class DynamicFilter : IFilter
	{
		public abstract string Name { get; }
		public abstract double ProcessFilter(double dataIn);
	}
}


