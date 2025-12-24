using System;

public class Solution {
    public int solution(int a, int b) {
            int g = Gcd(a, b);
            b /= g; // 기약분수의 분모

            // 2 제거
            while (b % 2 == 0)
            {
                b /= 2;
            }

            while (b % 5 == 0)
            {
                b /= 5;
            }

            return b == 1 ? 1 : 2;

        }

        private int Gcd(int x, int y)
        {
            while (y != 0)
                {
                int temp = y;
                y = x % y;
                x = temp;
            }

            return x;
        }
}