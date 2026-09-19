using System;
using System.Collections.Generic;

public class Solution {
    public int[] solution(string today, string[] terms, string[] privacies) {
        List<int> expired = new List<int>();
        int todayDays = ChangeDay(today);

        // 생성자 괄호 추가
        Dictionary<char, int> termsMonths = new Dictionary<char, int>();

        // terms는 string[] 이므로 foreach 변수는 string으로 받아야 함
        foreach (string term in terms)
        {
            string[] tokens = term.Split(' ');
            termsMonths[tokens[0][0]] = int.Parse(tokens[1]);
        }

        for(int i = 0; i < privacies.Length; i++)
        {
            string[] parts = privacies[i].Split(' ');
            int collectDays = ChangeDay(parts[0]);
            char termType = parts[1][0];
            int months = termsMonths[termType];

            if(todayDays >= collectDays + months * 28)
            {
                expired.Add(i + 1);
            }
        }

        
        return expired.ToArray();
    }

    int ChangeDay(string date)
    {
        string[] parts = date.Split('.');
        int year = int.Parse(parts[0]);
        int month = int.Parse(parts[1]);
        int day = int.Parse(parts[2]);
        return year * 12 * 28 + month * 28 + day;
    }
}