using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Advent22
{
    class Node
    {
        public readonly int id;
        public readonly string name;
        public int cost;
        public int previous;
        readonly List<int> neighbours = new();
        public void AddNeighbour(int id)
        {
            neighbours.Add(id);
        }
        public List<int> GetNeighbours() { return neighbours; }
        public void SetCost(int cost) { this.cost = cost + 1; }
        public int GetCost() { return cost; }
        public Node(int id, string name)
        {
            this.id = id;
            this.name = name;
            this.cost = int.MaxValue;
            this.previous = -1;
        }
    }

    internal class Day12
    {
        readonly List<string> File = System.IO.File.ReadLines("C:\\Users\\alexf\\OneDrive\\Documents\\AdventofCode\\AdventofCode\\22\\Day12.txt").ToList();
        readonly string alpha = "SabcdefghijklmnopqrstuvwxyzE";
        readonly string alpha2 = "EzyxwvutsrqponmlkjihgfedcbaS";
        readonly List<Node> allnodes = new();

        bool IsNeighbour(string current, string to, bool Part1)
        {
            int cur;
            int val;
            if (Part1)
            {
                cur = alpha.IndexOf(current);
                val = alpha.IndexOf(to);
            }
            else
            {
                cur = alpha2.IndexOf(current);
                val = alpha2.IndexOf(to);
            }
            if (val > (cur + 1))
            {
                return false;
            }
            return true;
            /*
                if (cur > 24) { return true; }
                if (current != "S" || current != "E")
                {
                    if (val > (cur + 1))
                    {
                        return false;
                    }
                    return true;
                }
                else
                {
                    if (val > (cur + 2))
                    {
                        return false;
                    }
                    return true;
                }
            */
        }

        List<int> GetNeighbours(int[][] idArray, List<string> File, int c, int l, bool Part1)
        {
            List<int> neighbours = new();
            string current;
            switch (File[c][l].ToString())
            {
                case "S": current = "a"; break;
                case "E": current = "z"; break;
                default: current = File[c][l].ToString(); break;
            }
            if (c != 0)
            {
                //UP
                if (IsNeighbour(current, File[c - 1][l].ToString(), Part1))
                {
                    neighbours.Add(idArray[c - 1][l]);
                }
            }
            if (c != (File.Count - 1))
            {
                //DOWN
                if (IsNeighbour(current, File[c + 1][l].ToString(), Part1))
                {
                    neighbours.Add(idArray[c + 1][l]);
                }
            }
            if (l != 0)
            {
                //LEFT
                if (IsNeighbour(current, File[c][l - 1].ToString(), Part1))
                {
                    neighbours.Add(idArray[c][l - 1]);
                }
            }
            if (l != (File[0].Length - 1))
            {
                //RIGHT
                if (IsNeighbour(current, File[c][l + 1].ToString(), Part1))
                {
                    neighbours.Add(idArray[c][l + 1]);
                }
            }
            return neighbours;
        }
        Node GetNode(int id)
        {
            Node? returnNode = allnodes.Find(x => x.id == id);
            if (returnNode != null) return returnNode;
            else
            { return allnodes.First(); }
        }
        Node GetNode(string name)
        {
            Node? returnNode = allnodes.Find(x => x.name == name);
            if (returnNode != null) return returnNode;
            else
            { return allnodes.First(); }
        }
        Node GetLowestNode(List<Node> nodeList)
        {
            int cost = int.MaxValue;
            for (int i = 0; i < nodeList.Count; i++)
            {
                if (nodeList[i].cost < cost)
                {
                    cost = nodeList[i].cost;
                }
            }
            if (cost != int.MaxValue)
            {
                Node? returnNode = nodeList.Find(x => x.cost == cost);
                if (returnNode != null) return returnNode;
                else
                { return allnodes.First(); }
            }
            else
            {
                // There are 2 height islands on the map, one at the top-leftish and bottom-leftish where this
                // statement occurs. It does not impact the final outcome
                return nodeList.First();
            }
        }

        int CalculateSteps(bool Part1)
        {
            if (Part1)
            {
                return GetNode("S").cost;
            }
            else
            {
                List<Node> nodeList = allnodes.Where(x => x.name == "a" && x.cost > 0).ToList();
                int returnStep = int.MaxValue;
                foreach (Node node in nodeList)
                {
                    if ((node.cost) < returnStep) returnStep = node.cost;
                }
                return returnStep;
            }
        }

        public Day12()
        {
            bool Part1 = false;

            int[][] idArray = new int[File.Count][];
            for (int i = 0; i < idArray.Length; i++)
            {
                idArray[i] = new int[File[0].Length];
            }
            int idCount = 1;
            for (int c = 0; c < File.Count; c++)
            {
                for (int l = 0; l < File[0].Length; l++)
                {
                    idArray[c][l] = idCount++;
                }
            }
            // Finished building a mirror array of id's to make unique nodes in each space

            for (int c = 0; c < File.Count; c++)
            {
                for (int l = 0; l < File[0].Length; l++)
                {
                    allnodes.Add(new Node(idArray[c][l], File[c][l].ToString()));
                    GetNeighbours(idArray, File, c, l, Part1).ForEach(n => allnodes.Last().AddNeighbour(n));
                }
            }
            //Nodes generated in a List format with their neighbour id's configured

            List<int> visitedNodes = new();
            List<int> unvisitedNodes = new();
            allnodes.ForEach(x => unvisitedNodes.Add(x.id));


            Node? currentNode;
            List<int>? currentNeighbours;
            if (Part1)
            {
                // Apply settings for starting node
                currentNode = GetNode("S");
                visitedNodes.Add(currentNode.id);
                unvisitedNodes.Remove(currentNode.id);
                currentNode.cost = 0;
                currentNeighbours = currentNode.GetNeighbours();
                for (int i = 0; i < currentNeighbours.Count; i++)
                {
                    GetNode(currentNeighbours[i]).SetCost(0);
                    GetNode(currentNeighbours[i]).previous = currentNode.id;
                }
            }
            else
            {
                currentNode = GetNode("E");
                visitedNodes.Add(currentNode.id);
                unvisitedNodes.Remove(currentNode.id);
                currentNode.cost = 0;
                currentNeighbours = currentNode.GetNeighbours();
                for (int i = 0; i < currentNeighbours.Count; i++)
                {
                    GetNode(currentNeighbours[i]).SetCost(0);
                    GetNode(currentNeighbours[i]).previous = currentNode.id;
                }
            }

            //The algorithm!
            while (visitedNodes.Count < allnodes.Count)
            {
                //CurrentNode = lowest cost
                currentNode = GetLowestNode(allnodes.Where(x => unvisitedNodes.Contains(x.id)).ToList());

                //Add to visited
                visitedNodes.Add(currentNode.id);

                //Remove from unvisited
                unvisitedNodes.Remove(currentNode.id);

                //Evaluate neighbour nodes
                currentNeighbours.Clear();
                currentNeighbours = currentNode.GetNeighbours();
                for (int i = 0; i < currentNeighbours.Count; i++)
                {
                    if (unvisitedNodes.Contains(currentNeighbours[i]))
                    {
                        Node neighbourNode = GetNode(currentNeighbours[i]);
                        if (neighbourNode.cost > (currentNode.cost + 1))
                        {
                            GetNode(currentNeighbours[i]).SetCost(currentNode.cost);
                            neighbourNode.previous = currentNode.id;
                        }
                    }
                }
            }
            Console.WriteLine($"Answer to Part 1 is: {CalculateSteps(false)}");
            Console.WriteLine($"Answer to Part 2 is: {CalculateSteps(Part1)}");

            /*
            if (!Part1)
            {
                //Draw map
                string x = "";
                for (int i = 0; i < allnodes.Count; i++)
                {
                    if (allnodes[i].name == "a" && allnodes[i].cost > 0 && allnodes[i].cost < 355)
                    {
                        x = allnodes[i].cost.ToString();
                    }
                    else
                    {
                        x = allnodes[i].name;
                    }
                    if ((i + 1) % File[0].Length == 0)
                    {
                        Console.WriteLine(x);
                    }
                    else
                    {
                        Console.Write(x);
                    }
                }
            }
            */
        }

    }
}


/*
 * That's not the right answer; your answer is too high. 
 * Curiously, it's the right answer for someone else; you might be logged in to the wrong account or just unlucky. 
 * In any case, you need to be using your puzzle input. If you're stuck, make sure you're using the full input data; 
 * there are also some general tips on the about page, or you can ask for hints on the subreddit. Please wait one minute before trying again. 
 * (You guessed 352.) [Return to Day 12]
 * */