using System;

class Solution
{
    public int solution(int[] nums)
    {
        
        bool[] isPrime = new bool[3001];
        for (int number = 0; number <= 3000; number++)
        {
            isPrime[number] = true;
        }

        for (int number = 2; number < 3000; number++)
        {
            if (!isPrime[number])
            {
                continue;
            }

            for (int multiple = number * number; multiple <= 3000; multiple += number)
            {
                isPrime[multiple] = false;
            }
        }

        int primeCount =0;
        for (int i = 0; i < nums.Length; i++)
        {
            for (int j = i+1; j < nums.Length; j++)
            {
                for (int k = j + 1; k < nums.Length; k++)
                {
                    if (isPrime[nums[i] + nums[j] + nums[k]])
                    {
                        primeCount++;
                    }
                }
            }
        }

        return primeCount;
    }
}