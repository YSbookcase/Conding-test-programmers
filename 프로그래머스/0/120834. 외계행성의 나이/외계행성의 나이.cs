using System;

public class Solution {
    public string solution(int age)        
        {
            string answer = "";
            int num = 0;


            while (age > 0)
            {
                num = age % 10;  // 현재 자리 수

                age /= 10;             // 다음 자리로 이동
            
            switch (num)
                    {

                    case 0:
                        answer += "a";
                        break;


                    case 1:
                        answer += "b";
                        break;

                    case 2:
                        answer += "c";
                        break;

                    case 3:
                        answer += "d";
                        break;

                    case 4:
                        answer += "e";
                        break;

                    case 5:
                        answer += "f";
                        break;

                    case 6:
                        answer += "g";
                        break;

                    case 7:
                        answer += "h";
                        break;

                    case 8:
                        answer += "i";
                        break;

                    case 9:
                        answer += "j";
                        break;
                }


            }

            char[] goodAnswer = answer.ToCharArray();
            int idx = 0;

            for (int i = 0; i < answer.Length; i++)
            {

                goodAnswer[idx++] = answer[answer.Length- 1 - i];
            }


            

            return new string(goodAnswer);
        }
}