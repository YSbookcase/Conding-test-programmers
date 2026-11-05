using System;

public class Solution {
    public long solution(int w, int h)
    {
        long width = w;
        long height = h;
        long brokenCount = width + height - Gcd(width, height);
        return width * height - brokenCount;
    }

    long Gcd(long a, long b)
    {
        while (b != 0)
        {
            long remain = a % b;
            a = b;
            b = remain;
        }

        return a;
    }
}