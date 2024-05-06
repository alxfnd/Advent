using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent22
{
    internal class Day5
    {
        List<string> File = System.IO.File.ReadLines("C:\\Users\\alexf\\OneDrive\\Documents\\VisualCode\\AdventofCode\\22\\Day5.txt").ToList();
        List<List<char>> columns = new List<List<char>>() {
            new List<char> {'R','Q','G','P','C','F'},
            new List<char> {'P','C','T','W'},
            new List<char> {'C','M','P','H','B'},
            new List<char> {'R','P','M','S','Q','T','L'},
            new List<char> {'N','G','V','Z','J','H','P'},
            new List<char> {'J','P','D'},
            new List<char> {'R','T','J','F','Z','P','G','L'},
            new List<char> {'J','T','P','F','C','H','L','N'},
            new List<char> {'W','C','T','H','Q','Z','V','G'}
        };
        List<List<char>> columns2 = new List<List<char>>() {
            new List<char> {'R','Q','G','P','C','F'},
            new List<char> {'P','C','T','W'},
            new List<char> {'C','M','P','H','B'},
            new List<char> {'R','P','M','S','Q','T','L'},
            new List<char> {'N','G','V','Z','J','H','P'},
            new List<char> {'J','P','D'},
            new List<char> {'R','T','J','F','Z','P','G','L'},
            new List<char> {'J','T','P','F','C','H','L','N'},
            new List<char> {'W','C','T','H','Q','Z','V','G'}
        };
        void MoveCrate(int i, int from, int to)
        {
            for (int c = 0; c < i; c++)
            {
                columns[to - 1].Insert(0, columns[from - 1].First());
                columns[from - 1].RemoveAt(0);
            }
        }
        void MoveCrate9000(int i, int from, int to)
        {
            for (int c = 1; c <= i; c++)
            {
                columns2[to - 1].Insert(0, columns2[from - 1][i - c]);
                columns2[from - 1].RemoveAt(i - c);
            }
        }
        public Day5() 
        {
            File.ForEach(x => MoveCrate(int.Parse(x.Split(' ')[1]), int.Parse(x.Split(' ')[3]), int.Parse(x.Split(' ')[5])));
            Console.Write("Answer to Part 1 is: ");
            columns.ForEach(x => Console.Write(x.First()));

            File.ForEach(x => MoveCrate9000(int.Parse(x.Split(' ')[1]), int.Parse(x.Split(' ')[3]), int.Parse(x.Split(' ')[5])));
            Console.Write("\nAnswer to Part 2 is: ");
            columns2.ForEach(x => Console.Write(x.First()));

        }
    }
}
