using System;

public class Solution
{
    public int solution(int i, int j, int k)
    {
        return (int)CountDigitInRange(i, j, k);
    }

    private long CountDigitInRange(int i, int j, int k)
    {
        if (i > j) return 0;
        return CountUpTo(j, k) - CountUpTo(i - 1, k);
    }

    private long CountUpTo(int N, int k)
    {
        if (N < 0) return 0;
        if (N == 0) return (k == 0) ? 1 : 0;

        long count = 0;
        long pos = 1;

        while (pos <= N)
        {
            long higher = N / (pos * 10);
            long current = (N / pos) % 10;
            long lower = N % pos;

            if (k != 0)
            {
                if (current > k) count += (higher + 1) * pos;
                else if (current == k) count += higher * pos + (lower + 1);
                else count += higher * pos;
            }
            else
            {
                if (higher != 0)
                {
                    if (current > 0) count += higher * pos;
                    else count += (higher - 1) * pos + (lower + 1);
                }
            }

            pos *= 10;
        }

        if (k == 0) count += 1; // 숫자 "0" 자체

        return count;
    }
}
