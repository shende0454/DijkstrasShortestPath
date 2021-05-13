using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QueueLib;

namespace GraphLib
{
    public class DijkstrasShortestPath : IDijkstrasShortestPath
    {
        private DirWeightedEdge[] theEdgeTo;
        public DijkstrasShortestPath(int source, IEdgeWeightedDigraph graph)
        {
            _bestPathTo = new double[graph.NVertices];
            theEdgeTo = new DirWeightedEdge[graph.NVertices];
            for (int vtx = 0; vtx < graph.NVertices; vtx++)
            {
                _bestPathTo[vtx] = Double.PositiveInfinity;
            }
            _bestPathTo[source] = 0.0;
            _priorityQueue.Insert(source, 0.0);
            while (!_priorityQueue.IsEmpty())
            {
                Relax(graph, _priorityQueue.DeleteMin());
            }
        }

        public double DistanceTo(int destination)
        {
            return _bestPathTo[destination];
        }
        public bool HasPathTo(int v)
        { 
            return _bestPathTo[v] < Double.PositiveInfinity;
        }
        public List<int> PathTo(int destination)
        {
            if (!HasPathTo(destination))
            {
                return null;
            }
            Stack<int> p = new Stack<int>();
            List<int> path = new List<int>();
            p.Push(destination);
            for (DirWeightedEdge e = theEdgeTo[destination]; e != null; e = theEdgeTo[e.Source])
            { 
                    p.Push(e.Source);
                if (p.Peek() == 1)
                {
                    p.Pop();
                }
             
            }
            
            
            return p.ToList();
        }

        void Relax(IEdgeWeightedDigraph edge, int workingNode)
        {
            foreach (DirWeightedEdge e in edge.GetEdgesFrom(workingNode))
            {
                int w = e.Destination;
                if (_bestPathTo[w] > _bestPathTo[workingNode] + e.Weight)
                {
                    _bestPathTo[w] = _bestPathTo[workingNode] + e.Weight;
                    theEdgeTo[w] = e;
                    if (_priorityQueue.Contains(w))
                    {
                        _priorityQueue.ChangeKey(w,_bestPathTo[w]);
                    }
                    else
                    {
                        _priorityQueue.Insert(w, _bestPathTo[w]);
                    }
                }
            }
        }

        IIndexedMinPriortyQueue<int, double> _priorityQueue = new IndexedMinPriorityQueue<int, double>();

        double[] _bestPathTo;
       
       
        public int Source { get; private set; }
    }
}
