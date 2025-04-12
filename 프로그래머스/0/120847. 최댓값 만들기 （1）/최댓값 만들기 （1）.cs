using System;

public class Solution {
    public int solution(int[] numbers) {
    int answer = 0;
    int max1 = int.MinValue;
    int max2 = int.MinValue;

    foreach(int num in numbers)
    {
        if (num > max1)
        {
            max2 = max1;
            max1 = num;
        }
        else if (num >max2)
        {
            max2 = num;
        }


    }

    return answer = max2*max1;
}
}