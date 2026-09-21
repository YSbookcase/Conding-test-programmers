using System;

public class Solution {
    public int solution(int a, int b, int n) {
        
        int answer = 0;
        while (n >= a)
        {
            int refilled = (n / a) * b;
            int remain = n % a;
            answer += refilled;
            n = refilled + remain;
        }
        return answer;
    }
}