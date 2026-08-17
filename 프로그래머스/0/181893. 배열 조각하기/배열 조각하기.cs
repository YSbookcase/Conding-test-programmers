using System;

public class Solution {
    public int[] solution(int[] arr, int[] query) {
      
       int start = 0;
        int end = arr.Length - 1;
        
        for(int i = 0; i < query.Length; i++)
        {
            if(i % 2 == 0)
            {
                end = start + query[i];
            }
            else
            {
                start = start + query[i];
                
            }
        }

        int[] result = new int[end - start + 1];
        
        for(int i = 0; i <result.Length; i++)
        {
            result[i] = arr[start +i];
        }
        return result;
    }
}