using System;
using System.Collections.Generic;

public class Solution {
    public int solution(int[] priorities, int location) {
            
        Queue<(int index, int priority)> waiting = new Queue<(int index, int priority)>();
        for(int index = 0; index < priorities.Length; index++)
        waiting.Enqueue((index, priorities[index]));

        int order = 0;

        while (waiting.Count > 0)
        {
            (int index, int priority) = waiting.Dequeue();

            bool hasHigher = false;
            foreach ((int otherIndex, int otherPriority) in waiting)
            {
                if (otherPriority > priority)
                {
                    hasHigher = true;
                    break;
                }
            }

            if (hasHigher)
            {
                waiting.Enqueue((index, priority));
                continue;
            }

            order++;
            if (index == location)
            {
                return order;
            }

        }

        return order;
    }
}