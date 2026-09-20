using System;

public class Solution {
    public int[] solution(string s) {
        
        int[] answer = new int[s.Length];

        int[] lastIndex = new int[26];
        Array.Fill(lastIndex, -1);

        for(int i = 0; i < s.Length; i++)
        {
            char ch = s[i];
            int index = ch - 'a';

            if (lastIndex[index] == -1)
            {
                answer[i] = -1;
            }
            else
            {
                answer[i] = i - lastIndex[index];
            }
                lastIndex[index] = i;
        }

        return answer;
    }
}