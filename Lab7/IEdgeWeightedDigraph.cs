using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphLib
{
    public interface IEdgeWeightedDigraph 
    {
        void AddEdge(int source, int destination, double weight);

        int NEdges { get;  }

        int NVertices { get;  }

        IEnumerable<IDirWeightedEdge> GetEdgesFrom(int vertex);
    }
}
