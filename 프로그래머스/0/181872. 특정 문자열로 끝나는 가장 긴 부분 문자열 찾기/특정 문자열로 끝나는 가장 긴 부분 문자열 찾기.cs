using System;

public class Solution {
    public string solution(string myString, string pat) {
        int index = myString.LastIndexOf(pat);
        
        return myString.Substring(0, index + pat.Length);
    }
}