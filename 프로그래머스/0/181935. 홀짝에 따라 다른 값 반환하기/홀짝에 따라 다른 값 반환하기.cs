using System;

public class Solution {
    public int solution(int n) {
        int answer = 0;
        
        if(n%2 == 1)
        {
            for(int i = 1; 2*i-1 <= n ; i++)
            {
                answer = answer + 2*i-1;
            }
            
        
        }
        else if(n%2 == 0)
        {
            for(int i = 1; 2*i <= n; i++)
            {
            answer = answer + (2*i)*(2*i);
            }
            
          
        }
        
        
        return answer;
    }
}