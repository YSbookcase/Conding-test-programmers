using System;

public class Solution {
    public int solution(string num_str) {
        
        int sum = 0;
        
        foreach(char c in num_str)
        {
            sum += c - '0';
        }
        
        return sum;
 
    }
}