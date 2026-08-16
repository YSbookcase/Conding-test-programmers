using System;

public class Solution {
    public int solution(string my_string, string is_prefix) {
        
        //범위 조심해야함. 0은 의미가 없고 1부터이며 마지막 문자를 포함하기 위해서 <= 로 진행해야함.왜냐하면 Substring의 2번째 변수가 문자의 길이를 나타내기 때문임.
        // for(int i = 1; i <= my_string.Length; i++)
        // {
        //     if(is_prefix == my_string.Substring(0,i))
        //     {
        //         return 1;
        //     }
        // }
        
        //return 0;
        
        
        return my_string.StartsWith(is_prefix) ? 1 : 0;
        
    }
}