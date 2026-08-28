using System;
using System.Collections.Generic;

public class Solution {
    public int[] solution(int[] arr) {
        
//         List<int> x = new List<int>();
        
//         for(int i = 0; i < arr.Length; i++)
//         {
//             int num = arr[i];
            
            
//             for(int j = 0; j < num; j++ )
//             {
//                 x.Add(num);
                
//             }
            
//         }
        
//         return x.ToArray();
        
        
        int totalLength = 0;
        
        for(int i = 0; i < arr.Length; i++)
        {
            totalLength += arr[i];
            
        }
        
        int[] answer = new int[totalLength];
        int index = 0;
        
        for (int i = 0; i < arr.Length; i++)
        {
            for (int j = 0; j < arr[i]; j++)
            {
                answer[index++] = arr[i];
            }
        }
        
        return answer;
    }
}