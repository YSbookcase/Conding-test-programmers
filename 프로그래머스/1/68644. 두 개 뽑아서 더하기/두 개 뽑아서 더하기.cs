using System;
using System.Collections.Generic;

public class Solution {
    public int[] solution(int[] numbers) {
        
        bool[] hasSum = new bool[201];

        for (int i = 0; i < numbers.Length - 1; i++)
        {
            for (int j = i + 1; j < numbers.Length; j++)
            {
                hasSum[numbers[i] + numbers[j]] = true;
            }
        }

        List<int> result = new List<int>();

        for (int sum = 0; sum <= 200; sum++)
        {
            if (hasSum[sum])
            {
                result.Add(sum);
            }
        }

        return result.ToArray();
    }
    
}