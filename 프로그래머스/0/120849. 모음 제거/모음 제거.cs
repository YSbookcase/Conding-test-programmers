using System;
using System.Text;

public class Solution {
    public string solution(string my_string) {
    string answer = "";
    string vowels = "aeiouAEIOU";
    StringBuilder result = new StringBuilder();


    foreach (char item in my_string)
    {
        if (!vowels.Contains(item))
        {
            result.Append(item);
        }

    }

    return answer = result.ToString();
}
}