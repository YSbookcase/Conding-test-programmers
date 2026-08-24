using System;

public class Solution {
    public string[] solution(string my_string) {
        
//        string[] parts = my_string.Split(' ');
//        List<string> result = new List<string>();

//          for (int i = 0; i < parts.Length; i++)
//          {
//              if (parts[i] != "")
//              {
//                  result.Add(parts[i]);
//              }
//          }
        
        
        return my_string.Split(' ', StringSplitOptions.RemoveEmptyEntries);
    }
}