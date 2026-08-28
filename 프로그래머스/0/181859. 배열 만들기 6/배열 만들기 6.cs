using System;
using System.Collections.Generic;

public class Solution {
    public int[] solution(int[] arr) {
       
        int[] stk = new int[arr.Length];
        int index = 0;
        
        for(int i = 0; i < arr.Length; i++)
        {
            if(index == 0)
            {
            stk[index] = arr[i];
                index++;
            }
            else if (stk[index -1] == arr[i])
            {
                index--;
            }
            else
            {
                stk[index] = arr[i];
                index++;
            }
            
        }
        
        if(index == 0)
        {
            return new int[] {-1};
        }
        
        
        int[] result = new int[index];
         Array.Copy(stk, result, index);
        return result;
        
//         List<int> stk = new List<int>();
        
//         for(int i = 0; i < arr.Length; i++)
//         {
//             if(stk.Count == 0)
//                 stk.Add(arr[i]);
//             else if(stk[stk.Count - 1] == arr[i])
//                 stk.RemoveAt(stk.Count - 1);
//             else
//                 stk.Add(arr[i]);
//         }
        
//         return stk.Count == 0 ? new int[] {-1} : stk.ToArray();
        
        
    }
}