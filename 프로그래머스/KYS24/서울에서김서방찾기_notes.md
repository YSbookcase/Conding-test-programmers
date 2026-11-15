# 서울에서 김서방 찾기 (12919)

## 상태
- 제출 성공은 확인하지 못함. 채점에서 `IndexOf`와 `Array`가 컴파일 에러로 막힌 뒤 원인을 정리함
- 연습은 `LocalTest/Program.cs`. 이후 다른 문제 코드로 덮여 그 파일에는 이 풀이가 없음
- 공식 폴더가 없어 `프로그래머스/KYS24/서울에서김서방찾기_notes.md`에 둠. 폴더가 생기면 그쪽으로 옮긴다

## 내가 한 질문
- LocalTest에 작성된 코드 확인해줘.
- 넣는데 컴파일 에러가 나서 당황했는데 `Array`도 컴파일 에러가 뜨는데?
- 단순한 문제인거지?
- 추가적으로 조언해줄 것은?
- C#에서 선언하고 아무 값도 안 넣어도 초기화해 주나?

## 막혔던 지점
- 로직은 `"Kim"`의 위치 `x`를 찾아 `김서방은 x에 있다`로 만드는 한 단계다. 막힌 곳은 채점 컴파일러와 반환 문자열이다.
- LocalTest 반환이 `김서방은 1에 있다.`였다. 예제는 `김서방은 1에 있다`라서 끝의 `.` 하나 때문에 불일치한다. `["Jane", "Kim"]`의 인덱스는 `1`이 맞다.
- `seoul.IndexOf("Kim")`은 LocalTest(.NET 10)에서는 `1`을 반환한다. 프로그래머스 채점(C# 7 근처)에서는 `CS1501`이다. 배열의 `IndexOf` 호출이 그 컴파일러에 없다.
- `Array.IndexOf(seoul, "Kim")`도 채점 기본 코드에서는 에러다. 기본 틀에 `using System;`이 없어 `Array` 이름을 못 찾는다. LocalTest는 `using System`이 자동이라 같은 코드가 빌드된다. 맨 위에 `using System;`을 넣거나 `System.Array.IndexOf`로 쓰면 된다.
- `solution` 안의 `index`, `answer`는 지역 변수라 선언만으로 값이 들어가지 않는다. 읽기 전에 안 넣으면 `CS0165`다. `int index = 0`은 언어가 채운 값이 아니라 직접 넣고 다음 줄에서 덮어쓴 것이다. `string answer = ""`의 `""`도 직접 넣은 값이다. 문자열 기본값은 `null`이다.
- 클래스 필드는 선언만 해도 숫자는 `0`, `bool`은 `false`, 문자열은 `null`이다. 이번 변수는 필드가 아니다.

## 문제 한 줄
`seoul`에서 `"Kim"`의 인덱스 `x`를 찾아 `김서방은 x에 있다`를 반환한다.

## 핵심 패턴
```text
using System
index = Array.IndexOf(seoul, "Kim")
return $"김서방은 {index}에 있다"
```
- `["Jane", "Kim"]` → 인덱스 `1` → `김서방은 1에 있다`
- 마침표, 띄어쓰기는 예제와 같아야 한다. `"Kim"`은 한 번만 있고 철자도 고정이다.

## 대안별 구현 비교

인덱스는 같다. `"Kim"`이 한 번만 있으므로 `Array.IndexOf`와 `break` 있는 `for`는 같은 칸을 반환한다. 차이는 채점에서 컴파일되는지와 반환 문자열이다. 길이 1000 이하라 둘 다 한 번 훑는 수준이다.

### A. `Array.IndexOf`
채점 코드 맨 위에 `using System;`이 필요하다. LocalTest에서는 그 줄 없이도 빌드된다.

```csharp
using System;

public class Solution {
    public string solution(string[] seoul) {
        int index = Array.IndexOf(seoul, "Kim");
        return $"김서방은 {index}에 있다";
    }
}
```

### B. `using` 없이 `System.Array`
이름 에러를 접두사로 피한 것이다. 반환 문자열은 A와 같다.

```csharp
public class Solution {
    public string solution(string[] seoul) {
        int index = System.Array.IndexOf(seoul, "Kim");
        return $"김서방은 {index}에 있다";
    }
}
```

### C. `for`로 위치 찾기
메서드 없이 같은 인덱스. `"Kim"`을 만나면 `break`한다.

```csharp
public class Solution {
    public string solution(string[] seoul) {
        int index = 0;
        for (int i = 0; i < seoul.Length; i++)
        {
            if (seoul[i] == "Kim")
            {
                index = i;
                break;
            }
        }
        return $"김서방은 {index}에 있다";
    }
}
```

끝에 `.`를 붙이면 A, B, C 모두 인덱스는 맞아도 채점 문자열이 다르다. `seoul.IndexOf`는 LocalTest에서만 컴파일된다.

## 다음에 볼 것
- 채점 기본 코드에 `using System;`이 없으면 `Array`, `Math`는 이름 에러다. LocalTest 빌드 성공이 채점 성공은 아니다.
- 제출 전에 예제를 출력해 반환 문자열을 예제와 글자까지 비교한다.
- 지역 변수는 선언만으로 `0`이나 `""`가 들어가지 않는다. 넣을 값을 정하는 줄에서 바로 넣는다.
