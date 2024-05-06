using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Advent22
{
    class entry : IComparable<entry>
    {
        public readonly string content;
        public string GetContent() { return content; }
        
        public int CompareTo(entry obj)
        {
            string otherContent = obj.GetContent();
            otherContent = otherContent.Substring(1, otherContent.Length - 2);

            // PUT IN THE SORTING FUNCTION HERE!!
            
            // If empty arrays, the bigger array counts as a higher value
            if (!Regex.Match(otherContent, @"\d").Success && !Regex.Match(this.content, @"\d").Success) {
                if (this.content.Length > otherContent.Length)
                {
                    return 1;
                }
                else
                {
                    return -1;
                }
            }

            // If the above failed, and one of the string does not contain a number, return value
            if (!Regex.Match(otherContent, @"\d").Success)
            {
                return 1;
            }
            if (!Regex.Match(this.content, @"\d").Success)
            {
                return -1;
            }

            List<string> thisList = this.content.Replace("[", "").Replace("]", "").Split(",").ToList();
            List<string> otherList = otherContent.Replace("[", "").Replace("]", "").Split(",").ToList();
            int max;

            if (thisList.Count > otherList.Count) max = thisList.Count; else max = otherList.Count;

            for (int i = 0; i < max; i++)
            {
                if (i == thisList.Count) return -1;
                if (i == otherList.Count) return 1;
                if (thisList[i].Length == 0 && otherList[i].Length != 0) return -1;
                if (thisList[i].Length != 0 && otherList[i].Length == 0) return 1;
                if (thisList[i].Length == 0 && otherList[i].Length == 0) continue;
                if (int.Parse(thisList[i]) == int.Parse(otherList[i])) continue;

                if (int.Parse(thisList[i]) > int.Parse(otherList[i]))
                {
                    return 1;
                }
                else
                {
                    return -1;
                }
            }

            //
            return -1;
        }
        public entry(string content)
        {
            this.content = content;
        }
    }
    internal class Day13
    {
        readonly List<string> File = System.IO.File.ReadLines("C:\\Users\\alexf\\OneDrive\\Documents\\AdventofCode\\AdventofCode\\22\\Day13.txt").ToList();
        readonly List<entry> entries= new ();
        public Day13() 
        { 
            for (int i = 0; i < File.Count; i++)
            {
                if ((i+1) % 3 != 0)
                {
                    entries.Add(new entry(File[i]));
                }
            }
            entries.Add(new entry("[[2]]"));
            entries.Add(new entry("[[6]]"));
            entries.Sort();
            //entries.ForEach(x => Console.WriteLine(x.GetContent()));
            int two = entries.IndexOf(entries.Find(x => x.content == "[[2]]")) + 1;
            int six = entries.IndexOf(entries.Find(x => x.content == "[[6]]")) + 1;
            Console.WriteLine(two * six);
        }
    }
}

// 19278 // didn't index correctly, dick puzzle
//19570?? Yes!!