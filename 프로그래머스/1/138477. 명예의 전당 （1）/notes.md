# 명예의 전당 (1) (138477)

## 상태
- 제출 완료 (`List hall`, 앞 `k`일은 `Add`, 이후 `minScore`와 비교 후 교체, 매일 `hall.Min()` 발표)
- 로컬 실험: `LocalTest/Program.cs` (`.gitignore`)
- 공식 폴더: `프로그래머스/1/138477. 명예의 전당 (1)/`
- 3.82 ms, 47 MB (제한 1~2초 대비 여유)

## 내가 한 질문
- `List`로 가변? 고정 `k` 배열은 갱신이 어려워 보인다.
- 정렬은 필요 없고 `k`개만 관리하면 되는 것 같다.
- 최솟값만 들고 갱신하면 안 되나? 선인장처럼.
- 그 범위에서 늘 최솟값을 구하는 부담.
- 정렬 없이 `Math.Min`? `List`도 되나?
- 가득 차면 최솟값을 두 번 구하나? 새 점수와 비교해서 그대로 두거나 교체?
- LocalTest 확인 / 수정함.
- LINQ `Count()`와 `Count` 차이? `()`만 빼면 되나?
- 추가 조언?
- `if`와 `Remove`에서 `hall.Min()`을 두 번 쓰면 부담 아닌가?
- `else if`에서 `int minScore`는 어디에 선언?
- 실행 시간 3.39ms. 초 단위 데이터면 이 로직은 지양?

## 막혔던 지점
- 최솟값 **변수 하나**만 있으면, 10이 내려간 뒤 다음 최소(20)를 모름. 선인장에서 창 최소가 빠질 때 후보가 필요했던 것과 같음. **최대 `k`개**를 보관.
- `new int[] { }` → `answer[i]` 범위 초과. `new int[score.Length]`.
- `if (Count < k) Add` 다음 `if (Count == k)`가 같은 날 또 돔. 셋째 날 `20`을 넣고 바로 10을 빼고 20을 또 넣음. `if` / `else`.
- `Math.Min`은 숫자 두 개. 리스트는 `hall.Min()` (`using System.Linq`).
- `Count()`는 LINQ 메서드, `Count`는 `List` 속성. 리스트에선 `()`만 빼면 됨.
- `else if (score[i] > hall.Min())` 조건 안에서는 `minScore`를 만들 수 없음. `else { int minScore = hall.Min(); if ... }`.

## 문제 한 줄
매일 상위 최대 `k`개 점수를 들고, 그 묶음의 최솟값(발표 점수) 배열. `k`번째보다 **더 높을** 때만 최솟값과 교체 (`>`).

## 핵심 패턴 (제출)
```text
hall = List
score 매일:
  Count < k → Add
  아니면:
    minScore = hall.Min()
    score[i] > minScore → Remove(minScore), Add
  answer[i] = hall.Min()
```
- 정렬은 선택. `Sort` 후 `[0]`이 최솟값일 뿐.
- `Remove(값)`은 같은 값의 첫 칸만. 최솟값이 둘이면 아무거나 내려가도 됨.
- `Min()` 매 호출이 리스트 한 바퀴. 비교·삭제에 같은 `minScore`를 쓰면 한 바퀴 줄어듦. `k` 100이면 안 줄여도 통과.

## 규모
- 이 제한: `n×k` ≈ 10만. 3~4ms는 한 패스 문제보다 조금 큰 정도.
- 데이터가 아주 많으면 크기 `k` 최소 힙. 초당 1개 × `k` 100은 `Min()`으로도 충분.

## 다음에 볼 것
- 상위 k + 매일 최솟값 → 묶음 보관, 최소 변수만 금지.
- `if` 연속 vs `else`: 방금 `Add`해서 `Count == k`가 된 날.
- `Count` 속성 vs LINQ `Count()` / `Min()`.
