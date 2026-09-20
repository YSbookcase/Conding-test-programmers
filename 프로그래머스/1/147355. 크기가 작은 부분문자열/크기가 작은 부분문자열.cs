using System;

public class Solution {
    public int solution(string t, string p) {
                int answer = 0;
        long pNum = long.Parse(p);
        for(int i = 0; i < t.Length - p.Length + 1; i++)
        {
            long partNum = long.Parse(t.Substring(i, p.Length));
            if(partNum <= pNum)
            {
                answer++;
            }
        }

        return answer;
    }
}