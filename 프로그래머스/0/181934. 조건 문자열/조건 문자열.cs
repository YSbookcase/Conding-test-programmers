using System;

public class Solution {
    public int solution(string ineq, string eq, int n, int m) {
        int answer = 0;
        
        if(ineq == ">" && eq == "=" && n >= m)
        {
            return answer = 1;
        }
        else if(ineq == "<" && eq == "=" && n <= m)
        {
            return answer = 1;
        }
        else if(ineq == ">" && eq == "!" && n > m)
        {
            return answer = 1;
        }
        else if(ineq == "<" && eq == "!" && n < m)
        {
            return answer = 1;
        }
        else
        {
            return answer = 0;
        }
        
        return answer = 0;
    }
}