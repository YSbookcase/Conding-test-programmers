using System;
using System.Linq;

public class Solution {
    public int solution(string[] strArr) {
        
        int[] count = new int[31];
        
        foreach (string str in strArr)
        {
            count[str.Length]++;
        }
        
        // int max = 0;
        // for(int i = 1; i <= 30; i++)
        // {
        //     if (count[i] > max) max = count[i];
        // }
        //   return max;
        
        return count.Max();
      
    }
}