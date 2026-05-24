using System;

public class Solution {
    public string solution(string code) {
        string ret = "";
        int mode = 0;
        for(int i = 0; i < code.Length; i++)
        {
            if(code[i] == '1'  && mode == 0)
            {
                mode = 1;
            }
            else if(code[i] != '1' && mode == 0 && i%2 == 0)
            {
                ret = ret + code[i];
            }
            else if(code[i] == '1' && mode == 1)
            {
                mode = 0;
            }
            else if(code[i] != '1' && mode == 1 && i%2 == 1)
            {
                ret = ret + code[i];
            }
        }
        
        return ret == "" ? "EMPTY" : ret;
    }
}