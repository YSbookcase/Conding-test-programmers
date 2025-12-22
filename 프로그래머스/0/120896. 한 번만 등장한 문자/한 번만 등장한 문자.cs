using System;
using System.Text;

public class Solution {
    public string solution(string s) {
        
                int[] charIndex = new int[26];

              foreach (var c in s)
              {
                  charIndex[c - 'a'] += 1;
              }

              StringBuilder sb = new StringBuilder();

              for (int  i = 0;  i < charIndex.Length;  i++)
              {   
                  if (charIndex[i] == 1)
                  {
                      sb.Append((char)(i + 'a'));
                  }
              }
                  
              return sb.ToString();
    }
}