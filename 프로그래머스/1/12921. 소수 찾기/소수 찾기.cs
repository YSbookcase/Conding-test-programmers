using System;
using System.Collections.Generic;

public class Solution {
    public int solution(int n) {
                
//         bool[] isPrime = new bool[n + 1];
//         if (n >= 2)
//         {
//             isPrime[2] = true;
//         }


//         for (int number = 3; number <= n; number += 2)
//         {
//             isPrime[number] = true;
//         }

//         int limit = (int)Math.Sqrt(n);
//         for (int number = 3; number <= limit; number +=2)
//         {
//             if (!isPrime[number])
//             {
//                 continue;
//             }

//             for (int multiple = number * number; multiple <= n; multiple += number * 2)
//             {
//                 isPrime[multiple] = false;
//             }
//         }

//         int primeCount = n >= 2 ? 1 : 0;
//         for (int number = 3; number <= n; number += 2)
//         {
//             if (isPrime[number])
//             {
//                 primeCount++;
//             }
//         }

//         return primeCount;
//     }
        
               if (n < 2)
       {
           return 0;
       }

       int root = (int)Math.Sqrt(n);
       List<int> primes = PrimesUpTo(root);
       int primeIndex = primes.Count;
       var memo = new Dictionary<(int value, int primeIndex), int>();
       return Phi(n, primeIndex, primes, memo) + primeIndex - 1;
   }

   int Phi(int value, int primeIndex, List<int> primes, Dictionary<(int value, int primeIndex), int> memo)
   {
       if (primeIndex == 0 || value < 2)
       {
           return value;
       }

       if (value < primes[primeIndex - 1])
       {
           return 1;
       }

       var key = (value, primeIndex);
       if (memo.TryGetValue(key, out int cached))
       {
           return cached;
       }

       int prime = primes[primeIndex - 1];
       int count = Phi(value, primeIndex - 1, primes, memo) - Phi(value / prime, primeIndex - 1, primes, memo);
       memo[key] = count;
       return count;
   }

   List<int> PrimesUpTo(int limit)
   {
       var primes = new List<int>();
       if (limit < 2)
       {
           return primes;
       }

       bool[] isPrime = new bool[limit + 1];
       for (int number = 2; number <= limit; number++)
       {
           isPrime[number] = true;
       }

       int root = (int)Math.Sqrt(limit);
       for (int number = 2; number <= root; number++)
       {
           if (!isPrime[number])
           {
               continue;
           }

           for (int multiple = number * number; multiple <= limit; multiple += number)
           {
               isPrime[multiple] = false;
           }
       }

       for (int number = 2; number <= limit; number++)
       {
           if (isPrime[number])
           {
               primes.Add(number);
           }
       }

       return primes;
   }
        
}