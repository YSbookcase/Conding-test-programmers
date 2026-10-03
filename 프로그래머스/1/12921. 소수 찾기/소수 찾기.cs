using System;
using System.Collections.Generic;

public class Solution {
    public int solution(int n) {
                
        bool[] isPrime = new bool[n + 1];
        if (n >= 2)
        {
            isPrime[2] = true;
        }


        for (int number = 3; number <= n; number += 2)
        {
            isPrime[number] = true;
        }

        int limit = (int)Math.Sqrt(n);
        for (int number = 3; number <= limit; number +=2)
        {
            if (!isPrime[number])
            {
                continue;
            }

            for (int multiple = number * number; multiple <= n; multiple += number * 2)
            {
                isPrime[multiple] = false;
            }
        }

        int primeCount = n >= 2 ? 1 : 0;
        for (int number = 3; number <= n; number += 2)
        {
            if (isPrime[number])
            {
                primeCount++;
            }
        }

        return primeCount;
    }
        
 
        
}