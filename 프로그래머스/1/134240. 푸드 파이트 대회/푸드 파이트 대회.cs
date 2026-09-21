using System;
using System.Text;

public class Solution {
    public string solution(int[] food) {
        StringBuilder sb = new StringBuilder();

        int pairTotalCount = 0;
        int[] pairFoodNumber = new int[food.Length];

        for (int i = 0; i < food.Length; i++)
        {

            pairTotalCount += (food[i] / 2) * 2;
            pairFoodNumber[i] = (food[i] / 2);
        }

        int index = 0;
        int foodNumber = 1;
        while( index < pairTotalCount + 1)
        {

            if (pairTotalCount / 2 > index)
            {

                for (int j = 0; j < pairFoodNumber[foodNumber]; j++)
                {
                    sb.Append(foodNumber);
                    index++;
                }

                foodNumber++;
            }
            else if (pairTotalCount /2 == index)
            {
                sb.Append('0');
                index++;
                foodNumber--;
            }
            else
            {
                
                for (int j = 0 ; j < pairFoodNumber[foodNumber]; j++)
                {
                    sb.Append(foodNumber);
                    index++;
                }

                foodNumber--;
            }

        }

        return sb.ToString();
}
}