using System;
using System.Collections.Generic;

public class Solution {
    public int solution(string[] friends, string[] gifts) {
           
        int n = friends.Length;

        Dictionary<string, int> indexByName = new Dictionary<string, int>();
        for (int i = 0; i < n; i++)
        {
            indexByName[friends[i]] = i;
        }

        int[,] give = new int[n, n];

        foreach (string gift in gifts)
        {
            string[] parts = gift.Split(' ');
            int giver = indexByName[parts[0]];
            int receiver = indexByName[parts[1]];
            give[giver, receiver]++;
        }

        int[] score = new int[n];
        for (int i = 0; i < n; i++)
        {
            int given = 0;
            int received = 0;
            for (int j = 0; j < n; j++)
            {
                given += give[i, j];
                received += give[j, i];
            }
            score[i] = given - received;
        }


        int[] next = new int[n];
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = i + 1; j < n; j++)
            {
                if (give[i, j] > give[j, i])
                {
                    next[i]++;
                }
                else if (give[i, j] < give[j, i])
                {
                    next[j]++;
                }
                else if (score[i] > score[j])
                {
                    next[i]++;
                }
                else if (score[i] < score[j])
                {
                    next[j]++;
                }
            }
        }

        int answer = 0;
        for (int i = 0; i < n; i++)
        {
            if (next[i] > answer)
            {
                answer = next[i];
            }
        }
        return answer;
    }
    
}