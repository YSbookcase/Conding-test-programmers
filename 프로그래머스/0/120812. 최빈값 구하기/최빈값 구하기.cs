using System;

public class Solution 
{
    public int solution(int[] array) 
    {
     if (array.Length == 1) return array[0];

     Array.Sort(array);

     int currentValue = array[0];
     int currentCount = 1;

     int mostFN = array[0];
     int maxCount = 1;
     bool isDuplicated = false;

     for (int i = 1; i < array.Length; i++)
     {
         if (array[i] == currentValue)
         {
             currentCount++;
         }
         else
         {
             if (currentCount > maxCount)
             {
                 mostFN = currentValue;
                 maxCount = currentCount;
                 isDuplicated = false;
             }
             else if (currentCount == maxCount)
             {
                 isDuplicated = true;
             }

             // 다음 숫자로 초기화
             currentValue = array[i];
             currentCount = 1;
         }
     }

     // 마지막 값 처리
     if (currentCount > maxCount)
     {
         mostFN = currentValue;
         maxCount = currentCount;
         isDuplicated = false;
     }
     else if (currentCount == maxCount)
     {
         isDuplicated = true;
     }

     return isDuplicated ? -1 : mostFN;
 }
           
}