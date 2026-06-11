using System;
using System.Collections.Generic;

public class Solution {
    public int[] solution(int l, int r) {
    // ------------------문자열 검사 방식
//         List<int> result = new List<int>();
        
//         for(int i = l; i <= r; i++)
//         {
//             string str = i.ToString();
            
//             bool isValid = true;
            
//             foreach(char c in str)
//             {
//                 if(c != '0' && c != '5')
//                 {
//                     isValid = false;
//                     break;
//                 }
//             }
            
//             if(isValid)
//             {
//             result.Add(i);
//             }
//         }
        
//         if(result.Count == 0)
//         {
//             return new int[] {-1};
//         }
        
        
//         return result.ToArray();
        
        //------------------------------숫자 자릿 수 검사 방식
        
//                List<int> result = new List<int>();

//         for(int i = l; i <= r; i++)
//         {
//             int temp = i;
//             bool isValid = true;

//             while(temp > 0)
//             {
//                 int digit = temp % 10;

//                 if(digit != 0 && digit != 5)
//                 {
//                     isValid = false;
//                     break;
//                 }

//                 temp /= 10;
//             }

//             if(isValid)
//             {
//                 result.Add(i);
//             }
//         }

//         if(result.Count == 0)
//         {
//             return new int[] { -1 };
//         }

//         return result.ToArray();

        //------------------------ 이진수 활용 방식
              List<int> result = new List<int>();

        for(int i = 1; i <= 64; i++)
        {
            string binary = Convert.ToString(i, 2);
            string numStr = binary.Replace('1', '5');

            int num = int.Parse(numStr);

            if(l <= num && num <= r)
            {
                result.Add(num);
            }
        }

        if(result.Count == 0)
        {
            return new int[] { -1 };
        }

        return result.ToArray();  
    }
}