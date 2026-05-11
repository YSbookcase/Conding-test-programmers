using System;

public class Solution {
    public string solution(string my_string, string overwrite_string, int s) {
        
        string front = my_string.Substring(0, s);
        string back  = my_string.Substring(overwrite_string.Length + s);
        
        string answer = front + overwrite_string + back;
        
        return answer;
    }
}