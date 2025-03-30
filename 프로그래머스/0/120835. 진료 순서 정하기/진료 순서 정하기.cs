using System;
using System.Linq;

public class Solution {
    public int[] solution(int[] emergency) {
        return GetRanks(emergency);
    }

    private int[] GetRanks(int[] emergency)
    {
        var sorted = emergency
            .Select((value, index) => new { value, index })
            .OrderByDescending(x => x.value)
            .ToList();

        int[] answer = new int[emergency.Length];

        for (int i = 0; i < sorted.Count; i++)
        {
            answer[sorted[i].index] = i + 1;
        }

        return answer;
    }
}