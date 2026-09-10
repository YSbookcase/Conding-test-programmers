# 선인장 숨기기 (468379, Lv.2)

## 내가 한 질문 (논의 순서에 가깝게)
- 문제 분석만 먼저 하자. 입출력 예로 규칙 검증.
- drop 기준 / 빈 공간에 선인장 → 1번 조건(안 맞음)에 가까운가? drop **근방만** 보면 `(0,0)` 쪽 빈 구역을 놓칠 수 있지 않나?
- 전체 빈칸에서 위·왼쪽부터 `h×w` 대입. 반복이 너무 많지 않나? 감당 가능?
- 그룹1→2에서 “창 안 drop 있는지” 확인만으로도 연산이 급증하나?
- **창 합**이 뭐지? 합도 결국 순회해야 하는 거 아닌가?
- 1차원 누적합은 알겠는데 **2차원**은? 값 4개로 drop 여부를 아나?
- 안 맞는 칸이 있으면 그 경우는 클리어. 없으면 **늦게 맞기**를 봐야 함.
- (확인) 빈 위치는 논의했는데 늦게 맞기는 안 했지?
- 나이브로 로직 확정하는 이유는? 안 맞는 것부터 작성하나?
- 맞는다는 걸 기존(창 합) 로직에서 얻어올 수 있나? 새로 계산해야 하나?
- 여러 drop이 들어가도 되는데, **가장 늦게 맞는다**는 감이 안 잡힘. 하나만 맞으면 늦은 drop 위치만 보면 되지 않나?
- 모든 범위에서 drop 체크 후 min이 최대인 곳 → 반복이 엄청나지 않나?
- drop을 시간순으로 1번→2번…만 체크하는 건가?
- 1번 drop이 맞는 위치 **범위를 지운다**는 느낌인가?
- 그 영역에 drop 위치에 따라 **숫자를 넣는** 건가? / “채운다”보다 “1의 범위에 속함, 2의 범위에 속함”이 맞나?
- 예로 확인하자. `(1,1)`이 첫 drop이고 `3×4`면 범위가 `(-2,-3)~(4,5)`처럼 되나?
- `r,c`가 `h×w`의 **왼쪽 상단**인가? `r=[a,b]`는 **r이 위치할 범위**인가?
- 범위 구하는 **내부 규칙**과, 그것으로 앞선 위치를 어떻게 제외하나?
- 1번 범위∩2번 범위, 2번 단독…을 끝까지 추적해서 최대 단독을 고르나? (헷갈림)
- 1번이 `(3,4)`, 5번이 `(1,2)`면 **5번으로 대체**되나?
- 최종은 반복으로 어떤 범위/번째가 나오고, 그중 최소 `r,c`인가?
- 이 알고리즘으로 코드 작성하면 되나? 그룹2에 문제 되나?
- 변수가 당황스러움. 시그니처 기준으로 변수부터.
- 지금 로직에서 **안 맞는 곳**은 안 들어가나? drop 먼저 vs 안 맞음 먼저?
- B(drop 먼저)에서도 안 맞는 위치·그중 최소 `(r,c)`가 체크되나?
- 누적합을 앞에 둘까, drop 돌고 `0`으로 알까? 뭐가 손쉬운가?
- B로 가면 안 맞는 위치를 **어떻게** 아나?
- 코드 어디에 최종 선택을 넣나? 오타 확인.
- 예제 통과 → 전체 제출 → 후반 TLE. 역시 그룹2.
- 만들어 두고 참조? 슬라이딩이 왜 빠르지? 시간 복잡도?
- 세로 결과 행 수가 `m-h+1`인가? 격자의 min을 모아 둔 2차원 배열 개념?
- 그 배열에서 최댓값의 `(r,c)`면 되나?
- 원본을 drop으로 `time` 격자 만들어야 하나? 기존과 다른 접근 같은데 코드 작성해 줘.
- `LinkedList`는 떨어져 있어 느릴 수 있는데 편의인가?
- 앞 제거는 알겠는데 **뒤 제거**는? 넣고 나서 비교하는 거 아닌가?
- 과거 최소가 빠지는 순서는 어떻게 아나? 새 최소가 왔는데 곧 front 제거 예정이었던 과거 최소는?
- 덱 크기가 틀(창)보다 작을 때가 있나?
- 뒷제거는 Last와 새 후보만 비교해 제거? 새 인덱스는 항상 추가? 제거 없이 추가만 할 때도?
- RemoveLast 후 새 Last로 while 반복? LinkedList 기능 활용?
- 방대한데 코테 시간은? 혼자 가능? 메모 정리하자. 시행착오·반복 질문도 전부 남겨 줘.

