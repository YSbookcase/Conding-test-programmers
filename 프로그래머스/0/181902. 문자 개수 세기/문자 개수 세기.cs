using System;

public class Solution {
    public int[] solution(string my_string) {
        
        int[] result = new int[52];
        
        for(int i = 0; i < my_string.Length; i++)
        {
            if(my_string[i] >= 'A' && my_string[i] <= 'Z')
            {
                result[my_string[i] - 'A']++;
            }
            else
            {
            
                result[my_string[i] - 'a'+ 26 ]++;
            }    

        }
    
        return result;
    }
}