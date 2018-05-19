using System;

namespace Lab1
{
    class Program
    {
        static int SumFromOneToValue(int value)
        {
            int result = 0;
            for (int i = 1; i <= value; i++)
            {
                result += i;
            }
            return result;
        }
        static int InitializeIntValue(String message)
        {
            int value;
            Console.Write(message);
            if (!int.TryParse(Console.ReadLine(), out value))
            {
                throw new Exception("You have to write a single number!");
            }
            return value;
        }

        static void Main(string[] args)
        {
            // Find out if matrix should be generate random or not
            bool isRandom = false;
            bool exit = false;
            while (!exit)
            {
                Console.Write("Generate radnom adjacency matrix?(Yes/No): ");
                string decision = Console.ReadLine().ToLower();
                switch (decision)
                {
                    case "yes": isRandom = true; exit = true; break;
                    case "no": isRandom = false; exit = true; break;
                    default: break;
                }
            }

            Graph graph = null;

            // Initialize nodeCount and connectionCount
            int nodeCount = 0, connectionCount = 0;
            try
            {
                nodeCount = InitializeIntValue("NodeCount: ");
                connectionCount = InitializeIntValue("ConnectionCount: ");

                // ConnectionCount can't be greater than 1 + 2 + ... + nodeCount - 1
                if (connectionCount > SumFromOneToValue(nodeCount - 1))
                {
                    throw new Exception("ConnectionCount can't be greater than 1 + 2 + ... + nodeCount - 1");
                }

                graph = new Graph(nodeCount, connectionCount);

                graph.CreateAdjacencyMatrix(isRandom);
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error:\n" + ex.Message);
                Console.Read();
                return;
            }

            graph.PrintAdjacencyMatrix();

            int[,] spanningTree = graph.FindSpanningTree();

            // Result
            Console.WriteLine("---------- Result -------");
            Console.WriteLine(String.Format("Longest distance: {0}" ,graph.FindSpanningTreeLongestEdge(spanningTree)));
            Console.WriteLine(String.Format("Cabels count: {0}", graph.FindSpanningTreeNodeCount(spanningTree)));
            graph.PrintSpanningTree(spanningTree);
            

            Console.ReadLine();
        }
    }
}
