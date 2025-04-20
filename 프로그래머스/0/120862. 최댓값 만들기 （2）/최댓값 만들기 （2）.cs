using System;

public class Solution {
    public int solution(int[] numbers) {
    int answer = 0;
    int max1 = int.MinValue;
    int max2 = int.MinValue;
    int min1 = int.MaxValue;
    int min2 = int.MaxValue;

    foreach (int num in numbers)
    {
        if (num > max1)
        {
            max2 = max1;
            max1 = num;
        }
        else if (num > max2)
        {
            max2 = num;
        }

        if (num < min1)
        {
            min2 = min1;
            min1 = num;
        }
        else if (num < min2)
        {
            min2 = num;
        }

    

    }

    int product1 = max1 * max2;
    int product2 = min1 * min2;


    return Math.Max(product1, product2);
}
}