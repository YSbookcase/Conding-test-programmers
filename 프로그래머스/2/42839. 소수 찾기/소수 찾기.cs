using System;
using System.Collections.Generic;

public class Solution {
    public int solution(string numbers) {
                
        HashSet<int> madeNumbers = new HashSet<int>();
        bool[] isUsed = new bool[numbers.Length];

        void Collect(int current, bool hasDigit)
        {
            if (hasDigit)
                madeNumbers.Add(current);

            for (int index = 0; index < numbers.Length; index++)
            {
                if (isUsed[index])
                {
                    continue;
                }

                isUsed[index] = true;
                int digit = numbers[index] - '0';
                Collect(current * 10 + digit, true);
                isUsed[index] = false;

            }

        }

        Collect(0, false);

        int primeCount = 0;
        foreach (int number in madeNumbers)
        {
            if (IsPrime(number))
            {
                primeCount++;
            }
        }

        bool IsPrime(int number)
        {
            if (number < 2)
            {
                return false;
            }

            for (int divisor = 2; divisor * divisor <= number; divisor++)
            {
                if (number % divisor == 0)
                {
                    return false;
                }
            }

            return true;
        }


        return primeCount;
    }
}