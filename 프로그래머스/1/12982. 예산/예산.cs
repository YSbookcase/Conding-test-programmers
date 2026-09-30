using System;

public class Solution {
    public int solution(int[] d, int budget) {
        
        Array.Sort(d);
        int spent = 0;
        int supportCount = 0;
        foreach (int amount in d)
        {
            if (spent + amount > budget)
            {
                break;
            }
            spent += amount;
            supportCount++;
        }


        return supportCount;
    }
}