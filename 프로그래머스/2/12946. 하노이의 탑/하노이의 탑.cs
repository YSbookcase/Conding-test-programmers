using System;
using System.Collections.Generic;

public class Solution {
    public int[,] solution(int n) {
                
        List<int[]> moves = new List<int[]>();
        Move(n, 1, 3, 2, moves);

        int[,] answer = new int[moves.Count, 2];

        for (int index = 0; index < moves.Count; index++)
        {
            answer[index, 0] = moves[index][0];
            answer[index, 1] = moves[index][1];
        }

        return answer;
    }

    void Move(int diskCount, int from, int to, int via, List<int[]> moves)
    {
        if (diskCount == 1)
        {
            moves.Add(new int[] { from, to });
            return;
        }

        Move(diskCount - 1, from, via, to, moves);
        moves.Add(new int[] { from, to });
        Move(diskCount - 1, via, to, from, moves);
    }
}