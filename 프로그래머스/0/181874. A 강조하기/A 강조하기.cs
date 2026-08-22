using System;
//using System.Text;
//using System.Linq;

public class Solution {
    public string solution(string myString) {
        
        char[] chars = myString.ToCharArray();
        
        for(int i = 0; i < chars.Length; i++)
        {
            if(chars[i] == 'a')
            {
                chars[i] = 'A';
            }
            else if ( chars[i] >= 'B' && chars[i] <= 'Z')
            {
                chars[i] = char.ToLower(chars[i]);
            }
        }
        
        return new string(chars);
        
        
//                 char[] chars = myString.ToLower().ToCharArray();

//         for (int i = 0; i < chars.Length; i++)
//         {
//             if (chars[i] == 'a')
//             {
//                 chars[i] = 'A';
//             }
//         }

//         return new string(chars);
        
//                 StringBuilder sb = new StringBuilder();

//         foreach (char c in myString)
//         {
//             if (c == 'a')
//                 sb.Append('A');
//             else if (char.IsUpper(c))
//                 sb.Append(char.ToLower(c));
//             else
//                 sb.Append(c);
//         }

//         return sb.ToString();
        
    //     return new string(
    // myString
    //     .Select(c => c == 'a' ? 'A' : char.ToLower(c))
    //     .ToArray()
    }
}