# 콜라 문제 (132267)

## 상태
- 제출 완료 (`while`, `refilled` / `remain`)
- 로컬 실험: `LocalTest/Program.cs` (재귀 `GetCoke`, `.gitignore`)
- 재귀·반복·한 줄: `콜라문제_학습.cs` (이 폴더)
- KYS24에서 이 폴더로 이동

## 내가 한 질문
- 재귀로 나눈 값에 `b`를 곱하고 나머지를 더해 다시 돌리면 되나? `n`이 100만인데.
- 재귀 코드 확인.
- `answer`가 마지막에 남는데 그게 잘못인가?
- 내부 `answer += refilled`는 필요 없고 `refilled`만 `return`에 더하면 되나?
- 수정 코드 확인. 재수정.
- 백만 단위에서 재귀가 너무 깊어지는 거 아닌가? 재귀 풀이는 노트에 남기자.
- `return (n > b ? n - b : 0) / (a - b) * b;` 다른 사람 풀이는 뭔가?

## 막혔던 지점
- 식은 맞다. `refilled = (n / a) * b`, `remain = n % a`, 다음 빈 병 `refilled + remain`. `n < a`면 0.
- 처음 재귀는 `answer += refilled` 후 `return GetCoke(...)`만 했다. 호출마다 `answer`가 따로 생기고 `return`에 안 넣어서 버려진다. 맨 아래 `return 0`만 올라와 예제가 0.
- `return refilled + GetCoke(a, b, n)`이어야 이번 회차 병이 합에 들어간다. 그때는 `answer` 변수가 필요 없다.
- `solution`이 비어 있으면 컴파일 실패. `return GetCoke(a, b, n)`.
- `n ≤ 1,000,000`은 시간보다 **재귀 깊이**가 문제. `a - b`가 1이면 빈 병이 1씩 줄어 수십만 프레임이 쌓일 수 있다. C# 기본 스택이 버티지 못할 수 있다. 예1·예2는 깊게 안 들어간다.

## 문제 한 줄
빈 병 `a`개를 주면 콜라 `b`병. 가진 빈 병 `n`개로 받을 수 있는 콜라 총합. `a`개 미만이면 교환 불가.

## 핵심 패턴
```text
n >= a 인 동안
  refilled = (n / a) * b
  remain = n % a
  받은 병에 refilled 더함
  n = refilled + remain
```

처음 들고 있던 `n`은 받은 콜라가 아니다. 예1은 20이 아니라 19.

## 재귀 풀이 (노트에 남김)
```csharp
int GetCoke(int a, int b, int n)
{
    int refilled = 0;
    if (n >= a)
    {
        refilled = (n / a) * b;
        int remain = n % a;
        n = refilled + remain;
    }
    else
    {
        return 0;
    }
    return refilled + GetCoke(a, b, n);
}
```

예1 19, 예2 9. `refilled`, `remain`은 역할이 보인다. 논리는 맞지만 숨은 테스트에서 스택 오버가 날 수 있다.

## 제출 코드 (while)
```csharp
int answer = 0;
while (n >= a)
{
    int refilled = (n / a) * b;
    int remain = n % a;
    answer += refilled;
    n = refilled + remain;
}
return answer;
```

## 대안별 구현 비교

| | A 재귀 | B `while` (제출) | C 한 줄 식 |
|---|---|---|---|
| 하는 일 | 교환을 한 단계씩 | 동일 | 교환 횟수를 나눗셈으로 |
| 깊이·반복 | 최악 수십만 프레임 | 최악 수십만 바퀴 | 1회 |
| 이 제한 | 예제는 통과, 스택 위험 | 제출 | 통과, 왜 맞는지는 덜 보임 |

한 번 교환하면 빈 병이 순수히 `a - b`개 줄어든다. `a`개를 주고 `b`개를 다시 받으니까. 교환 횟수 `k = (n - b) / (a - b)`(정수 나눗셈), 받은 콜라 `k * b`. `n > b`가 아니면 교환 불가라 0. `n - b`가 음수면 C#에서 음수 나눗셈이 나와서 삼항으로 막는다.

예1: `(20 - 1) / (2 - 1) * 1 = 19`. 예2: `(20 - 1) / (3 - 1) * 1 = 9`.

`/`가 `*`보다 먼저라 `(n - b) / (a - b)`를 내린 뒤 `* b`다. 시뮬레이션과 같은 값이다.

### A. 재귀
위 `GetCoke`. `solution`은 `return GetCoke(a, b, n)`.

### B. while
제출 코드.

### C. 한 줄
```csharp
return (n > b ? n - b : 0) / (a - b) * b;
```

## 다음에 볼 것
- 재귀에서 이번 값을 쓰려면 `return 이번 + 재귀(...)`. 지역 `answer`는 `return`에 안 넣으면 사라진다.
- 같은 감소가 느린 시뮬레이션은 `while`. 재귀는 깊이를 먼저 가늠.
- 교환 1회에 빈 병 `a - b` 감소 → 횟수 `(n - b) / (a - b)`.
