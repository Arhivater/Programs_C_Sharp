﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace _2_Tuples
{
    class Program
    {
        public class Node
        {
            public string Name;
            public List<Arc> Arcs = new List<Arc>();

            public Node(string name)
            {
                Name = name;
            }

            public Node AddArc(Node child, int w)
            {
                Arcs.Add(new Arc
                {
                    Parent = this,
                    Child = child,
                    Weigth = w
                });

                if (!child.Arcs.Exists(a => a.Parent == child && a.Child == this))
                {
                    child.AddArc(this, w);
                }

                return this;
            }
        }

        public class Arc
        {
            public int Weigth;
            public Node Parent;
            public Node Child;
        }

        public class Graph
        {
            public Node Root;
            public List<Node> AllNodes = new List<Node>();

            public Node CreateRoot(string name)
            {
                Root = CreateNode(name);
                return Root;
            }

            public Node CreateNode(string name)
            {
                var n = new Node(name);
                AllNodes.Add(n);
                return n;
            }

            public int?[,] CreateAdjMatrix()
            {
                int?[,] adj = new int?[AllNodes.Count, AllNodes.Count];

                for (int i = 0; i < AllNodes.Count; i++)
                {
                    Node n1 = AllNodes[i];

                    for (int j = 0; j < AllNodes.Count; j++)
                    {
                        Node n2 = AllNodes[j];

                        var arc = n1.Arcs.FirstOrDefault(a => a.Child == n2);

                        if (arc != null)
                        {
                            adj[i, j] = arc.Weigth;
                        }
                    }
                }
                return adj;
            }
        }

        private static void PrintMatrix(ref int?[,] matrix, int Count)
        {
            Console.WriteLine();
            Console.Write("       ");
            for (int i = 0; i < Count; i++)
            {
                Console.Write("{0}  ", (char)('A' + i));
            }

            Console.WriteLine();

            for (int i = 0; i < Count; i++)
            {
                Console.Write("  {0} | ", (char)('A' + i));

                for (int j = 0; j < Count; j++)
                {
                    if (i == j)
                    {
                        Console.Write(" ■ ");
                    }
                    else if (matrix[i, j] == null)
                    {
                        Console.Write(" - ");
                    }
                    else
                    {
                        Console.Write(" {0} ", matrix[i, j]);
                    }

                }
                Console.Write(" |\r\n");
            }
            Console.Write("\r\n");
        }

        static void Main(string[] args)
        {
            var graph = new Graph();

            var a = graph.CreateRoot("A");
            var b = graph.CreateNode("B");
            var c = graph.CreateNode("C");
            var d = graph.CreateNode("D");
            var e = graph.CreateNode("E");
            var f = graph.CreateNode("F");
            var g = graph.CreateNode("G");
            var h = graph.CreateNode("H");
            var i = graph.CreateNode("I");
            var j = graph.CreateNode("J");
            var k = graph.CreateNode("K");
            var l = graph.CreateNode("L");
            var m = graph.CreateNode("M");
            var n = graph.CreateNode("N");
            var o = graph.CreateNode("O");
            var p = graph.CreateNode("P");

            a.AddArc(b, 1)
             .AddArc(c, 1);

            b.AddArc(e, 1)
             .AddArc(d, 3);

            c.AddArc(f, 1)
             .AddArc(d, 3);

            c.AddArc(f, 1)
             .AddArc(d, 3);

            d.AddArc(h, 8);

            e.AddArc(g, 1)
             .AddArc(h, 3);

            f.AddArc(h, 3)
             .AddArc(i, 1);

            g.AddArc(j, 3)
             .AddArc(l, 1);

            h.AddArc(j, 8)
             .AddArc(k, 8)
             .AddArc(m, 3);

            i.AddArc(k, 3)
             .AddArc(n, 1);

            j.AddArc(o, 3);

            k.AddArc(p, 3);

            l.AddArc(o, 1);

            m.AddArc(o, 1)
             .AddArc(p, 1);

            n.AddArc(p, 1);

            int?[,] adj = graph.CreateAdjMatrix();

            PrintMatrix(ref adj, graph.AllNodes.Count);
        }
    }
}
