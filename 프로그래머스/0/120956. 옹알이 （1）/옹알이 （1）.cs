using System;

public class Solution {
    public int solution(string[] babbling) {
             int count = 0;

            foreach (string s in babbling)
            {
                if (CanPronounce(s)) count++;
            }

            return count;
        }

        private  bool CanPronounce(string s)
        {
            string[] words = { "aya", "ye", "woo", "ma" };
            int i = 0;

            while (i < s.Length)
            {
                bool matched = false;

                for (int k = 0; k < words.Length; k++)
                {
                    string w = words[k];
                    if (i + w.Length <= s.Length && s.Substring(i, w.Length) == w)
                    {
                        i += w.Length;
                        matched = true;
                        break;
                    }
                }

                if (!matched) return false;
            }

            return true;
        }
}