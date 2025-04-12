using System;

public class Solution {
    public int[] solution(int[] numbers, string direction)  {
     int[] answer = new int[numbers.Length];

     if (direction == "right")
     {
         answer[0] = numbers[numbers.Length - 1];
         for (int i = 0; i < numbers.Length-1; i++)
         {

             answer[i + 1] = numbers[i];
         }
     }
     if (direction == "left")
     {
         
         for (int i = 0; i < numbers.Length-1; i++)
         {

             answer[i] = numbers[i + 1];

         }

         answer[numbers.Length - 1] = numbers[0];

     }


        


     return answer;
 }
}