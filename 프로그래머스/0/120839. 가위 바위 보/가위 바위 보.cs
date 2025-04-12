using System;
using System.Text;

public class Solution {
    public string solution(string rsp)  {
     StringBuilder sb = new StringBuilder();
string answer = "";
     foreach (char c in rsp)
     {
         switch (c)
         {
             case '2':
                 sb.Append("0"); // 가위 -> 바위
                 break;
             case '0':
                 sb.Append("5"); // 바위 -> 보
                 break;
             case '5':
                 sb.Append("2"); // 보 -> 가위
                 break;
         }
     }

     return answer = sb.ToString();
 }
}