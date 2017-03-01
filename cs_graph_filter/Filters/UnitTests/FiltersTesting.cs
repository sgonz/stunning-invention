
using System;

using Filters;

namespace TestSuite
{
	public class FiltersTesting : TestInterface
	{
//		LinearStaticFilter lsf;
//		LinearDynamicFilter ldf;
		ScalingFilter sf;
		ScalingFilter sf2;

		public override void Init()
		{
		}


		public override void Run()
		{
			double[] myDataArr = new double[]{ 0.0, 1.0, 2.0};

			NumericFilterParam m = new NumericFilterParam("m");
			m.Value = 10.0;
//			lsf	= new LinearStaticFilter();
//			ldf	= new LinearDynamicFilter();
			sf	= new ScalingFilter(m);
			sf2	= new ScalingFilter(m);
//			sf	= new ScalingFilter();


//			Console.WriteLine("LinearStatusFilter Test:");
//			Console.WriteLine("  " + lsf.ToString() + ":");
//			foreach (double val in lsf.ProcessFilter(myDataArr))
//			{
//				Console.WriteLine("  " + val.ToString());
//			}
//			Console.WriteLine();
//
//			
//			Console.WriteLine("LinearDynamicFilter Test:");
//			Console.WriteLine("  " + ldf.ToString() + ":");
//			foreach (double val in myDataArr)
//			{
//				Console.WriteLine("  " + ldf.ProcessFilter(val).ToString());
//			}
//			Console.WriteLine();
//
//			Console.WriteLine("ScalingFilter2 Test:");
//			m.Value = 10;
//			Console.WriteLine("  " + sf.ToString() + ":");
//			foreach (double val in sf.ProcessFilter(myDataArr))
//			{
//				Console.WriteLine("  " + val.ToString());
//			}
//			Console.WriteLine();


			for (m.Value = 0.0; m.Value < 25.0;)
			{
				Console.WriteLine("ScalingFilter1 Test:");
				Console.WriteLine("  " + sf.ToString() + ":");
				foreach (double val in sf.ProcessFilter(myDataArr))
				{
					Console.WriteLine("  " + val.ToString());
				}
				Console.WriteLine();


				Console.WriteLine("ScalingFilter2 Test:");
				Console.WriteLine("  " + sf2.ToString() + ":");
				foreach (double val in sf2.ProcessFilter(myDataArr))
				{
					Console.WriteLine("  " + val.ToString());
				}
				Console.WriteLine();

				m.Value += 10.0;
			}
		}




	}
}


