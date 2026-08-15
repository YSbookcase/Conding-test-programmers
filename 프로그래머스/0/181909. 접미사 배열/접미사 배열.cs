using System;

public class Solution {
    public string[] solution(string my_string) {
        
        string[] result = new string[my_string.Length];
        
            for(int i = 0 ; i < my_string.Length; i++)
            {
                result[i] = my_string.Substring(i);
            }
            
        Array.Sort(result);
        
        return result;
    }
}