using System;

public class Solution {
    public int solution(int[] num_list) {
        
            int result;
        
             if(num_list.Length >= 11)
            {            
                result = 0;
                
                 for(int i = 0; i < num_list.Length; i++)
                {

                    result += num_list[i];

                }
                 
        
                 
            }   
            else
            {
                   result = 1;
                
                for(int i = 0; i < num_list.Length; i++)
                {
                 

                    result *= num_list[i];
                }
                
            }
           
                return result;
    
    }
        
 }
