using System;

namespace Floyd_Warshall_Algorithm
{
    internal class Program
    {
        static void FloydWarshall(int[,] weights, int numVerticies)
        {
            var dist = new double[numVerticies, numVerticies];
            for (int i = 0; i < numVerticies; i++)
            {
                for (int j = 0; j < numVerticies; j++)
                {
                    dist[i, j] = double.PositiveInfinity; // результат деления положительного числа на ноль
                }
            }

            for (int i = 0; i < weights.GetLength(0); i++)
            {
                dist[weights[i, 0] - 1, weights[i, 1] - 1] = weights[i, 2];
            }

            var next = new int[numVerticies, numVerticies];
            for (int i = 0; i < numVerticies; i++)
            {
                for (int j = 0; j < numVerticies; j++)
                {
                    if (i != j)
                    {
                        next[i, j] = j + 1;
                    }
                }
            }

            for (int k = 0; k < numVerticies; k++)
            {
                for (int i = 0; i < numVerticies; i++)
                {
                    for (int j = 0; j < numVerticies; j++)
                    {
                        if (dist[i, k] + dist[k, j] < dist[i, j])
                        {
                            dist[i, j] = dist[i, k] + dist[k, j];
                            next[i, j] = next[i, k];
                        }
                    }
                }
            }

            PrintResult(dist, next);
        }

        static void PrintResult(double[,] dist, int[,] next)
        {
            Console.WriteLine("pair     dist    path");
            for (int i = 0; i < next.GetLength(0); i++)
            {
                for (int j = 0; j < next.GetLength(1); j++)
                {
                    if (i != j)
                    {
                        int u = i + 1;
                        int v = j + 1;
                        string path = $"{u} -> {v}    {dist[i, j],2:G}     {u}";
                        do
                        {
                            u = next[u - 1, v - 1];
                            path += " -> " + u;
                        } while (u != v);
                        Console.WriteLine(path);
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            int[,] weights = { { 1, 3, -2 }, { 2, 1, 4 }, { 2, 3, 3 }, { 3, 4, 2 }, { 4, 2, -1 } };
            var Verticies = 4;
          FloydWarshall(weights, Verticies);
        }

    }
}