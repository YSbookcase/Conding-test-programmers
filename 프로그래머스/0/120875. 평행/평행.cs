using System;

public class Solution {
    public int solution(int[,] dots) {
        
            if (IsParallel(dots, 0, 1, 2, 3)) return 1;
            if (IsParallel(dots, 0, 2, 1, 3)) return 1;
            if (IsParallel(dots, 0, 3, 1, 2)) return 1;
            return 0;
        }

        private  bool IsParallel(int[,] d, int a, int b, int c, int e)
        {
            int dx1 = d[b, 0] - d[a, 0];
            int dy1 = d[b, 1] - d[a, 1];

            int dx2 = d[e, 0] - d[c, 0];
            int dy2 = d[e, 1] - d[c, 1];

            // dy1/dx1 == dy2/dx2  <=>  dy1*dx2 == dy2*dx1
            return dy1 * dx2 == dy2 * dx1;
        }
    }
