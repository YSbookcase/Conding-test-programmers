using System;

public class Solution {
    public string[] solution(string my_str, int n) {
            

                int len = my_str.Length;
                int size = (len + n - 1) / n; // 올림 계산
                string[] answer = new string[size];

        int index = 0;
        
                for (int i = 0; i < len; i += n)
                {
                    int count = Math.Min(n, len - i);
                    answer[index++] = my_str.Substring(i, count);
                }

                return answer;
    }
}