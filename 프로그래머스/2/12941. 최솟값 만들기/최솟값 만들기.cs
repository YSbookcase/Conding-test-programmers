using System;

public class Solution {
    public int solution(int[] A, int[] B)
    {
        Array.Sort(A);
        Array.Sort(B);
        Array.Reverse(B);

        int sum = 0;

        for (int index = 0; index < A.Length; index++)
        {
            sum += A[index] * B[index];
        }

        return sum;
    }
}