using System;

public class Solution {
    public int solution(int n) {
    int answer = 0;
    int i = 1;
    int result = 1;

   while(true)
    {
        result *= i;
        if (result > n)
        {
            return answer = i-1;
            
        }
        i++;
    }

    
}
}