# 없는 숫자 더하기 (86051)

## 상태
- 제출 완료. `result = 45`에서 `numbers`를 하나씩 뺌
- 제출 파일: `프로그래머스/1/86051. 없는 숫자 더하기/없는 숫자 더하기.cs`

## 내가 한 질문
- 45에서 `numbers`를 빼서 한 번 순회로 끝내도 되나? 존재 여부를 표시하고 없는 수를 다시 더하는 두 루프와 비교.
- 다른 방법, 더 좋은 방법이 있나?
- `result` / `missingSum` 조언은 이름에 대한 것인가? `Sum()`은 배열 함수인가?
- `Except().Sum()` 풀이는 자원을 어떻게 쓰나? LINQ인가?

## 막혔던 지점
- 로직은 처음부터 맞았다. 0~9의 합은 45이고, 원소가 서로 다르므로 있는 수를 한 번씩 빼면 없는 수의 합이 남는다. 0을 빼도 합은 그대로다.
- `result`는 반환값으로는 통한다. 루프 중에는 없는 수의 합이 남아 가므로 `missingSum`이 역할을 보여 준다. 존재 여부는 `isExist`. 개수가 아니면 `Count`를 붙이지 않는다.
- `Sum()`은 `int[]`의 함수가 아니다. `System.Linq`의 확장 함수라서, `using System.Linq;`이 있을 때 `numbers.Sum()`으로 호출된다. 프로그래머스 기본 코드에 이 `using`이 있는 경우가 많다.
- `Except` 예시의 배열은 1~9라 0이 없다. 합만 구할 때는 0을 더해도 결과가 같아서 통과한다. 없는 숫자 목록 자체가 필요하면 0을 넣어야 한다.

## 문제 한 줄
0~9 중 `numbers`에 없는 수를 모두 더한 값. 길이 1~9, 원소는 서로 다르다.

## 핵심 패턴
```text
missingSum = 45
있는 수를 한 번씩 빼기
return missingSum
```

예1: 45−31=14 (5+9). 예2: 45−39=6 (1+2+3). 합만 필요하면 이 방법이 가장 가볍다. 시간 O(n), 추가 메모리 O(1).

## 대안별 구현 비교

없는 수가 무엇인지를 남겨야 할 때 존재 배열이나 `Except`를 쓴다. n이 최대 9라 시간 차이는 체감되지 않고, 차이는 추가 메모리와 할당이다.

### A. 45에서 빼기
정수 하나만 쓴다.

```csharp
int missingSum = 45;
for (int i = 0; i < numbers.Length; i++)
    missingSum -= numbers[i];
return missingSum;
```

### B. `numbers.Sum()`
A와 같은 식. 내부도 한 번 더한다. `using System.Linq;`이 필요하다.

```csharp
return 45 - numbers.Sum();
```

### C. 존재 표시 후 0~9를 다시 더하기
없는 칸을 하나씩 볼 때. 루프 두 번, `bool[10]`.

```csharp
bool[] isExist = new bool[10];
for (int i = 0; i < numbers.Length; i++)
    isExist[numbers[i]] = true;

int missingSum = 0;
for (int digit = 0; digit <= 9; digit++)
{
    if (!isExist[digit])
        missingSum += digit;
}
return missingSum;
```

### D. `Except().Sum()`
`Except`는 앞 배열에서 뒤에 없는 값만 남기는 LINQ 집합 차이다. `Sum()`이 값을 꺼낼 때 실행된다. `numbers`를 해시 집합에 넣은 뒤, `numberArray`에서 집합에 없는 수만 더한다.

```csharp
int[] numberArray = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
return numberArray.Except(numbers).Sum();
```

호출마다 길이 9 배열, 해시 집합, 열거 객체가 생긴다. 추가 공간은 `numbers` 길이에 비례한다. 예 `[1,2,3,4,6,7,8,0]`이면 5와 9가 남아 14다.

| | A 45에서 빼기 | C 존재 배열 | D Except |
|---|---|---|---|
| 시간 | O(n) | O(n+10) | O(n+9) |
| 추가 메모리 | 정수 하나 | `bool[10]` | 해시 집합 + 배열 + 열거 객체 |
| 없는 수 자체 | 안 남음 | `isExist`가 false인 칸 | `Except`가 넘기는 값. 이 배열에는 0이 없음 |

## 다음에 볼 것
- 0~9처럼 전체가 고정이면 전체 합에서 있는 것을 뺀다.
- `Sum` / `Except`는 배열 멤버가 아니라 `System.Linq` 확장 함수.
- 빼 가는 합은 `missingSum`. 존재 여부는 `isExist`.
