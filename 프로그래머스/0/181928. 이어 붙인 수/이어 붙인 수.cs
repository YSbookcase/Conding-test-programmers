using System;

public class Solution {
    public int solution(int[] num_list) {
        int answer = 0;
        string get1 = "";
        string get2 = "";
        for(int i = 0; i < num_list.Length; i++)
        {
            if(num_list[i]%2 == 1)
            {
               get1 +=  num_list[i].ToString();
            }
            else
            {
                get2 += num_list[i].ToString();
            }
        }
   int getnum1 = int.Parse(get1);
       int  getnum2 = int.Parse(get2);
        answer = getnum1 + getnum2;
        return answer;
    }
}