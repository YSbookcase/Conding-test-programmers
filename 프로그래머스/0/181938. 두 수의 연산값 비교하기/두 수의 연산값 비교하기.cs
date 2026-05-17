using System;

public class Solution {
    public int solution(int a, int b) {
        int answer = 0;
        
        string str1 = a.ToString();
        string str2 = b.ToString();
        
        int num1 = int.Parse(str1 + str2);
        int num2 = 2*a*b;
        
        if(num1 >= num2)
        {
            return num1;
        }
        else
        {
            return num2;
        }
        
        
        
        
        //return answer;
    }
}