using System;

namespace LabsLibrary
{
	public class Lab2Runner
	{
		public Lab2Runner(string firstLine, string secondLine, string thirdLine) //only 3 lines
		{
			_firstLine = firstLine;
			_secondLine = secondLine;
			_thirdLine = thirdLine;
		}

		public readonly string _firstLine;
		public readonly string _secondLine;
		public readonly string _thirdLine;

		public string RunLab()
		{
			int m = 3;
			int n = 3;
			int[,] arr = new int[m, n];
			string[] tarr = new string[n - 1];


			tarr = _firstLine.Split(' ');
			for (int j = 0; j < n; j++)
			{
				arr[0, j] = Convert.ToInt32(tarr[j]);
			}


			tarr = _secondLine.Split(' ');
			for (int j = 0; j < n; j++)
			{
				arr[1, j] = Convert.ToInt32(tarr[j]);
			}


			tarr = _thirdLine.Split(' ');
			for (int j = 0; j < n; j++)
			{
				arr[2, j] = Convert.ToInt32(tarr[j]);
			}

			return findMaxSubMatrix(arr).ToString();
		}

		public static int[] kadane(int[] a)
		{
			int[] result = new int[] { int.MinValue, 0, -1 };
			int currentSum = 0;
			int localStart = 0;

			for (int i = 0; i < a.Length; i++)
			{
				currentSum += a[i];
				if (currentSum < 0)
				{
					currentSum = 0;
					localStart = i + 1;
				}
				else if (currentSum > result[0])
				{
					result[0] = currentSum;
					result[1] = localStart;
					result[2] = i;
				}
			}

			if (result[2] == -1)
			{
				result[0] = 0;
				for (int i = 0; i < a.Length; i++)
				{
					if (a[i] > result[0])
					{
						result[0] = a[i];
						result[1] = i;
						result[2] = i;
					}
				}
			}
			return result;
		}

		public static int findMaxSubMatrix(int[,] a)
		{
			int cols = a.GetLength(1);
			int rows = a.GetLength(0);
			int[] currentResult;
			int maxSum = int.MinValue;
			for (int leftCol = 0; leftCol < cols; leftCol++)
			{
				int[] dp = new int[rows];

				for (int rightCol = leftCol; rightCol < cols;
					 rightCol++)
				{

					for (int i = 0; i < rows; i++)
					{
						dp[i] += a[i, rightCol];
					}
					currentResult = kadane(dp);
					if (currentResult[0] > maxSum)
					{
						maxSum = currentResult[0];

					}
				}
			}

			return maxSum;
		}
	}
}
