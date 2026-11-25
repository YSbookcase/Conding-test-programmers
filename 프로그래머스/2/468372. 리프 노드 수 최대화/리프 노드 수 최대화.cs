using System;

public class Solution {
    public int solution(int dist_limit, int split_limit) {
       
        long answer = 1;

        for (long power2 = 1; power2 <= split_limit; power2 *= 2)
        {
            for (long power3 = 1; power2 * power3 <= split_limit; power3 *= 3)
            {
                long product = power2 * power3;
                long fullNodes = (power2 - 1) + power2 * (power3 - 1) / 2;
                if (fullNodes > dist_limit)
                    continue;

                answer = Math.Max(answer, product);
                long remain = dist_limit - fullNodes;

                if (product * 2 <= split_limit)
                {
                    long expanded = Math.Min(product, remain);
                    answer = Math.Max(answer, product + expanded);
                }

                if (product * 3 <= split_limit)
                {
                    long expanded = Math.Min(product, remain);
                    answer = Math.Max(answer, product + 2 * expanded);
                }
            }
        }

        return (int)answer;
    }
}