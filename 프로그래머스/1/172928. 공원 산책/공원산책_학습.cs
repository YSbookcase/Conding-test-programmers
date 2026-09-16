using System;

// 공원 산책 — 명령마다 경로를 미리 스캔한 뒤, 가능할 때만 위치 갱신
public class Solution
{
    public int[] solution(string[] park, string[] routes)
    {
        int height = park.Length;
        int width = park[0].Length;

        int row = 0;
        int col = 0;
        for (int r = 0; r < height; r++)
        {
            for (int c = 0; c < width; c++)
            {
                if (park[r][c] == 'S')
                {
                    row = r;
                    col = c;
                }
            }
        }

        foreach (string route in routes)
        {
            string[] parts = route.Split(' ');
            string op = parts[0];
            int step = int.Parse(parts[1]);

            int dRow = 0;
            int dCol = 0;
            switch (op)
            {
                case "N":
                    dRow = -1;
                    break;
                case "S":
                    dRow = 1;
                    break;
                case "W":
                    dCol = -1;
                    break;
                case "E":
                    dCol = 1;
                    break;
            }

            int nextRow = row;
            int nextCol = col;
            bool canMove = true;

            for (int i = 0; i < step; i++)
            {
                nextRow += dRow;
                nextCol += dCol;

                if (nextRow < 0 || nextRow >= height || nextCol < 0 || nextCol >= width)
                {
                    canMove = false;
                    break;
                }
                if (park[nextRow][nextCol] == 'X')
                {
                    canMove = false;
                    break;
                }
            }

            if (canMove)
            {
                row = nextRow;
                col = nextCol;
            }
        }

        return new int[] { row, col };
    }
}
