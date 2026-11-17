using System;
using System.Collections.Generic;

public class Solution {
    public int solution(int[] cards) {
            
        int length = cards.Length;
        bool[] isOpened = new bool[length];
        List<int> groupSizes = new List<int>();
        for (int start = 0; start < length; start++)
        {
            if (isOpened[start])
                continue;
            int size = 0;
            int current = start;
            while (!isOpened[current])
            {
                isOpened[current] = true;
                current = cards[current] - 1; // 카드 번호 → 0-index 상자
                size++;
            }
            groupSizes.Add(size);
        }
        if (groupSizes.Count < 2)
            return 0;
        groupSizes.Sort();
        int last = groupSizes.Count - 1;
        return groupSizes[last] * groupSizes[last - 1];
    }
}