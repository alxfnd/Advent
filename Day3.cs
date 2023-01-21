using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent22
{
    internal class Day3
    {
        public Day3() {
            List<string> File = System.IO.File.ReadLines("C:\\Users\\alexf\\OneDrive\\Documents\\VisualCode\\AdventofCode\\22\\Day3.txt").ToList();

            // Generate alphabet
            List<char> alpha = new();
            char[] range = Enumerable.Range('a', 26).Select(x => (char)x).ToArray();
            char[] range2 = Enumerable.Range('A', 26).Select(x => (char)x).ToArray();
            alpha.AddRange(range); alpha.AddRange(range2);
            //

            List<int> scores1 = new();
            List<int> scores2 = new();

            int count = 0;
            List<string> groups = new();
            foreach (string line in File)
            {
                string c1 = line.Substring(0, line.Length / 2);
                string c2 = line.Substring(line.Length / 2);
                IEnumerable<char> result1 = c1.Where(x => c2.Contains(x));
                scores1.Add(alpha.IndexOf(result1.First()) + 1);
                if (count == 2)
                {
                    groups.Add(line);
                    count = 0;
                    IEnumerable<char> result2 = groups[0].Where(x => groups[1].Contains(x) && groups[2].Contains(x));
                    scores2.Add(alpha.IndexOf(result2.First()) + 1);
                    groups.Clear();
                }
                else
                {
                    groups.Add(line);
                    count++;
                }
            }
            Console.WriteLine($"Answer to Part 1 is: {scores1.Sum()}");
            Console.WriteLine($"Answer to Part 2 is: {scores2.Sum()}");
        }

    }
}
