# 문자열 내 마음대로 정렬하기 (12915)

## 상태
- 제출 성공은 확인하지 못함
- LocalTest에는 `n`번째 문자로 `Array.Sort`한 뒤, 같은 문자 구간만 사전순으로 다시 정렬하는 코드가 있음. `LocalTest/Program.cs`
- 채팅에서는 사전순 `OrderBy` 다음에 `n`번째 문자 `OrderBy`를 둔 코드도 확인함. 둘 다 예제와 같다
- 공식 폴더가 없어 `프로그래머스/KYS24/문자열내마음대로정렬하기_notes.md`에 둠. 폴더가 생기면 그쪽으로 옮긴다

## 내가 한 질문
- 인덱스를 키, `n`번째 문자를 값으로 딕셔너리에 넣고 값으로 정렬한 뒤 키로 문자열을 되돌리면 되지 않나. 문자가 중복이면 문제이지 않나?
- 같은 문자끼리는 사전순이 더 붙는다. `for`로 그 구간을 다시 배치하면 되지 않나?
- 같은 문자를 모아 두는 반복이 있다. `ThenBy`는 정렬 뒤 추가 정렬인가? 3중도 되나? `OrderBy`를 두 번 쓰면 안 되나?
- `Array.Sort` 뒤의 람다가 익숙하지 않다.
- 전체를 사전순으로 정렬한 다음 `n`번째 문자로 다시 `OrderBy` 하는 코드는 괜찮은가?

## 막혔던 지점
- 인덱스를 키로 두고 `n`번째 문자를 값으로 넣으면 딕셔너리에는 들어간다. 값은 겹쳐도 된다. 그 문자로 다시 키를 찾으면, 같은 문자의 문자열이 둘일 때 어느 쪽인지 알 수 없다.
- 두 번째 조건은 문자열 전체의 사전순이다. `["abce", "abcd", "cdx"]`와 `n = 2`이면 둘 다 `'c'`다. 문자만 정렬하면 둘의 순서가 정해지지 않고, 원래 순서를 유지해도 `"abce"`가 앞에 있어서 오답이다. 정답은 `"abcd"`가 앞이다.
- 배열 전체를 사전순으로 한 번 더 정렬하면 첫 정렬이 풀린다. `["car", "bed", "sun"]`은 `n`번째 문자가 모두 달라서 두 번째 배치가 필요 없는데, 전체를 사전순으로 바꾸면 `"bed"`가 앞으로 간다.
- 같은 `n`번째 문자로 이어진 구간만 사전순으로 다시 정렬한다. `end`는 그 구간 끝의 다음 인덱스다. `end - start`가 1이면 단어가 하나라 순서가 그대로다.
- `ThenBy`는 앞 기준이 같은 항목만 다음 기준으로 가른다. 배열 전체를 두 번째 기준으로 다시 정렬하는 것이 아니다. `ThenBy`는 계속 이을 수 있다. `OrderBy`를 두 번 쓰면 마지막 `OrderBy`만 남고 앞 기준은 사라진다.
- `(a, b) => a[n].CompareTo(b[n])`는 두 문자열을 비교하는 함수다. `a[n]`이 더 작으면 음수라 `a`가 앞이고, 같으면 `0`, 더 크면 양수라 `b`가 앞이다. `n`은 바깥 매개변수를 그대로 쓴다. 람다가 없는 `Array.Sort(strings, start, end - start)`는 문자열 기본 사전순이다.
- 사전순 `OrderBy`를 먼저 하고, 그다음 `c[n]`으로 `OrderBy` 하면 예제와 같다. 두 번째 `OrderBy`는 안정 정렬이라 기준 문자가 같으면 첫 정렬 순서를 유지한다. 두 줄의 순서를 바꾸면 사전순만 남는다.
- 람다의 `c`는 문자 하나가 아니라 문자열 전체다.

## 문제 한 줄
각 문자열의 `n`번째 문자로 오름차순 정렬한다. 그 문자가 같으면 문자열 전체의 사전순이다.

## 핵심 패턴
```text
OrderBy(word => word[n]).ThenBy(word => word)
```
- `["sun", "bed", "car"]`, `n = 1` → `["car", "bed", "sun"]`
- `["abce", "abcd", "cdx"]`, `n = 2` → `["abcd", "abce", "cdx"]`
- 원소 길이 50 이하, 문자열 길이 100 이하. 모든 문자열 길이는 `n`보다 크다.

## 대안별 구현 비교

예제 둘은 결과가 같다. 차이는 `n`번째 문자가 같은 쌍을 누가 나누느냐다. 전체를 사전순으로 마지막에 정렬하면 `["sun", "bed", "car"]`가 `["bed", "car", "sun"]`이 된다.

### A. `OrderBy`와 `ThenBy`
한 정렬에 기준이 둘이다. `n`번째 문자가 다를 때는 `ThenBy`까지 가지 않는다. 채점 코드에는 `using System.Linq;`이 필요하다.

```csharp
using System.Linq;

public class Solution {
    public string[] solution(string[] strings, int n) {
        return strings.OrderBy(word => word[n]).ThenBy(word => word).ToArray();
    }
}
```

### B. 사전순을 먼저, `n`번째 문자를 나중에
안정 정렬이라 결과가 A와 같다. 마지막 `OrderBy`가 주 기준이다. 줄을 바꾸면 `n`번째 문자 순서는 사라진다. `Array.Sort`는 안정 정렬이 아니라서 이 두 줄을 그대로 바꾸면 같은 문자의 순서가 깨질 수 있다.

```csharp
using System.Linq;

public class Solution {
    public string[] solution(string[] strings, int n) {
        string[] answer = strings.OrderBy(word => word).ToArray();
        answer = answer.OrderBy(word => word[n]).ToArray();
        return answer;
    }
}
```

`["abce", "abcd", "cdx"]`는 사전순으로 `["abcd", "abce", "cdx"]`가 된 뒤, `'c'` 둘은 그 순서를 유지하고 `'x'`만 뒤로 간다.

### C. `n`번째 문자로 정렬한 뒤 같은 문자 구간만 사전순
LocalTest에 둔 버전. 두 번째 `Array.Sort`의 범위는 `start`부터 길이 `end - start`다. `using System;`이 필요하다.

```csharp
using System;

public class Solution {
    public string[] solution(string[] strings, int n) {
        Array.Sort(strings, (a, b) => a[n].CompareTo(b[n]));

        int start = 0;
        while (start < strings.Length)
        {
            int end = start + 1;
            while (end < strings.Length && strings[end][n] == strings[start][n])
            {
                end++;
            }

            Array.Sort(strings, start, end - start);
            start = end;
        }
        return strings;
    }
}
```

## 다음에 볼 것
- 두 번째 기준은 `ThenBy`다. `OrderBy`를 다시 호출하면 앞 기준이 사라진다.
- 안정 정렬로 두 번 정렬할 때는 나중 기준을 마지막에 둔다. 먼저 둔 기준은 같은 키의 순서로만 남는다.
- `Array.Sort`에 람다를 주면 비교 대상을 바꾼다. 람다가 없으면 배열 원소 자체의 기본 순서다.