---

## 시행착오 / 논의 흐름 (길어도 남김)

### A. 문제 읽기·예제
- 격자 `m×n`, 구역 `h×w`(회전 불가), `drops` 시간순.
- 우선순위: **안 맞음 > 첫 피격 최대한 늦음 > 위 > 왼쪽**.
- 예1 `[2,2]` 첫 피격 6, 예2 안 맞음 `[1,1]`, 예3 전부 동점이면 `[0,0]` 등.

### B. 1번 조건(안 맞음) — 빈 `h×w`
- **맞았던 방향**: 비 온 칸=장애물, 빈칸만으로 `h×w`.
- **위험했던 생각**: “drop **근방** 빈칸만” → 먼 곳 `(0,0)` 쪽 빈 구역 누락 가능. **전체 빈칸**을 봐야 함.
- 위→왼 순회가 우선순위와 맞음. 후보 수 ≤ `mn` ≤ 50만은 OK.
- 병목은 매번 `h×w`/`drops` 전체 스캔 → 그룹2에서 `C×(h×w)` 급증 가능.
- **창 합**: 구역 안 (비=1)의 합 = 비 온 칸 수. 합 0이면 안 맞음.
- 합도 순회 필요하지만, **매번**이 아니라 **누적합 1번 + 질의 O(1)**.
- 2D 창 합: `S[r2][c2]-S[r-1][c2]-S[r2][c-1]+S[r-1][c-1]` (경계 0 처리).

### C. 2번 조건(늦게 맞기) — 늦게 논의 시작
- 창 합(0/1)에는 **시각 정보 없음** → 재사용은 “1번 실패 여부·후보 범위” 정도, **첫 피격은 새 계산**.
- 점수 = 구역에 들어오는 drop 시각의 **min**. 목표 = 그 min의 **max**.
- “늦게 많이”가 아니라 **이른 비를 피하기**. 하나만 맞으면 그 시각=점수(특수 케이스).
- 나이브: 모든 `(r,c)`×drops → 그룹2에서 폭발. 그래서 **drop 시간순 갱신**으로 같은 답·적은 반복.

### D. drop 시간순 + 점수판 (나이브 구현으로 확정한 로직)
- drop 1→2→3… 순서 맞음.
- drop `(x,y)` 영향 받는 왼쪽 위:
  ```text
  r ∈ [max(0, x-h+1), min(x, m-h)]
  c ∈ [max(0, y-w+1), min(y, n-w)]
  ```
  (초기에 `(-2,-3)~(4,5)`처럼 잡으면 틀림 → **클램프** 필수.)
- `r,c` = 구역 **왼쪽 위**. `r∈[a,b]` = 그 행 좌표가 가질 수 있는 구간.
- “범위 지움/숫자 채움” 비유 → 더 정확히는 **“이 (r,c)는 i번 drop의 첫 피격 구간에 속함”**.
- 제외 = 범위 공식이 자동 삭제가 아니라, **이미 번호 있으면 skip** (`영향범위 ∩ 아직미정`).
- 교집합·2번 단독을 복잡 추적할 필요 **없음**. `if (firstHit==0) firstHit=i`면 충분.
- **대체 없음**: 1번에 속한 칸이 5번 범위에 다시 들어와도 **1 유지**.
- 예1 점수판 예:
  ```text
        c0  c1  c2  c3
  r0     1   5   3   3
  r1     5   5   3   3
  r2     2   2   6   4
  → max=6 at (2,2)
  ```

