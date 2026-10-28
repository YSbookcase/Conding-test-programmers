using System;

public class Solution {
    public int solution(int[] numbers, int target) {
        
        return Count(numbers, target, 0, 0);
    }

    int Count(int[] numbers, int target, int index, int sum)
    {
        if (index == numbers.Length)
        {
            return sum == target ? 1 : 0;
        }

        int addCount = Count(numbers, target, index + 1, sum + numbers[index]);
        int subtractCount = Count(numbers, target, index + 1, sum - numbers[index]);
        return addCount + subtractCount;
    }
}