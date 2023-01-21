using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent22
{
    public class Day2
    {
        public Day2()
        {
            List<string> File = System.IO.File.ReadLines("C:\\Users\\alexf\\OneDrive\\Documents\\VisualCode\\AdventofCode\\22\\Day2.txt").ToList();
            Player P = Player.X;
            Console.WriteLine(P);

            int p1_score = 0;
            int p2_score = 0;
            foreach (string line in File)
            {
                string Opponent = line.Split(' ')[0];
                string Player = line.Split(" ")[1];
                Opponent o = Day2.Opponent.A;
                Player p1 = Convert(Player);
                Player p2 = Convert(Player, Opponent);
                switch (Opponent)
                {
                    case "A": o = Day2.Opponent.A; break;
                    case "B": o = Day2.Opponent.B; break;
                    case "C": o = Day2.Opponent.C; break;
                }
                p1_score += Calculate(p1, o);
                p2_score += Calculate(p2, o);
            }
            Console.WriteLine($"Part 1 answer is {p1_score}");
            Console.WriteLine($"Part 2 answer is {p2_score}");
        }

        public Player Convert(string player)
        {
            switch (player)
            {
                case "X": return Player.X;
                case "Y": return Player.Y;
                case "Z": return Player.Z;
                default: throw new Exception();
            }
        }
        public Player Convert(string player, string opponent)
        {
            Day2.Rock rock = new();
            Day2.Paper paper = new();
            Day2.Scissors scissors = new();
            if (player == "X")
            {
                switch (opponent)
                {
                    case "A": return rock.Lose;
                    case "B": return paper.Lose;
                    case "C": return scissors.Lose;
                }
            }
            if (player == "Y")
            {
                switch (opponent)
                {
                    case "A": return rock.Draw;
                    case "B": return paper.Draw;
                    case "C": return scissors.Draw;
                }
            }
            if (player == "Z")
            {
                switch (opponent)
                {
                    case "A": return rock.Win;
                    case "B": return paper.Win;
                    case "C": return scissors.Win;
                }
            }
            throw new Exception();
        }
        public int Calculate(Player p, Opponent o)
        {
            int score = 0;
            if (o == Opponent.A)
            {
                switch (p)
                {
                    case Player.X: score += 4; break;
                    case Player.Y: score += 8; break;
                    case Player.Z: score += 3; break;
                }
            }
            if (o == Opponent.B)
            {
                switch (p)
                {
                    case Player.X: score += 1; break;
                    case Player.Y: score += 5; break;
                    case Player.Z: score += 9; break;
                }
            }
            if (o == Opponent.C)
            {
                switch (p)
                {
                    case Player.X: score += 7; break;
                    case Player.Y: score += 2; break;
                    case Player.Z: score += 6; break;
                }
            }
            return score;
        }
        public enum Opponent { A, B, C };
        public enum Player { X, Y, Z };
        public int score = 0;
        public struct Rock {
            public Player Win = Player.Y;
            public Player Draw = Player.X;
            public Player Lose = Player.Z;
            public Rock() {}
        };
        public struct Paper
        {
            public Player Win = Player.Z;
            public Player Draw = Player.Y;
            public Player Lose = Player.X;
            public Paper() {}
        };
        public struct Scissors
        {
            public Player Win = Player.X;
            public Player Draw = Player.Z;
            public Player Lose = Player.Y;
            public Scissors() {}
        };
    }
}





