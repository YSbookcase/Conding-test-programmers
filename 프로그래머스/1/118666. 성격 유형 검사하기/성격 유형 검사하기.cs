using System;
using System.Text;
using System.Collections.Generic;

public class Solution {
    public string solution(string[] survey, int[] choices) {
        
        StringBuilder result = new StringBuilder();

        Dictionary<char, int> typeScore = new Dictionary<char, int>();

        char[] types = { 'R', 'T', 'C', 'F', 'J', 'M', 'A', 'N'};

        foreach (char type in types)
        {
            typeScore[type] = 0;
        }

        for (int i = 0; i < survey.Length; i++)
        {
            int value = choices[i] - 4;
            if (value == 0)
            {
                continue;
            }


            if (value > 0)
            {
                typeScore[survey[i][1]] += value;
            }
            else
            {
                typeScore[survey[i][0]] += Math.Abs(value);
            }
        }

        if (typeScore['R'] >= typeScore['T'])
        {
            result.Append('R');

        }
        else
        {
            result.Append('T');
        }

        if (typeScore['C'] >= typeScore['F'])
        {
            result.Append('C');
        }
        else
        {
            result.Append('F');
        }

        if (typeScore['J'] >= typeScore['M'])
        {
            result.Append('J');
        }
        else
        {
            result.Append('M');
        }

        if (typeScore['A'] >= typeScore['N'])
        {
            result.Append('A');
        }
        else
        {
            result.Append('N');
        }
        return result.ToString();
    }
}