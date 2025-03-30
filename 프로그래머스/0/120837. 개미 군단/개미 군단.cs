using System;

public class Solution {
    public int solution(int hp) {
                  int answer = 0;
            int generalPow = 5;
            int militryPow = 3;
            int workerPow = 1;
            
            int generalNum = 0;
            int militryNum = 0;
            int workerNum = 0;
            
            int secondHp = 0;
            int thirdHP = 0;

            generalNum = hp / generalPow;
            secondHp = hp % generalPow;

            if (secondHp > 0)
            {
                militryNum = secondHp / militryPow;
                thirdHP = secondHp % militryPow;
            }
            

            if (thirdHP > 0 )
            {
                workerNum = thirdHP / workerPow;
            }

            answer =  generalNum + militryNum + workerNum;

            



            return answer;
    }
}