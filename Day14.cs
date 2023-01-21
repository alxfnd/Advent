using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent22
{
    class Grid
    {
        int[][]? grid;
        int bottomFloor = 0;
        public void CheckFloor(int val)
        {
            if (val > bottomFloor) { bottomFloor = val; }
        }
        public void BuildBottomFloor()
        {
            for (int i = 0; i < 1000; i++)
            {
                grid[i][bottomFloor + 2] = 1;
            }
        }
        public void BuildGrid()
        {
            grid = new int[1000][];
            for (int i = 0; i < 1000; i++)
            {
                grid[i] = new int[180];
                for(int c = 0; c < 180; c++)
                {
                    grid[i][c] = 0;
                }
            }
        }
        public void SetSpaces(int x, int y, int destx, int desty)
        {
            grid[x][y] = 1;
            while (destx > x) { x++; grid[x][y] = 1; }
            while (destx < x) { x--; grid[x][y] = 1; }
            while (desty > y) { y++; grid[x][y] = 1; CheckFloor(y); }
            while (desty < y) { y--; grid[x][y] = 1; }
        }
        public bool DropSand()
        {
            int x = 500;
            int y = 0;
            int dir = 2;
            while (dir != 0)
            {
                dir = WhichDirection(x, y);
                switch(dir)
                {
                    case 2: y++; break;
                    case 1: y++; x--; break;
                    case 3: x++; y++; break;
                    case 0: break;
                }
                // Part1 Commented out
                //if (y + 1 == 180) break;
            }
            //if (y + 1 == 180) return false;
            grid[x][y] = 2;
            if (grid[500][0] == 2) return false;
            return true;
        }
        int WhichDirection(int x, int y)
        {
            if (grid[x][y + 1] == 0) return 2;
            if (grid[x - 1][y + 1] == 0) return 1;
            if (grid[x + 1][y + 1] == 0) return 3;
            return 0;
        }
        public void DisplayGrid()
        {
            for (int i = 400; i < 580; i++)
            {
                for (int c = 0; c < 170; c++)
                {
                    string m = ".";
                    if (grid[i][c] != 0) m = grid[i][c].ToString();
                    if (c == 169) Console.WriteLine(m); else Console.Write(m);
                }
            }
        }
        public void GetValue(int x, int y) { Console.WriteLine(grid[x][y]); }
        public Grid() { }
    }
    internal class Day14
    {
        readonly List<string> File = System.IO.File.ReadLines("C:\\tmp\\Advent\\Day14.txt").ToList();
        
        public Day14()
        {
            Grid grid = new();
            grid.BuildGrid();
            foreach (string line in File)
            {
                List<string> instructions = line.Split(" -> ").ToList();
                for (int i = 0; i < instructions.Count - 1; i++)
                {
                    int x = int.Parse(instructions[i].Split(",")[0]);
                    int y = int.Parse(instructions[i].Split(",")[1]);
                    int destx = int.Parse(instructions[i + 1].Split(",")[0]);
                    int desty = int.Parse(instructions[i + 1].Split(",")[1]);
                    grid.SetSpaces(x, y, destx, desty);
                }
            }
            grid.BuildBottomFloor();
            bool allSand = true;
            int totalSand = 0;
            while (allSand)
            {
                allSand = grid.DropSand();
                totalSand++;
            }
            grid.DisplayGrid();
            grid.GetValue(100, 0);
            Console.WriteLine(totalSand); //Part 1 = -1 sand to exclude the last dropped sand
            //Part1 = 825
            //Part2 : 1747 is too low (turns out the checks from Part1 were interfering)
            // 26729
        }
    }
}
