using System;

public class Solution {
    public int solution(int[,] data, int col, int row_begin, int row_end) {
        
        int rowCount = data.GetLength(0);
        int colCount = data.GetLength(1);

        int[][] rows = new int[rowCount][];
        for (int r = 0; r < rowCount; r++)
        {
            rows[r] = new int[colCount];
            for (int c = 0; c < colCount; c++)
                rows[r][c] = data[r, c];
        }

        Array.Sort(rows, (a, b) =>
        {
            int compare = a[col - 1].CompareTo(b[col - 1]);
            if (compare != 0)
                return compare;
            return b[0].CompareTo(a[0]); // 기본키 내림차순
        });

        int hash = 0;
        for (int i = row_begin; i <= row_end; i++)
        {
            int sum = 0;
            int[] row = rows[i - 1];
            foreach (int value in row)
                sum += value % i;
            hash ^= sum;
        }

        return hash;
    }
}