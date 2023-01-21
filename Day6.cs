using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent22
{
    internal class Day6
    {
        //string buffer = "nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg";
        string File = System.IO.File.ReadAllText("C:\\Users\\alexf\\OneDrive\\Documents\\VisualCode\\AdventofCode\\22\\Day6.txt");
        int Part1 = 0;
        int Part2 = 0;
        public Day6() 
        {
            for (int i = 0; i != File.Length - 3; i++)
            {
                if (Part1 == 0)
                {
                    if (File.Substring(i, 4).Distinct().Count() == 4)
                    {
                        Part1 = i + 4;
                    }
                }
                if (Part2 == 0)
                {
                    if (File.Substring(i, 14).Distinct().Count() == 14)
                    {
                        Part2 = i + 14;
                    }
                }
            }
            Console.Write($"Answer to Part 1 is: {Part1}\nAnswer to Part 2 is: {Part2}");
        }
    }
}
