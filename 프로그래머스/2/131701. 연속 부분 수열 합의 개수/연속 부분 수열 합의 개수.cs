using System;
using System.Collections.Generic;

public class Solution {
    public int solution(int[] elements) {
                
        int length = elements.Length;
        HashSet<int> sums = new HashSet<int>();
        for (int windowSize = 1; windowSize <= length; windowSize++)
        {
            int sum = 0;
            for (int i = 0; i < windowSize; i++)
                sum += elements[i];
            sums.Add(sum);
            
            // 시작점만 0 ~ length-1, 원형은 %로 다음 칸
            for (int start = 1; start < length; start++)
            {
                sum -= elements[start - 1];
                sum += elements[(start + windowSize - 1) % length];
                sums.Add(sum);
            }
        }
        return sums.Count;
    }
}