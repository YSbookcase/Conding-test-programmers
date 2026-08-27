using System;

public class Solution {
    public int[] solution(string myString) {
        
        string[] parts = myString.Split('x');
        
        int[] result = new int[parts.Length];
            
            for(int i = 0; i < parts.Length; i++)
            {
                result[i] = parts[i].Length;
            }
            
        return result;
        
    }
}