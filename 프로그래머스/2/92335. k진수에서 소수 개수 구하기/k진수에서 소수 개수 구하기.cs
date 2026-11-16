using System;

public class Solution {
    public int solution(int n, int k) {
                
        string converted = ConvertToBase(n, k);
        string[] parts = converted.Split('0');
        int primeCount = 0;
        foreach (string part in parts)
        {
            if (part.Length == 0)
                continue;
            long number = long.Parse(part);
            if (IsPrime(number))
                primeCount++;
        }
        return primeCount;
    }

    string ConvertToBase(int n, int k)
    {
        if (n == 0)
            return "0";

        string result = "";
        while (n > 0)
        {
            result = (n % k) + result;
            n /= k;
        }
        return result;
    }

    bool IsPrime(long number)
    {
        if (number < 2)
            return false;

        for (long divisor = 2; divisor * divisor <= number; divisor++)
        {
            if (number % divisor == 0)
                return false;
        }

        return true;
    }
}