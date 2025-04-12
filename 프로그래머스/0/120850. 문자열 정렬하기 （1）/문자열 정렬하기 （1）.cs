using System;
using System.Collections.Generic;

public class Solution {
    public int[] solution(string my_string) 
   
    {
    int[] counts = new int[10];

    foreach (char c in my_string)
    {
        if (char.IsDigit(c))
        {
            counts[c - '0']++;
        }
    }

    List<int> sortedDigits = new List<int>();
        
    for (int i = 0; i <= 9; i++)
    {
        for (int j = 0; j < counts[i]; j++)
        {
            sortedDigits.Add(i);
        }
    }

    int[] answer = sortedDigits.ToArray();

    return answer;

}
    
}