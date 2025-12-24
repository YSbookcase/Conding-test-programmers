using System;

public class Solution {
    public int solution(string A, string B) {
            if (A == B) return 0;

            string cur = A;
            int n = A.Length;

            for(int k = 1; k <= n; k++)
            {
                cur = RotateString(cur);
                if(cur == B)
                {
                    return k;
                }

            }

            return -1;
        }

        private static string RotateString(string s)
        {
            int n = s.Length;
            
            return s.Substring(n - 1) + s.Substring(0, n - 1);
        }
}