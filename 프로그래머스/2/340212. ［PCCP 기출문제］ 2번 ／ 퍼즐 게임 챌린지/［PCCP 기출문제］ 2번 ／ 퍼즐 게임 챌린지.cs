using System;

public class Solution {
    public int solution(int[] diffs, int[] times, long limit) {
        
        int low = 1;
        int high = 0;
        foreach (int diff in diffs)
        {
            if (diff > high)
                high = diff;
        }
        int answer = high;
        while (low <= high)
        {
            int level = low + (high - low) / 2;
            if (CanClear(diffs, times, limit, level))
            {
                answer = level;
                high = level - 1;
            }
            else
            {
                low = level + 1;
            }
        }
        return answer;
    }
    bool CanClear(int[] diffs, int[] times, long limit, int level)
    {
        long total = 0;
        for (int i = 0; i < diffs.Length; i++)
        {
            if (diffs[i] <= level)
            {
                total += times[i];
            }
            else
            {
                long mistakes = diffs[i] - level;
                long prev = i == 0 ? 0 : times[i - 1];
                total += (times[i] + prev) * mistakes + times[i];
            }
            if (total > limit)
                return false;
        }
        return true;
    }
}