using System;

public class Solution {
    public int solution(int[] array, int height) {
        int answer = 0;
   
        
        for (int i = 0; i < array.Length; i++)
        {
            
            if(height < array[i])
            {
                answer +=1;
            }
            
        }
        
        return answer;
    }
}