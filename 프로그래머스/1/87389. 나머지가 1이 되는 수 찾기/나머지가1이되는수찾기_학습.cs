// 나머지가 1이 되는 수 찾기. n-1의 2 이상 최소 약수. 두 방법 결과는 같아야 함.
public class Solution
{
    public int solution(int n)
    {
        return SmallestBySqrt(n);
    }

    // A. 2부터 n % x == 1. 답이 n-1이면 거기까지 간다.
    int SmallestByLoop(int n)
    {
        for (int x = 2; x < n; x++)
        {
            if (n % x == 1)
                return x;
        }
        return n - 1;
    }

    // B. n-1을 2부터 제곱근까지. 없으면 n-1(소수).
    int SmallestBySqrt(int n)
    {
        int remain = n - 1;
        for (int i = 2; i * i <= remain; i++)
        {
            if (remain % i == 0)
                return i;
        }
        return remain;
    }
}
