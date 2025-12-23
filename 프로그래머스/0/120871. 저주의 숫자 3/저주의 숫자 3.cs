using System;

public class Solution {
    public int solution(int n) {
        int count = 0;
        int num = 0;

        while (count < n)
        {
            num++;

            if (num % 3 == 0)
                continue;

            if (num.ToString().Contains("3"))
                continue;

            count++;
        }

        return num;

    }
}