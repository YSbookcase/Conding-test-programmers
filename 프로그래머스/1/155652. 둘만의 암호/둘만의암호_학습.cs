using System;
using System.Text;

// 둘만의 암호 — 제출본(한 칸씩)과 다른 두 방법. 앞의 isSkip+circle은 같음.
public class TwoPersonCipherStudy
{
    bool[] BuildIsSkip(string skip)
    {
        bool[] isSkip = new bool[26];
        foreach (char ch in skip)
        {
            isSkip[ch - 'a'] = true;
        }
        return isSkip;
    }

    string BuildCircle(bool[] isSkip)
    {
        StringBuilder letters = new StringBuilder();
        for (char ch = 'a'; ch <= 'z'; ch++)
        {
            if (!isSkip[ch - 'a'])
            {
                letters.Append(ch);
            }
        }
        return letters.ToString();
    }

    // 방법 A: s 글자마다 원에서 (위치+index)%길이 점프
    public string EncodeByCircle(string s, string skip, int index)
    {
        bool[] isSkip = BuildIsSkip(skip);
        string circle = BuildCircle(isSkip);
        StringBuilder result = new StringBuilder();

        foreach (char ch in s)
        {
            int pos = circle.IndexOf(ch);
            char encoded = circle[(pos + index) % circle.Length];
            result.Append(encoded);
        }
        return result.ToString();
    }

    // 방법 B: 알파벳마다 암호를 표에 저장한 뒤 s는 조회만
    public string EncodeByCipherTable(string s, string skip, int index)
    {
        bool[] isSkip = BuildIsSkip(skip);
        string circle = BuildCircle(isSkip);
        char[] cipher = new char[26];

        for (int i = 0; i < 26; i++)
        {
            if (isSkip[i])
            {
                continue;
            }
            char ch = (char)('a' + i);
            int pos = circle.IndexOf(ch);
            cipher[i] = circle[(pos + index) % circle.Length];
        }

        StringBuilder result = new StringBuilder();
        foreach (char ch in s)
        {
            result.Append(cipher[ch - 'a']);
        }
        return result.ToString();
    }
}
