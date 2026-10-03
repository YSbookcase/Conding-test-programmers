using System;
using System.Text;

public class Solution {
    public string solution(string s) {
        
            StringBuilder result = new StringBuilder();
            int wordIndex = 0;

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == ' ')
                {
                    result.Append(' ');
                    wordIndex = 0;
                    continue;
                }


                if (wordIndex % 2 == 0)
                {
                    result.Append(char.ToUpper(s[i]));
                }
                else
                {
                    result.Append(char.ToLower(s[i]));

                }

                wordIndex++;

            }

            return result.ToString();
        }
}