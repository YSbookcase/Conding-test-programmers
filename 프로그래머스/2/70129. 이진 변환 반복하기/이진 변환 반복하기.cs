using System;

public class Solution {
    public int[] solution(string s) {
        
        int transformCount = 0;
        int removedZeroCount = 0;


        while (s != "1")
        {
                int zeroCount = 0;
                int oneCount = 0;

                foreach (char bit in s)
                {
                    if (bit == '0')
                    {
                        zeroCount++;
                    }
                    else
                    {
                        oneCount++;
                    }

                }

                removedZeroCount += zeroCount;
                s = Convert.ToString(oneCount, 2);
                transformCount++;
        }
        return new int[] { transformCount, removedZeroCount};
    }
    
}