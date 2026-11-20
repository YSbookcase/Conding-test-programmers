using System;

public class Solution {
    public int solution(int n, long l, long r) {
        
        return (int)(Count(n, r) - Count(n, l - 1));
    }
    
    long Count(int n, long pos)
    {
        if (pos <= 0)
            return 0;
        if (n == 0)
            return 1; // "1"
        
        long unit = (long)Math.Pow(5, n - 1);
        long fullOnes = (long)Math.Pow(4, n - 1);
        int[] pattern = { 1, 1, 0, 1, 1 };
        
        long ones = 0;
        for (int i = 0; i < 5; i++)
        {
            if (pos >= unit * (i + 1))
            {
                if (pattern[i] == 1)
                    ones += fullOnes;
            }
            else
            {
                if (pattern[i] == 1)
                    ones += Count(n - 1, pos - unit * i);
                break;
            }
        }
        return ones;
    }
}