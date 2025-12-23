using System;

public class Solution {
    public int solution(string my_string) {
                int answer = 0;

                string[] token = my_string.Split(' ');

                answer = int.Parse(token[0]);

                for (int i = 1; i < token.Length; i += 2)
                {
                    string op = token[i];
                    int num = int.Parse(token[i + 1]);
                    if (op == "+")
                    {
                        answer += num;
                    }
                    else if (op == "-")
                    {
                        answer -= num;
                    }
                }

                return answer;
    }
}