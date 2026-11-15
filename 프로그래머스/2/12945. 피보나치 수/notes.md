# 피보나치 수 (12945)

## 상태
- 제출 완료. 정확성 100, 합계 100. 메모리 46 MB, 시간 0.71 ms
- 제출 파일: `프로그래머스/2/12945. 피보나치 수/피보나치 수.cs`
- 고득점 Kit 연습문제
- 제출본의 반복 변수 이름은 `distance`다. 칸 수가 아니라 `n`까지 올라가는 항 번호다.

## 내가 한 질문
- 멀리뛰기를 그대로 쓰면 되나? 그런데 왜 `int`인가?
- 주의점은 초기값과 경계값을 어떻게 두느냐로 보인다
- 다른 사람은 딕셔너리에 모든 항을 저장한다. 이득이 있나?

## 막혔던 지점
- 덧셈과 `% 1234567`은 멀리뛰기와 같다. 시작 값과 반복 시작이 다르다.
- 멀리뛰기의 `n`칸은 `1, 2, 3, 5`다. 이 문제의 `F(n)`은 `0, 1, 1, 2, 3, 5`다. `n`이 3이면 멀리뛰기는 3, 피보나치는 2다. 멀리뛰기 초기값 `1, 2`로 돌리면 3이 나온다.
- `F(0) = 0`, `F(1) = 1`에서 시작하고 반복은 2부터다. `n`은 2 이상이라 `n`이 2이면 한 번 돌아 `0 + 1`인 1이 된다.
- 반환이 `int`인 이유는 나머지가 `1234567`보다 작기 때문이다. 나머지 둘을 더해도 `2,469,134`라 `int` 안에서 끝난다. 멀리뛰기의 `long`은 그 문제의 반환 형식이다.
- `n`이 10만이면 피보나치 수 자체는 `long`에도 안 들어간다. 더할 때마다 나머지를 저장한다.
- 딕셔너리에 `0`부터 `n`까지 넣어도 덧셈 횟수는 같다. 다음 항은 앞의 두 값만 쓰고, 반환도 `n`번째 하나다. 항목 10만 개와 해시 계산이 더 붙는다. `checked`는 나머지를 더하는 동안 넘침이 없어 역할이 없다.

## 문제 한 줄
`F(0) = 0`, `F(1) = 1`일 때 `n`번째 피보나치 수를 `1234567`로 나눈 나머지. `n`은 2 이상 10만 이하.

## 핵심 패턴
```text
previous = 0, current = 1
2부터 n까지 next = (previous + current) % 1234567
previous = current, current = next
current 반환
```

```csharp
int previous = 0;
int current = 1;
int divisor = 1234567;

for (int index = 2; index <= n; index++)
{
    int next = (previous + current) % divisor;
    previous = current;
    current = next;
}

return current;
```

- `3` → `2`
- `5` → `5`
- `2` → `1`

## 대안별 구현 비교

`n`번째 하나만 필요하면 A다. B는 모든 항을 저장한다. 답은 같다.

| 방법 | 저장 | `n`이 10만일 때 |
|---|---|---|
| A. 변수 두 개 | 앞의 두 항 | 덧셈 10만 번. 제출본 |
| B. 딕셔너리 | `0`부터 `n`까지 | 같은 덧셈에 해시와 항목 10만 개 |

### B. 딕셔너리

```csharp
Dictionary<int, int> fibonacciByIndex = new Dictionary<int, int>();
fibonacciByIndex.Add(0, 0);
fibonacciByIndex.Add(1, 1);
int divisor = 1234567;

for (int index = 2; index <= n; index++)
{
    int next = (fibonacciByIndex[index - 1] + fibonacciByIndex[index - 2]) % divisor;
    fibonacciByIndex.Add(index, next);
}

return fibonacciByIndex[n];
```

번호가 빠짐없이 이어지면 딕셔너리 대신 앞의 두 변수로 충분하다. 필요한 번호만 듬성듬성 다시 꺼낼 때 딕셔너리가 맞다.

## 다음에 볼 것
- 멀리뛰기와 표를 같이 본다. 시작이 `1, 2`이고 반복이 3부터면 멀리뛰기다. 시작이 `0, 1`이고 반복이 2부터면 이 문제다.
- 제출본의 `distance`는 항 번호다. 읽을 때는 `index`로 보면 된다.
