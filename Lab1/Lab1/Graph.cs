using System;

namespace Lab1
{
    class Graph
    {
        public int[,] IncidenceMatrix { get; set; }
        public int NodeCount { get; set; }
        public int ConnectionCount { get; set; }

        public Graph(int nodeCount, int connectionCount)
        {
            NodeCount = nodeCount;
            ConnectionCount = connectionCount;

            IncidenceMatrix = new int[nodeCount,nodeCount];
        }

        public void CreateIncidenceMatrix(bool isRandom)
        {
            if (isRandom)
            {
                // Firstly, we make sure that all nodes will be connected with at least one node
                Random random = new Random();
                int currConnectionCount = 0;

                while (currConnectionCount < ConnectionCount)
                {
                    for (int i = 0; i < NodeCount; i++)
                    {
                        int randomNode = random.Next(i, NodeCount);
                        if (randomNode != i && IncidenceMatrix[i,randomNode] == 0)
                        {
                            int randomWeight = random.Next(1, 10);
                            IncidenceMatrix[i, randomNode] = randomWeight;
                            IncidenceMatrix[randomNode, i] = randomWeight;
                            currConnectionCount++;
                        }

                        if(currConnectionCount >= ConnectionCount)
                        {
                            break;
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("---< IncidenceMatrix[from, to]= weight >---");
                for(int i = 0; i < NodeCount; i++)
                {
                    for(int j = i + 1; j < NodeCount; j++)
                    {
                        Console.Write("IncidenceMatrix[" + (i + 1).ToString() + ',' + (j + 1).ToString() + "]= ");
                        
                        int weight;
                        if (!int.TryParse(Console.ReadLine(), out weight))
                        {
                            throw new Exception("You have to write a single number!");
                        }

                        IncidenceMatrix[i, j] = weight;
                        IncidenceMatrix[j, i] = weight;
                    }
                }
            }
        }

        public void PrintIncidenceMatrix()
        {
            Console.WriteLine("Incidence Matrix:");
            for(int i = 0; i < NodeCount; i++)
            {
                for(int j = 0; j < NodeCount; j++)
                {
                    Console.Write(string.Format("{0} ", IncidenceMatrix[i, j]));
                }
                Console.WriteLine();
            }
        }

        // Find the minimum spanning tree using Kruskal's algorithm
        public int[,] FindSpanningTree() {
            int[,] result = new int[NodeCount, NodeCount];
            int[] nodes = new int[NodeCount];

            // Initialize result and nodes arrays
            for(int i = 0; i < NodeCount; i++)
            {
                for(int j = 0;j < NodeCount; j++)
                {
                    result[i, j] = Int32.MaxValue;
                }

                nodes[i] = i;
            }

            int nodeA = 0, nodeB = 0;
            int currNodeCount = 1;

            while(currNodeCount < NodeCount)
            {
                int min = Int32.MaxValue;
                for(int i = 0; i < NodeCount; i++)
                {
                    for(int j = 0; j< NodeCount; j++)
                    {
                        if (IncidenceMatrix[i, j] != 0 && min > IncidenceMatrix[i,j] && nodes[i] != nodes[j])
                        {
                            min = IncidenceMatrix[i, j];
                            nodeA = i;
                            nodeB = j;
                        }
                    }
                }

                if(nodes[nodeA] != nodes[nodeB])
                {
                    result[nodeA, nodeB] = min;
                    result[nodeB, nodeA] = min;

                    int temp = nodes[nodeB];
                    nodes[nodeB] = nodes[nodeA];
                    for(int k = 0; k < NodeCount; k++)
                    {
                        if(nodes[k] == temp)
                        {
                            nodes[k] = nodes[nodeA];
                        }
                    }
                    currNodeCount++;
                }
            }
            return result;
        }

        public int FindSpanningTreeLongestEdge(int[,] spanningTree)
        {
            int max = Int32.MinValue;

            for (int i = 0; i < NodeCount; i++)
            {
                for (int j = i; j < NodeCount; j++)
                {
                    if (spanningTree[i, j] != Int32.MaxValue)
                    {
                        if(spanningTree[i,j] > max)
                        {
                            max = spanningTree[i, j];
                        }
                    }
                }
            }
            return max;
        }

        public int FindSpanningTreeNodeCount(int[,] spanningTree)
        {
            int count = 0;

            for (int i = 0; i < NodeCount; i++)
            {
                for (int j = i; j < NodeCount; j++)
                {
                    if (spanningTree[i, j] != Int32.MaxValue)
                    {
                        count++;
                    }
                }
            }
            return count;
        }

        public void PrintSpanningTree(int[,] spanningTree)
        {
            for (int i = 0; i < NodeCount; i++)
            {
                for (int j = i; j < NodeCount; j++)
                {
                    if (spanningTree[i, j] != Int32.MaxValue)
                    {
                        Console.Write(string.Format("{0} {1}\n", i + 1, j + 1));
                    }
                }
            }
        }
    }
}
