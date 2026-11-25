using System;

public class Solution {
    public int solution(int[,] info, int n, int m) {
        
        int count = info.GetLength(0);
        int[] minA = new int[m];
        for (int b = 0; b < m; b++)
            minA[b] = n;
        minA[0] = 0;
        for (int i = 0; i < count; i++)
        {
            int aCost = info[i, 0];
            int bCost = info[i, 1];
            int[] nextA = new int[m];
            for (int b = 0; b < m; b++)
                nextA[b] = n;
            for (int b = 0; b < m; b++)
            {
                if (minA[b] >= n)
                    continue;
                int takeA = minA[b] + aCost;
                if (takeA < n)
                    nextA[b] = Math.Min(nextA[b], takeA);
                int nextB = b + bCost;
                if (nextB < m)
                    nextA[nextB] = Math.Min(nextA[nextB], minA[b]);
            }
            minA = nextA;
        }
        int answer = n;
        for (int b = 0; b < m; b++)
            answer = Math.Min(answer, minA[b]);
        return answer == n ? -1 : answer;
    }
}