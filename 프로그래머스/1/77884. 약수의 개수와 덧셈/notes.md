# 약수의 개수와 덧셈 (77884)

## 상태
- 제출 완료. 구간 합에서 제곱수를 두 번 뺌. 시작 제곱근은 `Math.Ceiling(Math.Sqrt(left))`
- 약수 개수 버전은 제출 `.cs` 안에 주석으로만 남아 있음
- 제출 파일: `프로그래머스/1/77884. 약수의 개수와 덧셈/약수의 개수와 덧셈.cs`

## 내가 한 질문
- 약수 개수를 세고, 짝수면 더하고 홀수면 빼면 되나?
- 제곱근이 정수인 수만 확인하고 빼면 되나? 나머지는 1씩 커지니 등차수열 합으로 해도 되나?
- `left`가 17이면 `root`는 4인가?
- 이 접근에 더 볼 점은?

## 막혔던 지점
- 바깥 반복 `i <= right - left`는 끝 값이 아니라 두 수의 차이다. 예시는 `13 <= 4`, `24 <= 3`이라 본문이 한 번도 안 돌고 결과가 0이다. 끝은 `number <= right`.
- `dcCount`는 약수 개수인지 안 읽힌다. 주석으로 남긴 이름은 `divisorCount`.
- 안쪽 `i * i <= n / 2`는 제곱근까지 가지 못한다. `i * i == n`이면서 `i * i <= n / 2`이면 `n <= n / 2`라, `n`이 1 이상이면 제곱근을 세는 분기는 실행되지 않는다. 16은 1, 16, 2, 8만 세고 4를 놓쳐 개수 4가 된다. 실제는 5라 빼야 하는데 더해져, 13부터 17이 75가 된다.
- 약수는 짝으로 생기고 제곱근만 혼자다. 약수 개수가 홀수인 수는 제곱수뿐이다.
- 구간 전체를 더하면 제곱수도 한 번 들어 있다. 그 수를 음수로 만들려면 두 번 뺀다. 16을 한 번만 빼면 59, 두 번 빼면 `75 - 32 = 43`. 24부터 27은 `102 - 50 = 52`.
- `left`가 17이면 `root`는 4가 아니다. 4의 제곱 16은 17보다 앞이다. `Ceiling`이면 5이고, 다음 제곱수는 25다.
- `(left + right) / 2`를 먼저 하면 홀수 합이 잘린다. 24부터 27은 `51 / 2`가 25가 되어 `25 × 4 = 100`. 2로 나누는 위치는 곱한 뒤다. 이 범위의 곱은 `int`에 들어간다.
- 제출은 `Ceiling` 버전이다. `Sqrt` 뒤 `root * root < left`이면 `root++`로 확인하는 식은 조언이고, 제출 코드에는 없다. `right`가 1,000 이하라 `Ceiling`으로도 예시는 맞다.

## 문제 한 줄
`left`부터 `right`까지, 약수 개수가 짝수면 더하고 홀수면 뺀다.

## 핵심 패턴
```text
total = (left + right) * (right - left + 1) / 2
root = 제곱이 left 이상인 가장 작은 정수
root * root <= right 동안 total -= 2 * root * root
```

13부터 17: 합 75, 제곱수 16만 두 번 빼서 43. 24부터 27: 합 102, 25를 두 번 빼서 52.

| left | 제곱근 | 올림 | root² |
|---|---|---|---|
| 13 | 3.606 | 4 | 16 |
| 16 | 4 | 4 | 16 |
| 17 | 4.123 | 5 | 25 |

## 제출 코드
```csharp
int total = (left + right) * (right - left + 1) / 2;
int root = (int)Math.Ceiling(Math.Sqrt(left));

for (; root * root <= right; root++)
    total -= 2 * root * root;

return total;
```

`total`은 구간의 합이다. `root`는 `left` 이상의 첫 정수 제곱근이다. `for`의 초기식이 비어 있는 이유는 `root`를 루프 밖에서 만들기 때문이다.

## 대안별 구현 비교

셋 다 제곱수만 빼고 나머지는 더한다. 제출은 A다.

| | A 구간 합, 제곱수 두 번 빼기 | B 숫자마다 제곱 판별 | C 약수 개수 |
|---|---|---|---|
| 시간 | 제곱수 개수. 1,000 이하에서 약 31번 | `right - left + 1` | 숫자마다 제곱근까지 |
| 실수 지점 | 한 번만 빼면 그 수는 0. 나눗셈을 먼저 하면 합이 잘림 | `root * root == number` 확인 | `i * i <= n / 2`면 제곱근을 놓침 |

### B. 숫자마다 제곱 판별
```csharp
int answer = 0;
for (int number = left; number <= right; number++)
{
    int root = (int)Math.Sqrt(number);
    if (root * root == number) answer -= number;
    else answer += number;
}
return answer;
```

### C. 약수 개수
처음 작성은 `i * i <= n / 2`였다. 아래는 제곱근까지 보는 수정이다. 제출 파일에는 이 형태가 주석으로 있다.

```csharp
int divisorCount(int number)
{
    int count = 0;
    for (int i = 1; i * i <= number; i++)
    {
        if (number % i != 0) continue;
        if (i * i == number) count++;
        else count += 2;
    }
    return count;
}
```

`Sqrt` 시작점을 정수로 확인할 때는 올림 대신 제곱으로 본다.

```csharp
int root = (int)Math.Sqrt(left);
if (root * root < left) root++;
```

17이면 4에서 시작하고 `16 < 17`이라 5가 된다. 16이면 4에서 멈춘다.

## 다음에 볼 것
- 제곱수 하나인 구간 `16, 16`은 `-16`. 없는 구간 `2, 3`은 `5`. `1, 1`은 `-1`.
- 등차수열 합의 2 나눗셈은 곱한 다음이다.
- 약수 개수의 홀짝만 필요하면 제곱수 판별로 충분하다.
