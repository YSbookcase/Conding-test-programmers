using System;

public class Solution {
    public bool solution(bool x1, bool x2, bool x3, bool x4) {
        bool answer = true;
        
//         bool result1 = true;
//         bool result2 = true;
        
//         if(x1 == false && x2 == false)
//         {
//             result1 = false;
//         }
//         else
//         {
//             result1 = true;
//         }
        
//         if(x3 == false && x4 == false)
//         {
//             result2 = false;
//         }
//         else
//         {
//             result2 = true;
//         }
        
//         if(result1 == true && result2 == true)
//         {
//             answer = true;
//         }
//         else
//         {
//             answer = false;
//         }
        
        
        answer = (x1 || x2 ) && (x3 || x4);
        
        
        return answer;
    }
}