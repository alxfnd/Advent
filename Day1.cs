using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent22
{
    internal class Day1
    {
        public Day1()
        {
            List<string> File = System.IO.File.ReadLines("C:\\Users\\alexf\\OneDrive\\Documents\\VisualCode\\AdventofCode\\22\\Day1.txt").ToList();

            List<int> Solution = new();
            int run_total = 0;
            foreach (var file in File)
            {
                if (file.Length == 0)
                {
                    Solution.Add(run_total);
                    run_total = 0;
                }
                else
                {
                    run_total += Int32.Parse(file);
                }
            }
            Solution.Add(run_total);
            Solution.Sort();
            Solution.RemoveRange(0, (Solution.Count - 3));
            Console.WriteLine(Solution.Last());
            Console.WriteLine(Solution.Sum());
        }
    }
}
