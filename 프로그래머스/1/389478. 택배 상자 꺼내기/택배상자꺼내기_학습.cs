using System;

// 택배 상자 꺼내기 — 방식 A(위층 루프) / 방식 B(층 차이 ±1)
public class Solution
{
    // 제출·기본 확인용: 방식 A
    public int solution(int n, int w, int num)
    {
        return SolveByUpperLoop(n, w, num);
        // return SolveByFloorDiff(n, w, num);
    }

    // --- 방식 A: 위층을 돌며 같은 열에 상자가 있을 때마다 +1 ---
    int SolveByUpperLoop(int n, int w, int num)
    {
        int row = (num - 1) / w;
        int order = (num - 1) % w;
        int col = IsEvenRow(row) ? order : (w - 1 - order);

        int answer = 1;
        int maxRow = (n - 1) / w;

        for (int r = row + 1; r <= maxRow; r++)
        {
            int box = GetBoxNumber(r, col, w);
            if (box <= n)
            {
                answer++;
            }
        }

        return answer;
    }

    // --- 방식 B: (생각했던 방식) 층 차이로 세고, 맨 위 열이 비면 -1 ---
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

    int GetBoxNumber(int r, int col, int w)
    {
        int start = r * w + 1;
        if (IsEvenRow(r))
        {
            return start + col;
        }
        return start + (w - 1 - col);
    }

    bool IsEvenRow(int row)
    {
        return row % 2 == 0;
    }
}
