
using System;


namespace TestSuite
{
	public abstract class TestInterface
	{
		public abstract void Init();
		public abstract void Run();
	}


	public static class Program
	{
		public static int Main(string[] args)
		{
			FiltersTesting test = new FiltersTesting();

			test.Init();
			test.Run();


			return 0;
		}
	}
}


