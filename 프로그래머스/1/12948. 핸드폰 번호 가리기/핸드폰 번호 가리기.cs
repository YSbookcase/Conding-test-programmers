public class Solution {
    public string solution(string phone_number) {
        
        string lastNum = phone_number.Substring(phone_number.Length - 4);
        string masked = new string('*', phone_number.Length - 4);

        return masked + lastNum;
    }
}