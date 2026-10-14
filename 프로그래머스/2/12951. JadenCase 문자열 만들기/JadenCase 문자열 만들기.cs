using System.Text;

public class Solution {
    public string solution(string s) {
                
        bool isWordStart = true;
        StringBuilder result = new StringBuilder();

        foreach (char c in s)
        {
            if (c == ' ')
            {
                result.Append(c);
                isWordStart = true;
            }
            else if (isWordStart)
            {
                result.Append(char.ToUpper(c));
                isWordStart = false;
            }
            else
            {
                result.Append(char.ToLower(c));
            }
        }

        return result.ToString();
    }
}