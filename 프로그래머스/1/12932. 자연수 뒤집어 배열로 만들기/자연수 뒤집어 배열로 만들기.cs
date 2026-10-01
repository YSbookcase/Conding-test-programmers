using System;
using System.Collections.Generic;

public class Solution {
    public int[] solution(long n) {
        List<int> digits = new List<int>();
        while (n > 0)
        {
            digits.Add((int)(n % 10));
            n /= 10;
        }

        return digits.ToArray();
    }
}