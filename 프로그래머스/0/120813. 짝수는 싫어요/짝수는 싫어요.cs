using System;

public class Solution {
    public int[] solution(int n) 
    {
             int[] answer = new int[] { };
        
        
            if (n % 2 == 0)
            {
                answer = new int[n / 2];
            }
            else if (n % 2 == 1)
            {
                answer = new int[n / 2 + 1];
            }

            int idx = 0;
    
            for (int i = 1; i <= n; i++)
            {
                if (i % 2 == 1)
                {

                    answer[idx++] = i;
                }

            }

            return answer;
}
}