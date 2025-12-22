using System;

public class Solution {
    public int solution(string my_string) {
                
                int sum = 0;
                int currentNumber = 0;

                foreach (char c in my_string)
                {
                    if (char.IsDigit(c))
                    {
                        currentNumber = currentNumber * 10 + (c - '0');
                    }
                    else
                    {
                        sum += currentNumber;
                        currentNumber = 0;
                    }
                }

                // 마지막 숫자 처리
                sum += currentNumber;

                return sum;
            }
}