using System;
using System.Text;

public class Solution {
    public string solution(string bin1, string bin2) {
                int i = bin1.Length - 1;
                int j = bin2.Length - 1;
                int carry = 0;

                StringBuilder sb = new StringBuilder();

                while (i >= 0 || j >= 0 || carry > 0)
                {
                    int sum = carry;
                    if (i >= 0)
                    {
                        sum += bin1[i] - '0';
                        i--;
                    }
                    if (j >= 0)
                    {
                        sum += bin2[j] - '0';
                        j--;
                    }
                    sb.Append(sum % 2);
                    carry = sum / 2;
                }

                char[] resultArray = sb.ToString().ToCharArray();
                System.Array.Reverse(resultArray);
                return new string(resultArray);
    }
}