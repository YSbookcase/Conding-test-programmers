using System;
using System.Collections.Generic;

public class Solution {
    public int solution(int[] picks, string[] minerals) {
        
        int pickCount = picks[0] + picks[1] + picks[2];
        int maxMine = Math.Min(minerals.Length, pickCount * 5);
        List<int[]> groups = new List<int[]>(); // [dia, iron, stone] 개수
        for (int i = 0; i < maxMine; i += 5)
        {
            int[] count = new int[3];
            int end = Math.Min(i + 5, maxMine);
            for (int j = i; j < end; j++)
            {
                if (minerals[j] == "diamond") count[0]++;
                else if (minerals[j] == "iron") count[1]++;
                else count[2]++;
            }
            groups.Add(count);
        }
        // 돌 곡괭이 기준 피로도 내림차순
        groups.Sort((a, b) =>
            (b[0] * 25 + b[1] * 5 + b[2]).CompareTo(a[0] * 25 + a[1] * 5 + a[2]));
        int fatigue = 0;
        int[] remain = { picks[0], picks[1], picks[2] };
        foreach (int[] group in groups)
        {
            int pickType;
            if (remain[0] > 0) { remain[0]--; pickType = 0; }
            else if (remain[1] > 0) { remain[1]--; pickType = 1; }
            else if (remain[2] > 0) { remain[2]--; pickType = 2; }
            else break;
            if (pickType == 0)
                fatigue += group[0] + group[1] + group[2];
            else if (pickType == 1)
                fatigue += group[0] * 5 + group[1] + group[2];
            else
                fatigue += group[0] * 25 + group[1] * 5 + group[2];
        }
        return fatigue;
    }
}