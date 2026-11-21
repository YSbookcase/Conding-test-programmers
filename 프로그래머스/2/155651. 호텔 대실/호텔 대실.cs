using System;
using System.Collections.Generic;

public class Solution {
    public int solution(string[,] book_time) {
        
        int count = book_time.GetLength(0);
        int[][] times = new int[count][];

        for (int i = 0; i < count; i++)
        {
            times[i] = new int[]
            {
            ToMinutes(book_time[i, 0]),
            ToMinutes(book_time[i, 1]) + 10
            };
        }

        Array.Sort(times, (a, b) => a[0].CompareTo(b[0]));

        PriorityQueue<int, int> roomEnds = new PriorityQueue<int, int>();

        foreach (int[] time in times)
        {
            int start = time[0];
            int end = time[1];

            if (roomEnds.Count > 0 && roomEnds.Peek() <= start)
                roomEnds.Dequeue();

            roomEnds.Enqueue(end, end);
        }

        return roomEnds.Count;
    }

    int ToMinutes(string time)
    {
        string[] parts = time.Split(':');
        return int.Parse(parts[0]) * 60 + int.Parse(parts[1]);
    }
}