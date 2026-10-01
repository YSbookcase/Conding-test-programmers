public class Solution {
    public bool solution(int x) {
                
        int digitSum = 0;
        int remain = x;

        while (remain > 0)
        {
            digitSum += remain % 10;
            remain = remain / 10;
        }

        return x % digitSum == 0;
    }
}