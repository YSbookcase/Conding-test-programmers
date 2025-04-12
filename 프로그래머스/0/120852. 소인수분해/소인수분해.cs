using System;
using System.Collections.Generic;

public class Solution {
    public int[] solution(int n)
    {

    List<int> factors = new List<int>();


    for (int i = 2; i < n; i++)
    {
        if (n % i == 0)
        {
            factors.Add(i);
            while (n % i == 0)
            {
                n /= i;
            }

        }


    }

    if (n > 1)
    {

        factors.Add(n);
    }

    int[] answer = new int[factors.Count];

    return answer = factors.ToArray();
}
}