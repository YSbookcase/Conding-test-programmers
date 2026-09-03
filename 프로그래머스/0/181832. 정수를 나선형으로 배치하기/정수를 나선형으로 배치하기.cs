using System;

public class Solution {
    public int[,] solution(int n) {
        
        int[,] answer = new int[n, n];
        
        int[] dx = {0, 1, 0, -1};
        int[] dy = {1, 0, -1, 0};
        
        int x = 0;
        int y = 0;
        int dir = 0;
        
        for (int num = 1; num <= n * n; num++)
        {
            answer[x, y] = num;
            
            int nx = x + dx[dir];
            int ny = y + dy[dir];
            
            if (nx < 0 || nx >= n || ny < 0 || ny >= n || answer[nx, ny] != 0)
            {
                dir = (dir + 1) % 4;
                nx = x + dx[dir];
                ny = y + dy[dir];
            }
            
            x = nx;
            y = ny;
            
        }
        
        return answer;
    }
}