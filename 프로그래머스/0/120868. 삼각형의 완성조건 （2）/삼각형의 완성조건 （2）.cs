using System;

public class Solution {
    public int solution(int[] sides) {
                int answer = 0;

                int a = sides[0];
                int b = sides[1];

                int max = Math.Max(a, b);
                int min = Math.Min(a, b);

                int start = max - min + 1;
                int end = a + b - 1;
                answer = end - start + 1;


                return answer;
    }
}