using System;

public class Solution {
    public int[] solution(string[] keymap, string[] targets) {
                int[] minPress = new int[26];

        for(int i = 0; i < keymap.Length; i++)
        {
            for (int j = 0; j < keymap[i].Length; j++)
            {
                int index = keymap[i][j] - 'A';
                int pressCount = j + 1;

                if (minPress[index] == 0 || minPress[index] > pressCount)
                {
                    minPress[index] = pressCount;
                }
            }
        }

        int[] answer = new int[targets.Length];

        for(int t = 0; t < targets.Length; t++)
        {
            int sum = 0;
            bool canType = true;

            foreach (char ch in targets[t])
            {
                int pressCount = minPress[ch - 'A'];
                if (pressCount == 0)
                {
                    canType = false;
                    break;
                }
                sum += pressCount;
            }

            answer[t] = canType ? sum : -1;
        }


        return answer;
    }
}