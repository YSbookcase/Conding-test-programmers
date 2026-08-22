using System;

public class Solution {
    public int solution(string myString, string pat) {
     
        int count = 0;
        int index = 0;
        
        while(true)
        {
            index = myString.IndexOf(pat, index);
            
            if(index == -1)
                break;
            
            count++;
            index++;
        }
     
        return count;
    }
}