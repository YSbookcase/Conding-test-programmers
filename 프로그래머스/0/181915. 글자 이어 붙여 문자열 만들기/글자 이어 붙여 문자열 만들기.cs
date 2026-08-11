using System;
using System.Text;

public class Solution {
    public string solution(string my_string, int[] index_list) {
        
        //string answer = "";
        StringBuilder answer = new StringBuilder();
        
        foreach(int index in index_list)
        {
            //answer += my_string[index];
            answer.Append(my_string[index]);
        }
        
        return answer.ToString();
    }
}