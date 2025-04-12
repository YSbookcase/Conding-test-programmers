using System;

public class Solution {
    public int solution(int[] numbers, int k){
    int answer = 0;
    int n = (2*k-2) % numbers.Length;
    answer = numbers[n];

    return answer;
}

}