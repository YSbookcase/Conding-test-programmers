# 배열의 길이에 따라 다른 연산하기 (181854)

## 내가 한 질문
- 작성한 코드에서 발생한 컴파일 에러의 원인과 접근 방향의 타당성은?
- 단순해 보이는 문제이지만 추가로 깊이 있게 배워둘 만한 요소가 있는가?

## 막혔던 지점 및 문법 정리
- **`for`문 증감식 대입 연산자 누락**:
  - `i + 2`는 연산 결과만 계산하고 `i`에 반영되지 않아 컴파일 에러 발생.
  - 반드시 **`i += 2`** (또는 `i = i + 2`) 형태로 대입해야 함.

## 핵심 패턴 및 코드 발전 과정

### 1. 기본 분기 풀이 (초기 접근)
```csharp
if (arr.Length % 2 == 0)
{
    for (int i = 1; i < arr.Length; i += 2) arr[i] += n;
}
else
{
    for (int i = 0; i < arr.Length; i += 2) arr[i] += n;
}
return arr;
```

### 2. 시작점 분리를 통한 코드 중복 제거 (최종 제출 ⭐)
- 내부 로직(`arr[i] += n`, `i += 2`)이 동일하므로, 시작 인덱스(`startIndex`)만 삼항 연산자로 결정하여 `for`문 1개로 통합.
```csharp
int startIndex = (arr.Length % 2 == 0) ? 1 : 0;
for (int i = startIndex; i < arr.Length; i += 2)
{
    arr[i] += n;
}
return arr;
```

## 추가 풀이 방법들 (대안 정리)

### 1. LINQ `Select`의 인덱스 오버로딩 (함수형 스타일)
```csharp
using System;
using System.Linq;

public class Solution {
    public int[] solution(int[] arr, int n) {
        // (x, i) -> x: 원소의 값, i: 현재 원소의 인덱스
        return arr.Select((x, i) => 
            (arr.Length % 2 != i % 2) ? x + n : x
        ).ToArray();
    }
}
```
- **수학적 조건식 (`arr.Length % 2 != i % 2`)**:
  - `arr.Length`가 홀수(1) ➔ `i`가 짝수(0)일 때만 둘의 홀짝이 달라 참(True)이 되어 `x + n` 수행.
  - `arr.Length`가 짝수(0) ➔ `i`가 홀수(1)일 때만 둘의 홀짝이 달라 참(True)이 되어 `x + n` 수행.
  - 문제의 두 조건을 단 하나의 비교식으로 표현 가능.

## 대안별 종합 비교
| 방식 | 시간 복잡도 | 공간 복잡도 | 특징 |
|---|---|---|---|
| **In-Place `for`문 (최종 제출 ⭐)** | $O(N)$ | $O(1)$ | 새 배열 할당 없이 기존 배열을 직접 수정하여 메모리/속도 최상 |
| **LINQ `Select` (인덱스 활용)** | $O(N)$ | $O(N)$ | 새 배열을 생성하여 원본 불변성 유지, 함수형 1줄 표현 |

## 다음에 볼 것
- `for`문 스텝 증가 시 `i += k` 대입 연산자 실수 주의
- 동일 로직의 분기문은 달라지는 상태값(시작 인덱스 등)만 추출하여 루프 통합 고려
- `Select((val, idx) => ...)` 형태의 인덱스 기반 변환 테크닉 기억하기
