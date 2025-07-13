using System;

public class Solution {
    public int solution(int[] sides) {
            int answer = 0;

            Array.Sort(sides);
            if (sides[0] + sides[1] > sides[2])
            {
                answer = 1; 
            }
            else
            {
                answer = 2;
            }


            return answer;
        }

}