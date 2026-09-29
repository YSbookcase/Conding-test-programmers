// 기사단원의 무기. 두 방법 결과는 같아야 함.
using System;

public class Solution
{
    public int solution(int number, int limit, int power)
    {
        return SumByMultiples(number, limit, power);
    }

    // A. 기사마다 제곱근까지 약수 짝 세기
    int SumBySqrt(int number, int limit, int power)
    {
        int answer = 0;
        for (int n = 1; n <= number; n++)
        {
            int count = 0;
            for (int i = 1; i * i <= n; i++)
            {
                if (n % i == 0)
                {
                    count++;
                    if (i * i != n)
                        count++;
                }
            }
            if (count > limit)
                answer += power;
            else
                answer += count;
        }
        return answer;
    }

    // B. 약수 i의 배수 기사에 +1 한 뒤 합 (O(n log n))
    int SumByMultiples(int number, int limit, int power)
    {
        int[] divCount = new int[number + 1];
        for (int i = 1; i <= number; i++)
        {
            for (int knight = i; knight <= number; knight += i)
                divCount[knight]++;
        }

        int answer = 0;
        for (int i = 1; i <= number; i++)
        {
            if (divCount[i] > limit)
                answer += power;
            else
                answer += divCount[i];
        }
        return answer;
    }
}
