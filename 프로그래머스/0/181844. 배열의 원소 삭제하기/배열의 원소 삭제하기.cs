using System;
using System.Collections.Generic;
using System.Linq;

public class Solution {
    public int[] solution(int[] arr, int[] delete_list) {
        
//         List<int> result = new List<int>();
   
//         foreach(int num in arr)
//         {
//             if (Array.IndexOf(delete_list, num) == -1)
//             {
//                 result.Add(num);
//             }
//         }
        
//         return result.ToArray();
        
        // return arr.Where(x => !delete_list.Contains(x)).ToArray();
        
        HashSet<int> deleteSet = new HashSet<int>(delete_list);
        
        return arr.Where(x => !deleteSet.Contains(x)).ToArray();
        
    }
}