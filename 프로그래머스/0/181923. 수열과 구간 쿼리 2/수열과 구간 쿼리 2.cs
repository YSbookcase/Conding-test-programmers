using System;

public class Solution {
    public int[] solution(int[] arr, int[,] queries) {
        int[] answer = new int[queries.GetLength(0)];
        
        for(int i = 0; i < queries.GetLength(0); i++)
        {
            int s = queries[i,0];
            int e = queries[i,1];
            int k = queries[i,2];
            
            int min = int.MaxValue;
            
            for(int j = s; j<= e; j++)
            {
                if(arr[j] > k && arr[j] < min)
                {
                    min = arr[j];
                    
                }
                
                if(min == int.MaxValue)
                {
                    answer[i] = -1;
                }
                else
                {
                    answer[i] = min;
                }
    
            }
            
    
            
        }
        
        return answer;
    }
}