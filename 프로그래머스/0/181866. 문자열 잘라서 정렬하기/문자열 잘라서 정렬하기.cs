using System;

public class Solution {
    public string[] solution(string myString) {
        
        string[] result = myString.Split(
        'x',
        StringSplitOptions.RemoveEmptyEntries
        );
        
        Array.Sort(result);
        
        return result;
    }
}