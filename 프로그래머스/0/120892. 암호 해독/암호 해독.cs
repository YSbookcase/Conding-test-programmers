using System;
using System.Text;

public class Solution {
    public string solution(string cipher, int code) {
            var sb = new StringBuilder();

           for (int i = code - 1; i < cipher.Length; i += code)
           {
               sb.Append(cipher[i]);
           }

           return sb.ToString();
    }
}