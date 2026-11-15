# 정수 내림차순으로 배치하기 (12933)

## 상태
- 제출 완료. `ToString` 후 `Array.Sort`, `Reverse`, `long.Parse`
- 제출 파일: `프로그래머스/1/12933. 정수 내림차순으로 배치하기/정수 내림차순으로 배치하기.cs`
- LocalTest는 쓰지 않음

## 내가 한 질문
- 자릿수를 배열이나 리스트로 만들어 오름차순으로 정렬한 뒤 합치면 되나?
- 문자열로 바꾸지 않고 `long`을 `% 10`으로 나눠 담는 방법인 줄 알았다.

## 막혔던 지점
- 정렬은 오름차순이 아니라 내림차순이다. `118372`를 작은 자릿수부터 붙이면 `112378`이다. 큰 자릿수부터 붙여야 `873211`이다.
- `Array.Sort`는 오름차순이라 `Reverse`로 뒤집는다. `'0'`부터 `'9'`는 문자 코드 순서와 숫자 크기가 같다.
- `n`은 최대 `8,000,000,000`이라 `int`에 들어가지 않는다. 입력과 반환은 `long`이다. 자릿수는 최대 10개라 다시 만든 수도 `long`에 들어간다.
- `ToString()`은 `% 10`으로 나온 나머지를 문자로 적어 둔 것이다. `118372`을 10으로 나누면 2, 7, 3, 8, 1, 1이다. 두 방법의 자릿수는 같다.
- `n`은 1 이상이라 `% 10` 반복이 한 번도 안 도는 경우는 없다.

## 문제 한 줄
`n`의 자릿수를 큰 것부터 작은 순으로 다시 붙인 수를 반환한다.

## 핵심 패턴
```text
자릿수를 모은다
오름차순 정렬 후 뒤집기
앞에서부터 result = result * 10 + 자릿수
```
- `118372` → `873211`

## 대안별 구현 비교

내림차순으로 붙이면 결과가 같다. 오름차순으로 붙이면 `112378`이 되어 다르다. 차이는 자릿수를 문자로 꺼낼지, 나머지로 꺼낼지다.

### A. 문자열 정렬 후 `Parse`
제출한 버전.

```csharp
char[] digits = n.ToString().ToCharArray();
Array.Sort(digits);
Array.Reverse(digits);
return long.Parse(new string(digits));
```

### B. `% 10`으로 담고 `* 10`으로 붙임
`Sort`는 오름차순이라 `Reverse`가 필요하다. `8` 다음은 `87`, 그 다음은 `873`이 되어 `873211`이 된다.

```csharp
List<long> digits = new List<long>();
while (n > 0)
{
    digits.Add(n % 10);
    n /= 10;
}

digits.Sort();
digits.Reverse();

long result = 0;
foreach (long digit in digits)
{
    result = result * 10 + digit;
}
return result;
```

### C. 오름차순으로 붙임
`118372`가 `112378`이 된다. A, B와 다르다.

```csharp
Array.Sort(digits);
return long.Parse(new string(digits));
```

## 다음에 볼 것
- 큰 자릿수부터면 정렬 방향은 내림차순이다. `Array.Sort`만 쓰면 반대다.
- 10으로 나눈 나머지와 `ToString`의 한 글자는 같은 자릿수다.
