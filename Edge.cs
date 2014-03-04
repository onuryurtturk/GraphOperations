using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Graphs
{
    class Edge<T> where T:IComparable
    {
        public T vertexValue;
        public Edge<T> nextEdge;
        public Edge(T val)
        {
            vertexValue = val;
            nextEdge = null;
        }
    }
}
