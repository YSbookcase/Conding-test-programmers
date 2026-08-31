# 정수 찾기 (181840)

## 내가 한 질문
- 문자열과 달리 정수 배열에서 `Contains(1)`를 수행할 때 `11`과 같은 숫자가 부분 일치로 포함되는가?
- `using System.Linq;`를 명시적으로 작성하지 않았는데도 컴파일 에러가 발생하지 않은 이유는 무엇인가?
- `Array.IndexOf`와 LINQ `Contains` 사이에 왜 약 5배 이상의 속도 차이가 발생하는가?

## 막혔던 지점 및 개념 정리
- **문자열 부분 일치 vs 숫자 완전 일치**:
  - `string.Contains("1")`: 문자열(문자들의 나열) 내에 `"1"`이 포함되어 있으면 부분 일치(`true`).
  - `int[].Contains(1)`: 각 원소 단위로 **완전 일치 비교(`element == 1`)**를 수행하므로 `11`이 있어도 거짓(`false`) 판정.
- **암시적 using (Implicit Usings) 기능 (.NET 6 / C# 10+)**:
  - 프로젝트 설정에 따라 `System`, `System.Linq`, `System.Collections.Generic` 등 필수 네임스페이스가 백그라운드에서 자동 포함됨.
  - 단, `System.Text`(`StringBuilder`)나 `System.Numerics`(`BigInteger`) 등은 여전히 수동 선언이 필요하며, 타 코딩테스트 플랫폼 호환성을 위해 명시적 작성을 권장.
- **`Array.IndexOf` vs LINQ `Contains` 성능 차이 원인**:
  - **`Array.IndexOf(arr, n)` (압도적 빠름 ⚡)**:
    - 런타임 네이티브 C++ 레벨에서 CPU 벡터 명령어(SIMD)로 메모리를 일괄 비교.
    - 힙 메모리 할당 제로 (GC 발생 없음).
  - **LINQ `Contains(n)` (약 5배 느림 🐢)**:
    - `IEnumerable` 열거자 객체 생성 오버헤드.
    - 매 요소마다 `EqualityComparer.Equals()` 인터페이스 간접 호출 비용 누적.

## 핵심 코드

### 1. LINQ `Contains` 활용 (간결한 표현 - 최종 제출 ⭐)
```csharp
using System.Linq;

public class Solution {
    public int solution(int[] num_list, int n) {
        // n이 포함되어 있으면 1, 없으면 0 반환
        return num_list.Contains(n) ? 1 : 0;
    }
}
```

### 2. `Array.IndexOf` 활용 (초고성능 네이티브 풀이)
```csharp
using System;

public class Solution {
    public int solution(int[] num_list, int n) {
        // 배열 내 인덱스 검색 (존재하면 0 이상, 없으면 -1)
        return Array.IndexOf(num_list, n) != -1 ? 1 : 0;
    }
}
```

## 배열 탐색 메서드 비교
| 메서드 | 반환 타입 | 특징 및 성능 | 추천 상황 |
|---|---|---|---|
| **`num_list.Contains(n)` ⭐** | `bool` | 가독성 우수, LINQ 열거자 오버헤드 존재 | 코딩테스트, 가독성 우선 코드 |
| **`Array.IndexOf(num_list, n)`** | `int` (인덱스) | C++ 네이티브 최적화, GC 제로, 5배 이상 빠름 | 대용량 데이터, 고성능 최적화 구간 |

## 다음에 볼 것
- 정수 배열의 `Contains`는 부분 매칭이 아닌 **완전 일치(`==`)** 검사임을 숙지
- 극한의 성능과 GC 최소화가 필요할 때는 LINQ 대신 **`Array.IndexOf`** 활용
