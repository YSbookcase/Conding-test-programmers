using System;

public class Solution {
    public string solution(int[] numbers) {
                
        string[] texts = new string[numbers.Length];

        for(int index = 0; index < numbers.Length; index++)
        {
            texts[index] = numbers[index].ToString();

        }

        Array.Sort(texts, (first, second) => (second + first).CompareTo(first + second));

        if (texts[0] == "0")
        {
            return "0";
        }

        return string.Concat(texts);
    }
}