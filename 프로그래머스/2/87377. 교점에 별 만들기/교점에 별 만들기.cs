using System;
using System.Collections.Generic;

public class Solution {
    public string[] solution(int[,] line) {
                
        int lineCount = line.GetLength(0);
        HashSet<(long x, long y)> stars = new HashSet<(long x, long y)>();
        for (int i = 0; i < lineCount; i++)
        {
            for (int j = i + 1; j < lineCount; j++)
            {
                long a = line[i, 0];
                long b = line[i, 1];
                long c = line[i, 2];
                long d = line[j, 0];
                long e = line[j, 1];
                long f = line[j, 2];
                long det = a * e - b * d;
                if (det == 0)
                    continue;
                long xNum = b * f - c * e;
                long yNum = c * d - a * f;
                if (xNum % det != 0 || yNum % det != 0)
                    continue;
                stars.Add((xNum / det, yNum / det));
            }
        }
        long minX = long.MaxValue;
        long maxX = long.MinValue;
        long minY = long.MaxValue;
        long maxY = long.MinValue;
        foreach ((long x, long y) in stars)
        {
            minX = Math.Min(minX, x);
            maxX = Math.Max(maxX, x);
            minY = Math.Min(minY, y);
            maxY = Math.Max(maxY, y);
        }
        int height = (int)(maxY - minY + 1);
        int width = (int)(maxX - minX + 1);
        char[][] board = new char[height][];
        for (int row = 0; row < height; row++)
        {
            board[row] = new char[width];
            for (int col = 0; col < width; col++)
                board[row][col] = '.';
        }
        foreach ((long x, long y) in stars)
        {
            int row = (int)(maxY - y);
            int col = (int)(x - minX);
            board[row][col] = '*';
        }
        string[] answer = new string[height];
        for (int row = 0; row < height; row++)
            answer[row] = new string(board[row]);
        return answer;
    }
}