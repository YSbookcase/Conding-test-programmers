# 소수 만들기 (12977)

## 상태
- 제출 완료. 3000까지 체를 만들고 `i < j < k`로 세 수의 합이 소수인지 셈
- 제출 파일: `프로그래머스/1/12977. 소수 만들기/소수 만들기.cs`
- LocalTest에서 배수 칸이 아니라 소수 자신을 `false`로 지운 적이 있음. gitignore라 커밋되지 않음

## 내가 한 질문
- 경우의 수를 전부 보면서 약수로 소수 검사를 하나? 범위 안 소수 배열과 비교하는 편이 빠르지 않나?
- 약수 판별이 확실히 더 늦나?
- 세 수를 고르는 방법이 여러 개 있던 것 같다. 이분 선택이랑. 3중 반복으로도 되나?
- 이전 문제 중 관련 문제가 있나? 그때 알려 준 내용은?
- 삼총사에서 다른 방법으로 설명한 것은?
- 단순 3개 선택이 아니라 합이 0인 특수한 경우라 다른 탐색이 가능한 건가?
- LocalTest 확인.
- `multiple` 반복이 정확히 뭔가?
- 소수를 넣는 것보다 소수가 아닌 것을 지우는 편이 쉽고 연산도 나은가?
- 인덱스를 직접 올리는 다른 사람 코드는 뭔가?
- 반복 횟수는 결국 같은가?
- 순열을 만든 뒤 문자열로 거르는 코드는 무슨 방법인가?

## 막혔던 지점
- LocalTest는 `isPrime[multiple] = false`가 아니라 `isPrime[number] = false`였다. 작은 소수가 지워지고 합성수는 `true`로 남는다. `[1, 2, 3, 4]`의 합 6, 7, 8, 9 중 7만 빠지고 답이 3이 된다. 정답은 1이다.
- 0과 1도 `true`로 뒀다. 세 수의 합은 최소 6이라 이 문제 답에는 영향이 없다.
- 약수 판별은 합마다 제곱근까지, 또는 `합 - 1`까지 나눈다. 체는 3000까지 한 번 만든 뒤 `isPrime[합]` 한 칸이다. 조합은 최대 약 2만이라 제출 시간 차이는 없다. 나누기 횟수는 약수 판별이 더 많다.
- 삼총사의 투 포인터, 해시, 이분 탐색은 합이 0이라 나머지가 `-(두 수의 합)`으로 정해질 때 쓴다. 소수인지는 세 번째 수가 하나로 정해지지 않는다. 메모는 `프로그래머스/1/131705. 삼총사/notes.md`.
- 순열은 같은 세 수를 6번 만든다. 정렬한 `"1,2,4"`로 한 번만 세면 조합과 같다. 합만 비교하면 `[1, 6, 10]`과 `[1, 4, 12]`가 둘 다 17이라 하나가 빠진다.

## 문제 한 줄
서로 다른 세 수를 골랐을 때 합이 소수인 경우의 수를 구한다.

## 핵심 패턴
```text
isPrime[0..3000], 2 이상은 처음 true
number가 소수면 number*number, +number 칸을 false
i < j < k 이고 isPrime[세 수의 합]이면 +1
```
- 예제 `[1, 2, 3, 4]`는 `1 + 2 + 4 = 7`만 소수 → 1.
- `[1, 2, 7, 6, 4]`는 7, 11, 13, 17 → 4.
- 바깥 반복은 `number * number <= 3000`까지면 된다. 제출본은 `number < 3000`이고, 안쪽은 `number * number`부터라 결과는 같다.
- 시간은 체 O(3000 log log 3000)과 조합 O(n³). `n`은 50 이하.

## 대안별 구현 비교

A, B, C의 답은 같다. 차이는 소수 판별과 인덱스를 올리는 방식이다. D는 순열을 만들었다가 조합으로 줄인다. 합으로 중복을 지우면 답이 달라진다.

### A. 체와 3중 반복
제출한 버전. `j`는 `i + 1`, `k`는 `j + 1`.

```csharp
bool[] isPrime = new bool[3001];
for (int number = 2; number <= 3000; number++)
{
    isPrime[number] = true;
}

for (int number = 2; number * number <= 3000; number++)
{
    if (!isPrime[number])
    {
        continue;
    }

    for (int multiple = number * number; multiple <= 3000; multiple += number)
    {
        isPrime[multiple] = false;
    }
}

int primeCount = 0;
for (int i = 0; i < nums.Length; i++)
{
    for (int j = i + 1; j < nums.Length; j++)
    {
        for (int k = j + 1; k < nums.Length; k++)
        {
            if (isPrime[nums[i] + nums[j] + nums[k]])
            {
                primeCount++;
            }
        }
    }
}
return primeCount;
```

`multiple`은 지울 칸이다. 2이면 4, 6, 8을 지우고, 3이면 9, 12, 15를 지운다. 더 작은 배수는 이미 지워져서 `number * number`부터 본다.

### B. 합마다 제곱근까지 나누기
조합 횟수는 A와 같다. 소수일 때만 제곱근까지 가고, 짝수는 2에서 끝난다.

```csharp
bool IsPrime(int sum)
{
    if (sum < 2)
    {
        return false;
    }

    for (int divisor = 2; divisor * divisor <= sum; divisor++)
    {
        if (sum % divisor == 0)
        {
            return false;
        }
    }

    return true;
}
```

`divisor`를 `sum - 1`부터 2까지 잡으면 결과만 같다. 나누는 횟수가 늘어난다.

### C. 조합 수만큼 인덱스를 직접 증가
`C(n, 3) = n * (n - 1) * (n - 2) / 6`번 돈다. `n` 3부터 50까지 A와 같은 조합이다. 3중 반복이 더 짧다.

```csharp
int count = nums.Length * (nums.Length - 1) * (nums.Length - 2) / 6;
int first = 0;
int second = 1;
int third = 2;
int primeCount = 0;
for (int i = 0; i < count; i++)
{
    if (IsPrime(nums[first] + nums[second] + nums[third]))
    {
        primeCount++;
    }

    third++;
    if (third >= nums.Length)
    {
        second++;
        third = second + 1;
    }

    if (second >= nums.Length - 1)
    {
        first++;
        second = first + 1;
        third = second + 1;
    }
}
return primeCount;
```

### D. 순열을 만들고 정렬 문자열로 한 번만 세기
길이 3 순열은 조합의 6배다. 세 수를 정렬한 `"1,2,4"`가 없을 때만 센다. 합이 같은 다른 조합까지 지우면 `[1, 6, 10]`과 `[1, 4, 12]`가 둘 다 17이라 하나가 빠진다.

## 다음에 볼 것
- 고르는 개수가 고정이고 나머지가 정해지지 않으면 `i < j < k`.
- 합이 특정 값이면 삼총사처럼 투 포인터, 해시, 이분 탐색.
- 범위의 소수가 전부 필요하면 배수를 지우는 체. 수마다 약수를 확인해서 목록에 넣는 쪽보다 나누기가 적다.
