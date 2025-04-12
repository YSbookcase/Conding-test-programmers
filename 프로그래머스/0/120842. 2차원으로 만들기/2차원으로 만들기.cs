using System;

public class Solution {
    public int[,] solution(int[] num_list, int n)   {  int div = num_list.Length / n;
    int k = 0;
    int[,] answer = new int[div, n];

    for (int i = 0; i < div ; i++)
    {
       
        for (int j = 0; j < n; j++)
        {


            answer[i, j] = num_list[k];
            k++;

        }
    }

    return answer;
}
}