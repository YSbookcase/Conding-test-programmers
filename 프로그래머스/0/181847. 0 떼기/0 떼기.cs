using System;

public class Solution {
    public string solution(string n_str) {
        
//         int.TryParse(n_str, out int num);
        
//         return num.ToString();
        
        return n_str.TrimStart('0');
        
    }
}