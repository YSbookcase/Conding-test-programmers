using System;

public class Solution {
    public int solution(string s)
   {
       int answer = 0;
       int i = 0;
       while (i < s.Length)
       {
           char x = s[i];
           int xCount = 0;
           int otherCount = 0;
           while (i < s.Length)
           {
               if (s[i] == x)
                   xCount++;
               else
                   otherCount++;
               i++;
               if (xCount == otherCount)
                   break;
           }
           answer++;
       }

       return answer;
   }
}