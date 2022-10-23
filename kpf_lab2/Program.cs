using System;
using System.IO;

namespace kpf_lab2
{
    class Program
    {

        /**
         * знаходимо maxSum в одномірному масиві - алгоритм Кадане
         *повертаємо {maxSum, left, right}
         */
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

        /**
        * знаходимо і друкуємо maxSum
        */
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
            Console.Write("MaxSum: " + maxSum);
            Console.ReadLine();
            return maxSum;
        }

        public static void Main()
        {
            StreamReader fs = new StreamReader("input.txt");
            string input1 = fs.ReadLine();
            string[] razm = new string[2];
            razm = input1.Split(' ');
            int m = Convert.ToInt32(razm[0]);
            int n = Convert.ToInt32(razm[1]);
            int[,] arr = new int[m, n];
            string[] tarr = new string[n - 1];
            for (int i = 0; i < m; i++)
            {
                string input2 = fs.ReadLine();
                tarr = input2.Split(' ');
                for (int j = 0; j < n; j++)
                {
                    arr[i, j] = Convert.ToInt32(tarr[j]);
                }
            }
            // виклик функції
            File.WriteAllText("output.txt", findMaxSubMatrix(arr).ToString() + Environment.NewLine);
        }
    }
}
