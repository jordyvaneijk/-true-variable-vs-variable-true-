using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace PerformanceSanbbox
{
	class Program
	{
		static void Main(string[] args)
		{
			var program = new Program();
			program.Run();
			Console.WriteLine("Press any key to continue");
			Console.ReadKey();
		}

		private void Run()
		{
			List<Performance> performanceCountersTrue = new List<Performance>();
			List<Performance> performanceCountersFalse = new List<Performance>();
			const int numberOfIterations = 1000000;

			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine("Performance test for 'variableTrue == true' vs 'true == variableTrue'");
			Console.WriteLine();
			for (int i = 0; i < 10000; i++)
			{
				CalculateTruePerformance(performanceCountersTrue, numberOfIterations);
			}

			//T1 == 'varTrue == true'
			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine("Performance for 'variableTrue == true'");
			Console.ResetColor();
			Console.WriteLine("Average: {0} ms", performanceCountersTrue.Average(c=>c.T1.TotalMilliseconds));
			Console.WriteLine("Min: {0} ms", performanceCountersTrue.Min(c=>c.T1.TotalMilliseconds));
			Console.WriteLine("Max: {0} ms", performanceCountersTrue.Max(c=>c.T1.TotalMilliseconds));
			Console.WriteLine();
			//T2 == 'varTrue == false'
			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine("Performance for 'variableTrue == false'");
			Console.ResetColor();
			Console.WriteLine("Average: {0} ms", performanceCountersTrue.Average(c => c.T2.TotalMilliseconds));
			Console.WriteLine("Min: {0} ms", performanceCountersTrue.Min(c => c.T2.TotalMilliseconds));
			Console.WriteLine("Max: {0} ms", performanceCountersTrue.Max(c => c.T2.TotalMilliseconds));
			Console.WriteLine();
			//T3 == 'true == varTrue'
			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine("Performance for 'true == variableTrue'");
			Console.ResetColor();
			Console.WriteLine("Average: {0} ms", performanceCountersTrue.Average(c => c.T3.TotalMilliseconds));
			Console.WriteLine("Min: {0} ms", performanceCountersTrue.Min(c => c.T3.TotalMilliseconds));
			Console.WriteLine("Max: {0} ms", performanceCountersTrue.Max(c => c.T3.TotalMilliseconds));
			Console.WriteLine();
			//T4 == 'false == varTrue'
			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine("Performance for 'false == variableTrue'");
			Console.ResetColor();
			Console.WriteLine("Average: {0} ms", performanceCountersTrue.Average(c => c.T4.TotalMilliseconds));
			Console.WriteLine("Min: {0} ms", performanceCountersTrue.Min(c => c.T4.TotalMilliseconds));
			Console.WriteLine("Max: {0} ms", performanceCountersTrue.Max(c => c.T4.TotalMilliseconds));
			Console.WriteLine();
			Console.WriteLine();

			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine("Performance test for 'variableFalse == false' vs 'false == variableFalse'");

			Console.WriteLine();
			for (int i = 0; i < 10; i++)
			{
				CalculateFalsePerformance(performanceCountersFalse, numberOfIterations);
			}

			//T1 == 'varFalse == true'
			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine("Performance for 'variableFalse == true'");
			Console.ResetColor();
			Console.WriteLine("Average: {0} ms", performanceCountersFalse.Average(c => c.T1.TotalMilliseconds));
			Console.WriteLine("Min: {0} ms", performanceCountersFalse.Min(c => c.T1.TotalMilliseconds));
			Console.WriteLine("Max: {0} ms", performanceCountersFalse.Max(c => c.T1.TotalMilliseconds));
			Console.WriteLine();
			//T2 == 'varFalse == false'
			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine("Performance for 'variableFalse == false'");
			Console.ResetColor();
			Console.WriteLine("Average: {0} ms", performanceCountersFalse.Average(c => c.T2.TotalMilliseconds));
			Console.WriteLine("Min: {0} ms", performanceCountersFalse.Min(c => c.T2.TotalMilliseconds));
			Console.WriteLine("Max: {0} ms", performanceCountersFalse.Max(c => c.T2.TotalMilliseconds));
			Console.WriteLine();
			//T3 == 'true == varFalse'
			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine("Performance for 'true == variableFalse'");
			Console.ResetColor();
			Console.WriteLine("Average: {0} ms", performanceCountersFalse.Average(c => c.T3.TotalMilliseconds));
			Console.WriteLine("Min: {0} ms", performanceCountersFalse.Min(c => c.T3.TotalMilliseconds));
			Console.WriteLine("Max: {0} ms", performanceCountersFalse.Max(c => c.T3.TotalMilliseconds));
			Console.WriteLine();
			//T4 == 'false == varFalse'
			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine("Performance for 'false == variableFalse'");
			Console.ResetColor();
			Console.WriteLine("Average: {0} ms", performanceCountersFalse.Average(c => c.T4.TotalMilliseconds));
			Console.WriteLine("Min: {0} ms", performanceCountersFalse.Min(c => c.T4.TotalMilliseconds));
			Console.WriteLine("Max: {0} ms", performanceCountersFalse.Max(c => c.T4.TotalMilliseconds));
			Console.WriteLine();
		}

		private static void CalculateTruePerformance(List<Performance> counters, int numberOfIterations)
		{
			Performance performanceCounter = new Performance();
			counters.Add(performanceCounter);


			bool variableTrue = true;

			Stopwatch swVariableTrueIsIsTrue = new Stopwatch();
			swVariableTrueIsIsTrue.Start();
			for (int i = 0; i < numberOfIterations; i++)
			{
				if (variableTrue == true)
				{
					continue;
				}
			}

			swVariableTrueIsIsTrue.Stop();
			//T1
			performanceCounter.T1 = swVariableTrueIsIsTrue.Elapsed;


			Stopwatch swVariableTrueIsIsFalse = new Stopwatch();
			swVariableTrueIsIsFalse.Start();
			for (int i = 0; i < numberOfIterations; i++)
			{
				if (variableTrue == false)
				{
					continue;
				}
			}

			swVariableTrueIsIsFalse.Stop();
			//T2
			performanceCounter.T2 = swVariableTrueIsIsFalse.Elapsed;

			Stopwatch swTrueIsIsVariableTrue = new Stopwatch();
			swVariableTrueIsIsTrue.Start();
			for (int i = 0; i < numberOfIterations; i++)
			{
				if (true == variableTrue)
				{
					continue;
				}
			}

			swVariableTrueIsIsTrue.Stop();
			//T3
			performanceCounter.T3 = swVariableTrueIsIsTrue.Elapsed;

			Stopwatch swFalseIsIsVariableTrue = new Stopwatch();
			swVariableTrueIsIsFalse.Start();
			for (int i = 0; i < numberOfIterations; i++)
			{
				if (false == variableTrue)
				{
					continue;
				}
			}

			swVariableTrueIsIsFalse.Stop();
			//T4
			performanceCounter.T4 = swVariableTrueIsIsFalse.Elapsed;

		}

		private static void CalculateFalsePerformance(List<Performance> counters, int numberOfIterations)
		{
			Performance performanceCounter = new Performance();
			counters.Add(performanceCounter);

			bool variableFalse = false;

			Stopwatch swVariableFalseIsIsTrue = new Stopwatch();
			swVariableFalseIsIsTrue.Start();
			for (int i = 0; i < numberOfIterations; i++)
			{
				if (variableFalse == true)
				{
					continue;
				}
			}

			swVariableFalseIsIsTrue.Stop();
			//T1
			performanceCounter.T1 = swVariableFalseIsIsTrue.Elapsed;


			Stopwatch swVariableFalseIsIsFalse = new Stopwatch();
			swVariableFalseIsIsFalse.Start();
			for (int i = 0; i < numberOfIterations; i++)
			{
				if (variableFalse == false)
				{
					continue;
				}
			}

			swVariableFalseIsIsFalse.Stop();
			//T2
			performanceCounter.T2 = swVariableFalseIsIsFalse.Elapsed;

			Stopwatch swTrueIsIsVariableFalse = new Stopwatch();
			swVariableFalseIsIsTrue.Start();
			for (int i = 0; i < numberOfIterations; i++)
			{
				if (true == variableFalse)
				{
					continue;
				}
			}

			swVariableFalseIsIsTrue.Stop();
			//T3
			performanceCounter.T3 = swVariableFalseIsIsTrue.Elapsed;

			Stopwatch swFalseIsIsVariableFalse = new Stopwatch();
			swVariableFalseIsIsFalse.Start();
			for (int i = 0; i < numberOfIterations; i++)
			{
				if (false == variableFalse)
				{
					continue;
				}
			}

			swVariableFalseIsIsFalse.Stop();
			//T4
			performanceCounter.T4 = swVariableFalseIsIsFalse.Elapsed;

		}
	}

	internal class Performance
	{
		public TimeSpan T1 { get; set; }
		public TimeSpan T2 { get; set; }
		public TimeSpan T3 { get; set; }
		public TimeSpan T4 { get; set; }
	}
}
