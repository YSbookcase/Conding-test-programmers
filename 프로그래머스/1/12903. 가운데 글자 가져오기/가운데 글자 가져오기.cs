public class Solution {
    public string solution(string s) {
                
        int mid = s.Length / 2;
        string answer;

        if (s.Length % 2 == 0)
        {
            answer = s.Substring(mid - 1, 2);
        }
        else
        {
            answer = s.Substring(mid, 1);
        }
        

        return answer;
    }
}