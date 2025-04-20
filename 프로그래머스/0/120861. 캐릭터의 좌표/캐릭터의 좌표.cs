using System;
using System.Collections.Generic;

public class Solution {
    public int[] solution(string[] keyinput, int[] board)        {
            int[] position = new int[2];
            int maxX = board[0] / 2;
            int maxY = board[1] / 2;

           
            Dictionary<string, int[]> direction = new Dictionary<string, int[]>
{
    { "right", new int[] { 1, 0 } },
    { "left", new int[] { -1, 0 } },
    { "up", new int[] { 0, 1 } },
    { "down", new int[] { 0, -1 } }
};

            foreach (var key in keyinput)
            {
                if (!direction.ContainsKey(key)) continue;

                int nextX = position[0] + direction[key][0];
                int nextY = position[1] + direction[key][1];

                if (Math.Abs(nextX) <= maxX && Math.Abs(nextY) <= maxY)
                {
                    position[0] = nextX;
                    position[1] = nextY;
                }
            }

            return position;
        }
}