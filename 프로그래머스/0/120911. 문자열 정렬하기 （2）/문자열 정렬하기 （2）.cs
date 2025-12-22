using System;

public class Solution {
    public string solution(string my_string) {
                char[] chars = my_string.ToLower().ToCharArray();
                Array.Sort(chars);
                return new string(chars);
    }
}