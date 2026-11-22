using System;

public class Solution {
    public int[] solution(int m, int n, int startX, int startY, int[,] balls) {
        
        int ballCount = balls.GetLength(0);
        int[] answer = new int[ballCount];
        
        for (int i = 0; i < ballCount; i++)
        {
            int targetX = balls[i, 0];
            int targetY = balls[i, 1];
            int minDistance = int.MaxValue;
            // 왼
            if (!(startY == targetY && targetX < startX))
                minDistance = Math.Min(minDistance, Dist2(startX, startY, -targetX, targetY));
            // 오른
            if (!(startY == targetY && startX < targetX))
                minDistance = Math.Min(minDistance, Dist2(startX, startY, 2 * m - targetX, targetY));
            // 아래
            if (!(startX == targetX && targetY < startY))
                minDistance = Math.Min(minDistance, Dist2(startX, startY, targetX, -targetY));
            // 위
            if (!(startX == targetX && startY < targetY))
                minDistance = Math.Min(minDistance, Dist2(startX, startY, targetX, 2 * n - targetY));
            answer[i] = minDistance;
        }
        return answer;
    }
    
    int Dist2(int x1, int y1, int x2, int y2)
    {
        int dx = x1 - x2;
        int dy = y1 - y2;
        return dx * dx + dy * dy;
    }
}