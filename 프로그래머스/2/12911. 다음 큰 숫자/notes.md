# 다음 큰 숫자 (12911)

## 상태
- 제출 완료. 정확성 70.0, 효율성 30.0, 합계 100. 메모리 45.8 MB, 시간 0.17 ms
- 제출 파일: `프로그래머스/2/12911. 다음 큰 숫자/다음 큰 숫자.cs`
- 고득점 Kit 연습문제

## 내가 한 질문
- 이진수로 전환해서 따져 보아야 하나? 감이 안 잡힌다
- `oneCount += number & 1`은 맨 오른쪽 비트가 1인지 보고 개수를 더하는 건가? `&`는 비트 AND인가?
- 숫자가 올라갈 때마다 `CountOnes`를 돌리는데 성능은 괜찮은가?

## 막혔던 지점
- 이진수 모양 전체를 맞추는 문제가 아니다. 세는 것은 1의 개수다. `n`보다 큰 수 중 그 개수가 같은 가장 작은 수가 답이다.
- `number & 1`은 맨 오른쪽 비트만 남긴다. 1이면 `oneCount`가 1 늘고, 0이면 그대로다. `&`는 정수 비트 AND다. `number >>= 1`은 그 비트를 버리고 한 칸 민다.
- `number >>= 1`은 함수 안의 복사본만 바꾼다. 호출한 `n`과 `nextNumber`는 그대로다.
- `n`은 최대 100만이라 1의 개수가 같은 수는 약 26만 칸 안에서 나온다. `CountOnes` 한 번은 비트를 20번 안쪽으로 본다. 78은 83까지 5번, 15는 23까지 8번이다. 맞는 개수에서 `while`이 끝난다.

## 문제 한 줄
`n`보다 크고, 이진수 1의 개수가 `n`과 같은 수 중 가장 작은 수. `n`은 100만 이하.

## 핵심 패턴
```text
targetCount = n의 1 개수
nextNumber = n + 1
1 개수가 targetCount와 같아질 때까지 nextNumber++
```

```csharp
int targetCount = CountOnes(n);
int nextNumber = n + 1;

while (CountOnes(nextNumber) != targetCount)
{
    nextNumber++;
}

return nextNumber;
```

```csharp
int CountOnes(int number)
{
    int oneCount = 0;

    while (number > 0)
    {
        oneCount += number & 1;
        number >>= 1;
    }

    return oneCount;
}
```

- `78` (`1001110`, 1이 4개) → `83` (`1010011`)
- `15` (`1111`) → `23` (`10111`)

## 다음에 볼 것
- 1의 개수만 같다. 이진수 문자열을 만들 필요는 없다.
- 오른쪽에서 1 묶음의 바로 왼쪽 0을 1로 올리고, 남은 1을 오른쪽으로 모으는 비트 이동도 같은 답이다. 100만에서는 지금 `while`로 충분하다. 제출 시간 0.17 ms.
