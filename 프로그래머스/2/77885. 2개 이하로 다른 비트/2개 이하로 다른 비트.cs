using System;

public class Solution {
    public long[] solution(long[] numbers) {
                
        long[] result = new long[numbers.Length];

        for (int i = 0; i < numbers.Length; i++)
        {
            result[i] = NextNumber(numbers[i]);
        }

        return result;
    }


    long NextNumber(long number)
    {
        if (number % 2 == 0)
            return number + 1;

        long bit = 1;
        while ((number & bit) != 0)
            bit <<= 1;

        return (number | bit) - (bit >> 1);
    }
}