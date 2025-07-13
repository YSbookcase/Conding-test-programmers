using System;

public class Solution {
    public int solution(int n, int t) {
                   int answer = 0;
            int value = 0;
       
            int.TryParse(Math.Pow(2, t).ToString(), out value);
            answer = n * value;

            return answer;
    }
}