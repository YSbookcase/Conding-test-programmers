using System;

public class Solution {
    public int solution(int[,] signals) {

        int n = signals.GetLength(0);

        int[] period = new int[n];
        for(int i = 0; i < n; i++)
        {
            period[i] = signals[i, 0] + signals[i, 1] + signals[i, 2];
        }
        
        int maxTime = period[0];
        for(int i = 1; i < n; i++)
        {
            maxTime = Lcm(maxTime, period[i]);
        }
        
        for (int t = 1; t <= maxTime; t++)
        {
            bool isAllYellow = true;
            
            for(int i = 0; i < n; i++)
            {
                int pos = (t -1) % period[i];
                int g = signals[i, 0];
                int y = signals[i, 1];

                if(pos < g || pos >= g + y)
                {
                    isAllYellow = false;
                    break;
                }
                
            }
            
           if(isAllYellow)
            {
                return t;
            }
            
        }
        
 
          return -1;
        }

    
    
        int Gcd(int a, int b)
        {
            while(b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            
            return a;
        }
        
        int Lcm(int a, int b)
        {
            return a / Gcd(a, b) * b;
        }

}