namespace LabsLibrary
{
	public static class Lab1
	{
		public static string Run(string input = "INPUT.TXT")
		{
			string inputData = File.ReadAllText(input);
			int n = Convert.ToInt32(inputData);
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