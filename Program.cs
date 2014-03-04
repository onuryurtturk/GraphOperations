using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * TODO:
 * 1) Write outDegree method for a given vertex value
 * 2) Write inDegree method for a given vertex
 * 3) Write DFS(Depth Firs Search) method for a given vertex iteratively(using stacks)
 * 4) Write BFS(Breadth First Search) method for a given vertex iteratively(usşng queues)
 * 5) Write adjacencyMatrix and relevant(vertexCount, isAdjacent) methods
 * PS: boolean visited member added to Vertex class for DFS and BFS
 */
namespace Graphs
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph<string> gr = new Graph<string>();
            gr.addVertex("A");
            gr.addVertex("B");
            gr.addVertex("C");
            gr.addVertex("D");
            gr.addVertex("E");
            gr.addVertex("F");
            gr.addVertex("G");
            gr.addEdge("A", "B");
            gr.addEdge("B", "A");
            gr.addEdge("A", "C");
            gr.addEdge("C", "A");
            gr.addEdge("A", "E");
            gr.addEdge("E", "A");
            gr.addEdge("B", "D");
            gr.addEdge("D", "B");
            gr.addEdge("B", "F");
            gr.addEdge("F", "B");
            gr.addEdge("C", "G");
            gr.addEdge("G", "C");
            gr.addEdge("E", "F");
            gr.addEdge("F", "E");
            gr.printGraph();
            Console.WriteLine(gr.outDegree("A"));
            Console.WriteLine(gr.inDegree("F"));

            gr.setVerticesNotVisited();


            gr.DFS("A");
            Console.WriteLine("\nBFS sonucu:");
            gr.BFS("A");
            Console.WriteLine("\nVertex sonucu:{0}",gr.vertexCount());
            Console.WriteLine("\nsonucu:{0}",gr.isAdjacent("D","G"));
          
            
            int[,] array = gr.adjacencyMatrix();

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write(" {0}", array[i, j]);
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }

    }
}
