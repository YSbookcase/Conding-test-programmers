using System;
using System.Collections.Generic;

public class Solution {
    public int solution(int[,] points, int[,] routes) {
        
        int robotCount = routes.GetLength(0);
        int routeLength = routes.GetLength(1);
        Dictionary<(int time, int row, int col), int> visitCount = new Dictionary<(int, int, int), int>();
        for (int robot = 0; robot < robotCount; robot++)
        {
            int startNumber = routes[robot, 0];
            int row = points[startNumber - 1, 0];
            int col = points[startNumber - 1, 1];
            int time = 0;
            Add(visitCount, time, row, col);
            for (int index = 1; index < routeLength; index++)
            {
                int targetNumber = routes[robot, index];
                int targetRow = points[targetNumber - 1, 0];
                int targetCol = points[targetNumber - 1, 1];
                while (row != targetRow)
                {
                    row += row < targetRow ? 1 : -1;
                    time++;
                    Add(visitCount, time, row, col);
                }
                while (col != targetCol)
                {
                    col += col < targetCol ? 1 : -1;
                    time++;
                    Add(visitCount, time, row, col);
                }
            }
        }
        int answer = 0;
        foreach (int count in visitCount.Values)
        {
            if (count >= 2)
                answer++;
        }
        return answer;
    }
    void Add(Dictionary<(int time, int row, int col), int> visitCount, int time, int row, int col)
    {
        (int time, int row, int col) key = (time, row, col);
        if (!visitCount.ContainsKey(key))
            visitCount[key] = 0;
        visitCount[key]++;
    }
}