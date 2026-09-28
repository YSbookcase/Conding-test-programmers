using System;

public class Solution {
    public int solution(int[] numbers) {
        int result   = 45;

        for (int i = 0; i < numbers.Length; i++)
        {
            result -= numbers[i];
        }

        return result;
    }
}