using System;

public class Solution {
    public int[] solution(int rows, int columns, int[,] queries)
    {
        int[,] board = new int[rows + 1, columns + 1];
        int number = 1;
        for (int row = 1; row <= rows; row++)
        {
            for (int col = 1; col <= columns; col++)
                board[row, col] = number++;
        }
        int queryCount = queries.GetLength(0);
        int[] answer = new int[queryCount];
        for (int index = 0; index < queryCount; index++)
        {
            int x1 = queries[index, 0];
            int y1 = queries[index, 1];
            int x2 = queries[index, 2];
            int y2 = queries[index, 3];
            answer[index] = Rotate(board, x1, y1, x2, y2);
        }
        return answer;


    }

    int Rotate(int[,] board, int x1, int y1, int x2, int y2)
    {
        int previous = board[x1, y1];
        int minValue = previous;
        // 위쪽: 왼 -> 오
        for (int col = y1 + 1; col <= y2; col++)
        {
            int current = board[x1, col];
            board[x1, col] = previous;
            previous = current;
            minValue = Math.Min(minValue, previous);
        }
        // 오른쪽: 위 -> 아래
        for (int row = x1 + 1; row <= x2; row++)
        {
            int current = board[row, y2];
            board[row, y2] = previous;
            previous = current;
            minValue = Math.Min(minValue, previous);
        }
        // 아래쪽: 오 -> 왼
        for (int col = y2 - 1; col >= y1; col--)
        {
            int current = board[x2, col];
            board[x2, col] = previous;
            previous = current;
            minValue = Math.Min(minValue, previous);
        }
        // 왼쪽: 아래 -> 위
        for (int row = x2 - 1; row >= x1; row--)
        {
            int current = board[row, y1];
            board[row, y1] = previous;
            previous = current;
            minValue = Math.Min(minValue, previous);
        }
        return minValue;
    }
}