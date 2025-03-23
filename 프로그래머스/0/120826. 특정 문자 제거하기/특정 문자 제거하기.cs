using System;

public class Solution {
    public string solution(string my_string, string letter) {
       

    char[] target = new char[my_string.Length];
    int idx = 0;

    for (int i = 0; i< my_string.Length; i++)
    {
        if (my_string[i] != letter[0])
        {

            target[idx++] = my_string[i];

        }

    }



    return new string(target, 0, idx); // idx까지의 문자만 사용

}
}