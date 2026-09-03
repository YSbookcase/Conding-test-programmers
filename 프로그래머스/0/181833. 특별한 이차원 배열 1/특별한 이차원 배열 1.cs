using System;

public class Solution {
    public int[,] solution(int n) {
        int[,] result = new int[n,n];
        
        for(int i = 0; i < n; i++)
        {
            result[i,i] = 1;

        }
        
        return result;
    }
}