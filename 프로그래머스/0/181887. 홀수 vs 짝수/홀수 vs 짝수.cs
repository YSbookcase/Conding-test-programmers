using System;

public class Solution {
    public int solution(int[] num_list) {
        int oddSum = 0;
        int evenSum = 0;
        
//         for(int i = 0; i < num_list.Length; i++)
//         {
//             if((i+1)%2 != 0)
//             {
//                 oddSum += num_list[i];
//             }
//             else if( (i+1)%2 == 0)
//             {
//                 evenSum += num_list[i];
//             }
//         }
        
//         return oddSum > evenSum ? oddSum : evenSum;
//     }
        
        for(int i = 0; i < num_list.Length; i++)
        {
            if(i % 2 == 0)
            {
                oddSum += num_list[i];
            }
            else
            {
                evenSum += num_list[i];
            }
        }
        
        return Math.Max(evenSum, oddSum);
    }
        
}