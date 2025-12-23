using System;

public class Solution {
    public int solution(string before, string after) {
                     int answer = 0;

                int[] count = new int[26];

                foreach (char c in before)
                {
                    count[c - 'a']++;
                }

                foreach (char c in after)
                        {
                    count[c - 'a']--;
                }

                foreach (int cnt in count)
                {
                    if(cnt !=0)
                    {
                        return 0;
                    }
                }

                answer = 1;

                return answer;
    }
}