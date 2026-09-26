using System;
using System.Collections.Generic;

public class Solution {
    public int[] solution(string[] id_list, string[] report, int k) {
                int[] answer = new int[] { };

        Dictionary<string, HashSet<string>> targetToReporters = new Dictionary<string, HashSet<string>>();
        Dictionary<string, HashSet<string>> reporterToTargets = new Dictionary<string, HashSet<string>>();

        foreach (string id in id_list)
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
        foreach (string id in id_list)
        {
            if (targetToReporters[id].Count >= k)
                bannedIds.Add(id);
        }

        int[] result = new int[id_list.Length];
        for (int i = 0; i < id_list.Length; i++)
        {
            int mailCount = 0;
            foreach (string target in reporterToTargets[id_list[i]])
            {
                if (bannedIds.Contains(target))
                    mailCount++;
            }

            result[i] = mailCount;
        }

        return result;
    }
}