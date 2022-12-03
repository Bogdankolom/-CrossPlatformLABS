using System;

namespace LabsLibrary
{
	public class Lab1Runner
	{
		public Lab1Runner(string inputNumber)
		{
			_inputNumber = inputNumber;
		}
		private readonly string _inputNumber; 

		public  string RunLab()
		{
			int n = Convert.ToInt32(_inputNumber);
			return SolveTask(n).ToString();
		}
		private static long SolveTask(int n1)
		{
			if (n1 == 0)
			{
				return 1;
			}
			else
			{
				return n1 * SolveTask(n1 - 1) + Convert.ToInt32(Math.Pow(-1, n1));
			}
		}
	}
}