public class Solution {
    public int[] solution(int[] arr) {
        
        if (arr.Length == 1)
        {
            return new int[] { -1 };
        }

        int minIndex = 0;
        for (int i = 1; i < arr.Length; i++)
        {
            if (arr[i] < arr[minIndex])
            {
                minIndex = i;
            }
        }

        int[] result = new int[arr.Length - 1];
        int resultIndex = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            if (i == minIndex)
            {
                continue;
            }

            result[resultIndex] = arr[i];
            resultIndex++;
        }
        return result;
    }
}