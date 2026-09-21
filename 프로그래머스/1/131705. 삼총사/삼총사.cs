using System;

public class Solution {
    public int solution(int[] number) {
                
        int answer = 0;

        for (int i = 0; i <= number.Length -3; i++)
        {
            for (int j = i+ 1; j <= number.Length -2; j++)
            {
                for (int k = j+1; k <= number.Length -1; k++)
                {
                    if (number[i] + number[j] + number[k] == 0)
                    {
                        answer++;
                    }
                    
                }
            }
        }

        return answer;
    }
}