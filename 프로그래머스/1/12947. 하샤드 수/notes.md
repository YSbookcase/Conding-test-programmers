# 하샤드 수 (12947)

## 상태
- 제출 완료. `remain`으로 자릿수 합을 구하고 `x % digitSum == 0`
- 제출 파일: `프로그래머스/1/12947. 하샤드 수/하샤드 수.cs`
- LocalTest: `LocalTest/Program.cs`에 첫 버전. gitignore라 커밋되지 않음. `Main`은 비어 있음

## 내가 한 질문
- LocalTest에 작성한 코드를 확인해 달라.
- 수정한 대로 제출할 건데 추가로 주의할 점이 있나?
- 다른 사람은 문자열로 바꾼 뒤 LINQ로 자릿수를 더하던데.
- `ToList().Select(...).Sum()` 풀이와, 자릿수마다 `Substring`으로 `Parse`하는 풀이를 확인해 달라.
- 같이 일할 사람 코드라 다른 풀이도 알아야 할 것 같다.

## 막혔던 지점
- `while (x <= 0)`이라 반복이 한 번도 안 돈다. `x`는 1 이상이다. `digitSum`이 0인 채로 `x % digitSum`에서 0으로 나눈다.
- `temp`를 반복마다 `x`로 다시 만들면 `temp / 10`이 다음 바퀴에서 사라진다. 조건도 `x`를 보므로 `x`가 줄지 않는다.
- 자릿수를 뗄 때 `x`를 직접 `x /= 10` 하면 반복이 끝날 때 `x`는 0이다. `0 % digitSum`은 항상 0이라 11, 13도 `true`가 된다. 남은 수는 `remain`에 두고 `x`는 남긴다.
- `Sum(digit => digit)`는 `'1'`을 1이 아니라 문자 코드 49로 더한다. `"10"`의 합이 1이 아니라 97이라, 하샤드 수인 10도 `false`가 된다. `int.Parse(digit.ToString())`이나 `digit - '0'`이어야 자릿수다.

## 문제 한 줄
`x`가 자기 자릿수 합으로 나누어 떨어지면 하샤드 수다.

## 핵심 패턴
```text
remain = x, digitSum = 0
remain > 0 인 동안:
  digitSum += remain % 10
  remain /= 10
return x % digitSum == 0
```
- 10 → 합 1, `10 % 1 == 0` → `true`
- 12 → 합 3 → `true`
- 11 → 합 2, 나머지 1 → `false`
- 13 → 합 4 → `false`
- 한 자리 수는 항상 하샤드 수다. `1 % 1 == 0`.
- `x`는 1 이상 10000 이하. 자릿수 합은 0이 되지 않고 `int`로 충분하다.

## 대안별 구현 비교

A, C, E, F는 이 범위에서 결과가 같다. 차이는 자릿수를 숫자로 떼느냐, 문자열로 바꾸느냐다. `x`를 소모하거나 문자 코드를 더하면 달라진다. 같이 읽을 때는 합이 같은지, 숫자로 더했는지, `x`가 0이 되지 않았는지만 보면 된다.

### A. `remain`에 자릿수를 누적
제출한 버전.

```csharp
int digitSum = 0;
int remain = x;
while (remain > 0)
{
    digitSum += remain % 10;
    remain /= 10;
}
return x % digitSum == 0;
```

### B. `x`를 직접 나눔
반복이 끝나면 `x`가 0이다. `0 % digitSum == 0`이라 하샤드 수가 아닌 11도 `true`다.

```csharp
int original = x;
int digitSum = 0;
while (x > 0)
{
    digitSum += x % 10;
    x /= 10;
}
return original % digitSum == 0;
```

`original`을 따로 두면 A와 같다. `x`만 쓰면 틀린다.

### C. 문자열로 자릿수 합
`x`는 그대로라 합 뒤에 바로 나눈다. 이 범위에서는 A와 같다.

```csharp
int digitSum = 0;
foreach (char digit in x.ToString())
{
    digitSum += digit - '0';
}
return x % digitSum == 0;
```

### D. LocalTest 첫 버전
`while (x <= 0)`이라 합이 0이다. 예제 10에서도 나머지 연산이 깨진다. 반복 안에 `int temp = x`를 두면 10으로 나눈 값이 다음 바퀴에 유지되지 않는다.

### E. `ToString` 한 번과 `Sum`
다른 사람 풀이. `ToList()`는 없어도 된다. 문자열에 바로 `Select`가 된다. `temp`는 자릿수 합이다. `using System.Linq`이 필요하다. `answer`를 `true`로 두었다가 나누어 떨어지지 않을 때만 `false`로 바꿔도 A와 같다.

```csharp
int digitSum = x.ToString().Sum(digit => int.Parse(digit.ToString()));
return x % digitSum == 0;
```

### F. 자릿수마다 `Substring`
다른 사람 풀이. `Substring(inx, 1)`의 1은 길이다. 결과는 A와 같다. `ToString()`이 조건과 본문에서 자릿수마다 다시 생긴다. 10000 이하라 통과한다. 문자열은 반복 밖에서 한 번이면 된다. `inx`는 위치다.

```csharp
string digits = x.ToString();
int digitSum = 0;
for (int index = 0; index < digits.Length; index++)
{
    digitSum += int.Parse(digits.Substring(index, 1));
}
return x % digitSum == 0;
```

`answer = true`를 넣어 두고 `if`의 양쪽에서 다시 대입하면 그 초기값은 쓰이지 않는다.

### G. 문자 코드를 더함
`"10"`의 합이 97이다. 10도 `false`가 되어 A와 다르다.

```csharp
int digitSum = x.ToString().Sum(digit => digit);
return x % digitSum == 0;
```

## 다음에 볼 것
- 합을 구한 뒤 처음 수로 나누면, 나누는 동안 그 수를 바꾸지 않는다.
- 반복 조건은 줄어드는 변수를 본다. `<= 0`과 `> 0`이 반대면 양수 입력은 한 번도 안 돈다.
- 다른 사람 코드는 같은 자릿수 합인지 먼저 본다. 없어도 되는 `ToList()`, 반복 안의 `ToString()`만 구분하면 된다.
