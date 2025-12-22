using System;
using System.Text;

public class Solution {
    public string solution(string my_string) {
        
                StringBuilder sb = new StringBuilder();
                var charArray = my_string.ToCharArray();

                foreach (var c in charArray)
                {
                    if (char.IsUpper(c))
                    {
                        sb.Append(char.ToLower(c));
                    }
                    else
                    {
                        sb.Append(char.ToUpper(c));
                    }
                }

                return sb.ToString();
            }
    
}