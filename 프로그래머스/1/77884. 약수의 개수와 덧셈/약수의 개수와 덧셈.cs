using System;

public class Solution {
    public int solution(int left, int right) {

//         int answer = 0;

//         for (int num = left; num <= right; num++)
//         {
//             if (divisorCount(num) % 2 == 0)
//             {
//                 answer += num;
//             }
//             else
//             {
//                 answer -= num;
//             }
//         }



//         return answer;
        
        int total = (left + right) * (right - left + 1) / 2;
        int root = (int)Math.Ceiling(Math.Sqrt(left));

        for (; root * root <= right; root++)
        total -= 2 * root * root;

        return total;
        
        
        
    }

//     int divisorCount(int n)
//     {
//         int count = 0;
//         for (int i = 1; i * i <= n; i++)
//         {
//             if (n % i != 0) continue;
//             if (i * i == n) count++;
//             else count += 2;
//         }


//         return count;
//     }
}