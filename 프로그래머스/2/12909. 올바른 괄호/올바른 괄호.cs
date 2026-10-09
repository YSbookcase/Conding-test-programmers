using System;
using System.Collections.Generic;

public class Solution {
    public bool solution(string s) {
        
        Stack<char> openBrackets = new Stack<char>();

        foreach (char bracket in s)
        {
            if (bracket == '(')
            {
                openBrackets.Push(bracket);
                continue;
            }

            if (openBrackets.Count == 0)
            {
                return false;
            }

            openBrackets.Pop();

        }

        return openBrackets.Count == 0;
    }
}