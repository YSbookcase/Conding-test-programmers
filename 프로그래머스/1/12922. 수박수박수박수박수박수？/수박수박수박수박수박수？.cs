using System.Text;

public class Solution {
    public string solution(int n) {
                
        StringBuilder result = new StringBuilder();

        string text = "수박";

        for (int i = 0; i < n; i++)
        {
            result.Append(text[i % 2 ]);
        }


        return result.ToString();
    }   
}