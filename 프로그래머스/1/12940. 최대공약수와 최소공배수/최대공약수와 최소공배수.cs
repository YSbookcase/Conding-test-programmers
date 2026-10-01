public class Solution {
    public int[] solution(int n, int m) {
        int[] answer = new int[2];

        int gcd = Gcd(n, m);
        long lcm = (long)n / gcd * m;

        answer[0] = gcd;
        answer[1] = (int)lcm;

        return answer;
    }

    int Gcd(int a, int b)
    {
        while (b != 0)
        {
            int remain = a % b;
            a = b;
            b = remain;
        }
        return a;
    }
}