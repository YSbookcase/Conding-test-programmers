# 선인장 숨기기 (468379, Lv.2)

## 내가 한 질문
- drop 기준으로 빈 공간에 선인장을 두면 1번 조건(안 맞음)에 가까운가? drop 근방만 보면?
- 전체 빈칸에서 `(0,0)`에 가까운 쪽부터 `h×w`를 대입하면 감당 가능한가?
- 창 합이란? 합도 결국 순회 아닌가? 2차원 누적합은?
- 안 맞는 배치가 없을 때(최대한 늦게 맞기)는? 기존 로직 재사용 vs 새 계산?
- “여러 drop이 들어가도 첫 피격만”, “하나만 맞으면 늦은 drop” 직관?
- drop 시간순으로 1→2→3… 체크? 범위를 지우는 느낌? 영역에 숫자를 넣나?
- `r,c`는 `h×w`의 왼쪽 위인가? `r=[a,b]`는 범위인가?
- 범위 공식과 “앞선 위치 제외”는 어떻게 연결되나?
- 교집합/단독 구간을 복잡하게 추적하나? 1번 점수가 5번으로 대체되나?
- 최종은 반복으로 최대 번째 + 최소 `(r,c)`?
- 그룹2 TLE 원인? 슬라이딩 윈도우로 바꾸면?
- 세로 먼저 하는 이유, `(m-h+1)×(n-w+1)` 결과 배열, 최댓값의 `(r,c)`?
- `LinkedList` deque: 앞/뒤 제거, 과거 최소 빠지는 순서, 덱 크기 < 창 크기?
- 이런 문제를 코테에서 혼자 시간 내에 풀 수 있나? 메모가 많지 않나?

## 막혔던 지점 및 개념 정리

### 문제 정의
- `h×w` 구역의 왼쪽 위 `(r,c)`를 고른다.
- 점수 = 구역에 들어오는 **가장 빠른 drop 순서** (없으면 안 맞음 = 최우선).
- 목표: 안 맞음 우선 → 아니면 점수 최대 → 동점이면 위·왼쪽.
- 반환: `[r, c]`.

### 1단계 학습: 나이브 (예제·그룹1 OK, 그룹2 TLE)
1. `firstHit[r,c]` 초기 0.
2. drop을 시간순으로 처리. drop `(x,y)`의 영향 범위:
   ```text
   r ∈ [max(0, x-h+1), min(x, m-h)]
   c ∈ [max(0, y-w+1), min(y, n-w)]
   ```
3. 범위 안 `firstHit==0`인 칸에만 `hitTime` 기록 (덮어쓰기 없음).
4. `0`이 있으면 그중 최소 `(r,c)`, 없으면 `firstHit` 최대 + 위·왼쪽.

- 복잡도: `O(D × h × w)` → 후반 **시간 초과**.
- 로직은 맞음 (예제·상당수 테스트 통과).

### 2단계: 같은 답을 O(mn)에 — 창 최솟값
- 격자 `time[x,y] = drop시각` 또는 `INF`.
- `windowMin[r,c] = time`의 `h×w` 창 최솟값 = 그 배치의 첫 피격.
- `INF = dropCount+1`이면 안 맞음이 자동으로 가장 큰 점수.
- 모든 창 min을 구한 뒤 **최댓값의 `(r,c)`** (`>`만 써서 위·왼쪽 유지).

### 2D 창 min = 1D 슬라이딩 min 두 번
1. 열마다 세로 길이 `h` → `colMin` 크기 `(m-h+1)×n`
2. 행마다 가로 길이 `w` → `windowMin` 크기 `(m-h+1)×(n-w+1)`
3. 전체 `O(m×n)` (`N=mn≤50만`)

### 슬라이딩 윈도우 min + LinkedList(덱)
- 덱에 **인덱스** 저장. front = 현재 창 최솟값.
- **앞 제거**: 창 밖 인덱스 (`<= index-len`).
- **뒤 제거**: 새 값보다 `>=`인 옛 후보 (밀림). while로 Last가 바뀌며 반복.
- 새 인덱스는 **항상** AddLast. 제거 0번일 수도 있음.
- 덱 크기 ≤ 창 길이, 보통 **더 작음** (후보만 보관).
- `LinkedList`는 양끝 연산 편의(덱 대용). 지역성은 배열 원형 덱이 더 좋지만 코테에선 보통 충분.

