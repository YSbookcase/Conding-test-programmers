using System;

public class Solution {
    
    
    private static readonly int[] primes = new int[]
  {
2, 3, 5, 7, 11, 13, 17, 19,
23, 29, 31, 37, 41, 43, 47,
53, 59, 61, 67, 71, 73, 79,
83, 89, 97
  };
    
    public int solution(int n)     { 
        if (n < 4) return 0;

        int primeCount = 0;
        foreach (int p in primes)
        {
            if (p > n) break;
            primeCount++;
        }

        return (n - 1) - primeCount;
    }

   
}