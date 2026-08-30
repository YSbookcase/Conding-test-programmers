using System;
using System.Linq;

public class Solution {
    public int solution(int[] arr1, int[] arr2) {
        
//         int a =  arr1.Length;
//         int b = arr2.Length;
//         int aSum = 0;
//         int bSum = 0;
        
//         if(a< b)
//         {
//             return -1;
//         }
//         else if (b < a)
//         {
//             return 1;
//         }
//         else
//         {
//             for(int i = 0; i < arr1.Length; i++)
//             {
//                 aSum += arr1[i];
//             }
//             for(int i = 0; i < arr2.Length; i++)
//             {
//                 bSum += arr2[i];
//             }
            
//             if(aSum < bSum)
//             {
//                 return -1;
//             }
//             else if (aSum > bSum)
//             {
//                 return 1;
//             }
//             else
//             {
//                  return 0;
//             }
        
//             if(arr1.Length != arr2.Length)
//             {
//                 return arr1.Length > arr2.Length ? 1 : -1;
//             }
        
//             int sum1 = arr1.Sum();
//             int sum2 = arr2.Sum();
        
//             if(sum1 == sum2) return 0;
//             return sum1 > sum2 ? 1 : -1;
        
            if(arr1.Length != arr2.Length)
            {
                return arr1.Length.CompareTo(arr2.Length);
            }
        
            return arr1.Sum().CompareTo(arr2.Sum());
        
        }
    }
