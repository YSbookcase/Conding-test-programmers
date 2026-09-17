using System;

public class Solution {
    public int solution(int n, int m, int[] section) {
        int answer = 0;
        int coverEnd = 0;


        foreach(int part in section)
        {
            if (part <= coverEnd)
            {
                continue;
            }

            coverEnd = part + m -1;
            answer++;
        }


        return answer;
    }
}