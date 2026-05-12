using System;

public class Solution {
    public string solution(string str1, string str2) {
        
        string answer = "";
        
        for( int i = 0; i < str1.Length; i++ )
        {
            answer += str1.Substring(i,1);
                answer += str2.Substring(i,1);
        }
                
        return answer;
    }
}