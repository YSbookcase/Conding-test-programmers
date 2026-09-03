using System;

public class Solution {
    public int[,] solution(int[,] arr) {

        int row = arr.GetLength(0);
        int col = arr.GetLength(1);
        
        if(row == col) 
        {
            return arr;
        }
        
        int size = Math.Max(row,col);
        int[,] result = new int[size, size];
        
        for(int i = 0; i < row; i++)
        {
            for(int j = 0; j < col; j++)
            {
                result[i,j] = arr[i,j];
            }
        }

        return result;
    }
}