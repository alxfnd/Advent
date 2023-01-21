using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Advent22
{
    internal class Day4
    {
        List<string> File = System.IO.File.ReadLines("C:\\Users\\alexf\\OneDrive\\Documents\\VisualCode\\AdventofCode\\22\\Day4.txt").ToList();
        int part1 = 0;
        int part2 = 0;

        public Day4() 
        {
            string a, b;
            
            foreach (string line in File)
            {
                a = line.Split(',')[0];
                int a1 = int.Parse(a.Split('-')[0]); int a2 = int.Parse(a.Split('-')[1]);
                b = line.Split(",")[1];
                int b1 = int.Parse(b.Split('-')[0]); int b2 = int.Parse(b.Split("-")[1]);
                if (!(a2 < b1 || a1 > b2))
                {
                    part2++;
                }
                if (a1 <= b1 && a2 >= b2) {
                    part1++;
                    continue;
                }
                if (a1 >= b1 && a2 <= b2)
                {
                    part1++;
                    continue;
                }
            }
            Console.WriteLine($"The answer to Part 1 is: {part1}");
            Console.WriteLine($"The answer to Part 2 is: {part2}");
        }
    }
}
