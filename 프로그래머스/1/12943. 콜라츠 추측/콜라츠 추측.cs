public class Solution {
    public int solution(int num) {
        
        int stepCount = 0;
        long current = num;

        while (current != 1 && stepCount < 500)
        {
            if (current % 2 == 0)
            {
                current /= 2;

            }
            else
            {
                current = current * 3 + 1;

            }
                stepCount++;


        }

        if (current == 1)
        {
            return stepCount;
        }

        return -1;
    }
}