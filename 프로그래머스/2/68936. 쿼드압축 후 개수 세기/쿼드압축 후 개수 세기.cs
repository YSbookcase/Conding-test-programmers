using System;

public class Solution {
    public int[] solution(int[,] arr) {
       int zeroCount = 0;
       int oneCount = 0;

       void Compress(int[,] arr, int row, int col, int size)
       {
           if (IsSame(arr, row, col, size))
           {
               if (arr[row, col] == 0)
               {
                   zeroCount++;
               }
               else
               {
                   oneCount++;
               }
               return;
           }

           int half = size / 2;
           Compress(arr, row, col, half);
           Compress(arr, row, col + half, half);
           Compress(arr, row + half, col, half);
           Compress(arr, row + half, col + half, half);
       }

       bool IsSame(int[,] arr, int row, int col, int size)
       {
           int startValue = arr[row, col];

           for (int currentRow = row; currentRow < row + size; currentRow++)
           {
               for (int currentCol = col; currentCol < col + size; currentCol++)
               {
                   if (arr[currentRow, currentCol] != startValue)
                   {
                       return false;
                   }
               }
           }
           return true;
       }

       Compress(arr, 0, 0, arr.GetLength(0));

       return new int[] { zeroCount, oneCount };
   }
}