using System;

public class Solution {
    public int solution(int[] schedules, int[,] timelogs, int startday) {
        int answer = 0;
        
        for(int i = 0; i < schedules.Length; i++)
        {

            int deadline = SaveTime(schedules[i]);
            bool isPass = true;

            for (int j = 0; j < 7; j++)
            {

                int day = (startday - 1 + j) % 7;

                if (day == 5 || day == 6)
                {
                    continue;
                }
                else if ( deadline < timelogs[i,j])
                {
                    isPass = false;
                    break;
                }

              
               
            }

            if(isPass)
            {
                answer++;
            }


        }
        
        return answer;
    }
    
    
    int SaveTime(int targetTime)
    {
        int save = 0;

         save = targetTime + 10;
         if(save % 100 >= 60)
        {
            // 100 -60
            save += 40;
        }


        return save;
    }
}