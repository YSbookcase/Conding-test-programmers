using System;
using System.Collections.Generic;

public class Solution {
    public int[] solution(string[] maps) {
            
        int rows = maps.Length;
        int cols = maps[0].Length;
        bool[,] isVisited = new bool[rows, cols];
        int[] deltaRow = { -1, 1, 0, 0 };
        int[] deltaCol = { 0, 0, -1, 1 };
        List<int> days = new List<int>();
        
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                if (maps[row][col] == 'X' || isVisited[row, col])
                    continue;
                
                int sum = 0;
                Queue<(int row, int col)> queue = new Queue<(int, int)>();
                queue.Enqueue((row, col));
                isVisited[row, col] = true;
                
                while (queue.Count > 0)
                {
                    (int currentRow, int currentCol) = queue.Dequeue();
                    sum += maps[currentRow][currentCol] - '0';
                    for (int dir = 0; dir < 4; dir++)
                    {
                        int nextRow = currentRow + deltaRow[dir];
                        int nextCol = currentCol + deltaCol[dir];
                        
                        if (nextRow < 0 || nextRow >= rows || nextCol < 0 || nextCol >= cols)
                            continue;
                        if (maps[nextRow][nextCol] == 'X' || isVisited[nextRow, nextCol])
                            continue;
                        
                        isVisited[nextRow, nextCol] = true;
                        queue.Enqueue((nextRow, nextCol));
                    }
                }
                days.Add(sum);
            }
        }
        if (days.Count == 0)
            return new int[] { -1 };
        days.Sort();
        return days.ToArray();
    }
}