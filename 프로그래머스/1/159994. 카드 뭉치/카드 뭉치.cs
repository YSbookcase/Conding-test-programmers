using System;

public class Solution {
    public string solution(string[] cards1, string[] cards2, string[] goal) {
                string answer = "";

        int index1 = 0;
        int index2 = 0;

        foreach( string word in goal)
        {
            if (index1 < cards1.Length && cards1[index1] == word)
            {
                index1++;
            }
            else if (index2 < cards2.Length && cards2[index2] == word)
            {
                index2++;
            }
            else
            {
                return answer = "No";
            }

        }

        return answer = "Yes";

    }
}