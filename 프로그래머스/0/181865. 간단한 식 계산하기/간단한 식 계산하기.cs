using System;

public class Solution {
    public int solution(string binomial) {
        
        int result = 0;
        
        string[] parts = binomial.Split(' ');
        
        int a = int.Parse(parts[0]);
        int b = int.Parse(parts[2]);
        
        if(parts[1] == "+")
        {
            result =  a + b;
        }
        else if (parts[1] == "-")
        {
            result = a - b;
        }
        else
        {
            result =  a * b;
        }
        
        return result;
    }
}