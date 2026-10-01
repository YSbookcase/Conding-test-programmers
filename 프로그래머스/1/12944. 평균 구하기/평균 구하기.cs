public class Solution {
    public double solution(int[] arr) {
        
        double answer = 0;
        int sum = 0;
        
        foreach(int number in arr)
        {
            sum += number;
        }
        
        return (double)sum / arr.Length;
    }
}