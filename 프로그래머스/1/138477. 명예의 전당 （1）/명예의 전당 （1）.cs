using System;
using System.Linq;
using System.Collections.Generic;

public class Solution {
    public int[] solution(int k, int[] score) {
                int[] answer = new int[score.Length];

        List<int> hall = new List<int>();

        for (int i = 0; i < score.Length; i++)
        {
            if (hall.Count < k)
            {
                hall.Add(score[i]);

            }
            else
            {
                int minScore = hall.Min();
                if(score[i] > minScore)
                {
                    hall.Remove(minScore);
                    hall.Add(score[i]);
                }
            }
      

            answer[i] = hall.Min();
        }


        return answer;
    }
}