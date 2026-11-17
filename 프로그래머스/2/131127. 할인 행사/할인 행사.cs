using System;
using System.Collections.Generic;

public class Solution {
    public int solution(string[] want, int[] number, string[] discount) {
            
        Dictionary<string, int> needByItem = new Dictionary<string, int>();
        for (int index = 0; index < want.Length; index++)
            needByItem[want[index]] = number[index];
        Dictionary<string, int> countByItem = new Dictionary<string, int>();
        for (int index = 0; index < 10; index++)
        {
            string item = discount[index];
            countByItem.TryGetValue(item, out int count);
            countByItem[item] = count + 1;
        }
        int answer = 0;
        if (IsMatch(needByItem, countByItem))
            answer++;
        for (int index = 10; index < discount.Length; index++)
        {
            string removeItem = discount[index - 10];
            countByItem[removeItem]--;
            if (countByItem[removeItem] == 0)
                countByItem.Remove(removeItem);
            string addItem = discount[index];
            countByItem.TryGetValue(addItem, out int count);
            countByItem[addItem] = count + 1;
            if (IsMatch(needByItem, countByItem))
                answer++;
        }
        return answer;
    }
    
    bool IsMatch(Dictionary<string, int> needByItem, Dictionary<string, int> countByItem)
    {
        foreach (KeyValuePair<string, int> pair in needByItem)
        {
            if (!countByItem.TryGetValue(pair.Key, out int count))
                return false;
            if (count != pair.Value)
                return false;
        }
        return true;
    }
}