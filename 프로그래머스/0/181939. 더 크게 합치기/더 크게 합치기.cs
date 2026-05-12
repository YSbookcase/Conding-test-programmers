using System;

public class Solution {
    public int solution(int a, int b) {
        int answer = 0;
        
        string str1 = a.ToString();
        string str2 = b.ToString();
        
        bool result3 = int.TryParse(str1 + str2 , out int num1);
        bool result4 = int.TryParse(str2 + str1, out int num2);
        
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