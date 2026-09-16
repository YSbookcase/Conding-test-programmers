using System;

public class Solution {
    public int[] solution(string[] wallpaper) {
                int h = wallpaper.Length;
        int w = wallpaper[0].Length;

        int minRow = h;
        int minCol = w;
        int maxRow = -1;
        int maxCol = -1;

        for(int r = 0; r < h; r++)
        {
            for (int c = 0; c < w; c++)
            {
                if (wallpaper[r][c] != '#')
                {
                    continue;
                }

                minRow = Math.Min(minRow, r);
                minCol = Math.Min(minCol, c);
                maxRow = Math.Max(maxRow, r);
                maxCol = Math.Max(maxCol, c);


            }
        }

        return new int[] { minRow, minCol, maxRow + 1, maxCol + 1 };
    }
}