using System;

public class Solution {
    public int solution(int[] array) {
                        
        int answer = 0;
                Array.Sort(array);
                int midAddress = (array.Length - 1) / 2 ;
                answer = (int)array[midAddress];

                
        
        return answer;
    }
}