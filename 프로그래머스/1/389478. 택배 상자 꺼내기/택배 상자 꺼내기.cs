using System;

public class Solution {
    public int solution(int n, int w, int num) {
        
        return SolveByFloorDiff(n, w, num);
        
    }
    
        // 중간 층은 항상 가득 차 있으므로, 빈 칸은 맨 위 층에만 생길 수 있음
    int SolveByFloorDiff(int n, int w, int num)
    {
        int row = (num - 1) / w;
        int order = (num - 1) % w;
        int col = IsEvenRow(row) ? order : (w - 1 - order);

        int maxRow = (n - 1) / w;
        int answer = (maxRow - row) + 1;

        int topCount = n % w;
        // 맨 위가 가득이면 보정 없음 (topCount==0 이면 w개로 가득)
        if (topCount == 0)
        {
            return answer;
        }

        // 맨 위 층에 num과 같은 col 칸이 없으면 하나 덜 셈
        if (!HasBoxOnTopRow(maxRow, col, w, topCount))
        {
            answer--;
        }

        return answer;
    }

    // 불완전한 맨 위 층에서 col에 상자가 있는지
     bool HasBoxOnTopRow(int maxRow, int col, int w, int topCount)
    {
        if (IsEvenRow(maxRow))
        {
            // 왼→오: 0 .. topCount-1
            return col < topCount;
        }
        // 오→왼: (w-topCount) .. (w-1)
        return col >= w - topCount;
    }
    
        bool IsEvenRow(int row)
    {
        return row % 2 == 0;
    }
}