using System;

public class Solution {
    public int solution(int[,] lines) {
            int offset = 100;
            int[] cnt = new int[200];

            for (int i = 0; i < 3; i++)
            {
                int a = lines[i, 0];
                int b = lines[i, 1];

                for (int x = a; x < b; x++)
                {
                    cnt[x + offset]++;
                }
            }

            int overlap = 0;
            for (int i = 0; i < cnt.Length; i++)
            {
                if (cnt[i] >= 2)
                {
                    overlap++;
                }
            }


            return overlap;


        
    }
}