### 코테에서 이 문제의 위치
- Lv.2 / 카카오 스타일: **구현 + 최적화**가 한 문제에 묶인 편.
- 전형적 시험: 수 시간·여러 문제. 이 한 문제에 **1~2시간+** 쓰는 경우도 있음.
- 처음 보면 “정의 구현(나이브)”까지가 현실적 목표, 슬라이딩 min은 **패턴 학습** 후 재등장 시 적용.
- 지금 혼자 처음부터 완벽 풀이가 버거운 것은 정상. 과정을 메모로 남긴 것 자체가 다음을 위한 자산.

## 핵심 코드 (최종 제출 ⭐)

```csharp
using System;
using System.Collections.Generic;

public class Solution {
    public int[] solution(int m, int n, int h, int w, int[,] drops) {
        int dropCount = drops.GetLength(0);
        int inf = dropCount + 1;

        int[,] timeGrid = new int[m, n];
        for (int row = 0; row < m; row++) {
            for (int col = 0; col < n; col++) {
                timeGrid[row, col] = inf;
            }
        }
        for (int i = 0; i < dropCount; i++) {
            timeGrid[drops[i, 0], drops[i, 1]] = i + 1;
        }

        int rowCount = m - h + 1;
        int colCount = n - w + 1;

        int[,] colMin = new int[rowCount, n];
        for (int col = 0; col < n; col++) {
            int[] columnValues = new int[m];
            for (int row = 0; row < m; row++) {
                columnValues[row] = timeGrid[row, col];
            }
            int[] verticalMin = SlidingWindowMin(columnValues, h);
            for (int row = 0; row < rowCount; row++) {
                colMin[row, col] = verticalMin[row];
            }
        }

        int[,] windowMin = new int[rowCount, colCount];
        for (int row = 0; row < rowCount; row++) {
            int[] rowValues = new int[n];
            for (int col = 0; col < n; col++) {
                rowValues[col] = colMin[row, col];
            }
            int[] horizontalMin = SlidingWindowMin(rowValues, w);
            for (int col = 0; col < colCount; col++) {
                windowMin[row, col] = horizontalMin[col];
            }
        }

        int bestR = 0, bestC = 0, bestHit = -1;
        for (int r = 0; r < rowCount; r++) {
            for (int c = 0; c < colCount; c++) {
                if (windowMin[r, c] > bestHit) {
                    bestHit = windowMin[r, c];
                    bestR = r;
                    bestC = c;
                }
            }
        }
        return new int[] { bestR, bestC };
    }

    int[] SlidingWindowMin(int[] arr, int len) {
        int n = arr.Length;
        int[] result = new int[n - len + 1];
        LinkedList<int> indexDeque = new LinkedList<int>();

        for (int index = 0; index < n; index++) {
            while (indexDeque.Count > 0 && indexDeque.First.Value <= index - len) {
                indexDeque.RemoveFirst();
            }
            while (indexDeque.Count > 0 && arr[indexDeque.Last.Value] >= arr[index]) {
                indexDeque.RemoveLast();
            }
            indexDeque.AddLast(index);
            if (index >= len - 1) {
                result[index - len + 1] = arr[indexDeque.First.Value];
            }
        }
        return result;
    }
}
```

## 복잡도
| 방식 | 시간 |
|---|---|
| drop 범위 칠하기 | `O(D·h·w)` (그룹2 TLE) |
| time + 2D 슬라이딩 min (최종) | `O(m·n)` |

## 다음에 볼 것
- 창 최솟값/최댓값 → **슬라이딩 윈도우 + 덱** 패턴 복습
- 코테에서는 **맞는 나이브 → 복잡도 병목 → 패턴 최적화** 순이 현실적
- `LinkedList` 덱은 편의용, 여유 있으면 배열 원형 덱도 연습
