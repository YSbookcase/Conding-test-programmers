# 이차원 배열 대각선 순회하기 (181829)

## 내가 한 질문
- `i + j <= k`인 칸만 더하는 단순 이중 for로 풀었는데, 개선이 필요한가?

## 막혔던 지점 및 개념 정리
- **문제 핵심**: `board[i, j]` 중 **행+열 인덱스 합이 k 이하**인 칸들의 합.
  - 이름에 “대각선”이 들어가지만, 실제로는 `i + j <= k`인 **왼쪽 위 삼각형(대각선 기준 한쪽)** 영역의 합.
- **단순 이중 for 평가**:
  - `board` 최대 100×100 → 약 1만 번 연산으로 충분.
  - 문제 조건을 그대로 코드로 옮긴 **정석 풀이**.
  - 이 제한에서는 **추가 최적화 불필요**.
- **선택적 개선** (알아두면 좋음):
  - `i`가 고정이면 `j`는 `0 ~ min(열-1, k-i)`만 보면 됨.
  - `i > k`인 이후 행은 볼 필요 없음.
  - `n ≤ 100`이라 체감 이득은 거의 없음.
- **누적합까지?** 질의 1회 + 크기 작음 → 불필요.

## 핵심 코드

### 1. 단순 이중 for (최종 제출 ⭐)
```csharp
public class Solution {
    public int solution(int[,] board, int k) {
        int result = 0;

        for (int i = 0; i < board.GetLength(0); i++) {
            for (int j = 0; j < board.GetLength(1); j++) {
                if (i + j <= k) {
                    result += board[i, j];
                }
            }
        }

        return result;
    }
}
```

### 2. 범위 줄인 버전 (선택)
```csharp
int rows = board.GetLength(0);
int cols = board.GetLength(1);

for (int i = 0; i < rows; i++) {
    if (i > k) break;

    int maxJ = Math.Min(cols - 1, k - i);
    for (int j = 0; j <= maxJ; j++) {
        result += board[i, j];
    }
}
```

## 방식 비교
| 방식 | 특징 | 이 문제 |
|---|---|---|
| **이중 for + if (최종 제출 ⭐)** | 가장 읽기 쉬움 | 충분 |
| `j` 상한 축소 | 불필요한 칸 스킵 | 선택 |
| 2차원 누적합 | 다중 질의에 유리 | 과함 |

## 다음에 볼 것
- 조건이 단순한 합/카운트이고 크기가 작으면 **가독성 우선** 이중 for가 최선인 경우가 많음
- `int[,]` 접근은 `board[i, j]` (쉼표)
- “대각선” 관련 문제는 인덱스 합 `i+j` 또는 `i-j` 조건을 먼저 확인
