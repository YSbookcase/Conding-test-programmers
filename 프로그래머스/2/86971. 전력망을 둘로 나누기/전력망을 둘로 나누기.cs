using System;
using System.Collections.Generic;

public class Solution {
    public int solution(int n, int[,] wires) {
                
        List<int>[] graph = new List<int>[n + 1];
        for (int node = 1; node <= n; node++)
            graph[node] = new List<int>();
        int wireCount = wires.GetLength(0);
        for (int index = 0; index < wireCount; index++)
        {
            int a = wires[index, 0];
            int b = wires[index, 1];
            graph[a].Add(b);
            graph[b].Add(a);
        }
        int minDiff = n;
        for (int index = 0; index < wireCount; index++)
        {
            int cutA = wires[index, 0];
            int cutB = wires[index, 1];
            int count = CountNodes(graph, n, cutA, cutB);
            int diff = Math.Abs(n - 2 * count);
            minDiff = Math.Min(minDiff, diff);
            if (minDiff == 0)
                return 0;
        }
        return minDiff;
    }
    int CountNodes(List<int>[] graph, int n, int start, int blocked)
    {
        bool[] isVisited = new bool[n + 1];
        Queue<int> queue = new Queue<int>();
        queue.Enqueue(start);
        isVisited[start] = true;
        int count = 0;
        while (queue.Count > 0)
        {
            int node = queue.Dequeue();
            count++;
            foreach (int next in graph[node])
            {
                if (isVisited[next])
                    continue;
                if ((node == start && next == blocked) || (node == blocked && next == start))
                    continue;
                isVisited[next] = true;
                queue.Enqueue(next);
            }
        }
        return count;
    }
}