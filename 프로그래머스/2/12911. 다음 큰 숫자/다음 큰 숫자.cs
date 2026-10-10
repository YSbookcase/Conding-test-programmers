using System;

class Solution 
{
    public int solution(int n) 
   {
        int targetCount = CountOnes(n);
        int nextNumber = n + 1;

        while (CountOnes(nextNumber) != targetCount)
        {
            nextNumber++;
        }

        return nextNumber;
    }

    int CountOnes(int number)
    {
        int oneCount = 0;

        while (number >0)
        {
            oneCount += number & 1;
            number >>= 1;
        }

        return oneCount;
    }
}