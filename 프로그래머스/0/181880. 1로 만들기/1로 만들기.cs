using System;

public class Solution {
    public int solution(int[] num_list) {
        
        int resultSum = 0;
        
        for(int i = 0; i < num_list.Length; i++)
        {
            int checkNum = num_list[i];
        
            while(checkNum > 1)
            {

                
                if(checkNum % 2 == 0)
                {
                    checkNum /= 2;
                    
                }
                else
                {
                    checkNum = (checkNum-1)/2;
                    
                }
                
                resultSum++;

            }
            
        }
        
        return resultSum;
        
    }
}