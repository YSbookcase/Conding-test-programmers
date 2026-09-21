# 푸드 파이트 대회 (134240)

## 상태
- 제출 완료 (`while` + `index`로 왼쪽/물/오른쪽. 학습 파일에 세 단계 버전)
- 로컬 실험: `LocalTest/Program.cs` (`.gitignore`)
- 세 방법 코드: `푸드파이트대회_학습.cs` (이 폴더)
- KYS24에서 이 폴더로 이동

## 내가 한 질문
- `while`과 `index`로 왼쪽/물/오른쪽을 나눈 접근은 뭐가 문제인가?
- `food[i]`가 물이라 항상 1인가?
- 수정한 코드 확인해 달라.
- 주먹구구 말고 안정적인 코드를 보여 달라.
- 성능 차이가 있나?
- `+`로 숫자를 문자열에 붙이면 느려지나? `Append(int)`는 자료형이 안 맞나?
- List / LINQ / StringBuilder 풀이 비교.

## 막혔던 지점
- 물은 **`food[0]`만** 항상 1. `food[i]` 전부가 물이 아니다. `food[i]`는 i번 음식 개수.
- 첫 코드는 `count`를 1부터 두고 `hallFoodSetCount[count - 1]`을 봐서 첫 바퀴가 물(0개)을 봤다. 1번 음식을 건너뛰고, 왼쪽이 끝나면 `count`가 길이를 넘어 오른쪽에서 범위 오류.
- `count`는 횟수가 아니라 음식 번호. `foodNumber`가 맞다.
- `(food[i] / 2) * 2` 뒤 다시 `/ 2`는 필요 없다. 한쪽에 놓는 개수는 `food[i] / 2`.
- `while` + `index == 총길이/2`로 물을 찾는 방식은 동작은 시킬 수 있으나, `foodNumber`가 왼쪽 끝·물·오른쪽에서 어긋나기 쉽다.
- `string result = result + foodNumber`를 루프에서 반복하면 매번 새 문자열 복사. `StringBuilder.Append`는 버퍼에 붙인다.
- `Append(foodNumber)`는 `int`를 `string` 변수에 넣는 게 아니라 `Append(int)` 오버로드가 숫자 글자로 바꾼다. `string text = foodNumber`는 오류.

## 문제 한 줄
칼로리 낮은 음식부터 같은 양·같은 순서로 양쪽에서 먹고, 가운데는 물(0). 홀수 개는 버린다. 배치 문자열.

## 핵심 패턴
```text
i = 1부터 food[i] / 2번 i를 붙인다 (왼쪽)
0을 붙인다
마지막 음식부터 1까지 같은 개수로 붙인다 (오른쪽)
```

예1 `[1, 3, 4, 6]` → 한쪽 1하나·2둘·3셋 → `"122333" + "0" + "333221"`.
예2 `[1, 7, 1, 2]` → 2번은 `1/2=0`이라 건너뜀 → `"111303111"`.

## 대안별 구현 비교

| | A StringBuilder | B List | C LINQ |
|---|---|---|---|
| 모으는 곳 | 문자 버퍼 | `List<int>` | 중간 수열 |
| 오른쪽 | 번호를 내려가며 `Append` | `Reverse` 후 `Join` | `left.Reverse()` |
| 할당 | 버퍼 하나 | 리스트 + `Join` 두 번 | 이터레이터·문자열 여러 개 |
| 이 문제 | 답이 문자열이라 가장 맞음 | 거울이 잘 보임 | 짧음, 흐름은 덜 보임 |

결과 길이는 최대 약 8천. 세 방법 모두 `O(결과 길이)`. 체감 차이는 없고 효율성 테스트도 없다. 루프 안 `+`만 피하면 된다. `left + "0" + right`처럼 **한 번** 붙이는 `+`는 괜찮다.

`List.Reverse()`는 제자리다. 뒤집기 **전에** 왼쪽 문자열을 저장해야 한다.

답이 문자열이고 루프로 붙인다 → A. 목록을 뒤집거나 빼는 게 핵심 → B. 걸러/변환만 → C.

코드는 `푸드파이트대회_학습.cs`. `solution`에서 호출만 바꿔 비교.

### A. StringBuilder (학습 기본)
```csharp
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
```

### B. List
```csharp
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
```

### C. LINQ
```csharp
string left = string.Concat(
    Enumerable.Range(1, food.Length - 1)
        .SelectMany(foodNumber => Enumerable.Repeat(foodNumber.ToString(), food[foodNumber] / 2))
);
return left + "0" + string.Concat(left.Reverse());
```

## 다음에 볼 것
- 물은 `food[0]`. 음식 루프는 `i = 1`.
- 한쪽 짝 `food[i] / 2` → 물 → 반대쪽. `index`로 가운데를 찾지 않기.
- 루프에서 문자열을 키울 때는 `StringBuilder`. `Append(int)`는 오버로드.
