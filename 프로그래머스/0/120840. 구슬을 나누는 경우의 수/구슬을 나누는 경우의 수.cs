using System;

public class Solution {
    public int solution(int balls, int share)         {
            int answer = 0;


            // share == 0 || 과제에서 제외 제한사항에 의해서
            if ( share == balls) return 1;

            if (share > balls / 2) share = balls - share;

            long result = 1;
            for (int i = 1; i <= share; i++)
            {
                result *= balls - (share - i);
                result /= i;
            }


            return answer = (int)result;
        }
}