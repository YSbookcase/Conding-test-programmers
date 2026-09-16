using System;

// 바탕화면 정리 — #의 행/열 min·max로 드래그 사각형
public class Solution
{
    public int[] solution(string[] wallpaper)
    {
        int height = wallpaper.Length;
        int width = wallpaper[0].Length;

        // min은 큰 값으로, max는 작은 값으로 시작해야 첫 #에서 갱신됨
        int minRow = height;
        int minCol = width;
        int maxRow = -1;
        int maxCol = -1;

        for (int row = 0; row < height; row++)
        {
            for (int col = 0; col < width; col++)
            {
                if (wallpaper[row][col] != '#')
                {
                    continue;
                }

                minRow = Math.Min(minRow, row);
                minCol = Math.Min(minCol, col);
                maxRow = Math.Max(maxRow, row);
                maxCol = Math.Max(maxCol, col);
            }
        }

        return new int[] { minRow, minCol, maxRow + 1, maxCol + 1 };
    }
}
