using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Advent22
{
    namespace Day7
    {
        internal class Dir
        {
            public int id;
            public string name;
            public int size;
            private int parent;
            public List<Dir> dirs = new();
            private List<int> files = new();
            public Dir(int id, string name)
            {
                this.id = id;
                this.name = name;
            }
            public void SetParent(int parent)
            {
                this.parent = parent;
            }
            public int getParent()
            {
                return this.parent;
            }
            public void AddDir(Dir dir)
            {
                dirs.Add(dir);
            }
            public void AddFile(int val)
            {
                files.Add(val);
            }
            public void CalculateSize()
            {
                foreach (Dir d in dirs)
                {
                    d.CalculateSize();
                }
                foreach (Dir d in dirs)
                {
                    size += d.size;
                }
                foreach (int f in files)
                {
                    size += f;
                }
            }
        }
        internal class Day7
        {
            private List<string> File = System.IO.File.ReadLines("C:\\Users\\alexf\\OneDrive\\Documents\\VisualCode\\AdventofCode\\22\\Day7.txt").ToList();
            private List<Dir> alldirs = new() { new Dir(0, "/") };
            private Dir currentDir;
            private int idCount = 0;
            private Dir FindDir(int id)
            {
                return alldirs.Find(x => x.id == id);
                for (int i = 0; i < alldirs.Count; i++)
                {
                    if (alldirs[i].id == id && alldirs[i].getParent() == currentDir.id)
                    {
                        return alldirs[i];
                    }
                }
                return new(-1, "");
            }

            void terminal(string input)
            {
                if (input.StartsWith('$'))
                {
                    if (input.Contains("cd"))
                    {
                        if (currentDir.dirs.Exists(x => x.name == input[5..]))
                        {
                            currentDir = FindDir(currentDir.dirs.Find(x => x.name == input[5..]).id);
                        }
                        else
                        {
                            currentDir = FindDir(currentDir.getParent());
                        }
                        return;
                    }
                    else
                    {
                        return;
                    }
                }
                if (input.StartsWith("dir"))
                {
                    Dir newDir = new(idCount, input.Split(' ')[1]);
                    newDir.SetParent(currentDir.id);
                    currentDir.AddDir(newDir);
                    alldirs.Add(newDir);
                    return;
                }
                currentDir.AddFile(int.Parse(input.Split(' ')[0]));
                return;
            }

            public Day7()
            {
                currentDir = alldirs[0];
                foreach (var line in File)
                {
                    idCount++;
                    terminal(line);
                }
                alldirs[0].CalculateSize();

                List<Dir> output = alldirs.Where(x => x.size < 100000).ToList();
                Console.WriteLine($"The answer to Part 1 is: {output.Sum(x => x.size)}");
                int total = alldirs[0].size;
                List<Dir> part2 = alldirs.Where(x => (total - x.size) < 40000000).ToList();
                Console.WriteLine($"The answer to Part 2 is: {part2.OrderBy(x => x.size).First().size}");
            }
        }
    }
}
