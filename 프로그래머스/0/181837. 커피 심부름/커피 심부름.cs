using System;

public class Solution {
    public int solution(string[] order) {
        
        int total = 0;
        
        foreach (string menu in order)
        {
            if (menu == "anything" || menu.Contains("americano"))
            {
                total += 4500;
            }
            else
            {
                total += 5000;
            }
            
        }
        
        return total;
    }
}