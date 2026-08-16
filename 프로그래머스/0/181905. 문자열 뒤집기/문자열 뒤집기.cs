using System;

public class Solution {
    public string solution(string my_string, int s, int e) {
        
        char[] chars = my_string.ToCharArray();
        
        int start = s;
        int end = e;
        
        while(start < end)
        {
            char temp = chars[start];
            chars[start] = chars[end];
            chars[end] = temp;
            
            start++;
            end--;
            
        }
        
        return new string(chars);
        
    }
}