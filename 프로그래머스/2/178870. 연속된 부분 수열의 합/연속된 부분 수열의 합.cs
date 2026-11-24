using System;

public class Solution {
    public int[] solution(int[] sequence, int k) {
        
        int left = 0;
        int sum = 0;
        int bestLength = sequence.Length + 1;
        int bestLeft = 0;
        int bestRight = 0;
        for (int right = 0; right < sequence.Length; right++)
        {
            sum += sequence[right];
            while (left <= right && sum > k)
            {
                sum -= sequence[left];
                left++;
            }
            if (sum == k)
            {
                int length = right - left + 1;
                if (length < bestLength)
                {
                    bestLength = length;
                    bestLeft = left;
                    bestRight = right;
                }
            }
        }
        return new int[] { bestLeft, bestRight };
    }
    
}