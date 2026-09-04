# 노란불 신호등 (468371)

## 내가 한 질문
- 초당 상태를 보고 전부 모두 `'Y'`인 시각을 찾고, 탐색 상한은 주기(`G+Y+R`)의 LCM으로 두면 방향이 맞는가?
- `IsYellow`와 `period`/LCM을 어떻게 조합해야 하는가? (`period`를 어디서 쓰는지 헷갈림)
- GCD/LCM을 다시 정리할 필요가 있는가?
- 추가로 주의할 점은?

## 막혔던 지점 및 개념 정리
- **문제 핵심**: 모든 신호등이 **동시에 노란불**인 **가장 빠른 시각(초)** 구하기. 없으면 `-1`.
- **접근 방향 (맞음)**: 초 단위 시뮬레이션 + 탐색 상한 = 각 신호 주기의 **LCM**.
  - LCM 이후에는 모든 신호 상태 조합이 반복되므로, LCM까지 없으면 영원히 없음.
- **시간·상태 판별**:
  - 시간은 **1초부터**, 시작은 초록.
  - 신호 `i`의 주기 `P = G+Y+R`, `pos = (t - 1) % P`
  - `0 ~ G-1` 초록, `G ~ G+Y-1` 노란, `G+Y ~ P-1` 빨강
  - 노란: `pos >= G && pos < G + Y`
- **`period` 조합 방법**:
  1. 각 신호의 `period[]`를 **먼저** 구한다.
  2. `period[]`로 **LCM(maxTime)** 계산.
  3. `t = 1 ~ maxTime`에서 같은 `period[i]`로 노란 여부 판별.
  - `IsYellow` 안에 period를 새로 만들기보다, **배열로 만들어 양쪽에서 재사용**.
- **GCD / LCM**:
  - GCD: 유클리드 호제법 (`a % b` 반복, 나머지 0이면 GCD)
  - LCM: `a / Gcd(a, b) * b` (곱을 먼저 하면 오버플로우 위험)
  - 3개 이상: 누적 LCM
- **추가 주의**:
  - `(t - 1) % period` (1초 시작)
  - 노란 구간 경계 (`<` / `>=`)
  - `signals`가 `int[,]`면 `signals[i, 0]` 접근
  - 문자 `'G'/'Y'/'R'` 매핑은 필수가 아님 (노란 여부 boolean이면 충분)

## 핵심 코드

### 최종 제출 ⭐
```csharp
using System;

public class Solution {
    public int solution(int[,] signals) {
        int n = signals.GetLength(0);

        // 1) 각 신호 주기
        int[] period = new int[n];
        for (int i = 0; i < n; i++) {
            period[i] = signals[i, 0] + signals[i, 1] + signals[i, 2];
        }

        // 2) 탐색 상한 = LCM
        int maxTime = period[0];
        for (int i = 1; i < n; i++) {
            maxTime = Lcm(maxTime, period[i]);
        }

        // 3) t초마다 전부 노란인지 확인
        for (int t = 1; t <= maxTime; t++) {
            bool isAllYellow = true;

            for (int i = 0; i < n; i++) {
                int pos = (t - 1) % period[i];
                int g = signals[i, 0];
                int y = signals[i, 1];

                if (pos < g || pos >= g + y) {
                    isAllYellow = false;
                    break;
                }
            }

            if (isAllYellow) {
                return t;
            }
        }

        return -1;
    }

    int Gcd(int a, int b) {
        while (b != 0) {
            int temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }

    int Lcm(int a, int b) {
        return a / Gcd(a, b) * b;
    }
}
```

## 풀이 흐름
| 단계 | 내용 |
|---|---|
| 1 | `period[i] = G+Y+R` |
| 2 | `maxTime = LCM(period[])` |
| 3 | `t = 1 ~ maxTime` 시뮬 |
| 4 | 모두 노란이면 `t`, 없으면 `-1` |

## GCD / LCM 요약
| | 의미 | 코드 핵심 |
|---|---|---|
| **GCD** | 최대공약수 | 유클리드: `b = a % b` 반복 |
| **LCM** | 최소공배수 | `a / Gcd(a,b) * b` |
| **역할** | 모든 주기 상태가 한 바퀴 도는 최소 시간 | 탐색 상한 |

## 다음에 볼 것
- 주기·동시 상태 문제는 **시뮬 + LCM** 패턴을 우선 떠올리기
- GCD/LCM 두 함수는 코테 템플릿으로 외워 두기
- `n ≤ 5`, `P ≤ 20`처럼 작을 때는 복잡한 수론(중국인의 나머지 정리 등)보다 시뮬이 안전
