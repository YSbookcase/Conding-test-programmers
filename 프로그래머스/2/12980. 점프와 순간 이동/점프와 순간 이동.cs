using System;

class Solution
{
    public int solution(int n)
    {
        int battery = 0;

        while (n > 0)
        {
            battery += n % 2;
            n /= 2;
        }

        return battery;
    }
}