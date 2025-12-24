using System;

public class Solution {
    public string solution(string polynomial) {
int xSum = 0;
int constSum = 0;

string[] tokens = polynomial.Split(' ');

foreach (string t in tokens)
{
    if (t == "+")
    {
        continue;
    }

    if (t.EndsWith('x'))
    {
        if (t.Length == 1)
        {
            xSum += 1;
        }
        else
        {
            int coef = int.Parse(t.Substring(0, t.Length - 1));
            xSum += coef;
        }
    }
    else
    {
        // 상수항
        constSum += int.Parse(t);
    }
}

    // 최종 결과 문자열 생성
    if (xSum == 0)
    {
        return constSum.ToString();
    }
    if (constSum == 0)
    {
        if (xSum == 1)
        {
            return "x";
        }
        else
        {
            return $"{xSum}x";
        }
    }
  
        string xPart = (xSum == 1) ? "x" : $"{xSum}x";
        return $"{xPart} + {constSum}";

                
        
    }
}