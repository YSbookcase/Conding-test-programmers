using System;

public class Solution {
    public int solution(int[,] board) {
        int n = board.GetLength(0);
        bool[,] danger = new bool[n, n];

        // 8방향 + 자기 자신
        int[] dx = { -1, -1, -1,  0, 0, 0,  1, 1, 1 };
        int[] dy = { -1,  0,  1, -1, 0, 1, -1, 0, 1 };

        for (int y = 0; y < n; y++)
        {
            for (int x = 0; x < n; x++)
            {
                if (board[y, x] != 1) continue;

                for (int k = 0; k < 9; k++)
                {
                    int ny = y + dy[k];
                    int nx = x + dx[k];

                    if (ny < 0 || ny >= n || nx < 0 || nx >= n) continue;
                    danger[ny, nx] = true;
                }
            }
        }

        int safeCount = 0;
        for (int y = 0; y < n; y++)
        {
            for (int x = 0; x < n; x++)
            {
                if (!danger[y, x]) safeCount++;
            }
        }

        return safeCount;
    }
    
}