using System.Collections.Generic;

namespace GraphLib
{
    public interface IDijkstrasShortestPath
    {
        int Source { get; }

        double DistanceTo(int destination);

        // A list of vertices that are traversed on a path to destination.
        // The source is not included in the list.
        List<int> PathTo(int destination);
    }
}