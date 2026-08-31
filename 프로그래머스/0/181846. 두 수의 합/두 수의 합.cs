using System;
using System.Numerics;
using System.Text;

public class Solution {
    public string solution(string a, string b) {
        
//         BigInteger numA = BigInteger.Parse(a);
//         BigInteger numB = BigInteger.Parse(b);
        
//         return (numA + numB).ToString();
        
        StringBuilder sb = new StringBuilder();
        
        int i = a.Length - 1;
        int j = b.Length - 1;
        int carry = 0;
        
        while(i >= 0 || j >= 0|| carry> 0)
        {
            int sum = carry;
        
            if(i >= 0) sum += a[i--] - '0';
            if(j >= 0) sum += b[j--] - '0';
            
            carry = sum / 10;
            sb.Append(sum % 10);
        }
        
        char[] result = sb.ToString().ToCharArray();
        Array.Reverse(result);
        return new string(result);
        
    }
}