### E. 구현 순서 A vs B (헷갈렸던 부분)
- **답 우선순위**는 항상 안 맞음이 1순위.
- **A**: 누적합으로 안 맞음 먼저 → 있으면 return → 없으면 drop 점수. (그룹2에 유리할 수 있음)
- **B**: drop으로 `firstHit` 채움 → `0`이 안 맞음 → 없으면 max. (구현 단순, 누적합 불필요)
- B에서 안 맞음은 drop 루프에 “안 들어간다”기보다 **`0`으로 남음**. 최종에서 `0`을 위·왼 순으로 찾아야 완성.
- 처음에 B 뼈대만 두고 최종 선택을 안 넣으면 안 맞음이 답으로 안 나옴 → **return 앞에 선택 코드 위치**.

### F. 코드 시행착오
- 변수: `rowCount=m-h+1`, `colCount=n-w+1`, `firstHit`, `rStart/rEnd/...`
- 오타: `dropcount`→`dropCount`, `rowcount`→`rowCount`, `besttR`→`bestR`, `bestCd`→`bestC`
- 예제·상당수 테스트 통과 → 후반 **TLE** (14~17, 19~20, 27~32 등). 로직 OK, **복잡도 문제**.

### G. 최적화: 같은 정의, 다른 계산
- `timeGrid`에 시각/`INF` → 창 min = 첫 피격 → min들의 max (+INF 우선은 INF가 더 커서 자동).
- 2D 창 min = 세로 `h` 슬라이딩 min 후 가로 `w`.
- 세로 후 크기 `(m-h+1)×n` (행만 감소). 가로 후 `(m-h+1)×(n-w+1)`.
- “만들어 두고 참조” → `windowMin[r,c]` 조회.
- 복잡도: `O(D·h·w)` → **`O(m·n)`**.

### H. 슬라이딩 min + LinkedList (반복해서 확인한 내용)
- 덱에 값 말고 **인덱스**. front=창 최솟값.
- **앞 제거**: 창 밖 (`First <= index-len`). “틀에서 빠짐”.
- **뒤 제거**: Last와 새 값 비교, `arr[Last]>=arr[새]`면 RemoveLast, **새 Last로 while 반복**. “새 후보에 밀림”.
- 새 인덱스는 **항상** AddLast. 새 값이 더 크면 제거 0번일 수 있음.
- 넣고 나서가 아니라 **넣기 전(과정)에 뒤 정리**가 일반적.
- 과거 최소가 “곧 front 제거 예정”이어도, 새 더 작은 값에 먼저 덱에서 지워져도 OK (이미 후보 자격 상실).
- 덱 크기 **≤ 창 길이**, 종종 **더 작음**.
- LinkedList는 양끝 편의(덱 대용). 캐시 지역성은 배열 원형 덱이 더 좋지만 코테에선 대개 충분.

### I. 코테 현실
- 방대함 정상. Lv.2에 정의+최적화가 묶인 편.
- 시험은 보통 수 시간·여러 문제. 이 한 문제 처음이면 시간 많이 씀.
- 현실적 목표: 맞는 나이브 → TLE 보면 패턴 최적화. 슬라이딩 min은 **학습 패턴**으로 축적.

---

## 문제 정의 (요약)
- 가능 왼쪽 위: `r=0..m-h`, `c=0..n-w`.
- 점수 = 구역 안 drop 시각의 min (없으면 INF/안 맞음).
- 안 맞음 > 점수 max > 위 > 왼쪽. 반환 `[r,c]`.

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

### 참고: 그룹1용 나이브 골격 (TLE 전 통과 로직)
```csharp
// firstHit 0으로 시작
// 각 drop: 영향 [rStart..rEnd]×[cStart..cEnd]에 firstHit==0만 hitTime 기록
// 그다음 firstHit==0 조기 return / 없으면 max firstHit의 (r,c)
```

## 복잡도
| 방식 | 시간 | 결과 |
|---|---|---|
| drop 범위 칠하기 | `O(D·h·w)` | 예제·부분 OK, 그룹2 TLE |
| time + 2D 슬라이딩 min | `O(m·n)` | 최종 통과 |

## 다음에 볼 것
- **창 최솟값 + 덱** 패턴을 짧은 문제로 한 번 더 연습
- 코테: 맞는 나이브 → 병목 → 패턴 최적화
- 긴 메모는 “시행착오 흐름”을 다시 읽는 용도, 복습 시 복잡도 표·최종 코드부터
