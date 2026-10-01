using System;

public class Solution {
    public long solution(long n) {
        char[] digits = n.ToString().ToCharArray();
        Array.Sort(digits);
        Array.Reverse(digits);
        return long.Parse(new string(digits));
    }
}