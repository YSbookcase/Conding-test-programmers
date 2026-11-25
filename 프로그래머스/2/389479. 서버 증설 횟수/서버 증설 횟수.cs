using System;

public class Solution {
    public int solution(int[] players, int m, int k) {
        
        int[] added = new int[24];
        int answer = 0;
        
        for (int hour = 0; hour < 24; hour++)
        {
            int running = 0;
            int start = hour - k + 1;
            if (start < 0)
                start = 0;
            
            for (int time = start; time < hour; time++)
                running += added[time];
            
            int need = players[hour] / m;
            if (need > running)
            {
                added[hour] = need - running;
                answer += added[hour];
            }
        }
        return answer;
    }
}