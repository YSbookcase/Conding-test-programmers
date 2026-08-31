# 꼬리 문자열 (181841)

## 내가 한 질문
- 문자열을 합칠 때 `+=` 연산은 불변 객체 특성상 메모리 낭비와 잦은 객체 생성이 발생하는데, `StringBuilder`에서 합치는 메서드는 무엇인가?
- 작성한 코드에서 발생한 컴파일 에러의 원인은 무엇인가?
- 성능 최적화 및 코드 작성에 있어 추가적인 조언은 무엇이 있는가?

## 막혔던 지점 및 개념 정리
- **문자열 덧셈(`+=`) vs `StringBuilder`**:
  - `string`은 불변(Immutable) 객체이므로 루프 내에서 `+=`를 수행하면 매번 새로운 문자열이 힙에 할당되고 이전 문자열은 GC 대상이 되어 $O(N^2)$ 성능 저하 유발.
  - `StringBuilder`는 내부 가변 버퍼를 사용하여 메모리 재할당 없이 $O(N)$으로 문자열을 이어붙임.
- **컴파일 에러 원인: 3인칭 단수 `s` 누락**:
  - ❌ `str_list[i].Contain(ex)` ➔ ⭕ `str_list[i].Contains(ex)`
  - C#에서 조건을 묻는(참/거짓 반환) 메서드는 3인칭 단수 문법에 따라 끝에 `s`가 붙음 (`Contains`, `StartsWith`, `EndsWith`, `ContainsKey`).
- **성능 및 가독성 팁**:
  - 인덱스가 필요 없는 순차 탐색에서는 `for`문 대신 **`foreach`**를 사용하면 코드가 간결해지고 인덱스 범위 초과 실수를 방지함.
  - 대용량 데이터 처리 시 `new StringBuilder(예상크기)`처럼 **초기 용량(Capacity)**을 지정하면 내부 버퍼 2배 증가 재할당 비용을 제거 가능.

## 핵심 코드

### 1. `StringBuilder` 활용 (메모리 최적화 표준 풀이 - 최종 제출 ⭐)
```csharp
using System.Text;

public class Solution {
    public string solution(string[] str_list, string ex) {
        StringBuilder sb = new StringBuilder();
        
        // ex를 포함하지 않는 문자열만 순서대로 버퍼에 추가
        for (int i = 0; i < str_list.Length; i++) {
            if (!str_list[i].Contains(ex)) {
                sb.Append(str_list[i]);
            }
        }
        
        return sb.ToString();
    }
}
```

### 2. LINQ `Where` + `string.Concat` 활용 (간결한 1줄 풀이)
```csharp
using System.Linq;

public class Solution {
    public string solution(string[] str_list, string ex) {
        // LINQ로 필터링한 후 Concat으로 한 번에 결합
        return string.Concat(str_list.Where(s => !s.Contains(ex)));
    }
}
```

## `StringBuilder` 주요 메서드 요약
| 메서드 | 설명 |
|---|---|
| **`sb.Append(val)` ⭐** | 뒤에 문자열/숫자/문자를 이어붙임 |
| **`sb.AppendLine(val)`** | 뒤에 값과 함께 줄바꿈(`\n`)을 이어붙임 |
| **`sb.AppendJoin(구분자, 컬렉션)`** | 컬렉션 요소 사이에 구분자를 넣어 한 번에 이어붙임 |

## 다음에 볼 것
- 반복문 내 문자열 결합 시 **`StringBuilder.Append()`** 습관화
- 조건 판별 메서드 호출 시 3인칭 단수 **`s`(`Contains`, `StartsWith`, `EndsWith`)** 주의
