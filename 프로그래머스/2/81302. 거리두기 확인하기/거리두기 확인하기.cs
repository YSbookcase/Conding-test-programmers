using System;

public class Solution {
    public int[] solution(string[,] places) {
               
        int[] answer = new int[5];

        for (int index = 0; index < 5; index++)
            answer[index] = IsKeepDistance(places, index) ? 1 : 0;

        return answer;
    }

    bool IsKeepDistance(string[,] places, int room)
    {
        for (int row = 0; row < 5; row++)
        {
            for (int col = 0; col < 5; col++)
            {
                if (places[room, row][col] != 'P')
                    continue;

                if (!IsPersonSafe(places, room, row, col))
                    return false;
            }
        }

        return true;
    }

    bool IsPersonSafe(string[,] places, int room, int row, int col)
    {
        int[] rowDelta1 = { -1, 1, 0, 0 };
        int[] colDelta1 = { 0, 0, -1, 1 };

        for (int direction = 0; direction < 4; direction++)
        {
            int nextRow = row + rowDelta1[direction];
            int nextCol = col + colDelta1[direction];
            if (IsPerson(places, room, nextRow, nextCol))
                return false;
        }

        for (int direction = 0; direction < 4; direction++)
        {
            int nextRow = row + rowDelta1[direction] * 2;
            int nextCol = col + colDelta1[direction] * 2;
            if (!IsPerson(places, room, nextRow, nextCol))
                continue;

            int midRow = row + rowDelta1[direction];
            int midCol = col + colDelta1[direction];
            if (places[room, midRow][midCol] != 'X')
                return false;
        }

        int[] rowDelta2 = { -1, -1, 1, 1 };
        int[] colDelta2 = { -1, 1, -1, 1 };

        for (int direction = 0; direction < 4; direction++)
        {
            int nextRow = row + rowDelta2[direction];
            int nextCol = col + colDelta2[direction];
            if (!IsPerson(places, room, nextRow, nextCol))
                continue;

            if (places[room, row][nextCol] != 'X' || places[room, nextRow][col] != 'X')
                return false;
        }

        return true;
    }

    bool IsPerson(string[,] places, int room, int row, int col)
    {
        if (row < 0 || row >= 5 || col < 0 || col >= 5)
            return false;
        return places[room, row][col] == 'P';
    }
}