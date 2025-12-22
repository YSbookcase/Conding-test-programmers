using System;
using System.Collections.Generic;

public class Solution {
    public int[] solution(int n, int[] numlist) {
                               List<int> answerList = new List<int>();
                foreach (var num in numlist)
                {
                    if (num % n == 0)
                    {
                        answerList.Add(num);
                    }
                }
                return answerList.ToArray();
    }
}