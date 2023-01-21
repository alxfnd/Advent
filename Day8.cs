using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent22
{
    internal class Day8
    {
        List<string> File = System.IO.File.ReadLines("C:\\Users\\alexf\\OneDrive\\Documents\\VisualCode\\AdventofCode\\22\\Day8.txt").ToList();
        /* PART 1 METHOD
        bool SearchDirection(int dir, int val, int index, int line)
        {
            if (dir == 1)
            {
                //UP
                while (line > 0)
                {
                    line--;
                    if (int.Parse(File[line][index].ToString()) >= val)
                    {
                        return false;
                    }
                }
                return true;
            }
            if (dir == 2)
            {
                //DOWN
                while (line < (File.Count) - 1)
                {
                    line++;
                    if (int.Parse(File[line][index].ToString()) >= val)
                    {
                        return false;
                    }
                }
                return true;
            }
            if (dir == 3)
            {
                //LEFT
                while (index > 0)
                {
                    index--;
                    if (int.Parse(File[line][index].ToString()) >= val)
                    {
                        return false;
                    }
                }
                return true;
            }
            if (dir == 4)
            {
                //RIGHT
                while (index < (File[line].Length) - 1)
                {
                    index++;
                    if (int.Parse(File[line][index].ToString()) >= val)
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        }
        */
        // PART 2 METHOD
        int SearchDirection(int dir, int val, int index, int line)
        {
            int count = 0;
            if (dir == 1)
            {
                //UP
                while (line > 0)
                {
                    line--;
                    if (int.Parse(File[line][index].ToString()) >= val)
                    {
                        count++;
                        return count;
                    }
                    count++;
                }
                return count;
            }
            if (dir == 2)
            {
                //DOWN
                while (line < (File.Count) - 1)
                {
                    line++;
                    if (int.Parse(File[line][index].ToString()) >= val)
                    {
                        count++;
                        return count;
                    }
                    count++;
                }
                return count;
            }
            if (dir == 3)
            {
                //LEFT
                while (index > 0)
                {
                    index--;
                    if (int.Parse(File[line][index].ToString()) >= val)
                    {
                        count++;
                        return count;
                    }
                    count++;
                }
                return count;
            }
            if (dir == 4)
            {
                //RIGHT
                while (index < (File[line].Length) - 1)
                {
                    index++;
                    if (int.Parse(File[line][index].ToString()) >= val)
                    {
                        count++;
                        return count;
                    }
                    count++;
                }
                return count;
            }
            return count;
        }

        // bool GoodSpot etc. - PART 1
        int GoodSpot(int line, int index, string c)
        {
            int val = int.Parse(c);
            int dir = 1;
            List<int> distances = new();
            while (dir != 5)
            {
                distances.Add(SearchDirection(dir, val, index, line));
                dir++;
            }
            int score = 1;
            distances.ForEach(s => score *= s);
            return score;
        }

        //int Part1 = 0;
        public Day8()
        {
            int bottomRow = File.Count;
            int endColumn = File[0].Length;
            List<int> allscores = new();
            for (int l = 0; l < bottomRow; l++)
            {
                for (int i = 0; i < endColumn; i++)
                {
                    allscores.Add(GoodSpot(l, i, File[l][i].ToString()));
                }
            }
            allscores.Sort();
            Console.WriteLine($"Part 2 = { allscores.Last()}");
            //Console.WriteLine(Part1);
        }
    }
}
