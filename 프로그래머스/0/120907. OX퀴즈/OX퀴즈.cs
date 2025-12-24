using System;

public class Solution {
    public string[] solution(string[] quiz) {
            string[] answer = new string[quiz.Length];

            for (int i = 0; i < quiz.Length; i++)
            {
                string[] t = quiz[i].Split(' ');
                int num1 = int.Parse(t[0]);
                string op = t[1];
                int num2 = int.Parse(t[2]);
                int result = int.Parse(t[4]);

                int calc = 0;
                if (op == "+")
                {
                    calc = num1 + num2;
                }
                else if (op == "-")
                {
                    calc = num1 - num2;
                }
                answer[i] = (calc == result) ? "O" : "X";
            }


            return answer;
        }
}