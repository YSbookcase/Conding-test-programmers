using System;
using System.Text;

public class Solution {
    public string solution(int[] numLog) {
        StringBuilder sb  =  new StringBuilder();
        
        for(int i = 1; i < numLog.Length; i++)
        {
            int diff = numLog[i] - numLog[i-1];
            
            switch(diff)
            {
            case 1:
        sb.Append('w');
        break;
        
        case -1:
        sb.Append('s');
            break;
        
        case 10:
        sb.Append('d');
        break;
        
        case -10:
        sb.Append('a');
        break;
        }
        }
            
        
        
        return sb.ToString();
    }
}