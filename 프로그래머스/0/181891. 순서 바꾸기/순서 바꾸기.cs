using System;

public class Solution {
    public int[] solution(int[] num_list, int n) {
        
        int[] answer = new int[num_list.Length];
        
//         for(int i = 0; i < num_list.Length; i++)
//         {
//             if(n+i < num_list.Length)
//             answer[i] = num_list[ n+ i];
//             else
//                 answer[i] = num_list[n+i - num_list.Length];
            
//         }
        
        for(int i = 0; i < num_list.Length; i++)
        {
            answer[i] = num_list[(n+i)%num_list.Length];
        }
        
            return  answer;
    }
}