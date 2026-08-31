# 주사위 게임 1 (181839)

## 내가 한 질문
- 절댓값 계산에 `Math` 함수가 있는가? `using`을 추가해야 하는가?
- `Math.Abs()`를 쓰는 것이 더 직관적인가, 아니면 `if`로 직접 절댓값을 구하는 현재 풀이도 괜찮은가?

## 막혔던 지점 및 개념 정리
- **초기 실수: `a - a` 오타**:
  - 둘 다 짝수일 때 `return a - a;`로 작성하면 항상 `0`이 반환됨.
  - 의도한 식은 `return a - b;` 또는 `return Math.Abs(a - b);`.
- **`Math` 클래스 사용법**:
  - `Math`는 `System` 네임스페이스에 포함되어 있으므로 `using System;`만 있으면 추가 `using` 불필요.
  - 절댓값: `Math.Abs(a - b)`
- **절댓값 구현 방식 비교**:
  - **수동 `if` 방식**: `if (a - b < 0) return b - a; return a - b;` — 동작은 맞지만 구현 방식을 직접 표현.
  - **`Math.Abs()` 방식**: `return Math.Abs(a - b);` — "절댓값"이라는 의도가 한눈에 드러나고 오타 위험이 적음.
  - 성능 차이는 이 문제 수준에서는 사실상 없음. 가독성과 실수 방지 기준으로 선택.
- **전체 분기 구조 평가**:
  - `if / else if / else`로 문제 조건 3가지를 그대로 옮긴 정석적인 풀이.
  - 홀수 판별: `n % 2 != 0` (홀수), `n % 2 == 0` (짝수).

## 핵심 코드

### 1. `if / else if / else` + 수동 절댓값 (최종 제출 ⭐)
```csharp
using System;

public class Solution {
    public int solution(int a, int b) {
        if (a % 2 != 0 && b % 2 != 0) {
            return a * a + b * b;
        }
        else if (a % 2 == 0 && b % 2 == 0) {
            if (a - b < 0) {
                return b - a;
            }
            return a - b;
        }
        else {
            return 2 * (a + b);
        }
    }
}
```

### 2. `Math.Abs()` 활용 (더 직관적인 절댓값 처리)
```csharp
using System;

public class Solution {
    public int solution(int a, int b) {
        if (a % 2 != 0 && b % 2 != 0) {
            return a * a + b * b;
        }
        else if (a % 2 == 0 && b % 2 == 0) {
            return Math.Abs(a - b);
        }
        else {
            return 2 * (a + b);
        }
    }
}
```

## `Math` 클래스 자주 쓰는 메서드 (`using System;`만 필요)
| 메서드 | 설명 | 예시 |
|---|---|---|
| **`Math.Abs(x)`** | 절댓값 | `Math.Abs(-5)` → `5` |
| **`Math.Max(a, b)`** | 더 큰 값 | `Math.Max(3, 7)` → `7` |
| **`Math.Min(a, b)`** | 더 작은 값 | `Math.Min(3, 7)` → `3` |
| **`Math.Pow(a, b)`** | 거듭제곱 | `Math.Pow(2, 3)` → `8` |
| **`Math.Sqrt(x)`** | 제곱근 | `Math.Sqrt(9)` → `3` |
| **`Math.Floor(x)`** | 내림 | `Math.Floor(3.9)` → `3` |
| **`Math.Ceiling(x)`** | 올림 | `Math.Ceiling(3.1)` → `4` |

## 다음에 볼 것
- 절댓값이 필요하면 `if` 분기 대신 **`Math.Abs()`** 우선 고려
- 조건 분기가 여러 개인 문제는 **`if / else if / else`**로 문제 문장을 그대로 옮기는 방식이 직관적
