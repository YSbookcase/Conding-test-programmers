using System;
//using System.Text;

public class Solution {
    public string solution(string my_string, int[] indices) {
        bool[] remove = new bool[my_string.Length];
        
        for(int i = 0; i < indices.Length; i++)
        {
            remove[indices[i]] = true; 
        }
        
        char[] result = new char[my_string.Length - indices.Length];
        int index = 0;
        
        for (int i = 0; i < my_string.Length; i++)
        {
            if(!remove[i])
            {
                result[index] = my_string[i];
                index++;
            }
        }
        
        return new string(result);
    }
}