using System;

public class Solution {
    public int solution(int[,] targets) {
            
        int count = targets.GetLength(0);
        int[][] ranges = new int[count][];
        for (int i = 0; i < count; i++)
        {
            ranges[i] = new int[] { targets[i, 0], targets[i, 1] };
        }
        Array.Sort(ranges, (a, b) => a[1].CompareTo(b[1]));
        int answer = 0;
        int shotEnd = -1;
        foreach (int[] range in ranges)
        {
            int start = range[0];
            int end = range[1];
            if (shotEnd <= start)
            {
                answer++;
                shotEnd = end;
            }
        }
        return answer;
    }
    
}