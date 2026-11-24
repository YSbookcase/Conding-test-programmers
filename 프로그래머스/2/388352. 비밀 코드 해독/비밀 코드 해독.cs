using System;

public class Solution {
    
    int codeLength = 5;
    int[] code = new int[5];
    int answer;
    int range;
    int[,] queries;
    int[] response;
    
    public int solution(int n, int[,] q, int[] ans) {
    
        range = n;
        queries = q;
        response = ans;
        answer = 0;
        Pick(1, 0);
        return answer;
    }
    void Pick(int start, int picked)
    {
        if (picked == codeLength)
        {
            if (MatchesAll())
                answer++;
            return;
        }
        for (int number = start; number <= range; number++)
        {
            code[picked] = number;
            Pick(number + 1, picked + 1);
        }
    }
    
    bool MatchesAll()
    {
        bool[] chosen = new bool[range + 1];
        for (int i = 0; i < codeLength; i++)
            chosen[code[i]] = true;
        for (int i = 0; i < response.Length; i++)
        {
            int matchCount = 0;
            for (int j = 0; j < codeLength; j++)
            {
                if (chosen[queries[i, j]])
                    matchCount++;
            }
            if (matchCount != response[i])
                return false;
        }
        return true;
    }
}