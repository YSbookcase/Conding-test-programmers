# 문자열 내림차순으로 배치하기 (12917)

## 상태
- 제출 성공은 확인하지 못함. LocalTest에는 `OrderByDescending`까지 적혀 있음
- 연습 파일: `LocalTest/Program.cs`. `using System.Linq`은 파일에 없고, LocalTest는 그 `using`이 자동이라 빌드된다
- 공식 폴더가 없어 `프로그래머스/KYS24/문자열내림차순으로배치하기_notes.md`에 둠. 폴더가 생기면 그쪽으로 옮긴다

## 내가 한 질문
- LINQ로 하면 되는건가?
- 단순히 `string` 내장 함수가 있나?
- 뭐가 더 나은 판단이라고 생각해? 조언은?

## 막혔던 지점
- `string`에는 정렬 함수가 없다. 문자 배열로 바꿨다가 `new string`으로 돌아온다.
- 소문자 코드가 대문자보다 크다. `'g'`는 103, `'Z'`는 90이라 큰 값부터 정렬하면 대문자가 뒤로 간다. 문제의 "대문자는 소문자보다 작다"와 문자 코드 순서가 같다.
- `OrderByDescending` 결과는 문자열이 아니라 정렬된 문자 목록이다. `ToArray()` 뒤에 `new string`을 해야 한다.
- 채점 기본 코드에는 `using System.Linq`이 없다. `Array.Sort`를 쓰면 `using System`이 없다.
- `Array.Sort`는 오름차순이다. `Reverse`를 빠뜨리면 `"Zbcdefg"`가 내림차순이 되지 않는다. `OrderBy`도 오름차순이라 방향이 반대다.
- 이 문제에서는 `OrderByDescending`이 맞다. 요구가 "큰 것부터"라서 메서드 이름에 방향이 있다. `Array.Sort`와 `Reverse`는 배열을 그 자리에서 정렬할 때 쓴다. 이 길이에서는 속도 차이는 없다.

## 문제 한 줄
영문 대소문자를 큰 문자부터 정렬한 새 문자열을 반환한다. 대문자는 소문자보다 작다.

## 핵심 패턴
```text
using System.Linq
return new string(s.OrderByDescending(ch => ch).ToArray())
```
- `"Zbcdefg"` → `"gfedcbZ"`

## 대안별 구현 비교

방향을 맞추면 결과는 같다. `OrderBy`나 `Reverse`를 빼면 `"Zbcdefg"`의 순서가 반대로 나온다.

### A. `OrderByDescending`
이 문제에 쓰는 쪽. 채점 코드 맨 위에 `using System.Linq;`이 필요하다.

```csharp
using System.Linq;

public class Solution {
    public string solution(string s) {
        return new string(s.OrderByDescending(ch => ch).ToArray());
    }
}
```

### B. `Array.Sort` 후 `Reverse`
오름차순으로 정렬한 뒤 뒤집는다. `using System;`이 필요하다. `Reverse`가 없으면 내림차순이 아니다.

```csharp
using System;

public class Solution {
    public string solution(string s) {
        char[] chars = s.ToCharArray();
        Array.Sort(chars);
        Array.Reverse(chars);
        return new string(chars);
    }
}
```

`"Zbcdefg"`를 오름차순으로 정렬하면 `"Zbcdefg"`이고, 뒤집으면 `"gfedcbZ"`다.

## 다음에 볼 것
- 내림차순은 `OrderByDescending`. `OrderBy`와 `Array.Sort`는 오름차순이다.
- `string`은 정렬 메서드가 없다. 문자 배열을 정렬하고 `new string`으로 만든다.
- 채점에 `using System.Linq` 또는 `using System`을 넣는 줄이 있는지 본다.
