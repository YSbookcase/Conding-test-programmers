using System;
using System.Collections.Generic;

public class Solution {
    public int[] solution(int[] progresses, int[] speeds)
    {
        List<int> answer = new List<int>();
        int deployDay = (100 - progresses[0] + speeds[0] - 1) / speeds[0];
        int count = 1;

        for (int index = 1; index < progresses.Length; index++)
        {
            int remainDay = (100 - progresses[index] + speeds[index] - 1) / speeds[index];

            if (remainDay <= deployDay)
            {
                count++;

            }
            else
            {
                answer.Add(count);
                deployDay = remainDay;
                count = 1;
            }
        }

        answer.Add(count);
        return answer.ToArray();
    }

}