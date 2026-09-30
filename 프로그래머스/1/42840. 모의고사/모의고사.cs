using System;
using System.Collections.Generic;
using System.Linq;

public class Solution {
    public int[] solution(int[] answers) {
        
        int[][] patterns =
        {
            new[] {1,2,3,4,5},
            new[] {2,1,2,3,2,4,2,5},
            new[] {3,3,1,1,2,2,4,4,5,5}
        };

        int[] scores = new int[3];
        for (int i = 0; i < answers.Length; i++)
        {
            for (int person = 0; person < patterns.Length; person++)
            {
                if (answers[i] == patterns[person][i % patterns[person].Length])
                {
                    scores[person]++;
                }
            }
        }

        int maxScore = scores.Max();
        List<int> result = new List<int>();
        for (int person = 0; person < scores.Length; person++)
        {
            if (scores[person] == maxScore)
            {
                result.Add(person + 1);
            }
        }

        return result.ToArray();
    }
}