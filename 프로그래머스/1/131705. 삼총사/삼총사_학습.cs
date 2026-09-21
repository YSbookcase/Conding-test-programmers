// 삼총사. 제출은 三重 for. 나머지는 n이 클 때 보기.
using System;
using System.Collections.Generic;

public class Solution
{
    public int solution(int[] number)
    {
        return CountByTripleLoop(number);
    }

    // A. i < j < k. n <= 13이면 이게 맞음
    int CountByTripleLoop(int[] number)
    {
        int answer = 0;
        for (int i = 0; i < number.Length - 2; i++)
        {
            for (int j = i + 1; j < number.Length - 1; j++)
            {
                for (int k = j + 1; k < number.Length; k++)
                {
                    if (number[i] + number[j] + number[k] == 0)
                        answer++;
                }
            }
        }
        return answer;
    }

    // B. 하나 고정, 남은 구간 왼쪽·오른쪽을 좁힘. 이게 투 포인터
    int CountByTwoPointers(int[] number)
    {
        int[] sorted = (int[])number.Clone();
        Array.Sort(sorted);
        int answer = 0;
        int n = sorted.Length;
        for (int i = 0; i < n - 2; i++)
        {
            int left = i + 1;
            int right = n - 1;
            while (left < right)
            {
                int sum = sorted[i] + sorted[left] + sorted[right];
                if (sum < 0)
                    left++;
                else if (sum > 0)
                    right--;
                else
                {
                    if (sorted[left] == sorted[right])
                    {
                        int same = right - left + 1;
                        answer += same * (same - 1) / 2;
                        break;
                    }
                    int leftValue = sorted[left];
                    int rightValue = sorted[right];
                    int leftCount = 0;
                    int rightCount = 0;
                    while (left < right && sorted[left] == leftValue)
                    {
                        leftCount++;
                        left++;
                    }
                    while (left <= right && sorted[right] == rightValue)
                    {
                        rightCount++;
                        right--;
                    }
                    answer += leftCount * rightCount;
                }
            }
        }
        return answer;
    }

    // C. 하나 고정, 지나온 번호를 통에 넣고 필요값을 찾음
    int CountByHash(int[] number)
    {
        int answer = 0;
        for (int i = 0; i < number.Length; i++)
        {
            Dictionary<int, int> seenCount = new Dictionary<int, int>();
            for (int j = i + 1; j < number.Length; j++)
            {
                int need = -(number[i] + number[j]);
                if (seenCount.TryGetValue(need, out int count))
                    answer += count;
                if (!seenCount.ContainsKey(number[j]))
                    seenCount[number[j]] = 0;
                seenCount[number[j]]++;
            }
        }
        return answer;
    }

    // D. 둘 고정, 오른쪽에서 세 번째 값을 이분 탐색
    int CountByBinarySearch(int[] number)
    {
        int[] sorted = (int[])number.Clone();
        Array.Sort(sorted);
        int answer = 0;
        for (int i = 0; i < sorted.Length - 2; i++)
        {
            for (int j = i + 1; j < sorted.Length - 1; j++)
            {
                int need = -(sorted[i] + sorted[j]);
                answer += CountEqualFrom(sorted, j + 1, need);
            }
        }
        return answer;
    }

    int CountEqualFrom(int[] sorted, int from, int need)
    {
        int left = from;
        int right = sorted.Length - 1;
        int found = -1;
        while (left <= right)
        {
            int mid = (left + right) / 2;
            if (sorted[mid] == need)
            {
                found = mid;
                right = mid - 1;
            }
            else if (sorted[mid] < need)
                left = mid + 1;
            else
                right = mid - 1;
        }
        if (found < 0)
            return 0;
        int count = 0;
        for (int index = found; index < sorted.Length && sorted[index] == need; index++)
            count++;
        return count;
    }
}
