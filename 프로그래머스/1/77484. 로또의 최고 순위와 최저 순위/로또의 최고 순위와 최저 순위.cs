using System;

public class Solution {
    public int[] solution(int[] lottos, int[] win_nums) {
        
        int matchCount = 0;
        int zeroCount = 0;

        for (int i = 0; i < lottos.Length; i++)
        {
            if (lottos[i] == 0)
            {
                zeroCount++;
                continue;
            }

            for (int j = 0; j < win_nums.Length; j++)
            {
                if (lottos[i] != win_nums[j]) continue;
                matchCount++;
                break;
            }
        }

        int bestRank = Rank(matchCount + zeroCount);
        int worstRank = Rank(matchCount);
        return new int[] { bestRank, worstRank };

    }

    int Rank(int count)
    {
        if (count < 2) return 6;
        return 7 - count;
    }
}