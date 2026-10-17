using System;
using System.Collections.Generic;

public class Solution {
    public int solution(string[,] clothes) {
               
        Dictionary<string, int> countByType = new Dictionary<string, int>();
        int clothCount = clothes.GetLength(0);

        for(int index = 0; index < clothCount; index++)
        {
            string type = clothes[index, 1];
            if (!countByType.ContainsKey(type))
            {
                countByType[type] = 0;
                
            }

            countByType[type]++;
        }

        int answer = 1;
        foreach (int count in countByType.Values)
        {
            answer *= count + 1;
        }
        return answer -1;
    }
}