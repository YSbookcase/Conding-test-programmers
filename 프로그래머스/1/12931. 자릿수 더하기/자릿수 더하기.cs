using System;

public class Solution {
    public int solution(int n) {
        
        int digitSum = 0;
        while(n > 0)
        {
            digitSum += n % 10;
            n /= 10;
        }
        
        return digitSum;
    }
}