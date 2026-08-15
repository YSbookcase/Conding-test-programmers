using System;


public class Solution {
    public string solution(string my_string, int n) {
       
       int start = my_string.Length - n;
        
       string result = my_string.Substring(start, n);
        
        return result;
    }
}