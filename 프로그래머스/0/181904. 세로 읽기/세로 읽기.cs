using System;
using System.Text;

public class Solution {
    public string solution(string my_string, int m, int c) {
       
        StringBuilder sb = new StringBuilder();
        
        for(int i = c-1; i < my_string.Length; i += m)
        {
            sb.Append(my_string[i]);
        }
        
        return sb.ToString();
    }
}