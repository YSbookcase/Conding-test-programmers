using System;

public class Solution {
    public int[] solution(int n, long left, long right) {
            
        int length = (int)(right - left + 1);
        int[] answer = new int[length];
        for (int index = 0; index < length; index++)
        {
            long k = left + index;
            long row = k / n;
            long col = k % n;
            answer[index] = (int)Math.Max(row, col) + 1;
        }
        return answer;
    }
}