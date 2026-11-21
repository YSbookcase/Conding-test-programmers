using System;
using System.Collections.Generic;

public class Solution {
    public int[] solution(int[] numbers) {
        
        int length = numbers.Length;
        int[] answer = new int[length];
        Array.Fill(answer, -1);
        Stack<int> indexStack = new Stack<int>();
        
        for (int i = 0; i < length; i++)
        {
            while (indexStack.Count > 0 && numbers[indexStack.Peek()] < numbers[i])
            {
                int index = indexStack.Pop();
                answer[index] = numbers[i];
            }
            
            indexStack.Push(i);
        }
        return answer;
    }
}