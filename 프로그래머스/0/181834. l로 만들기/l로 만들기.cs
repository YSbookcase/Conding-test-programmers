using System;
using System.Text;

public class Solution {
    public string solution(string myString) {

        char[] chars = myString.ToCharArray();
        
       for(int i = 0; i < chars.Length; i++)
        {
            if(chars[i]  <  'l')
            {
                chars[i] = 'l';
            }
        }
        
        return new string(chars);
    
        
//         StringBuilder sb = new StringBuilder();
        
//         foreach ( char c in myString)
//         {
//             sb.Append(c < 'l' ? 'l' : c);
//         }
        
//         return sb.ToString();
        
    }
}