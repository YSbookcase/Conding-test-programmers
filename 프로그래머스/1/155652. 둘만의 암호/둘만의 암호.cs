using System;
using System.Text;

public class Solution {
    public string solution(string s, string skip, int index) {
                StringBuilder result = new StringBuilder();

        int[] isSkip = new int[26];

        for (int i = 0; i < skip.Length; i++)
        {
            
            isSkip[skip[i] - 'a'] =  1;
        }

        foreach (char ch in s)
        {
            char current = ch;

            int step = 0;

            while ( step < index)
            {
                current = (char)((current - 'a' + 1) % 26 + 'a');
                if (isSkip[current - 'a'] == 0)
                {
                    step++;
                }
            }

            result.Append(current);
           
        }


        return result.ToString();
    }
}