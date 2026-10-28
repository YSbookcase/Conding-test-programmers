using System;

public class Solution {
    public int solution(string skill, string[] skill_trees) {
                
        int possibleCount = 0;

        foreach (string tree in skill_trees)
        {
            int step = 0;
            bool isPossible = true;

            foreach (char learned in tree)
            {
                int order = skill.IndexOf(learned);
                if (order == -1)
                {
                    continue;
                }

                if (order != step)
                {
                    isPossible = false;
                    break;
                }
                step++;
            }

            if (isPossible)
            {
                possibleCount++;
            }
        }
        return possibleCount;
    }
}