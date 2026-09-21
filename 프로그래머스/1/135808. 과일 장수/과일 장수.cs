using System;

public class Solution {
    public int solution(int k, int m, int[] score) {
       int answer = 0;

       Array.Sort(score, (a, b) => b.CompareTo(a));

       int limit = (score.Length / m) * m;

       for(int i = 0; i < limit; i += m)
       {
           int minScore = score[i + m - 1];
           answer += minScore* m;
       }


       return answer;
    }
}