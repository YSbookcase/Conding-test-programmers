using System;

public class Solution {
    public int[] solution(int[] num_list) {
        
        Array.Sort(num_list);
        
        int[] result = new int[5];
        Array.Copy(num_list, result, 5);
        
        return result;
    }
}