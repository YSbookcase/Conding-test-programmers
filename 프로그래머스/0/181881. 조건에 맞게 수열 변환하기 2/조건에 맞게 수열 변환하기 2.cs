using System;

public class Solution {
    public int solution(int[] arr) {
        
        int x = 0;
        
        while(true)
        {
            bool changed = false;
            
            for(int i = 0; i < arr.Length; i++)
            {
                if(arr[i] >= 50 && arr[i] % 2 == 0)
                {
                     arr[i] /= 2;
                    changed = true;
                }
                else if (arr[i] < 50 && arr[i] % 2 != 0)
                {
                    arr[i] = arr[i]*2 +1;
                    changed = true;
                }
            }
            
            if(!changed)
            {
                return x;
            }
            
            x++;
        }
        
    }
}