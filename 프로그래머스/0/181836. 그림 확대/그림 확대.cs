using System;
using System.Collections.Generic;
using System.Text;

public class Solution {
    public string[] solution(string[] picture, int k) {
        List<string> answer = new List<string>();
        
        foreach( string row in picture)
        {
            StringBuilder expandedRow = new StringBuilder();
            
            foreach(char pixel in row )
            {
                expandedRow.Append(new string(pixel, k));
                
            }
            
            for (int i = 0; i < k ; i ++)
            {
                answer.Add(expandedRow.ToString());
            }
        }
        
        return answer.ToArray();
        
//         List<string> answer = new List<string>();
        
//         foreach (string row in picture)
//         {
//             string expandedRow = row
//                 .Replace(".", new string('.',k))
//                 .Replace("x", new string('x',k));
            
//             for (int i = 0; i < k; i++)
//             {
//                 answer.Add(expandedRow);
//             }
            
//         }
        
//         return answer.ToArray();
        
    }
}