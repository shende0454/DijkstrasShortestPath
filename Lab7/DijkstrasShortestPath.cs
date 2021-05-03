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
        private DirWeightedEdge[] edgeTo;
        public DijkstrasShortestPath(int source, IEdgeWeightedDigraph graph)
        {
            _bestPathTo = new double[graph.NVertices];
            edgeTo = new DirWeightedEdge[graph.NVertices];
            for (int v = 0; v < graph.NVertices; v++)
            {
                _bestPathTo[v] = Double.PositiveInfinity;
            }
            _bestPathTo[source] = 0.0;
            _priorityQueue.Insert(source, 0.0);
            while (!_priorityQueue.IsEmpty())
                Relax(graph, _priorityQueue.DeleteMin());
        }

        public double DistanceTo(int destination)
        {
            return _bestPathTo[destination];
        }

        public List<int> PathTo(int destination)
        {
            return null;
        }

        void Relax(IEdgeWeightedDigraph edge, int workingNode)
        {
            foreach (DirWeightedEdge e in edge.GetEdgesFrom(workingNode))
            {
                int w = e.Destination;
                if (_bestPathTo[w] > _bestPathTo[workingNode] + e.Weight)
                {
                    _bestPathTo[w] = _bestPathTo[workingNode] + e.Weight;
                    edgeTo[w] = e;
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
        int[] _pathFrom;
        bool[] _permanent;
       
        public int Source { get; private set; }
    }
}
