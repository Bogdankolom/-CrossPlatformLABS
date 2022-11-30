namespace LabsLibrary
{
	public static class Lab3
	{
		readonly static int INF = 99999;

		public static string Run(string input = "INPUT.TXT")
		{
			StreamReader fs = new StreamReader(input);
			string input1 = fs.ReadLine();
			int n = Convert.ToInt32(input1);
			int[,] graph = new int[n, n];
			string[] tarr = new string[n - 1];
			for (int i = 0; i < n; i++)
			{
				string input2 = fs.ReadLine();
				tarr = input2.Split(' ');
				for (int j = 0; j < n; j++)
				{
					graph[i, j] = Convert.ToInt32(tarr[j]);
					if (graph[i, j] == -1)
					{
						graph[i, j] = INF;
					}
				}
			}

			var result = floydWarshall(graph, n);
			return result;
		}

		private static string floydWarshall(int[,] graph, int V)
		{
			int[,] dist = new int[V, V];
			int i, j, k;
			for (i = 0; i < V; i++)
			{
				for (j = 0; j < V; j++)
				{
					dist[i, j] = graph[i, j];
				}
			}

			for (k = 0; k < V; k++)
			{
				for (i = 0; i < V; i++)
				{
					for (j = 0; j < V; j++)
					{
						if (dist[i, k] + dist[k, j]
								< dist[i, j])
						{
							dist[i, j]
								= dist[i, k] + dist[k, j];
						}
					}
				}
			}

			// Print the shortest distance matrix
			printSolution(dist, V);
			var result = maxSolution(dist, V);
			return result;
		}
		private static string maxSolution(int[,] dist, int n)
		{
			int max = 0;
			for (int i = 0; i < n; i++)
			{
				for (int j = 0; j < n; j++)
				{
					if (dist[i, j] > max)
					{
						max = dist[i, j];
					}
				}
			}

			return max.ToString();
		}
		private static void printSolution(int[,] dist, int n)
		{
			Console.WriteLine(
				"Following matrix shows the shortest "
				+ "distances between every pair of vertices");
			for (int i = 0; i < n; ++i)
			{
				for (int j = 0; j < n; ++j)
				{
					if (dist[i, j] == INF)
					{
						Console.Write("INF ");
					}
					else
					{
						Console.Write(dist[i, j] + " ");
					}
				}
				Console.WriteLine();
			}
		}
	}
}


