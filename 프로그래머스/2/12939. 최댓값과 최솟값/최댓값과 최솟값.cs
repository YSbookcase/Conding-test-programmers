public class Solution {
    public string solution(string s) {
                
        string[] tokens = s.Split(' ');
        int min = int.Parse(tokens[0]);
        int max = min;

        for (int index = 1; index < tokens.Length; index++)
        {
            int number = int.Parse(tokens[index]);

            if (number < min)
            {
                min = number;
            }

            if (number > max)
            {
                max = number;
            }
        }

        return min + " " + max;
    }
}