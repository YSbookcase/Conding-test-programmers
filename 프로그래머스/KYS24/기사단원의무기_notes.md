# 기사단원의 무기 (136798)

## 상태
- 아직 공식 폴더 없음 → `프로그래머스/KYS24/`
- 로컬 실험: `LocalTest/Program.cs` (배수 +1 방식, `.gitignore`)
- 두 방법 코드: `프로그래머스/KYS24/기사단원의무기_학습.cs`
- 공식 폴더가 생기면 이 파일들을 그쪽으로 옮긴다

## 내가 한 질문
- 약수 개수는 숫자를 올리며 나머지가 0인 개수, 구간은 제곱근까지인가?
- `Math.Sqrt`였나?
- `if (i * i != n) count++;`는 뭐지?
- 그 `if` 아래에 `limit` 넘치면 `power`, 아니면 `answer`에 더하면 되나?
- 기사당이라 이중 `for`인가?
- 기사 루프 없이 간다는 게 무슨 말이지? `i=1`인데 왜 1~6에 다 +1인가?
- `i*i` 이후로는 자기 자신밖에 없잖아?
- 배수 방식은 로그처럼 반복이 줄어드는 느낌이다.
- 원래 하려던 제곱근 방식 코드도 보여 달라.
- 실제 결과가 다른데?

## 막혔던 지점
- `limit`/`power` 비교는 약수 개수를 **다 센 뒤** 기사당 한 번. 안쪽 루프에 두면 약수 찾을 때마다 더함.
- `>` : 제한수치보다 **큰** 것만 `power`. 개수 3, limit 3은 그대로.
- 배수 +1에서 `i=1`은 1번 기사가 아니라 **약수 1**. 모든 수가 1로 나누어떨어져서 1~number에 +1.
- 제곱근에서 멈추는 건 **한 기사의 짝 세기**. 배수 방식 바깥 `i`는 `1..number`까지 (제곱근에서 멈추면 자기 자신 약수가 빠짐).
- 합 루프 `i < number`는 마지막 기사 누락. 기사는 `i = 1; i <= number`. `i < n`은 0부터 도는 배열 습관.
- `divCount[0]`은 안 씀. `i=0`부터 돌면 0을 더해서 합은 우연히 맞을 수 있음.

## 문제 한 줄
1~number 각 수의 약수 개수(공격력). `limit`보다 크면 `power`. 그 합(철 무게).

## 핵심 패턴
```text
약수 개수 구한 뒤
count > limit → +power
아니면 +count
```

## 대안별 구현 비교
| | A 기사마다 제곱근 | B 배수에 +1 (LocalTest) |
|---|---|---|
| 바깥 | 기사 `n = 1..number` | 약수 `i = 1..number` |
| 안쪽 | `i*i <= n`, `%`로 짝 세기 | `knight += i` 배수에 `divCount++` |
| 합 | 기사 루프 안에서 바로 | 표 채운 뒤 `1..number` 한 번 더 |
| 복잡도 | `O(n √n)` ≈ 3천만 | `O(n log n)` ≈ 120만 |
| 읽기 | 처음 이해가 쉬움 | “약수가 누구의 것인가”로 뒤집음 |

둘 다 이 제한(`n ≤ 100,000`)에서 통과. 제곱근 방식에서 `i*i != n`일 때만 짝 `n/i`를 더 센다. 제곱수는 같은 약수를 두 번 세면 안 됨.

합 루프는 **`i <= number`**. `i < number`면 예1에서 5번이 빠져 8 (정답 10).

### A. 기사마다 제곱근 (처음 생각)
```csharp
int answer = 0;
for (int n = 1; n <= number; n++)
{
    int count = 0;
    for (int i = 1; i * i <= n; i++)
    {
        if (n % i == 0)
        {
            count++;
            if (i * i != n)
                count++;
        }
    }
    if (count > limit)
        answer += power;
    else
        answer += count;
}
```

### B. 배수 +1 (지금 LocalTest)
```csharp
int[] divCount = new int[number + 1];
for (int i = 1; i <= number; i++)
{
    for (int knight = i; knight <= number; knight += i)
        divCount[knight]++;
}
int answer = 0;
for (int i = 1; i <= number; i++)
{
    if (divCount[i] > limit)
        answer += power;
    else
        answer += divCount[i];
}
```

`Math.Sqrt`는 `double`이라 제곱수에서 `(int)`가 한 칸 작아질 수 있음. 루프 끝은 `i * i <= n`.

배수 합 = `n/1 + n/2 + … + n/n` = `n H_n` → `O(n log n)`. `log n` 한 번이 아님.

## 다음에 볼 것
- 1~n 전부 약수 개수 → 배수 표. 한 수면 제곱근.
- 합은 `1..number` 닫힌 구간. `Length`/`< n`과 기사 번호를 섞지 않기.
- 공식 폴더 생기면 KYS24 파일을 그쪽으로 이동.
