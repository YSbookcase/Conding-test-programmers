using System;
using System.Collections.Generic;

public class Solution {
    public int solution(int x, int y, int n) {
        
        if (x == y)
            return 0;
        
        int[] distance = new int[y + 1];
        Array.Fill(distance, -1);
        Queue<int> queue = new Queue<int>();
        
        queue.Enqueue(x);
        distance[x] = 0;
        
        while (queue.Count > 0)
        {
            int current = queue.Dequeue();
            int[] nextValues = { current + n, current * 2, current * 3 };
            
            foreach (int next in nextValues)
            {
                if (next > y || distance[next] != -1)
                    continue;
                distance[next] = distance[current] + 1;
                if (next == y)
                    return distance[next];
                queue.Enqueue(next);
            }
            
        }
        return -1;
    }
}