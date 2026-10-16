using System;

public class Solution {
       
    int count;
   int[] cols;

   public int solution(int n)
   {
       count = 0;
       cols = new int[n];
       Place(n, 0);
       return count;
   }

   void Place(int n, int row)
   {
       if (row == n)
       {
           count++;
           return;
       }

       for (int col = 0; col < n; col++)
       {
           if (!IsSafe(row,col))
           {
               continue;
           }

           cols[row] = col;
           Place(n, row + 1);
       }
   }



    bool IsSafe(int row, int col)
   {
       for (int prev = 0; prev < row; prev++)
       {
           bool isSameColumn = cols[prev] == col;
           bool isSameDiagonal = Math.Abs(cols[prev] - col) == row - prev;
           if (isSameColumn || isSameDiagonal)
           {
               return false;
           }
       }
       return true;
   }
}