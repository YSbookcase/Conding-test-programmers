using System;

public class Solution {
    public int solution(int[,] sizes) {
        int maxLong = 0;
        int maxShort = 0;

        for (int i = 0; i < sizes.GetLength(0); i++)
        {
            int longSide = Math.Max(sizes[i, 0], sizes[i, 1]);
            int shortSide = Math.Min(sizes[i, 0], sizes[i, 1]);
            if (longSide > maxLong) 
            {
                maxLong = longSide;
            }
            if (shortSide > maxShort)
            {
                maxShort = shortSide;
            }
        }

        return maxLong * maxShort;
    }
}