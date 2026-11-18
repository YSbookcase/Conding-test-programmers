using System;
using System.Collections.Generic;

public class Solution {
    public int solution(int[] order) {
        
        int length = order.Length;
        Stack<int> assist = new Stack<int>();
        int box = 1;      // 메인에서 다음에 올 상자
        int loaded = 0;   // 이미 실은 개수(= order 인덱스)
        while (loaded < length)
        {
            int need = order[loaded];
            if (assist.Count > 0 && assist.Peek() == need)
            {
                assist.Pop();
                loaded++;
                continue;
            }
            if (box > length)
                break;
            if (box == need)
            {
                box++;
                loaded++;
            }
            else
            {
                assist.Push(box);
                box++;
            }
        }
        return loaded;
    }
}