// 신고 결과 받기. 고유 신고 쌍 → k 이상 정지 → 메일 수. 두 방법 결과는 같아야 함.
using System.Collections.Generic;

public class Solution
{
    public int[] solution(string[] id_list, string[] report, int k)
    {
        return CountMailsByTwoDicts(id_list, report, k);
    }

    // A. 대상→신고자, 신고자→대상. 정지는 Count, 메일은 내가 신고한 것 중 정지 수.
    int[] CountMailsByTwoDicts(string[] idList, string[] report, int k)
    {
        Dictionary<string, HashSet<string>> targetToReporters = new Dictionary<string, HashSet<string>>();
        Dictionary<string, HashSet<string>> reporterToTargets = new Dictionary<string, HashSet<string>>();

        foreach (string id in idList)
        {
            targetToReporters[id] = new HashSet<string>();
            reporterToTargets[id] = new HashSet<string>();
        }

        foreach (string row in report)
        {
            string[] parts = row.Split(' ');
            string reporter = parts[0];
            string target = parts[1];
            targetToReporters[target].Add(reporter);
            reporterToTargets[reporter].Add(target);
        }

        HashSet<string> bannedIds = new HashSet<string>();
        foreach (string id in idList)
        {
            if (targetToReporters[id].Count >= k)
                bannedIds.Add(id);
        }

        int[] result = new int[idList.Length];
        for (int i = 0; i < idList.Length; i++)
        {
            int mailCount = 0;
            foreach (string target in reporterToTargets[idList[i]])
            {
                if (bannedIds.Contains(target))
                    mailCount++;
            }
            result[i] = mailCount;
        }
        return result;
    }

    // B. 신고자→대상만. 정지는 집합을 뒤집어 횟수를 센다.
    int[] CountMailsByOneDict(string[] idList, string[] report, int k)
    {
        Dictionary<string, HashSet<string>> reporterToTargets = new Dictionary<string, HashSet<string>>();
        Dictionary<string, int> reportCount = new Dictionary<string, int>();

        foreach (string id in idList)
        {
            reporterToTargets[id] = new HashSet<string>();
            reportCount[id] = 0;
        }

        foreach (string row in report)
        {
            string[] parts = row.Split(' ');
            string reporter = parts[0];
            string target = parts[1];
            reporterToTargets[reporter].Add(target);
        }

        foreach (string reporter in idList)
        {
            foreach (string target in reporterToTargets[reporter])
                reportCount[target]++;
        }

        int[] result = new int[idList.Length];
        for (int i = 0; i < idList.Length; i++)
        {
            int mailCount = 0;
            foreach (string target in reporterToTargets[idList[i]])
            {
                if (reportCount[target] >= k)
                    mailCount++;
            }
            result[i] = mailCount;
        }
        return result;
    }
}
