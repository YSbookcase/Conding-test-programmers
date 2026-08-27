using System;

public class Solution {
    public int solution(string myString, string pat) {
        
        Char[] chars = myString.ToCharArray();
        
        for(int i = 0; i < chars.Length; i++)
        {
            if( chars[i] == 'A')
            {
                chars[i] = 'B';
            }
            else
            {
                chars[i] = 'A';
            }
        }
        
        string changed = new string(chars);
        
        return changed.Contains(pat) ? 1 : 0;
        
    }
}