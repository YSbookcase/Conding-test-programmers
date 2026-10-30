using System;
using System.Collections.Generic;

public class Solution {
    public int solution(string dirs) {
                
        HashSet<string> roads = new HashSet<string>();
        int currentX = 0;
        int currentY = 0;

        Dictionary<char, int[]> moves = new Dictionary<char, int[]>
        {
            ['U'] = new int[] { 0, 1 },
            ['D'] = new int[] { 0, -1 },
            ['R'] = new int[] { 1, 0 },
            ['L'] = new int[] { -1, 0 },
        };


        foreach (char direction in dirs)
        {

            int nextX = currentX + moves[direction][0];
            int nextY = currentY + moves[direction][1];

            if (nextX < -5 || nextX > 5 || nextY < -5 || nextY > 5)
            {
                continue;
            }

            roads.Add($"{currentX},{currentY},{nextX},{nextY}");
            roads.Add($"{nextX},{nextY},{currentX},{currentY}");

            currentX = nextX;
            currentY = nextY;

            
        }

        return roads.Count / 2;

    }
}