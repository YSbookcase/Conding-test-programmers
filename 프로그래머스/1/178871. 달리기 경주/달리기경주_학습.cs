using System.Collections.Generic;

// 달리기 경주 — Dictionary로 등수 O(1) 조회 후 앞 선수와 교환
public class Solution
{
    public string[] solution(string[] players, string[] callings)
    {
        int n = players.Length;
        Dictionary<string, int> indexByName = new Dictionary<string, int>();

        for (int i = 0; i < n; i++)
        {
            indexByName[players[i]] = i;
        }

        foreach (string name in callings)
        {
            int idx = indexByName[name];
            int front = idx - 1;
            string frontName = players[front];

            players[front] = name;
            players[idx] = frontName;

            indexByName[name] = front;
            indexByName[frontName] = idx;
        }

        return players;
    }
}
