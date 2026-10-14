public class Solution {
    public int solution(int n) {
            
        int previous = 0;
        int current = 1;
        int divisor = 1234567;

        for (int distance = 2; distance <= n; distance++)
        {
            int next = (previous + current) % divisor;
            previous = current;
            current = next;
        }

        return current;
    }
}