using System;
using System.Collections.Generic;
public class Solution {
    public int[] solution(int[] arr) {

//         int targetLen = 1;
        
//         while(targetLen < arr.Length)
//         {
//             targetLen *= 2;
//         }
        
//         int[] result = new int[targetLen];
//         Array.Copy(arr, result, arr.Length);

//         return result;
        
        
        List<int> result = new List<int>(arr);
        
        int targetLen = 1;
        
        while(targetLen < arr.Length)
        {
            targetLen *= 2;
        }
        
        while (result.Count < targetLen)
        {
            result.Add(0);
        }
        
        return result.ToArray();
        
    }
}