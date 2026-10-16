using System;
using System.Collections.Generic;


class Solution
{
    public int solution(int N, int[,] road, int K)
    {

                List<(int next, int time)>[] graph = new List<(int next, int time)>[N + 1];

        for (int village = 1; village <= N; village++)
        {
            graph[village] = new List<(int next, int time)>();
        }

        int roadCount = road.GetLength(0);
        for (int index = 0; index < roadCount; index++)
        {
            int from = road[index, 0];
            int to = road[index, 1];
            int time = road[index, 2];

            graph[from].Add((to, time));
            graph[to].Add((from, time));
        }

        int[] dist = new int[N + 1];
        Array.Fill(dist, int.MaxValue);
        dist[1] = 0;
        bool[] isVisited = new bool[N + 1];

        for (int pick = 0; pick < N; pick++)
        {
            int current = 0;
            for (int village = 1; village <= N; village++)
            {
                if (!isVisited[village] && dist[village] < dist[current])
                {
                    current = village;
                }

            }

              isVisited[current] = true;
            
            foreach ((int next, int time) in graph[current])
            {
                int nextDist = dist[current] + time;
                if (nextDist < dist[next])
                {
                    dist[next] = nextDist;
                }
            }
        }

        int count = 0;
        for (int village = 1; village <= N; village++)
        {
            if (dist[village] <= K)
            {
                count++;
            }
        }
        return count;
    }
}