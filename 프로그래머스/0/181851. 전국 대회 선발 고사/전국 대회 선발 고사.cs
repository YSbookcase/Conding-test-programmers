using System;

public class Solution {
    public int solution(int[] rank, bool[] attendance) {
        
//         int result = 0;
//         int count = 0;
//         int[] multiplier = {10000, 100, 1};
        
//         for(int i = 1; i < rank.Length + 1; i++ )
//         {
            
//             int index = Array.IndexOf(rank, i);
//             if(attendance[index])
//             {
//                 result += index * multiplier[count++];
//                 if(count == 3) break;
//             }
//         }
        
//         return result;
        
        int[] studentOfRank = new int[rank.Length + 1];
        
        for(int i = 0; i < rank.Length; i++)
        {
            studentOfRank[rank[i]] = i;
        }
        
        int count = 0;
        int result = 0;
        int[] score = {10000, 100, 1};
        
        for(int r = 1; r <= rank.Length; r++)
        {
            int studentId = studentOfRank[r];
            if(attendance[studentId])
            {
                result += studentId * score[count++];
                if(count == 3) break;
            }
        }
        
        return result;
        
    }
}