using System;

public class Solution {
    public int solution(int storey) {
        
        int stones = 0;
        while (storey > 0)
        {
            int digit = storey % 10;
            storey /= 10;
            if (digit < 5)
            {
                stones += digit;
            }
            else if (digit > 5)
            {
                stones += 10 - digit;
                storey++; // 윗자리 올림
            }
            else // digit == 5
            {
                stones += 5;
                if (storey % 10 >= 5)
                    storey++;
            }
        }
        return stones;
    }
}