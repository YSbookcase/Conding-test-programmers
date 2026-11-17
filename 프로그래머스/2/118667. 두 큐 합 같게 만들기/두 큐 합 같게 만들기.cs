using System;
using System.Collections.Generic;

public class Solution {
    public int solution(int[] queue1, int[] queue2) {
        Queue<int> first = new Queue<int>(queue1);
        Queue<int> second = new Queue<int>(queue2);
        long sum1 = 0;
        long sum2 = 0;
        foreach (int value in queue1)
            sum1 += value;
        foreach (int value in queue2)
            sum2 += value;
        long total = sum1 + sum2;
        if (total % 2 != 0)
            return -1;
        long target = total / 2;
        int limit = (queue1.Length + queue2.Length) * 3;
        int count = 0;
        while (sum1 != target && count < limit)
        {
            if (sum1 > target)
            {
                int value = first.Dequeue();
                second.Enqueue(value);
                sum1 -= value;
            }
            else
            {
                int value = second.Dequeue();
                first.Enqueue(value);
                sum1 += value;
            }
            count++;
        }
        return sum1 == target ? count : -1;
    }                                   
}