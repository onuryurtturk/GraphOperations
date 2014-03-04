using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    class Graph<T> where T:IComparable
    {
        public Vertex<T> vertexHead;
        public Vertex<T> findVertex(T val)
        {
            Vertex<T> iterator = vertexHead;
            while (iterator != null)
            {
                if (val.CompareTo(iterator.vertexValue) == 0)
                    return iterator;
                iterator = iterator.nextVertex;
            }
            return null;
        }
        public void addVertex(T val)
        {
            if (vertexHead == null)
                vertexHead = new Vertex<T>(val);
            else
            {
                Vertex<T> iterator = vertexHead;
                while (iterator.nextVertex != null)
                {
                    iterator = iterator.nextVertex;
                }
                iterator.nextVertex = new Vertex<T>(val);
            }
        }
        public void addEdge(T vertexVal, T edgeVal)
        {
            Vertex<T> v = findVertex(vertexVal);
            if(v==null)
                return;
            if (v.nextEdge == null)
                v.nextEdge = new Edge<T>(edgeVal);
            else
            {
                Edge<T> iterator = v.nextEdge;
                while (iterator.nextEdge != null)
                    iterator = iterator.nextEdge;
                iterator.nextEdge = new Edge<T>(edgeVal);
            }

        }

        public void printGraph()
        {
            Vertex<T> iteratorVertex = vertexHead;
            while (iteratorVertex != null)
            {
                Console.Write("[{0}] ", iteratorVertex.vertexValue);
                Edge<T> iteratorEdge = iteratorVertex.nextEdge;
                while (iteratorEdge != null)
                {
                    Console.Write("{0} -> ", iteratorEdge.vertexValue);
                    iteratorEdge = iteratorEdge.nextEdge;
                }
                Console.WriteLine();
                iteratorVertex = iteratorVertex.nextVertex;
            }
        }

        public int outDegree(T value)
        {
            int count = 0;
            Vertex<T> v = findVertex(value);
            Edge<T> current = v.nextEdge;
            while (current != null)
            {
                count++;
                current = current.nextEdge;
            }
            return count;
        }

        public int inDegree(T value)
        {
            int count = 0;
            Vertex<T> current = vertexHead;
            Edge<T> iterator;
            while (current!=null)
            {
                iterator = current.nextEdge;
                current = current.nextVertex;
                while (iterator!= null)
                {
                    if (iterator.vertexValue.CompareTo(value)==0)
                    {
                        count++;                        
                    }
                    iterator = iterator.nextEdge;
                }                
            }
            return count;
        }
        public void setVerticesNotVisited()//Set all vertices' visited property to false
        {         
            Vertex<T> current = vertexHead;

            while (current!=null)
            {
                current.visited = false;
                current = current.nextVertex;               
            }
        }
        public void DFS(T value)
        {
            setVerticesNotVisited();
            Vertex<T> current=findVertex(value);
            Stack<Vertex<T>> stack=new Stack<Vertex<T>>();
            if (current != null)
            {
                stack.Push(current);

                while (stack.Count != 0)
                {
                    current = stack.Pop();
                    if (!current.visited)
                    {
                        Console.Write("{0}, ", current.vertexValue);
                    }
                    current.visited = true;
                    Edge<T> CurrentEdge = current.nextEdge;
                    while (CurrentEdge != null)
                    {
                        current = findVertex(CurrentEdge.vertexValue);
                        if (!current.visited)
                        {
                            stack.Push(current);
                        }
                        CurrentEdge = CurrentEdge.nextEdge;

                    }
                }
            }
                Console.WriteLine();
            
           
        }

        public void BFS(T value)
        {

            setVerticesNotVisited();
            Vertex<T> current = findVertex(value);

            myArrayQueue<Vertex<T>> queue = new myArrayQueue<Vertex<T>>();
            queue.Enqueue(current);

            while (!queue.isEmpty())
            {
                current = queue.Dequeue();
                if (!current.visited)
                {
                    Console.Write("{0}, ", current.vertexValue);
                }
                current.visited = true;
                Edge<T> CurrentEdge = current.nextEdge;
                while (CurrentEdge != null)
                {
                    current = findVertex(CurrentEdge.vertexValue);
                    if (!current.visited)
                    {
                        queue.Enqueue(current);
                    }
                    CurrentEdge = CurrentEdge.nextEdge;

                }
            }
            Console.WriteLine();
        }

        public int vertexCount()
        {
            int count = 0;
            Vertex<T> v = vertexHead;

            setVerticesNotVisited();
            while (v.nextVertex != null && v!=null)
            {
                count++;
                v.visited = true;
                if (v.nextVertex.visited==true)
                {
                    break;
                }
                v = v.nextVertex;
            }
            return ++count;          
        }

        public bool isAdjacent(T vertex1, T vertex2)
        {

            Vertex<T> current = findVertex(vertex1);
            Edge<T> currentEdge = current.nextEdge;

            if (current!=null && currentEdge!=null)
            {

                while (currentEdge != null)
                {
                    if (currentEdge.vertexValue.CompareTo(vertex2)==0)
                    {
                        return true;
                    }

                    currentEdge = currentEdge.nextEdge;
                }                
            }
            return false;
        }

        public int[,] adjacencyMatrix()
        {
           int[,] matrice = new int[vertexCount(),vertexCount()];

            Vertex<T> satir= vertexHead;
            int i = 0;
            while (satir != null)
            {
                Vertex<T> sutun = vertexHead;
                int j = 0;

                while (sutun != null)
                {
                    if (isAdjacent(satir.vertexValue, sutun.vertexValue))
                    {
                        matrice[i, j] = 1;
                    }
                   
                    sutun = sutun.nextVertex;
                    j++;               
                }
                satir = satir.nextVertex;
                i++;
            
            }
            return matrice;
        
        }   


    }
    
}
