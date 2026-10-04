using System;

public class Solution {
    public string solution(int a, int b) {
                
        string[] days = { "SUN", "MON", "TUE", "WED", "THU", "FRI", "SAT" };
        DateTime date = new DateTime(2016, a, b);
        return days[(int)date.DayOfWeek];
    }
}