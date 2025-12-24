using System;

public class Solution {
    public int[] solution(int[] numlist, int n) {
             Array.Sort(numlist, (a, b) =>
            {
                int diffA = Math.Abs(a - n);
                int diffB = Math.Abs(b - n);
                if (diffA != diffB)
                {
                    return diffA - diffB; // 절대값 차이 오름차순
                }
                else
                {
                    return b - a; // 차이가 같다면 값 내림차순
                }
            });

            return numlist;
        }
}