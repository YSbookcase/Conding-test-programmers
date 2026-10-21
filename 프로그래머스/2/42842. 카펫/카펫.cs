using System;

public class Solution {
    public int[] solution(int brown, int yellow) {
                
        for (int innerHeight = 1; innerHeight * innerHeight <= yellow; innerHeight++)
        {
            if (yellow % innerHeight != 0)
            {
                continue;
            }

            int innerWidth = yellow / innerHeight;
            int width = innerWidth + 2;
            int height = innerHeight + 2;

            if (2 * (width + height - 2) == brown)
            {
                return new int[] { width, height };

            }
        }

        return new int[] { 0, 0 };
    }

}