using System;

// [PCCP 기출] 동영상 재생기 — 초 단위로 계산 후 mm:ss로 되돌림
public class Solution
{
    public string solution(string video_len, string pos, string op_start, string op_end, string[] commands)
    {
        int videoLen = ToSeconds(video_len);
        int cur = ToSeconds(pos);
        int opStart = ToSeconds(op_start);
        int opEnd = ToSeconds(op_end);

        cur = SkipOpening(cur, opStart, opEnd);

        foreach (string command in commands)
        {
            if (command == "prev")
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

    // "mm:ss" → 앞 2글자 분, 뒤 2글자 초 → 총 초
    int ToSeconds(string time)
    {
        int minute = int.Parse(time.Substring(0, 2));
        int second = int.Parse(time.Substring(3, 2));
        return minute * 60 + second;
    }

    // 총 초 → "mm:ss" (한 자리면 0 채움)
    string ToTimeString(int totalSeconds)
    {
        int minute = totalSeconds / 60;
        int second = totalSeconds % 60;
        return $"{minute:D2}:{second:D2}";
    }

    int SkipOpening(int cur, int opStart, int opEnd)
    {
        if (cur >= opStart && cur <= opEnd)
        {
            return opEnd;
        }
        return cur;
    }
}
