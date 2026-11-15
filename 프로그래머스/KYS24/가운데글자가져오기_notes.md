# 가운데 글자 가져오기 (12903)

## 상태
- 제출 성공은 확인하지 못함
- `if`로 고친 코드를 LocalTest에 두었다가, 이후 2016년 코드로 덮임
- 공식 폴더가 없어 `프로그래머스/KYS24/가운데글자가져오기_notes.md`에 둠. 폴더가 생기면 그쪽으로 옮긴다

## 내가 한 질문
- 작성된 거 확인 좀.
- 소소하게 뭔가 계속 틀린다.
- `(길이 + 1) % 2`로 짝수 나머지를 만들어 계산하는 코드는 신박하다.
- 실수할 수 있으니 무난하게 가는 게 좋겠지.

## 막혔던 지점
- 방향은 맞았다. 어긋난 곳은 시작 인덱스와 `Substring`에 넘긴 길이다.
- `Substring(시작)`은 그 칸부터 끝까지다. 홀수에서 `"abcde"`에 `Substring(2)`를 쓰면 `"cde"`다. 가운데 한 글자는 `Substring(2, 1)`이라 `"c"`다.
- 짝수 시작을 `길이 / 2 + 1`로 잡았다. `"qwer"`의 칸은 `0:q 1:w 2:e 3:r`이라 가운데 두 글자는 인덱스 1부터 `"we"`다. `길이 / 2`는 2, 즉 `"e"`의 자리라 시작은 그보다 한 칸 앞인 `길이 / 2 - 1`이다. `Substring(3, 2)`는 문자열 밖이라 `ArgumentOutOfRangeException`이 난다.
- 길이가 1이면 `Substring(0)`이 전체라 `"a"`가 우연히 맞는다. `"ab"`는 짝수 식에서 같은 예외가 난다. `"abcdef"`는 `Substring(4, 2)`가 `"ef"`라 정답 `"cd"`와 다르다.
- `(길이 + 1) % 2`는 짝수일 때만 1이다. 그 값만큼 시작을 당기고, 자를 길이는 그 값에 1을 더한 것이다. `"abcde"`는 `Substring(2, 1)`, `"qwer"`는 `Substring(1, 2)`라 `if`와 같은 규칙이다. `n`, `l`만 보면 0과 1이 시작 보정인지 길이인지 바로 안 보인다.
- 예제 아래에 인덱스를 한 줄 적고 시작 칸을 고르면 `+1`과 `-1`이 바뀌는 실수가 코드 전에 보인다.

## 문제 한 줄
길이가 홀수면 가운데 한 글자, 짝수면 가운데 두 글자를 반환한다.

## 핵심 패턴
```text
mid = 길이 / 2
짝수면 Substring(mid - 1, 2)
홀수면 Substring(mid, 1)
```
- `"abcde"` → `"c"`
- `"qwer"` → `"we"`
- 길이는 1 이상 100 이하

## 대안별 구현 비교

두 예제는 결과가 같다. 차이는 짝수와 홀수를 식으로 누르느냐, `if`로 나누느냐다. 다시 볼 때는 `if`가 읽기 쉽다.

### A. `if`
무난한 쪽. 짝수는 한 칸 앞에서 두 글자, 홀수는 가운데 한 글자다.

```csharp
public class Solution {
    public string solution(string s) {
        int mid = s.Length / 2;
        if (s.Length % 2 == 0)
        {
            return s.Substring(mid - 1, 2);
        }
        return s.Substring(mid, 1);
    }
}
```

### B. 나머지로 시작과 길이를 계산
짝수면 `n`이 1, 홀수면 0이다. 시작은 `길이 / 2 - n`, 자를 길이는 `n + 1`이다.

```csharp
public class Solution {
    public string solution(string s) {
        int n = (s.Length + 1) % 2;
        int l = s.Length / 2 - n;
        return s.Substring(l, n + 1);
    }
}
```

`"abcde"`는 `n = 0`, `l = 2`, `Substring(2, 1)`. `"qwer"`는 `n = 1`, `l = 1`, `Substring(1, 2)`.

## 다음에 볼 것
- `Substring(시작)`은 끝까지다. 한 글자는 `Substring(시작, 1)`이다.
- 가운데 두 글자의 시작은 `길이 / 2 - 1`이다.
- 예제 문자열 아래에 인덱스를 적고 시작 칸을 고른다.
