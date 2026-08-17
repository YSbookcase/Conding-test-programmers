using System;

public class Solution {
    public int[] solution(int n, int[] slicer, int[] num_list) {
        
        int a = slicer[0];
        int b = slicer[1];
        int c = slicer[2];
        
        int start = 0;
        int end = 0;
        int step = 1;
        
        if(n == 1)
        {
            start = 0;
            end = b;
        }
        else if (n == 2)
        {
            start = a;
            end = num_list.Length -1;
        }
        else if (n == 3)
        {
            start = a;
            end = b;
        }
        else
        {
            start = a;
            end = b;
            step = c;
        }
        
        int length = (end - start) / step + 1;
        int [] result = new int[length];
        
        int index = 0;
        
        for(int i = start; i <= end; i += step)
        {
            result[index] = num_list[i];
            index++;
        }
        
        return result;
        
    }
}