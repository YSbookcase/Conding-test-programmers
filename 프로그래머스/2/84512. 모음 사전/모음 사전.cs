using System;

public class Solution {
    public int solution(string word) {
        
        string vowels = "AEIOU";
        int order = 0;
        int answer = 0;

        void Dfs(string current)
        {
            if (current.Length >= 5)
                return;

            foreach (char vowel in vowels)
            {
                string next = current + vowel;
                order++;
                if (next == word)
                    answer = order;
                Dfs(next);
            }
        }

        Dfs("");
        return answer;
    }
}