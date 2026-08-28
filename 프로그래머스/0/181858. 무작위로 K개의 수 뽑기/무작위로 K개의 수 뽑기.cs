using System;
using System.Collections.Generic;

public class Solution {
    public int[] solution(int[] arr, int k) {
        
//         int[] result = new int[k];
//         Array.Fill(result, -1);
//         int index = 0;

//         for(int i = 0; i < arr.Length; i++)
//         {
            
//             if(index == k) break;
            
//             if(Array.IndexOf(result, arr[i], 0, index)== -1)
//                {
//                    result[index++] = arr[i];
//                }



//         }

//        if(index < k)
//        {
//            for(int i = index; i < k ; i++)
//            {
//                result[i] = -1;
//            }

//        }

//        return result;
        
        
        List<int> list = new List<int>();

        for( int i = 0; i < arr.Length; i++)
        {
            if(list.Count == k) break;

            if(!list.Contains(arr[i]))
            {
                list.Add(arr[i]);
            }
        }

        while(list.Count < k)
        {
            list.Add(-1);
        }

        return list.ToArray();
        
    }
}