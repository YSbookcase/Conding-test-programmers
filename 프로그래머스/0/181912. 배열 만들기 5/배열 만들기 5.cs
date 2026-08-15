using System;
using System.Collections.Generic;

public class Solution {
    public int[] solution(string[] intStrs, int k, int s, int l) {
       
       List<int> result = new List<int>();
        
        foreach (string intStr in intStrs)
        {
            string sliced = intStr.Substring(s,l);
            int number = int.Parse(sliced);
            
            if(number > k)
            {
                result.Add(number);
            }
        }
        
        
        return result.ToArray();
        
        
    }
}