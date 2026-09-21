using System;
using System.Collections.Generic;

public class Solution {
    public int solution(int[] ingredient) {

        int answer = 0;
        List<int> pack = new List<int>(ingredient.Length);

        for (int i = 0; i < ingredient.Length; i++)
        {
            pack.Add(ingredient[i]);
            if (pack.Count >= 4
                && pack[pack.Count - 4] == 1
                && pack[pack.Count - 3] == 2
                && pack[pack.Count - 2] == 3
                && pack[pack.Count - 1] == 1
                )
            {
                pack.RemoveRange(pack.Count - 4, 4);
                answer++;
            }


        }

        return answer;  
    }
}