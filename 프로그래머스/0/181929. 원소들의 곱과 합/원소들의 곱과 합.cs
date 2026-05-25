using System;

public class Solution {
    public int solution(int[] num_list) {
        
        int get1 = 0;
        int get2 = 1;
        
        for(int i = 0; i < num_list.Length; i++)
        {
           get1 += num_list[i];
            get2 *= num_list[i];
        }
        
        if(get2 < get1*get1 )
        {
            return 1;
        }
        else
        {
            return 0;
        }
        
    }
}