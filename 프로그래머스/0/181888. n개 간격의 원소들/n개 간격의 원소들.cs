using System;

public class Solution {
    public int[] solution(int[] num_list, int n) {
    
        int[] result = new int[(num_list.Length-1)/n+1];
        
        int index = 0;
        
        for(int i = 0; i < num_list.Length; i += n)
        {
            result[index++] = num_list[i];
        }
        return result;
    }
}