using System;
using System.Text;

public class Solution {
    public string solution(string X, string Y) {
        
        string answer = "";

        int[] xNumCount = new int[10];
        int[] yNumCount = new int[10];

        int[] pairCount = new int[10];
        StringBuilder result = new StringBuilder(Math.Min(X.Length, Y.Length));


        for (int  i = 0;  i < X.Length;  i++)
        {
            xNumCount[X[i] - '0']++;
        }
        for (int i = 0; i < Y.Length; i++)
        {
            yNumCount[Y[i] - '0']++;
        }

        for (int digit = 0; digit < 10; digit++)
        {
            pairCount[digit] = Math.Min(xNumCount[digit], yNumCount[digit]);
        }

        for (int digit = 9; digit >= 0; digit--)
        {
            result.Append((char)('0' + digit), pairCount[digit]);

        }

        answer= result.ToString();
        if (answer.Length == 0)
            return "-1";
        if (answer[0] == '0')
            return "0";

        return answer;

        }
}