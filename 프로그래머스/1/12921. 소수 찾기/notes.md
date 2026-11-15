# 소수 찾기 (12921)

## 상태
- 제출 완료. 저장소에 올라온 코드는 홀수 체. 기록 시간 2.61ms, 채점 화면에서는 2.67ms
- 제출 파일: `프로그래머스/1/12921. 소수 찾기/소수 찾기.cs`
- 처음 전체 체는 효율성 1번 시간 초과, 나머지 테스트 3.25ms
- 르장드르 공식은 사이트에서 5.97ms로 통과. 그 코드는 제출 파일에 없고 LocalTest에만 있음. gitignore라 커밋되지 않음

## 내가 한 질문
- 이번엔 범위가 좀 많네. 체를 만드는 것은 이전과 똑같은가? 합을 구하는 것은 안 느린가? 체를 만드는 것은 과한가?
- 로컬에 작성한 것 확인해 줘. 효율성 테스트에서 틀렸다는데 왜지?
- 붙여 넣은 체 그대로 올렸는데 효율성 1번만 시간 초과, 나머지는 3.25ms
- 개수를 가지고 있는 체로 바로 개수를 알게 하는 게 좋을까?
- 여러 번 묻는 경우에만 유효한가? 직전에 적은 홀수 체가 개선인가?
- 이 정도 최적화가 필요한 문제인가? 짝수를 빼면 얼마나 나아지나? 로컬 확인
- 기술적으로 더 줄이는 정답이 있나?
- 개수만 구하는 공식이 있나?
- 마이셀은 정확한 개수라 못 쓰나? 공식이 여러 개고 르장드르가 간단한 수준인가?
- 홀수 체로 통과했다. 르장드르 코드와 시간 비교가 필요하다
- 공식은 더 느린데 왜 통과인가? 5.97ms. 이전 통과를 이어 준 건가? 맞기만 하면 통과인가?
- 약수 검사와 `2 * i`부터 지우는 체도 통과했다. 처음 체보다 나은가?
- 왜 공식이 더 느린가?

## 막혔던 지점
- 마지막 반복은 소수 칸의 개수다. 소수 값을 더하면 `10`이 `4`가 아니라 `17`이 된다.
- 칸마다 지금까지의 개수를 저장해도 `n` 하나를 한 번만 물으면 마지막에 세는 일과 같다. `n`이 여러 개인 배열로 여러 상한을 물을 때 그 배열이 맞다.
- 처음 체의 `number * number <= n`은 `n`이 `100만`이면 `number`가 `1001`에서 끝난다. `number`가 `46341` 근처까지 가야 곱이 `int`를 넘어 음수가 되고 반복이 안 끝난다. 붙여 넣은 코드만 보면 그 무한 반복은 생기지 않는다. 그런데 효율성 1번은 시간 초과였다. 이후 `2 * i` 체가 통과한 것을 보면, 처음 알고리즘이 너무 느려서 막힌 것은 아니다.
- 통과는 제출마다 다시 채점한다. 이전 통과를 이어 받지 않고, 이전보다 빨라야 하는 것도 아니다. 답이 맞고 제한 시간 안이면 통과다. `2.67ms`와 `5.97ms`는 둘 다 그 안이다. 처음 시간 초과는 제한을 넘긴 경우다.
- 마이셀 공식도 정확한 개수다. `n / ln(n)`이 근사고, `100만`이면 약 `72382`가 나온다. 실제는 `78498`.
- 르장드르는 `√n`까지 소수를 만든 뒤에도 점화 호출이 남는다. `100만`에서 호출 `41095`번, 딕셔너리 키 `20547`개. 홀수 체는 칸을 약 `181만` 번 순서대로 건드린다. 횟수는 공식이 약 `44`배 적은데, 한 번이 함수 호출과 해시 조회라 이 PC에서 `1.31ms` 대 `2.80ms`로 공식이 더 느렸다.

## 문제 한 줄
`1`부터 `n`까지 소수의 개수. `n`은 `2` 이상 `100만` 이하. `1`은 소수가 아니다.

