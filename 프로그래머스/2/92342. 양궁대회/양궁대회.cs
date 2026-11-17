using System;

public class Solution {
    
    int n;
    int[] info;
    int[] ryan;
    int[] answer;
    int maxDiff;
    
    public int[] solution(int n, int[] info) {
  
        this.n = n;
        this.info = info;
        ryan = new int[11];
        answer = new int[] { -1 };
        maxDiff = 0;
        Dfs(0, n);
        return answer;
    }
    void Dfs(int index, int remain)
    {
        if (index == 11)
        {
            ryan[10] += remain;
            UpdateAnswer();
            ryan[10] -= remain;
            return;
        }
        Dfs(index + 1, remain);
        int need = info[index] + 1;
        if (need <= remain)
        {
            ryan[index] = need;
            Dfs(index + 1, remain - need);
            ryan[index] = 0;
        }
    }
    void UpdateAnswer()
    {
        int ryanScore = 0;
        int apeachScore = 0;
        for (int index = 0; index < 11; index++)
        {
            if (ryan[index] == 0 && info[index] == 0)
                continue;
            int score = 10 - index;
            if (ryan[index] > info[index])
                ryanScore += score;
            else
                apeachScore += score;
        }
        int diff = ryanScore - apeachScore;
        if (diff <= 0)
            return;
        if (diff > maxDiff)
        {
            maxDiff = diff;
            answer = (int[])ryan.Clone();
            return;
        }
        if (diff == maxDiff && IsBetter(ryan, answer))
            answer = (int[])ryan.Clone();
    }
    // 낮은 점수에 화살이 더 많은지 (0점 칸부터 비교)
    bool IsBetter(int[] candidate, int[] current)
    {
        for (int index = 10; index >= 0; index--)
        {
            if (candidate[index] != current[index])
                return candidate[index] > current[index];
        }
        return false;
    }
}