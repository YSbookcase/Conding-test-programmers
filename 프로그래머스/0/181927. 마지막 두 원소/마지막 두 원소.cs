using System;
using System.Collections.Generic;

public class Solution {
    public int[] solution(int[] num_list) {
        int[] answer = new int[] {};
        
        List<int> list = new List<int>(num_list);
        
        int fIndex = num_list.Length -1;
        int fNum = num_list[fIndex];
        
        int comIndex = num_list.Length -2;
        int comNum = num_list[comIndex];
        
        if(fNum > comNum)
        {
            list.Add(fNum - comNum);
        }
        else if(fNum <= comNum)
        {
            list.Add(fNum*2);
        }
        
        return list.ToArray();
        
    }
}