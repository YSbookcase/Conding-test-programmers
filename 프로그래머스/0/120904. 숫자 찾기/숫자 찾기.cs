using System;

public class Solution {
    public int solution(int num, int k) {
   
                string numString = num.ToString();
                char targetChar = (char)(k + '0');

                for (int i = 0; i < numString.Length; i ++)
                {
                    if (numString[i] == targetChar)
                    {
                        return i + 1;
                    }
                }

                return -1;
    }
}