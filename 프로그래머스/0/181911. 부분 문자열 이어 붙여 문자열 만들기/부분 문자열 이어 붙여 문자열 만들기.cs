using System;
using System.Text;

public class Solution {
    public string solution(string[] my_strings, int[,] parts) {

        StringBuilder result = new StringBuilder();
        
        for(int i = 0; i < my_strings.Length; i++)
        {
            int start = parts[i, 0];
            int end = parts[i, 1];
            
            string part = my_strings[i].Substring(
                start,
                end - start + 1
            );
            
            result.Append(part);
            
        }
        
        return result.ToString();
        
    }
}