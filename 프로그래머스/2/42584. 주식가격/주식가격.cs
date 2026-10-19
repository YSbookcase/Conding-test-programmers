using System;
using System.Collections.Generic;

public class Solution {
    public int[] solution(int[] prices) {
        
        int[] answer = new int[prices.Length];
        Stack<int> indexStack = new Stack<int>();

        for (int index = 0; index < prices.Length; index++)
        {
            while (indexStack.Count > 0 && prices[indexStack.Peek()] > prices[index])
            {
                int dropIndex = indexStack.Pop();
                answer[dropIndex] = index - dropIndex;
            }

            indexStack.Push(index);

        }

        while (indexStack.Count > 0)
        {
            int remainIndex = indexStack.Pop();
            answer[remainIndex] = prices.Length - 1 - remainIndex;
        }

        return answer;
    }
}