using System;

public class Solution {
    public int solution(string myString, string pat) {
        return myString.Contains(pat, StringComparison.OrdinalIgnoreCase) ? 1 : 0;
    }
}