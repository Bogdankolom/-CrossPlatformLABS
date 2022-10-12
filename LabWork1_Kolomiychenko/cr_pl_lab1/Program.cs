using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cr_pl_lab1
{
    class Program
    {
        
        static long SolveTask(int n1)
        {
            if (n1 == 0)
            {
                return 1;
            }
            else
            {
                return n1 * SolveTask(n1 - 1) + Convert.ToInt32(Math.Pow(-1,n1));
            }
        }
        static void Main(string[] args)
        {
            string input = System.IO.File.ReadAllText("input.txt");
            int n = Convert.ToInt32(input);
            File.WriteAllText("output.txt", SolveTask(n).ToString() + Environment.NewLine);
        }
    }
}