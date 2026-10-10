public class Solution {
    public long solution(int n) {
                if (n == 1)
        {
            return 1;
        }

        long previous = 1;
        long current = 2;
        int divisor = 1234567;

        for (int distance = 3; distance <= n; distance++)
        {
            long next = (previous + current) % divisor;
            previous = current;
            current = next;
        }

        return current;
    }
}