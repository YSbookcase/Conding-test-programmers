using System;

public class Solution {
    public int[] solution(int[] arr, int n) {
        
        // if(arr.Length % 2 == 0)
        // {
        //     for(int i = 1; i <arr.Length; i += 2)
        //     {
        //         arr[i] += n;
        //     }
        // }
        // else
        // {
        //     for(int i = 0; i <arr.Length; i += 2)
        //     {
        //         arr[i] += n;
        //     }
        // }
        
        int startIndex = (arr.Length % 2 == 0) ? 1 : 0;
        
        for(int i = startIndex; i < arr.Length; i += 2)
        {
            arr[i] += n;
        }
        
        
        return arr;
        
    }
}