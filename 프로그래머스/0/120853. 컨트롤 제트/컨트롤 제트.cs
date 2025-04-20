using System;
using System.Collections.Generic;


public class Solution {
    public int solution(string s){
    int answer = 0;

    string[] temps = s.Split(' ', StringSplitOptions.RemoveEmptyEntries);

    int sum = 0;
    Stack<int> histroy = new Stack<int>();

    foreach(string temp in temps)
    {
        if (temp == "Z")
        {
            if (histroy.Count > 0)
            {
                answer -= histroy.Pop();
            }


        }
        else if (int.TryParse(temp, out int num))
        {
            answer += num;
            histroy.Push(num);
        }

    }

    return answer;
}
}