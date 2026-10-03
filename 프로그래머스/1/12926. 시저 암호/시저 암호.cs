public class Solution {
    public string solution(string s, int n) {
                
        char[] result = new char[s.Length];
        for (int i = 0; i < s.Length; i++)
        {
            char letter = s[i];
            if (letter == ' ')
            {
                result[i] = ' ';
            }
            else if (letter >= 'a' && letter <= 'z')
            {
                result[i] = (char)((letter - 'a' + n) % 26 + 'a'); 
            }
            else
            {
                result[i] = (char)((letter - 'A' + n) % 26 + 'A');
            }

        }

        return new string(result);
    }
}