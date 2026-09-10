using System;
using System.Collections.Generic;

public class Solution {
    public int[] solution(int m, int n, int h, int w, int[,] drops) {
        int dropCount = drops.GetLength(0);
        int inf = dropCount + 1;

        // 1) 칸별 시각 격자
        int[,] timeGrid = new int[m, n];
        for (int row = 0; row < m; row++) {
            for (int col = 0; col < n; col++) {
                timeGrid[row, col] = inf;
            }
        }

        for (int dropIndex = 0; dropIndex < dropCount; dropIndex++) {
            int dropRow = drops[dropIndex, 0];
            int dropCol = drops[dropIndex, 1];
            timeGrid[dropRow, dropCol] = dropIndex + 1;
        }

        int rowCount = m - h + 1;
        int colCount = n - w + 1;

        // 2) 세로 h 슬라이딩 min
        int[,] colMin = new int[rowCount, n];
        for (int col = 0; col < n; col++) {
            int[] columnValues = new int[m];
            for (int row = 0; row < m; row++) {
                columnValues[row] = timeGrid[row, col];
            }

            int[] verticalMin = SlidingWindowMin(columnValues, h);
            for (int row = 0; row < rowCount; row++) {
                colMin[row, col] = verticalMin[row];
            }
        }

        // 3) 가로 w 슬라이딩 min
        int[,] windowMin = new int[rowCount, colCount];
        for (int row = 0; row < rowCount; row++) {
            int[] rowValues = new int[n];
            for (int col = 0; col < n; col++) {
                rowValues[col] = colMin[row, col];
            }

            int[] horizontalMin = SlidingWindowMin(rowValues, w);
            for (int col = 0; col < colCount; col++) {
                windowMin[row, col] = horizontalMin[col];
            }
        }

        // 4) INF(안 맞음) > 모든 실제 시각 이므로 최댓값 + 위·왼쪽
        int bestR = 0;
        int bestC = 0;
        int bestHit = -1;

        for (int r = 0; r < rowCount; r++) {
            for (int c = 0; c < colCount; c++) {
                if (windowMin[r, c] > bestHit) {
                    bestHit = windowMin[r, c];
                    bestR = r;
                    bestC = c;
                }
            }
        }

        return new int[] { bestR, bestC };
    }

    int[] SlidingWindowMin(int[] arr, int len) {
        int n = arr.Length;
        int[] result = new int[n - len + 1];
        LinkedList<int> indexDeque = new LinkedList<int>();

        for (int index = 0; index < n; index++) {
            while (indexDeque.Count > 0 && indexDeque.First.Value <= index - len) {
                indexDeque.RemoveFirst();
            }

            while (indexDeque.Count > 0 && arr[indexDeque.Last.Value] >= arr[index]) {
                indexDeque.RemoveLast();
            }

            indexDeque.AddLast(index);

            if (index >= len - 1) {
                int start = index - len + 1;
                result[start] = arr[indexDeque.First.Value];
            }
        }

        return result;
    }
}