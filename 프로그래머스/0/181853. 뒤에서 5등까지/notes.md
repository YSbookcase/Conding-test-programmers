# 뒤에서 5등까지 (181853)

## 내가 한 질문
- `num_list.Sort()`나 `result.Copy()`처럼 배열 변수 뒤에 직접 메서드를 호출할 수 없는 이유는?
- `Array.Copy`는 내부적으로 큰 오버헤드가 발생하는가?
- LINQ 체이닝(`OrderBy`, `Take`) 작성 시 호출 순서가 바뀌면 결과에 어떤 영향이 있는가?
- 배열 변수에 점(`.`)을 찍어 사용하는 함수들과 `Array.` 정적 메서드의 구분 기준은?
- `using System.Array;` 형태로 선언해서 쓸 수 없는 이유는?

## 막혔던 지점 및 문법 정리
- **`Array` 클래스의 정적 메서드 호출 규칙**:
  - `num_list.Sort()` ❌ ➔ **`Array.Sort(num_list)`** ⭕
  - `result.Copy(num_list, 0, 5)` ❌ ➔ **`Array.Copy(num_list, result, 5)`** ⭕
- **네임스페이스와 클래스 구분**:
  - `System`은 네임스페이스(폴더)이므로 `using System;` 가능.
  - `Array`는 `System` 내의 클래스이므로 `using System.Array;` 선언 불가.

## 핵심 패턴 및 성능/동작 원리

### 1. `Array.Copy`의 고성능 원리
- 단순 반복문 복사와 달리 C/C++ 레벨의 `memcpy` / `memmove` 네이티브 메모리 블록 복사 명령을 직접 실행.
- 객체 생성 및 불필요한 오버헤드가 거의 0에 수렴하여 대량 데이터 복사 시 가장 빠름.

### 2. LINQ 메서드 체이닝 순서의 중요성 (파이프라인)
- **올바른 순서 (`OrderBy` ➔ `Take`)**: 전체 정렬 후 상위 5개 추출 ➔ **정답 (`[1, 4, 12, 14, 15]`)**
- **잘못된 순서 (`Take` ➔ `OrderBy`)**: 정렬 전 앞 5개를 먼저 자르고 정렬 ➔ **오답 (가장 작은 값 `1` 누락)**
- LINQ는 왼쪽에서 오른쪽으로 순차 실행되므로 필터/정렬의 파이프라인 순서가 절대적임.

## 추가 풀이 방법들 (대안 정리)

### 1. `Array.Sort` + LINQ `Take(5)` (하이브리드)
```csharp
using System;
using System.Linq;

public int[] solution(int[] num_list) {
    Array.Sort(num_list);
    return num_list.Take(5).ToArray();
}
```

### 2. LINQ 1줄 풀이 (`OrderBy` + `Take`)
```csharp
using System;
using System.Linq;

public int[] solution(int[] num_list) {
    return num_list.OrderBy(x => x).Take(5).ToArray();
}
```

## 메서드 호출 형태별 분류 요약
| 구분 | 호출 형태 | 예시 메서드 | 네임스페이스 요구 |
|---|---|---|---|
| **배열 조작/정렬/복사 (In-Place)** | `Array.메서드(arr)` | `Array.Sort()`, `Array.Copy()`, `Array.Fill()` | `using System;` |
| **LINQ 확장 메서드 (조회/변환)** | `arr.메서드()` | `arr.Take()`, `arr.OrderBy()`, `arr.Sum()` | `using System.Linq;` |
| **`List<T>` 인스턴스 메서드** | `list.메서드()` | `list.Sort()`, `list.Add()`, `list.RemoveAt()` | `using System.Collections.Generic;` |

## 다음에 볼 것
- 원본 배열을 변형하는 정렬/복사는 `Array.Sort`, `Array.Copy` 정적 메서드 기억
- LINQ 체이닝 사용 시 데이터 가공 흐름(정렬 ➔ 추출)의 순서 검증 필수
