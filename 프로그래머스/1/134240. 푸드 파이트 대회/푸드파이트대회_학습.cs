// 푸드 파이트 대회. 세 방법 결과는 같아야 함.
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Solution
{
    public string solution(int[] food)
    {
        return PlaceByStringBuilder(food);
    }

    // A. 버퍼에 왼쪽을 붙이고 0 다음 오른쪽
    string PlaceByStringBuilder(int[] food)
    {
        StringBuilder result = new StringBuilder();

        for (int foodNumber = 1; foodNumber < food.Length; foodNumber++)
        {
            int pairCount = food[foodNumber] / 2;
            for (int i = 0; i < pairCount; i++)
                result.Append(foodNumber);
        }

        result.Append('0');

        for (int foodNumber = food.Length - 1; foodNumber >= 1; foodNumber--)
        {
            int pairCount = food[foodNumber] / 2;
            for (int i = 0; i < pairCount; i++)
                result.Append(foodNumber);
        }

        return result.ToString();
    }

    // B. 한쪽에 번호를 모아 둔 뒤 Join, 같은 목록을 뒤집어 오른쪽
    string PlaceByList(int[] food)
    {
        List<int> leftFood = new List<int>();

        for (int foodNumber = 1; foodNumber < food.Length; foodNumber++)
        {
            int pairCount = food[foodNumber] / 2;
            for (int i = 0; i < pairCount; i++)
                leftFood.Add(foodNumber);
        }

        string left = string.Join("", leftFood);
        leftFood.Reverse();
        return left + "0" + string.Join("", leftFood);
    }

    // C. Range로 음식 번호를 만들고 Repeat으로 짝만큼 펼친 뒤 가운데 0
    string PlaceByLinq(int[] food)
    {
        string left = string.Concat(
            Enumerable.Range(1, food.Length - 1)
                .SelectMany(foodNumber => Enumerable.Repeat(foodNumber.ToString(), food[foodNumber] / 2))
        );
        return left + "0" + string.Concat(left.Reverse());
    }
}
