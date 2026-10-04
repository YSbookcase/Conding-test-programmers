using System;

public class Solution {
    public string[] solution(string[] strings, int n) {
                
        Array.Sort(strings, (a, b) => a[n].CompareTo(b[n]));

        int start = 0;
        while (start < strings.Length)
        {
            int end = start + 1;
            while (end < strings.Length && strings[end][n] == strings[start][n])
            {
                end++;
            }

            Array.Sort(strings, start, end - start);
            start = end;
        }
        

        return strings;
    }
}