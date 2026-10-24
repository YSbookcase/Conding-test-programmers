using System;
using System.Text;

public class Solution {
    public string solution(string number, int k) {
                
        StringBuilder result = new StringBuilder();
        int removeCount = k;

        foreach (char digit in number)
        {
            while (removeCount > 0 && result.Length > 0 && result[result.Length - 1] < digit)
            {
                result.Length--;
                removeCount--;
            }

            result.Append(digit);
        }

        result.Length -= removeCount;
        return result.ToString();
    }
}