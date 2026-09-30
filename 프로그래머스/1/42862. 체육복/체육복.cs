using System;

public class Solution {
    public int solution(int n, int[] lost, int[] reserve) {
            
        int[] clothes = new int[n + 1];

            for (int i = 1; i <= n; i++)
            {
                clothes[i] = 1;
            }

            foreach (int student in lost)
            {
                clothes[student]--;
            }

            foreach (int student in reserve)
            {
                clothes[student]++;
            }

            for (int i = 1; i <= n; i++)
            {
                if (clothes[i] > 0)
                {
                    continue;
                }

                if (i > 1 && clothes[i - 1] == 2)
                {
                    clothes[i - 1]--;
                    clothes[i]++;
                }
                else if (i < n && clothes[i + 1] == 2)
                {
                    clothes[i + 1]--;
                    clothes[i]++;
                }
            }

            int attendCount = 0;
            for (int i = 1; i <= n; i++)
            {
                if (clothes[i] > 0)
                {
                    attendCount++;
                }
            }
            return attendCount;


        }
    
}