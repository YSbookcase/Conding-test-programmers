using System;

public class Solution {
    public int[] solution(int[,] edges) {
        
        int edgeCount = edges.GetLength(0);
        int[] outCount = new int[1000001];
        int[] inCount = new int[1000001];
        for (int i = 0; i < edgeCount; i++)
        {
            int from = edges[i, 0];
            int to = edges[i, 1];
            outCount[from]++;
            inCount[to]++;
        }
        int generated = 0;
        int stickCount = 0;
        int eightCount = 0;
        for (int vertex = 1; vertex <= 1000000; vertex++)
        {
            if (outCount[vertex] == 0 && inCount[vertex] == 0)
                continue;
            if (inCount[vertex] == 0 && outCount[vertex] >= 2)
                generated = vertex;
            else if (outCount[vertex] == 0)
                stickCount++;
            else if (outCount[vertex] >= 2)
                eightCount++;
        }
        int donutCount = outCount[generated] - stickCount - eightCount;
        return new int[] { generated, donutCount, stickCount, eightCount };
    }
}
