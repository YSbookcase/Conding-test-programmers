using System;

public class Solution {
    public int[] solution(int[,] score) {
        
            int n = score.GetLength(0);
            int[] avg = new int[n];
            int[] answer = new int[n];


            // 평균 개산
            for( int i = 0; i < n; i ++)
            {
                avg[i] = score[i, 0] + score[i, 1];

            }

            // 등수 계산
            for (int  i = 0;  i < n;  i++)
            {
                int rank = 1;
                for(int j = 0; j < n; j++)
                {
                    if(avg[i] < avg[j])
                    {
                        rank++;
                    }

                                
                }

                answer[i] = rank;

            }

            return answer;
        
    }
}