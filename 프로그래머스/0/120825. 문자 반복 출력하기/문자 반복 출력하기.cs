using System;

public class Solution {
    public string solution(string my_string, int n)    {

        int totalLength = my_string.Length * n;

        char[] target = new char[totalLength];

        int idx = 0;

        for (int i = 0; i < my_string.Length; i++)
        {

            for (int j = 0; j < n; j++)
            {

                target[idx++] = my_string[i];
            }

        }

        return new string(target);
    }

    
}