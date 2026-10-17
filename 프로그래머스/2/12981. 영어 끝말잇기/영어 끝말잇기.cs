using System;
using System.Collections.Generic;

class Solution
{
    public int[] solution(int n, string[] words)
    {
        HashSet<string> usedWords = new HashSet<string>();

        for (int index = 0; index < words.Length; index++)
        {
            string word = words[index];
            bool isDuplicate = usedWords.Contains(word);
            bool isWrongStart = index > 0 && word[0] != words[index - 1][words[index - 1].Length - 1];

            if (isDuplicate || isWrongStart)
            {
                int personNumber = index % n + 1;
                int turn = index / n + 1;
                return new int[] { personNumber, turn };
            }


            usedWords.Add(word);
        }


        return new int[] { 0, 0 };
    }
}