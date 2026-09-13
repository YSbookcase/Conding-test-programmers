using System;
using System.Collections.Generic;

// 구간별로 작성하며 이해하기 위한 학습용 초안 (제출용과 시그니처만 맞추면 됨)
public class Solution
{
    // --- 구간1: 단어 한 개의 정보 ---
    public class WordInfo
    {
        public int Start;
        public int End;
        public string Text;

        public WordInfo(int start, int end, string text)
        {
            Start = start;
            End = end;
            Text = text;
        }
    }

    public int solution(string message, int[,] spoilerRanges)
    {
        int rangeCount = spoilerRanges.GetLength(0);

        // --- 구간2: 메시지에서 단어 파싱 ---
        List<WordInfo> words = ParseWords(message);

        // --- 구간3: 공개 구간에만 등장한 단어 집합 ---
        HashSet<string> publicWords = BuildPublicWords(words, spoilerRanges, rangeCount);

        // --- 구간4: 구간 j 클릭 시 새로 전부 공개되는 단어들 ---
        List<WordInfo>[] revealAt = BuildRevealAt(words, spoilerRanges, rangeCount);

        // --- 구간5: 왼쪽부터 클릭하며 중요한 단어 개수 세기 ---
        return CountImportantWords(revealAt, publicWords, rangeCount);
    }

    // 공백 기준으로 단어의 시작·끝·문자열을 모은다
    List<WordInfo> ParseWords(string message)
    {
        List<WordInfo> words = new List<WordInfo>();
        int index = 0;
        int length = message.Length;

        while (index < length)
        {
            while (index < length && message[index] == ' ')
            {
                index++;
            }
            if (index >= length)
            {
                break;
            }

            int start = index;
            while (index < length && message[index] != ' ')
            {
                index++;
            }
            int end = index - 1;
            string text = message.Substring(start, end - start + 1);
            words.Add(new WordInfo(start, end, text));
        }

        return words;
    }

    // 단어 출현이 스포와 한 글자도 안 겹치면 공개 단어로 본다
    HashSet<string> BuildPublicWords(List<WordInfo> words, int[,] spoilerRanges, int rangeCount)
    {
        HashSet<string> publicWords = new HashSet<string>();

        foreach (WordInfo word in words)
        {
            if (!IsOverlapAnyRange(word, spoilerRanges, rangeCount))
            {
                publicWords.Add(word.Text);
            }
        }

        return publicWords;
    }

    // 스포 단어마다 겹치는 마지막 구간 인덱스에 넣어 둔다
    List<WordInfo>[] BuildRevealAt(List<WordInfo> words, int[,] spoilerRanges, int rangeCount)
    {
        List<WordInfo>[] revealAt = new List<WordInfo>[rangeCount];
        for (int i = 0; i < rangeCount; i++)
        {
            revealAt[i] = new List<WordInfo>();
        }

        foreach (WordInfo word in words)
        {
            int last = FindLastOverlapRange(word, spoilerRanges, rangeCount);
            if (last != -1)
            {
                revealAt[last].Add(word);
            }
        }

        return revealAt;
    }

    // 공개 집합·이미 본 스포 단어와 겹치지 않으면 카운트한다
    int CountImportantWords(List<WordInfo>[] revealAt, HashSet<string> publicWords, int rangeCount)
    {
        HashSet<string> seenSpoilerWords = new HashSet<string>();
        int answer = 0;

        for (int j = 0; j < rangeCount; j++)
        {
            foreach (WordInfo word in revealAt[j])
            {
                if (publicWords.Contains(word.Text))
                {
                    continue;
                }
                if (seenSpoilerWords.Contains(word.Text))
                {
                    continue;
                }

                answer++;
                seenSpoilerWords.Add(word.Text);
            }
        }

        return answer;
    }

    bool IsOverlapAnyRange(WordInfo word, int[,] spoilerRanges, int rangeCount)
    {
        return FindLastOverlapRange(word, spoilerRanges, rangeCount) != -1;
    }

    // 겹치는 구간 중 가장 오른쪽(늦게 클릭되는) 인덱스를 반환한다
    int FindLastOverlapRange(WordInfo word, int[,] spoilerRanges, int rangeCount)
    {
        int last = -1;
        for (int i = 0; i < rangeCount; i++)
        {
            int rangeStart = spoilerRanges[i, 0];
            int rangeEnd = spoilerRanges[i, 1];
            if (IsOverlap(word.Start, word.End, rangeStart, rangeEnd))
            {
                last = i;
            }
        }
        return last;
    }

    bool IsOverlap(int wordStart, int wordEnd, int rangeStart, int rangeEnd)
    {
        return wordStart <= rangeEnd && rangeStart <= wordEnd;
    }
}