## 핵심 패턴
```text
isPrime[2]만 true, 3부터 홀수만 true
limit = (int)Math.Sqrt(n)
3부터 limit까지 홀수 소수면, number*number부터 +number*2 칸을 false
개수는 2가 있으면 1에서 시작, 홀수 칸만 셈
```
- `10` → `4` (`2, 3, 5, 7`). `5` → `3`. `100만` → `78498`.
- 소수 만들기는 상한이 `3000`이고 세 수의 합이 소수인지를 본다. 이번 상한은 `n`이고 결과는 개수다.
- `100만`에서 전체 체 대비 처음 표시 `2.0`배, 바깥 반복 `2.0`배, 배수 지우기 `2.6`배, 개수 세기 `2.0`배. 전체를 더하면 약 `2.3`배.
- 짝수를 빼는 것은 같은 체의 손질이다. 이 문제는 체만 만들면 된다.

## 대안별 구현 비교

`100만`에서 답은 모두 `78498`이다. 통과 여부와 하는 일의 양은 다르다.

| 방법 | 100만에서 무거운 일 | 횟수 | 채점 |
|---|---|---:|---|
| A. 홀수 체 | 홀수 배수 지우기 | 811,068 | 통과, 2.61ms |
| B. 전체 체 | `i * i`부터 지우기 | 2,122,048 | 효율성 1번 시간 초과 |
| C. `2 * i` 체 | `2 * i`부터 지우기 | 2,775,210 | 다른 사람 코드, 통과 |
| D. 약수 검사 | 제곱근까지 나머지 | 67,740,404 | 다른 사람 코드, 통과 |
| E. 르장드르 | 점화 호출 | 41,095 | 5.97ms 통과, 로컬에서는 A보다 느림 |

A가 제출본이다. B는 A보다 일이 많지만 같은 몇 밀리초 대여야 해서, 시간 초과 원인과 횟수가 맞지 않는다. C는 B와 같은 계열이고 이미 지운 칸을 다시 밟아 지우기가 `212만`에서 `277만`으로 늘었다. D는 숫자마다 나눈다. E는 호출 수는 적어도 호출 하나가 무겁다.

`2`와 `3`의 배수를 같이 건너뛰는 체, 합성수를 한 번만 지우는 선형 체, 마이셀 이후 공식은 `100만`에서 코드만 길어진다. 배열을 못 만드는 큰 `n`에서 공식 쪽 횟수가 의미를 가진다.

### A. 홀수 체
제출한 버전. `limit`라 `number * number`가 반복 조건에 없다.

```csharp
public int solution(int n)
{
    bool[] isPrime = new bool[n + 1];
    if (n >= 2)
    {
        isPrime[2] = true;
    }

    for (int number = 3; number <= n; number += 2)
    {
        isPrime[number] = true;
    }

    int limit = (int)Math.Sqrt(n);
    for (int number = 3; number <= limit; number += 2)
    {
        if (!isPrime[number])
        {
            continue;
        }

        for (int multiple = number * number; multiple <= n; multiple += number * 2)
        {
            isPrime[multiple] = false;
        }
    }

    int primeCount = n >= 2 ? 1 : 0;
    for (int number = 3; number <= n; number += 2)
    {
        if (isPrime[number])
        {
            primeCount++;
        }
    }

    return primeCount;
}
```

### B. 전체 체
처음 제출. `2`부터 `n`까지 참으로 두고, `number * number`부터 `+number`로 지운 뒤 참인 칸을 센다. `10`과 `100만`의 답은 A와 같다.

```csharp
public int solution(int n)
{
    bool[] isPrime = new bool[n + 1];
    for (int number = 2; number <= n; number++)
    {
        isPrime[number] = true;
    }

    for (int number = 2; number * number <= n; number++)
    {
        if (!isPrime[number])
        {
            continue;
        }

        for (int multiple = number * number; multiple <= n; multiple += number)
        {
            isPrime[multiple] = false;
        }
    }

    int primeCount = 0;
    for (int number = 2; number <= n; number++)
    {
        if (isPrime[number])
        {
            primeCount++;
        }
    }

    return primeCount;
}
```

