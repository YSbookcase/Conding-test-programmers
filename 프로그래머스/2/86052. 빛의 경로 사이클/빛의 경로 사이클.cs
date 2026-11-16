using System;
using System.Collections.Generic;

public class Solution {
    public int[] solution(string[] grid) {
                
        int rowCount = grid.Length;
        int colCount = grid[0].Length;
        bool[,,] isVisited = new bool[rowCount, colCount, 4];
        List<int> cycleLengths = new List<int>();
        int[] rowDelta = { -1, 0, 1, 0 };
        int[] colDelta = { 0, 1, 0, -1 };
        for (int row = 0; row < rowCount; row++)
        {
            for (int col = 0; col < colCount; col++)
            {
                for (int dir = 0; dir < 4; dir++)
                {
                    if (isVisited[row, col, dir])
                        continue;
                    cycleLengths.Add(Follow(grid, isVisited, rowDelta, colDelta, row, col, dir));
                }
            }
        }
        cycleLengths.Sort();
        return cycleLengths.ToArray();
    }
    int Follow(string[] grid, bool[,,] isVisited, int[] rowDelta, int[] colDelta,
        int startRow, int startCol, int startDir)
    {
        int rowCount = grid.Length;
        int colCount = grid[0].Length;
        int row = startRow;
        int col = startCol;
        int dir = startDir;
        int length = 0;
        do
        {
            isVisited[row, col, dir] = true;
            length++;
            char cell = grid[row][col];
            if (cell == 'L')
                dir = (dir + 3) % 4;
            else if (cell == 'R')
                dir = (dir + 1) % 4;
            row = (row + rowDelta[dir] + rowCount) % rowCount;
            col = (col + colDelta[dir] + colCount) % colCount;
        }
        while (row != startRow || col != startCol || dir != startDir);
        return length;
    }
}