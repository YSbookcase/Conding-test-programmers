using System;

public class Solution {
    public string solution(string my_string, string alp) {
        char[] chars = my_string.ToCharArray();
        
        for(int i = 0; i < chars.Length; i++)
        {
            if(chars[i] == alp[0])
            chars[i] = char.ToUpper(chars[i]);
        }
        
        return new string(chars);
    
        
        //return my_string.Replace(alp, alpToUpper());
        
    }
}