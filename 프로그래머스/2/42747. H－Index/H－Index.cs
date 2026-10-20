using System;

public class Solution {
    public int solution(int[] citations) {
                
        int paperCount = citations.Length;
        int[] citationCounts = new int[paperCount + 1];

        foreach (int citation in citations)
        {
            int capped = Math.Min(citation, paperCount);
            citationCounts[capped]++;
        }

        int papersAtLeast = 0;
        for (int h = paperCount; h >= 0; h--)
        {
            papersAtLeast += citationCounts[h];
            if (papersAtLeast >= h)
            {
                return h;
            }
        }

        return 0;
      
    }
}