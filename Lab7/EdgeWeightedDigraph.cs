﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace GraphLib
{
    //public class EdgeWeightedDigraph : IEdgeWeightedDigraph
    //{
    //    public EdgeWeightedDigraph(string filename)
    //    {
    //        using(StreamReader reader = new StreamReader(filename))
    //        {
    //            char[] delimiters = " \t".ToCharArray();
    //            string line = reader.ReadLine();
    //            int nVertices = int.Parse(line);
    //            line = reader.ReadLine();
    //            NEdges = int.Parse(line);

    //            string[] fields = line.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

    //            while(!reader.EndOfStream)
    //            {
    //                line = reader.ReadLine();
    //                fields = line.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
    //                int source = int.Parse(fields[0]);
    //                int destination = int.Parse(fields[1]);
    //                double weight = double.Parse(fields[2]);

    //                AddEdge(source, destination, weight);
    //            }

    //        }
    //    }

    //    List<List<IDirWeightedEdge>> adjList = new List<List<IDirWeightedEdge>>();
    //}
}
