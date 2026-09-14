using System;

public class Solution {
    public string solution(string video_len, string pos, string op_start, string op_end, string[] commands) {
    
        int videoLen = ToSeconds(video_len);
        int cur = ToSeconds(pos);
        int opStart = ToSeconds(op_start);
        int opEnd = ToSeconds(op_end);
        
        cur = SkipOpening(cur, opStart, opEnd);
        
        foreach(string command in commands)
        {
            if(command == "prev")
            {
                cur = Math.Max(0, cur - 10);
            }
            else
            {
                cur = Math.Min(videoLen, cur + 10);
            }
            
            cur = SkipOpening(cur, opStart, opEnd);
            
        }
        
        return ToTimeString(cur);
        
    }
    
    
    int ToSeconds(string time)
    {
        int minute = int.Parse(time.Substring(0,2));
        int second = int.Parse(time.Substring(3,2));
        
        return minute * 60 + second;
    }
    
    string ToTimeString(int totalSecond)
    {
        int minute = totalSecond / 60;
        int second = totalSecond % 60;
        
        return $"{minute:D2}:{second:D2}";
    }
    
    int SkipOpening(int cur, int opStart, int opEnd)
    {
        if(cur >= opStart && cur <= opEnd)
        {
            return opEnd;
        }
        return cur;
    }
}