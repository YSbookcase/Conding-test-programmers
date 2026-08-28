using System;
using System.Collections.Generic;

public class Solution {
    public string[] solution(string myStr) {
        
        List<string> result = new List<string>();
        
        int start = 0;
        
        for(int i = 0; i < myStr.Length; i++)
        {
            
            if(myStr[i] == 'a' || myStr[i] == 'b' || myStr[i] == 'c')
            {
                if (i > start)
                {
                    result.Add(myStr.Substring(start, i - start));
                }
                
                start = i + 1;
            }
        }
        
        if( start < myStr.Length)
        {
            result.Add(myStr.Substring(start));
        }
        
        if(result.Count == 0)
        {
            result.Add("EMPTY");
        }
        
        return result.ToArray();
        
//         string[] result = myStr.Split(
//             new char[] {'a', 'b', 'c'},
//             StringSplitOptions.RemoveEmtyEntries
//         );
        
//         if(result.Length == 0)
//         {
//             return new string[] {"EMPTY"};
//         }
        
//         return result;
    }
}