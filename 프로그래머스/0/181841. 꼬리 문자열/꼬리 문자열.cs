using System;
using System.Text;
using System.Linq;

public class Solution {
    public string solution(string[] str_list, string ex) {
        
        StringBuilder sb = new StringBuilder();
        
        for(int i = 0; i < str_list.Length; i++)
        {
            if(!str_list[i].Contains(ex))
            {
                sb.Append(str_list[i]);
            }
        }
        
        return sb.ToString();
        
        // return string.Concat(str_list.Where(s => !s.Contains(ex)));
    }
}