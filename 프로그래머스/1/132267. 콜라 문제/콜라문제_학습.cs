// 콜라 문제. A 재귀는 노트용, 제출은 B while.
using System;

public class Solution
{
    public int solution(int a, int b, int n)
    {
        return SumByLoop(a, b, n);
    }

    // A. 받은 병을 재귀 결과에 더함. 깊이가 커질 수 있음
    int GetCoke(int a, int b, int n)
    {
        int refilled = 0;
        if (n >= a)
        {
            refilled = (n / a) * b;
            int remain = n % a;
            n = refilled + remain;
        }
        else
        {
            return 0;
        }
        return refilled + GetCoke(a, b, n);
    }

    // B. 같은 식, 스택 없이 반복
    int SumByLoop(int a, int b, int n)
    {
        int answer = 0;
        while (n >= a)
        {
            int refilled = (n / a) * b;
            int remain = n % a;
            answer += refilled;
            n = refilled + remain;
        }
        return answer;
    }

    // C. 한 교환에 빈 병이 a-b 줄어듦. 횟수 (n-b)/(a-b)
    int SumByFormula(int a, int b, int n)
    {
        return (n > b ? n - b : 0) / (a - b) * b;
    }
}
