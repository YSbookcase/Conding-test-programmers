# 날짜 비교하기 (181838)

## 내가 한 질문
- `[year, month, day]` 배열을 `for`문으로 순차 비교하는 접근이 맞는가?
- 초기 풀이에서 놓친 논리적 빈틈은 무엇인가?
- 더 간결하게 풀 수 있는 대안은 있는가?

## 막혔던 지점 및 개념 정리
- **초기 풀이의 논리 빈틈**:
  - `date1[i] < date2[i]`일 때만 `return 1`하고, `date1[i] > date2[i]`일 때는 `continue`로 넘어감.
  - 예: `date1 = [2022, 1, 1]`, `date2 = [2021, 12, 31]` → 실제로는 `date1`이 더 늦은 날짜인데, 연도 비교에서 `>`를 무시하고 월 비교에서 `1 < 12`로 잘못 `1` 반환.
- **수정 핵심: 더 큰 경우도 즉시 종료**:
  - `date1[i] < date2[i]` → `date1`이 앞섬 → `return 1`
  - `date1[i] > date2[i]` → `date1`이 뒤섬 → `return 0`
  - 같으면 → 다음 자리(월, 일) 비교
  - 끝까지 같으면 → `return 0` (같은 날짜는 "앞서지 않음")
- **날짜 비교의 기본 원칙**:
  - 연도 → 월 → 일 순서로 비교 (사전식 비교, Lexicographical Comparison).
  - `[year, month, day]` 배열 구조는 이 순서를 자연스럽게 지원.

## 핵심 코드

### 1. `for`문 순차 비교 (수정 완료 - 최종 제출 ⭐)
```csharp
public class Solution {
    public int solution(int[] date1, int[] date2) {
        for (int i = 0; i < date1.Length; i++) {
            if (date1[i] < date2[i]) {
                return 1;
            }
            if (date1[i] > date2[i]) {
                return 0;
            }
        }
        return 0;
    }
}
```

### 2. `YYYYMMDD` 숫자 압축 비교 (간결한 1줄 풀이)
```csharp
public class Solution {
    public int solution(int[] date1, int[] date2) {
        int num1 = date1[0] * 10000 + date1[1] * 100 + date1[2];
        int num2 = date2[0] * 10000 + date2[1] * 100 + date2[2];
        return num1 < num2 ? 1 : 0;
    }
}
```

### 3. 연/월/일 명시적 분기 비교 (가독성 우선 풀이)
```csharp
public class Solution {
    public int solution(int[] date1, int[] date2) {
        if (date1[0] != date2[0]) return date1[0] < date2[0] ? 1 : 0;
        if (date1[1] != date2[1]) return date1[1] < date2[1] ? 1 : 0;
        if (date1[2] != date2[2]) return date1[2] < date2[2] ? 1 : 0;
        return 0;
    }
}
```

## 풀이 방식 비교
| 방식 | 장점 | 단점 |
|---|---|---|
| **`for`문 순차 비교 (최종 제출 ⭐)** | 배열 길이에 유연, 의도 명확 | `>` 케이스 누락 시 버그 위험 |
| **`YYYYMMDD` 숫자 압축** | 코드가 짧고 직관적 | 월/일이 한 자릿수일 때 자릿수 보정 필요 (이 문제는 2자리 보장) |
| **연/월/일 명시적 분기** | 날짜 비교 의도가 가장 명확 | 배열 길이가 고정(3)일 때만 적합 |

## 다음에 볼 것
- 순차 비교 시 **더 작은 경우(`<`)와 더 큰 경우(`>`) 모두 즉시 반환**하는 패턴 숙지
- `[year, month, day]` 형태 날짜는 **`YYYYMMDD` 숫자 변환**으로 한 번에 비교 가능
