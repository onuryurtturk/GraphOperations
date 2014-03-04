using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    class Vertex<T> where T:IComparable
    {
        public T vertexValue;
        public Vertex<T> nextVertex;
        public Edge<T> nextEdge;
        public bool visited;
        public Vertex(T val)
        {
            vertexValue = val;
            nextVertex = null;
            nextEdge = null;
            visited = false;
        }
    }
}
