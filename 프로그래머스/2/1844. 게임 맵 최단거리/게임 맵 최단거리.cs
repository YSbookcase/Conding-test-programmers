using System;
using System.Collections.Generic;

class Solution {
    public int solution(int[,] maps) {

      int rowCount = maps.GetLength(0);
      int colCount = maps.GetLength(1);
      int[] dRow = { -1, 1, 0, 0 };
      int[] dCol = { 0, 0, -1, 1 };

      bool[,] isVisited = new bool[rowCount, colCount];
      Queue<(int row, int col, int dist)> queue = new Queue<(int row, int col, int dist)>();

      queue.Enqueue((0, 0, 1));
      isVisited[0, 0] = true;

      while (queue.Count > 0)
      {
          (int row, int col, int dist) = queue.Dequeue();

          if (row == rowCount - 1 && col == colCount - 1)
          {
              return dist;
          }

          for (int dir = 0; dir < 4; dir++)
          {
              int nextRow = row + dRow[dir];
              int nextCol = col + dCol[dir];

              bool isOut = nextRow < 0 || nextRow >= rowCount || nextCol < 0 || nextCol >= colCount;
              if (isOut)
              {
                  continue;
              }

              if (maps[nextRow, nextCol] == 0 || isVisited[nextRow, nextCol])
              {
                  continue;
              }

              isVisited[nextRow, nextCol] = true;
              queue.Enqueue((nextRow, nextCol, dist + 1));

          }
      }

      return -1;
  }
}