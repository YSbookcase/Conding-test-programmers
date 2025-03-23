using System;

public class Solution {
    public int[] solution(int[] num_list) {
        int[] answer = new int[2];
        int countOdd = 0;
        int countEven = 0;
        
        for (int i = 0; i < num_list.Length; i++)
        {
            
            if ( num_list[i]%2== 0)
            {
                
                countEven +=1;
                
            }
            else if (num_list[i]% 2 !=0)
            {
                countOdd +=1;
                
            }
            
        }
        
        answer[0] = countEven;
        answer[1] = countOdd;
        
        
        return answer;
    }
}