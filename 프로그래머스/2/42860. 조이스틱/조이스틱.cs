using System;

public class Solution {
    public int solution(string name) {
                
        int changeCount = 0;
        int moveCount = name.Length - 1;

        for (int index = 0; index < name.Length; index++)
        {
            int up = name[index] - 'A';
            int down = 'Z' - name[index] + 1;
            changeCount += Math.Min(up, down);

            int nextIndex = index + 1;
            while (nextIndex < name.Length && name[nextIndex] == 'A')
            {
                nextIndex++;
            }

            int moveRightThenLeft = index * 2 + (name.Length - nextIndex);
            int moveLeftThenRight = (name.Length - nextIndex) * 2 + index;
            moveCount = Math.Min(moveCount, Math.Min(moveRightThenLeft, moveLeftThenRight));

        }

        return changeCount + moveCount;
    }
}