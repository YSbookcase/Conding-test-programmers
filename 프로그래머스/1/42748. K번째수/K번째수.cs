using System;

public class Solution {
    public int[] solution(int[] array, int[,] commands) {
        
        int commandCount = commands.GetLength(0);
        int[] result = new int[commandCount];
        for (int c = 0; c < commandCount; c++)
        {
            int start = commands[c, 0];
            int end = commands[c, 1];
            int k = commands[c, 2];

            int[] slice = new int[end - start + 1];
            for (int i = 0; i < slice.Length; i++)
            {
                slice[i] = array[start - 1 + i];
            }

            Array.Sort(slice);
            result[c] = slice[k - 1];
        }

        return result;
    }
}