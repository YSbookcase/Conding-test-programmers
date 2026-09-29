// 성격 유형 검사하기. 제출은 네 if, 학습은 쌍 배열로 결과 조립.
using System.Collections.Generic;
using System.Text;

public class Solution
{
    public string solution(string[] survey, int[] choices)
    {
        Dictionary<char, int> typeScore = AddTypeScores(survey, choices);
        return BuildByPairs(typeScore);
    }

    Dictionary<char, int> AddTypeScores(string[] survey, int[] choices)
    {
        Dictionary<char, int> typeScore = new Dictionary<char, int>();
        char[] types = { 'R', 'T', 'C', 'F', 'J', 'M', 'A', 'N' };
        foreach (char type in types)
            typeScore[type] = 0;

        for (int i = 0; i < survey.Length; i++)
        {
            int value = choices[i] - 4;
            if (value == 0)
                continue;
            char type = value > 0 ? survey[i][1] : survey[i][0];
            typeScore[type] += Math.Abs(value);
        }
        return typeScore;
    }

    // 제출과 같은 네 if. 지표가 눈에 들어옴
    string BuildByIfs(Dictionary<char, int> typeScore)
    {
        StringBuilder result = new StringBuilder();
        if (typeScore['R'] >= typeScore['T']) result.Append('R');
        else result.Append('T');
        if (typeScore['C'] >= typeScore['F']) result.Append('C');
        else result.Append('F');
        if (typeScore['J'] >= typeScore['M']) result.Append('J');
        else result.Append('M');
        if (typeScore['A'] >= typeScore['N']) result.Append('A');
        else result.Append('N');
        return result.ToString();
    }

    // 출력 쌍만 배열로. 같은 비교가 한 루프
    string BuildByPairs(Dictionary<char, int> typeScore)
    {
        StringBuilder result = new StringBuilder();
        string[] pairs = { "RT", "CF", "JM", "AN" };
        foreach (string pair in pairs)
        {
            char leftType = pair[0];
            char rightType = pair[1];
            if (typeScore[leftType] >= typeScore[rightType])
                result.Append(leftType);
            else
                result.Append(rightType);
        }
        return result.ToString();
    }
}
