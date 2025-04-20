using System;
using System.Collections.Generic;
using System.Linq;

public class Solution {
    
              public int solution(int[,] dots)
{
    List<double> distances = new List<double>();

    for (int i = 1; i < 4; i++)
    {
        int dx = dots[0, 0] - dots[i, 0];
        int dy = dots[0, 1] - dots[i, 1];
        double dist = Math.Sqrt(dx * dx + dy * dy);
        distances.Add(dist);
    }

    // 최대값 1개 제외하고 나머지 두 개 곱
    double max = distances.Max();
    bool removed = false;
    double area = 1.0;

    foreach (var d in distances)
    {
        if (!removed && d == max)
        {
            removed = true;
            continue;
        }
        area *= d;
    }

    return (int)area;
}
//    public int solution(int[,] dots) {
//    double answer = 0;
//    int solution = 0;
//    double tempLength1 = 0;
//    double tempLength2 = 0;
//    double tempLength3 = 0;
//
//
//    for (int i = 1; i < dots.GetLength(0); i++)
//    {
//
//        
//
//        int pow1 = (dots[0, 0] - dots[i, 0]) * (dots[0, 0] - dots[i, 0]);
//        int pow2 = (dots[0, 1] - dots[i, 1]) * (dots[0, 1] - dots[i, 1]);
//
//
//        if (tempLength1 == 0)
//        {
//            tempLength1 = Math.Sqrt(pow1 + pow2);
//        }
//        else if (tempLength2 == 0)
//        {
//            tempLength2 = Math.Sqrt(pow1 + pow2);
//        }
//        else
//        {
//            tempLength3 = Math.Sqrt(pow1 + pow2);
//        }
//    }
//        double[] numbers = { tempLength1, tempLength2, tempLength3 };
//        double max = numbers[0];
//        foreach (var x in numbers)
//            if (x > max) max = x;
//
//        answer = 1.0;
//        bool skipped = false;
//        foreach (var x in numbers)
//        {
//            if (x == max && !skipped)
//            {
//                skipped = true;
//                continue;
//            }
//            answer *= x;
//            solution = (int)answer;
//        }
//    
//
//    return solution;
//}
    
}