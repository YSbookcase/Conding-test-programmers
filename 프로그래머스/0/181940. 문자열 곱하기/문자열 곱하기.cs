using System;
// using System.Linq;

public class Solution {
    public string solution(string my_string, int k) {
        string answer = "";
     
        for(int i = 0; i< k; i++)
        {
             answer += my_string;
        }
        return answer;
        
//         return string.Concat(Enumerable.Repeat(my_string, k ));
        
        
    }
}