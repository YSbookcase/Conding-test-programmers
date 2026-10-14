using System;

public class Solution {
    public int[,] solution(int[,] arr1, int[,] arr2) {
        
        
        int rowCount = arr1.GetLength(0);
        int sharedCount = arr1.GetLength(1);
        int colCount = arr2.GetLength(1);
        int[,] answer = new int[rowCount, colCount];

        for (int row = 0; row < rowCount; row++)
        {
            for (int col = 0; col < colCount; col++)
            {
                int sum = 0;

                for (int index = 0; index < sharedCount; index++)
                {
                    sum += arr1[row, index] * arr2[index, col];

                }

                answer[row, col] = sum;
            }
        }

        return answer;

    }
}