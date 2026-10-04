public class Solution {
    public bool solution(string s) {
        
        bool isFourOrSix = s.Length == 4 || s.Length == 6;
        bool isNumber = int.TryParse(s, out _);
        return isFourOrSix && isNumber;
    }
}