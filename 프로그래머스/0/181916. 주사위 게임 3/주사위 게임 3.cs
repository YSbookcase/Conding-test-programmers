using System;

public class Solution {
    public int solution(int a, int b, int c, int d) {
        int answer = 0;
        
        int[] count = new int[7];
        
        count[a]++;
        count[b]++;
        count[c]++;
        count[d]++;


        // 4개 같음
        for(int i = 1 ; i <= 6; i++)
        {
            if(count[i] == 4)
            {
                return 1111 * i;
            }
        }
        
        // 3개 + 1개
        int p = 0;
        int q = 0;
        
        for(int i = 1; i <= 6; i++)
        {
            if(count[i] == 3)
            {
                p = i;
            }
            else if(count[i] == 1)
            {
                q = i;
            }
            
                       
        }
        
        
        if(p != 0 && q !=0)
        {
            return (int)Math.Pow((10 * p + q), 2);    
        }

        // 2개 + 2개
        int firstPair = 0;
        int secondPair = 0;
        
        for(int i = 1; i <= 6; i++)
        {
            if(count[i] == 2)
            {
                if(firstPair == 0)
                {
                    firstPair = i;    
                }
                else
                {
                    secondPair = i;
                }
                
                
            }
        }
        
        if(firstPair != 0 && secondPair != 0)
        {
            return (firstPair + secondPair) * Math.Abs(firstPair - secondPair);
        }
        
        
        // 2개 +1개 +1개
        int single1 = 0;
        int single2 = 0;
        
        for(int i = 1; i <= 6; i++)
        {
            if(count[i] == 1)
            {
                if(single1 == 0)
                {
                    single1 = i;
                }
                else
                {
                    single2 = i;
                }
            }
        }
        
        if(single1 != 0 && single2 != 0 && firstPair !=0 && secondPair == 0 )
        {
            return single1 * single2;
        }
        
        // 전부 다름
        for(int i = 1; i <= 6; i++)
        {
            if(count[i] == 1)
            {
                return i;
            }
        }
        return answer;
    }
}