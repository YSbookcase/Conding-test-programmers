using System;

public class Solution {
    public int solution(string[] board) {

        int countO = 0;
        int countX = 0;
        foreach (string row in board)
        {
            foreach (char cell in row)
            {
                if (cell == 'O') countO++;
                else if (cell == 'X') countX++;
            }
        }
        if (countO < countX || countO > countX + 1)
            return 0;
        bool isOWin = HasWin(board, 'O');
        bool isXWin = HasWin(board, 'X');
        if (isOWin && isXWin)
            return 0;
        if (isOWin && countO != countX + 1)
            return 0;
        if (isXWin && countO != countX)
            return 0;
        return 1;
    }
    bool HasWin(string[] board, char mark)
    {
        for (int i = 0; i < 3; i++)
        {
            if (board[i][0] == mark && board[i][1] == mark && board[i][2] == mark)
                return true;
            if (board[0][i] == mark && board[1][i] == mark && board[2][i] == mark)
                return true;
        }
        if (board[0][0] == mark && board[1][1] == mark && board[2][2] == mark)
            return true;
        if (board[0][2] == mark && board[1][1] == mark && board[2][0] == mark)
            return true;
        return false;
    }
}