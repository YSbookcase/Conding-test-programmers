using System;

public class Solution {
    public int solution(int[] array, int n) {
        int answer = array[0];
        
int minDiff = Math.Abs(array[0] - n);
        
            for(int i = 1; i < array.Length ; i++)
            {
                int diff = Math.Abs(array[i] - n);
                
                if(diff < minDiff)
                {
                
                    minDiff = diff;
                    answer = array[i];
                }
                else if (diff == minDiff && array[i]< answer)
                {
                    answer = array[i];
                    
                }
            }
        
        
        return answer;
    }
}