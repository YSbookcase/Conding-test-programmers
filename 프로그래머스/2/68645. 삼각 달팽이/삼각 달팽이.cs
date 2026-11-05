using System;

public class Solution {
    public int[] solution(int n) {
                
        int[][] triangle = new int[n][];
        for (int line = 0; line < n; line++)
        {
            triangle[line] = new int[line + 1];
        }

        int[] rowDelta = { 1, 0, -1 };
        int[] colDelta = { 0, 1, -1 };

        int row = 0;
        int col = 0;
        int direction = 0;
        int lastNumber = n * (n + 1) / 2;

        for (int number = 1; number <= lastNumber; number++)
        {
            triangle[row][col] = number;

            int nextRow = row + rowDelta[direction];
            int nextCol = col + colDelta[direction];
            bool canMove = nextRow >= 0 && nextRow < n
                && nextCol >= 0 && nextCol <= nextRow
                && triangle[nextRow][nextCol] == 0;

            if (!canMove)
            {
                direction = (direction + 1) % 3;
                nextRow = row + rowDelta[direction];
                nextCol = col + colDelta[direction];
            }

            row = nextRow;
            col = nextCol;
        }

        int[] answer = new int[lastNumber];
        int index = 0;
        for (int line = 0; line < n; line++)
        {
            for (int column = 0; column < triangle[line].Length; column++)
            {
                answer[index++] = triangle[line][column];
            }
        }

        return answer;
    }

    
}