using System;

public class Solution {
    public int solution(int number, int limit, int power) {
                int answer = 0;

        int[] divCount = new int[number + 1];
        for(int i = 1; i <= number; i++)
        {
            for(int knight = i; knight <= number; knight += i)
            {
                divCount[knight]++;
            }
        }

        for(int i = 1; i <= number; i++ )
        {
            if (divCount[i] > limit)
            {
                answer += power;
            }
            else
            {
                answer += divCount[i];
            }
        }

        return answer;
    }
}