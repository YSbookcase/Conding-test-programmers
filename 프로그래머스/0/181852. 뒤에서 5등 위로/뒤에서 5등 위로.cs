using System;

public class Solution {
    public int[] solution(int[] num_list) {
        
        Array.Sort(num_list);
        
        int[] result = new int[num_list.Length - 5];
        Array.Copy(num_list, 5, result, 0, num_list.Length - 5);
        
        return result;
    }
}