using System;
using System.Collections.Generic;

public class Solution {
    public string[] solution(string[,] plans) {
        
        int count = plans.GetLength(0);
        (string name, int start, int play)[] tasks = new (string, int, int)[count];
        for (int i = 0; i < count; i++)
        {
            tasks[i] = (plans[i, 0], ToMinutes(plans[i, 1]), int.Parse(plans[i, 2]));
        }
        Array.Sort(tasks, (a, b) => a.start.CompareTo(b.start));
        Stack<(string name, int remain)> paused = new Stack<(string, int)>();
        List<string> finished = new List<string>();
        for (int i = 0; i < count; i++)
        {
            int nextStart = i + 1 < count ? tasks[i + 1].start : int.MaxValue;
            int spare = nextStart - tasks[i].start;
            int remain = tasks[i].play;
            if (remain <= spare)
            {
                finished.Add(tasks[i].name);
                spare -= remain;
                while (spare > 0 && paused.Count > 0)
                {
                    (string name, int remain) top = paused.Pop();
                    if (top.remain <= spare)
                    {
                        spare -= top.remain;
                        finished.Add(top.name);
                    }
                    else
                    {
                        paused.Push((top.name, top.remain - spare));
                        spare = 0;
                    }
                }
            }
            else
            {
                paused.Push((tasks[i].name, remain - spare));
            }
        }
        return finished.ToArray();
    }
    
    int ToMinutes(string time)
    {
        string[] parts = time.Split(':');
        return int.Parse(parts[0]) * 60 + int.Parse(parts[1]);
    }
}