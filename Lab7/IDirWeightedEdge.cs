using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphLib
{
    // IComparable will compare Weight only.
    public interface IDirWeightedEdge : IComparable<IDirWeightedEdge>
    {
        double Weight { get; set; }
        int Source { get; set; }
        int Destination { get; set; }
    }
}
