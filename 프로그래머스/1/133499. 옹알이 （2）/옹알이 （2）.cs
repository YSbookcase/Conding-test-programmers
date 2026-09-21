using System;

public class Solution {
    public int solution(string[] babbling) {
        int answer = 0;

        string[] words = new string[] { "aya", "ye", "woo", "ma" };

        foreach(string part in babbling)
        {

            int i = 0;
            string last = "";
            bool canSpeak = true;

            while (i < part.Length)
            {
                bool isMatch = false;
                foreach (string w in words)
                {
                    if (i + w.Length <= part.Length 
                        && part.Substring(i, w.Length) == w
                        )
                    {
                        if (w == last)
                        {
                            canSpeak = false; 
                            break;
                        }
                        last = w;
                        i += w.Length;
                        isMatch = true;
                        break;

                    }
                }
                if(!isMatch) { canSpeak = false; break; }

            }
            if(canSpeak)
                answer++;
        }



        return answer;
    }
}