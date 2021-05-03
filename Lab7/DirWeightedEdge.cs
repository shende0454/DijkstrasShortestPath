using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphLib
{
    public class DirWeightedEdge : IDirWeightedEdge
    {
        public DirWeightedEdge(int source, int destintion, double weight)
        {
          Source = source;
           Destination = destintion;
            Weight = weight;
        }
        
        public int Source { get; set; }
       

       public double Weight { get ; set; }
        public int Destination { get ; set; }

        public int CompareTo(IDirWeightedEdge other)
        {
            return this.CompareTo(other);
        }
    }
}
