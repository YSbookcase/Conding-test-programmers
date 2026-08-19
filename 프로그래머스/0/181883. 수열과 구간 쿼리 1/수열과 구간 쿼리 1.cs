using System;

public class Solution {
    public int[] solution(int[] arr, int[,] queries) {
        
        
            
            for(int i = 0; i < queries.GetLength(0); i++)
            {
               
                    int start = queries[i,0];
                    int end = queries[i,1];
                    
                    for(int a = start; a <= end; a++)
                    {
                        arr[a] += 1;
                    }
                
            }
        
        return arr;
    }
}