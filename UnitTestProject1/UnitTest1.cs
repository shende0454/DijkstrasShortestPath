using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GraphLib;
using QueueLib;

namespace UnitTestProject1
{
    [TestClass]
    public class GraphLibTest
    {
        //[TestMethod]
        //public void T001_MakeEdge()
        //{
        //    IDirWeightedEdge edge = new DirWeightedEdge(1, 2, .5);
        //    Assert.AreEqual(1, edge.Source);
        //    Assert.AreEqual(2, edge.Destination);
        //    Assert.AreEqual(.5, edge.Weight);
        //}

        //[TestMethod]
        //public void T002_readTinyEWG()
        //{
        //    string path = System.Environment.GetEnvironmentVariable("HOMEPATH");
        //    string filename = path + @"\graphFiles\tinyEWG.txt";
        //    IEdgeWeightedDigraph tinyEWG = new EdgeWeightedDigraph(filename);
        //    Assert.AreEqual(8, tinyEWG.NVertices);
        //    Assert.AreEqual(16, tinyEWG.NEdges);
        //}


        //[TestMethod]
        //public void T003_enumeratedEdges()
        //{
        //    string path = System.Environment.GetEnvironmentVariable("HOMEPATH");
        //    string filename = path + @"\graphFiles\tinyEWG.txt";
        //    IEdgeWeightedDigraph tinyEWG = new EdgeWeightedDigraph(filename);
        //    int nDestinations = 0;
        //    foreach(IDirWeightedEdge edge in tinyEWG.GetEdgesFrom(6))
        //    {
        //        if (edge.Destination == 2)
        //        {
        //            Assert.AreEqual(.4, edge.Weight);
        //            ++nDestinations;
        //        }

        //        if (edge.Destination == 0)
        //        { 
        //            Assert.AreEqual(.58, edge.Weight);
        //            ++nDestinations;
        //        }

        //        if (edge.Destination == 4)
        //        { 
        //            Assert.AreEqual(.93, edge.Weight);
        //            ++nDestinations;
        //        }
        //    }
        //    Assert.AreEqual(3, nDestinations);
        //}

        //[TestMethod]
        //public void T004_pathLengths()
        //{
        //    string path = System.Environment.GetEnvironmentVariable("HOMEPATH");
        //    string filename = path + @"\graphFiles\networkExample.txt";
        //    IEdgeWeightedDigraph network = new EdgeWeightedDigraph(filename);
        //    DijkstrasShortestPath shortestPaths = new DijkstrasShortestPath(1, network);
        //    Assert.AreEqual(2, shortestPaths.DistanceTo(2));
        //    Assert.AreEqual(9, shortestPaths.DistanceTo(3));
        //    Assert.AreEqual(10, shortestPaths.DistanceTo(4));
        //    Assert.AreEqual(4, shortestPaths.DistanceTo(5));
        //    Assert.AreEqual(6, shortestPaths.DistanceTo(6));
        //    Assert.AreEqual(5, shortestPaths.DistanceTo(7));
        //    Assert.AreEqual(8, shortestPaths.DistanceTo(8));
        //}

        //[TestMethod]
        //public void T005_paths()
        //{
        //    string path = System.Environment.GetEnvironmentVariable("HOMEPATH");
        //    string filename = path + @"\graphFiles\networkExample.txt";
        //    IEdgeWeightedDigraph network = new EdgeWeightedDigraph(filename);
        //    DijkstrasShortestPath shortestPaths = new DijkstrasShortestPath(1, network);

        //    // Specify the path to 8
        //    List<int> pathToEight = shortestPaths.PathTo(8);
        //    Assert.AreEqual(2, pathToEight[0]);
        //    Assert.AreEqual(5, pathToEight[1]);
        //    Assert.AreEqual(6, pathToEight[2]);
        //    Assert.AreEqual(8, pathToEight[3]);

        //    // Specify the path to 4
        //    List<int> pathToFour = shortestPaths.PathTo(4);
        //    Assert.AreEqual(2, pathToFour[0]);
        //    Assert.AreEqual(5, pathToFour[1]);
        //    Assert.AreEqual(6, pathToFour[2]);
        //    Assert.AreEqual(8, pathToFour[3]);
        //    Assert.AreEqual(4, pathToFour[4]);
        //}
    }
}
