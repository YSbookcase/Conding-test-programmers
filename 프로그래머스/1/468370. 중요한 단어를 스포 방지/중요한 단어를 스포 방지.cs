using System;
using System.Collections.Generic;

public class Solution {
    
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
    
    
    
    public int solution(string message, int[,] spoiler_ranges) {
        
        int rangeCount = spoiler_ranges.GetLength(0);
        
        List<WordInfo> words = ParseWords(message);
        
        HashSet<string> publicWords = BuildPublicWords(words, spoiler_ranges, rangeCount);
        
        List<WordInfo>[] revealAt = BuildRevealAt(words, spoiler_ranges, rangeCount);
        
        return CountImportantWords(revealAt, publicWords, rangeCount);
        
    }
    
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