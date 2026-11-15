# 평균 구하기 (12944)

## 상태
- 제출 완료. `int` 합을 구한 뒤 `(double)sum / arr.Length`
- 제출 파일: `프로그래머스/1/12944. 평균 구하기/평균 구하기.cs`
- LocalTest는 쓰지 않음

## 내가 한 질문
- `double`이면 소수점도 나오나?
- 추가로 주의할 점이 있나?

## 막혔던 지점
- `int`끼리 나누면 소수가 먼저 버려진다. `[1, 2, 3, 4]`의 합 10을 4로 나누면 2다. 그 뒤를 `(double)`로 바꿔도 2.0이다. 나누기 전에 한쪽을 `double`로 바꾼다.
- `(double)sum / arr.Length`와 `sum / (double)arr.Length`는 같다. `(long)` 때와 같이 캐스트는 나눗셈 앞의 값 하나에 붙는다.
- `[5, 5]`는 5.0이라 출력은 5로 보여도 값은 맞다.
- 길이는 1 이상이라 0으로 나누지 않는다. 음수도 같은 식이다. `[-1, -3]`은 합 -4를 2로 나눈 -2다.
- 원소는 -10,000 이상 10,000 이하, 길이는 100 이하. 합은 최대 100만이라 `int`에 들어간다. 반환만 `double`이면 된다.

## 문제 한 줄
정수 배열의 평균을 `double`로 반환한다.

## 핵심 패턴
```text
sum = 원소 합 (int)
return (double)sum / arr.Length
```
- `[1, 2, 3, 4]` → 2.5
- `[5, 5]` → 5
- 시간 O(arr 길이).

## 대안별 구현 비교

나누기 전에 `double`이 되면 결과가 같다. `int`로 나눈 뒤 캐스트하면 2.5가 2가 된다.

### A. 합을 `int`로 모으고 나눌 때 캐스트
제출한 버전.

```csharp
int sum = 0;
foreach (int number in arr)
{
    sum += number;
}
return (double)sum / arr.Length;
```

### B. `Average`
`System.Linq`. 합을 `double`로 나눈 값이라 A와 같다.

```csharp
return arr.Average();
```

### C. 나눈 뒤에 캐스트
`[1, 2, 3, 4]`가 2.5가 아니라 2다.

```csharp
return (double)(sum / arr.Length);
```

## 다음에 볼 것
- 반환이 `double`이어도 나누는 두 수가 `int`면 소수가 먼저 사라진다. 캐스트는 나눗셈 앞에 둔다.
- 이 제한의 합은 `int`로 충분하다.
