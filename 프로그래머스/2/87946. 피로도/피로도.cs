using System;

public class Solution {
    public int solution(int k, int[,] dungeons) {
    int maxCount = 0;

    void Dfs(int fatigue, int count, bool[] isVisited)
    {
        maxCount = Math.Max(maxCount, count);

        for (int index = 0; index < dungeons.GetLength(0); index++)
        {
            if (isVisited[index])
                continue;
            if (fatigue < dungeons[index, 0])
                continue;

            isVisited[index] = true;
            Dfs(fatigue - dungeons[index, 1], count + 1, isVisited);
            isVisited[index] = false;
        }
    }

    Dfs(k, 0, new bool[dungeons.GetLength(0)]);
    return maxCount;
    }
}