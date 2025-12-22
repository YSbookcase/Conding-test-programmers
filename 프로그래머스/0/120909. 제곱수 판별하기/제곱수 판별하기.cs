using System;

public class Solution {
    public int solution(int n) {
        
                int k = (int)Math.Sqrt(n);

                if (k * k == n)
                {
                   return 1;
                }
                else
                {
                    return 2;
                }
    }
}