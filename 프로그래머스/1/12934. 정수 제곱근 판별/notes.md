# 정수 제곱근 판별 (12934)

## 상태
- 제출 완료. `Math.Sqrt` 후 `root * root == n`이면 `(root + 1)`의 제곱
- 제출 파일: `프로그래머스/1/12934. 정수 제곱근 판별/정수 제곱근 판별.cs`
- LocalTest: `LocalTest/Program.cs`에 같은 코드. gitignore라 커밋되지 않음. `Main`은 비어 있음

## 내가 한 질문
- `n`의 절반부터 오름차순으로 확인해야 하나?
- `i * i`로 비교하려 했는데 그 방법은 나쁘나? `Math.Sqrt`는 괜찮은가? 오차는 없나?
- 1부터 올리면 생각보다 많이 안 걸리나?
- `Math.Sqrt` 내부도 비슷하게 반복하지 않나?
- `Math.Sqrt`는 소수점 문제가 없게 되어 있나?
- `Math`는 기본 `using`으로 쓰나?
- LocalTest에 작성한 코드를 확인해 달라.
- 추가로 주의할 점이 있나?
- `sqrt % 1.0`으로 정수인지 보는 풀이가 있다. 정수 판별은 또 어떤 방법이 있나?

## 막혔던 지점
- `n`의 절반부터 위로 보면 제곱근을 지난다. `121`의 절반은 `60`이고 `60 * 60`은 `3600`이다. 제곱근은 `11`이다.
- `i * i` 비교 자체는 맞다. 범위가 `n / 2`이면 횟수가 수조 단위다. `i * i`가 `n`을 넘으면 멈추면 최대 약 700만 번이다. `121`은 11번, `3`은 `2 * 2`에서 끝난다.
- `i`와 곱은 `long`이다. 약 700만을 `int`로 곱하면 넘친다. `(root + 1)`의 제곱도 이 제한에서는 `long`에 들어간다.
- `Math.Sqrt`는 `i`를 1씩 올리지 않는다. `(추측 + n / 추측) / 2`로 당기거나 CPU 제곱근 명령을 쓴다. `121`을 10으로 시작하면 다음이 `11.05`다.
- `Sqrt`는 소수점 오차가 없게 만든 함수가 아니다. `double` 근삿값이다. 이 문제의 `n`은 `double`이 정수를 그대로 담는 범위보다 작아, 제곱수면 `11.0`처럼 떨어진다. `(long)`은 소수점을 버린다. `3`은 `1.732...`가 `1`이 되고 `1 * 1`이 `3`이 아니라 `-1`이다.
- `n`이 더 커지면 정수 자체가 `double`에 안 담길 수 있다. 그때는 `root + 1`의 제곱도 `n`과 본다. 이번 제한은 `root * root == n`이면 된다.
- `Math.Sqrt(n) * Math.Sqrt(n) == n`처럼 `double`끼리 비교하면 제곱수인데도 어긋날 수 있다. 정수로 바꾼 뒤 곱한다.
- `Math`는 `System` 안이다. `using System;`이면 된다. `using System.Math`는 없다. LocalTest는 이 using이 자동으로 켜져 있다.
- `n`이 1이면 `root`는 1이고 반환은 4다. `1`의 제곱이므로 `(1 + 1)`의 제곱이 맞다.

## 문제 한 줄
`n`이 어떤 양의 정수 `x`의 제곱이면 `(x + 1)`의 제곱, 아니면 `-1`.

## 핵심 패턴
```text
root = (long)Math.Sqrt(n)
root * root == n 이면 (root + 1) * (root + 1)
아니면 -1
```
- `121` → `11` → `144`
- `3` → `-1`
- `1` → `4`
- `n`은 1 이상 `50,000,000,000,000` 이하. 제곱근은 약 700만.

## 대안별 구현 비교

`long`으로 제곱해 `n`과 같으면 결과가 같다. `double`의 소수부만 보거나 `double`끼리 곱하면, `n`이 커졌을 때 달라질 수 있다. 이번 제한에서는 A, B, C가 같다.

### A. `Sqrt` 후 `long` 제곱
제출한 버전. `Math`는 `using System;`으로 쓴다.

```csharp
long root = (long)Math.Sqrt(n);
if (root * root == n)
{
    return (root + 1) * (root + 1);
}
return -1;
```

### B. `i * i`가 `n`을 넘기 전까지
정의 그대로다. 최대 약 700만 번. `i`는 `long`이다. `n / 2`까지 가면 제한 시간을 넘긴다.

```csharp
long i = 1;
while (i * i < n)
{
    i++;
}
if (i * i == n)
{
    return (i + 1) * (i + 1);
}
return -1;
```

### C. `sqrt % 1.0`으로 정수처럼 보이는지
다른 사람 풀이. 소수부가 0이면 `(sqrt + 1)`의 제곱. `sqrt == Math.Floor(sqrt)`, `sqrt == (long)sqrt`도 같은 확인이다. 이번 제한에서는 A와 같다. `n`이 더 커지면 제곱수인데도 소수로 보일 수 있다.

```csharp
double sqrt = Math.Sqrt(n);
if (sqrt % 1.0 != 0)
{
    return -1;
}
long root = (long)sqrt + 1;
return root * root;
```

### D. `double`끼리 제곱 비교
제곱수인데도 소수점 때문에 `-1`이 될 수 있다. 비교는 `long`으로 한다.

```csharp
double sqrt = Math.Sqrt(n);
if (sqrt * sqrt == n)
{
    long root = (long)sqrt + 1;
    return root * root;
}
return -1;
```

## 다음에 볼 것
- 제곱근까지는 1씩 올려도 약 700만 번이다. 절반까지 올리는 것과 다르다.
- `Sqrt` 결과는 `double`이다. 맞는지 보려면 정수로 바꾼 뒤 다시 제곱해 `n`과 비교한다.
