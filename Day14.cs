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
            for (int i = 0; i < 200; i++)
            {
                grid[i][bottomFloor + 2] = 1;
            }
        }
        public void BuildGrid()
        {
            grid = new int[300][];
            for (int i = 0; i < 300; i++)
            {
                grid[i] = new int[250];
                for(int c = 0; c < 250; c++)
                {
                    grid[i][c] = 0;
                }
            }
        }
        public void SetSpaces(int x, int y, int destx, int desty)
        {
            x -= 400; destx-= 400;
            grid[x][y] = 1;
            while (destx > x) { x++; grid[x][y] = 1; }
            while (destx < x) { x--; grid[x][y] = 1; }
            while (desty > y) { y++; grid[x][y] = 1; CheckFloor(y); }
            while (desty < y) { y--; grid[x][y] = 1; }
        }
        public bool DropSand()
        {
            int x = 100;
            int y = 0;
            if (grid[x][y] == 2) return false;
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
                if (y + 1 == 250) break;
            }
            if (y + 1 == 250) return false;
            grid[x][y] = 2;
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
            for (int i = 0; i < 200; i++)
            {
                for (int c = 0; c < 200; c++)
                {
                    string m = ".";
                    if (grid[i][c] != 0) m = grid[i][c].ToString();
                    if (c == 199) Console.WriteLine(m); else Console.Write(m);
                }
            }
            Console.WriteLine(bottomFloor + 2);
        }
        public Grid() { }
    }
    internal class Day14
    {
        readonly List<string> File = System.IO.File.ReadLines("C:\\Users\\alexf\\OneDrive\\Documents\\AdventofCode\\AdventofCode\\22\\Day14.txt").ToList();
        
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
            //grid.BuildBottomFloor();
            bool allSand = true;
            int totalSand = 0;
            while (allSand)
            {
                allSand = grid.DropSand();
                totalSand++;
            }
            grid.DisplayGrid();
            Console.WriteLine(totalSand - 1); //exclude the last dropped sand
            //Part1 = 825
            //Part2 : 1747 is too low
            // 1750 is too low
        }
    }
}
