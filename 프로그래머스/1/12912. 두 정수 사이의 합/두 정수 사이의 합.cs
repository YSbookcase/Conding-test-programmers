using System;

public class Solution {
    public long solution(int a, int b) {
                
        long x = a;
        long y = b;

        return (y + x)*(Math.Abs(y - x) + 1) / 2;

    }
}