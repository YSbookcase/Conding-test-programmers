using System;
using System.Collections.Generic;

public class Solution {
    public int solution(string s) {
               
        
        Queue<char> brackets = new Queue<char>(s);
       int validCount = 0;

       for (int rotate = 0; rotate < s.Length; rotate++)
       {
           if (IsValid(brackets))
           {
               validCount++;
           }

           char front = brackets.Dequeue();
           brackets.Enqueue(front);
       }

       return validCount;
   }


   bool IsValid(Queue<char> brackets)
   {
       Stack<char> openBrackets = new Stack<char>();

       foreach (char bracket in brackets)
       {
           if (bracket == '(' || bracket == '[' || bracket == '{')
           {
               openBrackets.Push(bracket);
               continue;
           }

           if (openBrackets.Count == 0)
           {
               return false;
           }

           char open = openBrackets.Pop();
           if (bracket == ')' && open != '(')
           {
               return false;
           }
           if (bracket == ']' && open != '[')
           {
               return false;
           }
           if (bracket == '}' && open != '{')
           {
               return false;
           }

       }

           return openBrackets.Count == 0;
   }
}