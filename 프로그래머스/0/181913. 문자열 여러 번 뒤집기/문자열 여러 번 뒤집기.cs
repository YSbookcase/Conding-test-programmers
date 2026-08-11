using System;

public class Solution {
    public string solution(string my_string, int[,] queries) {
        char[] characters = my_string.ToCharArray();
        
        for(int i = 0; i < queries.GetLength(0); i++)
        {
            int left = queries[i, 0];
            int right = queries[i, 1];
       
        
            while(left < right)
            {
                char temp = characters[left];
                characters[left] = characters[right];
                characters[right] = temp;

                left++;
                right--;

            }
        }
        
        
        return new string(characters);
    }
}