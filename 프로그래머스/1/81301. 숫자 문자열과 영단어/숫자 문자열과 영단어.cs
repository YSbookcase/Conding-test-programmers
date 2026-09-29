using System;

public class Solution {
    public int solution(string s) {
        string[] words = {"zero", "one","two","three","four","five","six","seven","eight","nine"};
        for(int digit = 0; digit <= 9; digit++)
        {
            s = s.Replace(words[digit], digit.ToString());
        }
        
        return int.Parse(s);
    }
}