### C. `2 * i`부터 지우는 체
소수를 만나면 바로 개수를 센다. 안쪽은 `i * 2`, `i * 3`이라 `i * i` 아래의 합성수도 다시 쓴다. `n`이 `100만`이면 `i * j`는 `int` 안에 있다.

```csharp
public int solution(int n)
{
    int answer = 0;
    bool[] isComposite = new bool[n + 1];

    for (int number = 2; number <= n; number++)
    {
        if (isComposite[number])
        {
            continue;
        }

        answer++;
        for (int multiple = number * 2; multiple <= n; multiple += number)
        {
            isComposite[multiple] = true;
        }
    }

    return answer;
}
```

### D. 약수 검사
`2`부터 `n`까지 각각 제곱근까지 나눈다. 짝수는 `2`에서 바로 끝나고, 소수는 제곱근까지 간다. 나머지 검사가 약 `6774만` 번이다.

```csharp
bool IsPrime(int num)
{
    for (int number = 2; number * number <= num; number++)
    {
        if (num % number == 0)
        {
            return false;
        }
    }

    return true;
}

public int solution(int n)
{
    int primeCount = 0;
    for (int number = 2; number <= n; number++)
    {
        if (IsPrime(number))
        {
            primeCount++;
        }
    }

    return primeCount;
}
```

### E. 르장드르
`a`는 `√n` 이하 소수의 개수. `φ(n, a)`는 `1`부터 `n`까지 그 소수들로 안 나누어지는 수의 개수다. `π(n) = φ(n, a) + a - 1`. `n = 10`이면 소수가 `2, 3`이라 `a = 2`, 안 나누어지는 수가 `1, 5, 7`이라 `3 + 2 - 1 = 4`.

`value`가 지금 소수보다 작으면 남는 수는 `1`뿐이다. 이 기준 없이 재면 이 PC에서 `3.82ms`였고, 기준을 두면 `2.80ms`였다. 홀수 체는 `1.31ms`.

```csharp
public int solution(int n)
{
    if (n < 2)
    {
        return 0;
    }

    int root = (int)Math.Sqrt(n);
    List<int> primes = PrimesUpTo(root);
    int primeIndex = primes.Count;
    var memo = new Dictionary<(int value, int primeIndex), int>();
    return Phi(n, primeIndex, primes, memo) + primeIndex - 1;
}

int Phi(int value, int primeIndex, List<int> primes, Dictionary<(int value, int primeIndex), int> memo)
{
    if (primeIndex == 0 || value < 2)
    {
        return value;
    }

    if (value < primes[primeIndex - 1])
    {
        return 1;
    }

    var key = (value, primeIndex);
    if (memo.TryGetValue(key, out int cached))
    {
        return cached;
    }

    int prime = primes[primeIndex - 1];
    int count = Phi(value, primeIndex - 1, primes, memo) - Phi(value / prime, primeIndex - 1, primes, memo);
    memo[key] = count;
    return count;
}

List<int> PrimesUpTo(int limit)
{
    var primes = new List<int>();
    if (limit < 2)
    {
        return primes;
    }

    bool[] isPrime = new bool[limit + 1];
    for (int number = 2; number <= limit; number++)
    {
        isPrime[number] = true;
    }

    int root = (int)Math.Sqrt(limit);
    for (int number = 2; number <= root; number++)
    {
        if (!isPrime[number])
        {
            continue;
        }

        for (int multiple = number * number; multiple <= limit; multiple += number)
        {
            isPrime[multiple] = false;
        }
    }

    for (int number = 2; number <= limit; number++)
    {
        if (isPrime[number])
        {
            primes.Add(number);
        }
    }

    return primes;
}
```

## 다음에 볼 것
- 소수 만들기와 같은 체다. 달라지는 것은 상한 `n`과 마지막이 개수라는 점.
- `number * number`를 반복 조건에 두면 `n`이 `int` 한계 근처일 때 음수 곱으로 반복이 안 끝난다. `100만`에서는 `limit`와 결과가 같다.
- 여러 상한을 한 체에 묻으면 칸에 누적 개수를 저장한다. 이번 입력은 `n` 하나다.
