using System;

public class Solution {
    public int[] solution(int[] array) {
        int maxValue = array[0];
        int index = 0;

        for (int i = 1; i < array.Length; i++)
        {
            if (array[i] > maxValue)
            {
                maxValue = array[i];
                index = i;
            }
        }

        return new int[] { maxValue, index };
    }
}