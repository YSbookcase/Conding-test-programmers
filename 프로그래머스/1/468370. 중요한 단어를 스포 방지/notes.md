# 중요한 단어를 스포 방지

## 상태
- 제출 완료
- 학습용 초안: `프로그래머스/KYS24/중요한단어스포방지_구간별학습.cs`
- 로컬 실험: `LocalTest/` (`.gitignore` 대상, 커밋 안 함)

## 내가 한 질문 (논의 순서)
- 논의·의사코드부터 들어가자.
- 파싱에 start/end가 있는 건 스포가 숫자 구간이라서인가?
- 들어내는 단어들을 하나의 리스트로? 파싱과 같은 구조? 클래스로?
- class vs struct, 콜바이밸류/리퍼런스 — 지금은 어떻게 고르면 좋은가?
- 구간별로 코드 작성하며 설명해 줘. 작성하면서 공부할 필요가 있다.
- 프로그래머스에서 중간 실행은 안 되나? / 테스트 케이스 넣어야 하나? / 로컬은?
- 솔루션·프로젝트 파일을 만들어야 하나? / 프로젝트 만들면 솔루션이 자동?
- LocalTest는 gitignore 하는 게 좋지? 중간 실험은 저장할 필요 있나?
- Main에서 static으로 둔 건 테스트 때문인가?
- 구간 2까지 작성해 준 것 확인 / Length·파싱 루프 순서 확인
- VS에서 Tab 한 줄 완성 너무 알려줌 — 이름 제안만 남기고 끄고 싶다
- `BuildPublicWords`에 접근 한정자 필요? / 구간 3 작성 확인 (함수 중첩)
- 코드를 여기 안 붙여도 되나? (LocalTest 저장하면 읽기 가능)
- `last = -1` 버그 수정 후 공개 단어만 보이는지 확인
- HashSet 설명 (Dictionary와 비교)
- 함수에 함수라 알고리즘이 헷갈림 — 펼쳐서 보고 싶다
- `FindLastOverlapRange` 동작 자세히 / 단어마다 체크, i=스포 배열 순서
- 이런 걸 30분 만에? 배경지식?
- 두 단어의 `last`(i)가 같아질 수 있나? revealAt 순서
- `List<WordInfo>[]`는 리스트의 리스트?
- 구간 4 작성 확인 / 구간 5 이해 확인 (`publicWords`·`seenSpoilerWords`)
- 제출 코드 뭐가 문제? (오타) / 진행이 더딤 / 최적화 문제 없나?
- 메모 정리 + 추가로 말해 줄 것?

---

## 문제 한 줄
스포 구간을 왼쪽→오른쪽 클릭할 때마다 **새로 전부 공개된 스포 단어** 중,  
공개 구간에 나온 적 없고·이미 센 스포 단어와 중복 아닌 것의 **개수**.

## 중요한 단어 조건
1. 스포 단어 (글자 중 하나라도 스포 구간)
2. 공개 구간(어떤 스포에도 안 속한 출현)에 같은 문자열 없음
3. 이전에 공개된 스포 단어와 중복 아님
4. 동시에 여러 개면 **왼쪽부터** 판정

## 핵심 관찰
- 구간은 겹치지 않고 start 오름차순 → 배열 순서 = 클릭 순서
- 단어가 **전부 공개되는 시점** = 겹치는 스포 중 **가장 오른쪽 인덱스 `last`**
- `last`가 같은 단어들 = 같은 클릭에 같이 공개 (예: `may`, `i`)
- 파싱에 `(Start, End, Text)`가 필요한 이유: 스포가 **인덱스 구간**이라 위치 없이 겹침 판정 불가

---

## 시행착오 / 학습 흐름

### A. 의사코드·데이터
- `WordInfo`: Start, End, Text — class (리스트·여러 함수에서 참조 공유가 단순)
- struct도 가능하지만, 공유·수정·컬렉션에 넣을 땐 **기본 class** 습관
- `revealAt[j]`: j번 클릭 때 새로 전부 공개되는 단어 리스트 (배열 + 리스트)
- 같은 `last`여도 충돌 아님 → 같은 `revealAt[j]`에 여러 개 Add

### B. 구간별 구현 (LocalTest로 나눠 확인)
1. **WordInfo**
2. **ParseWords** — 공백 스킵 → 끝이면 break → 단어 추출 (순서 중요)
3. **BuildPublicWords** — 스포와 안 겹치는 출현의 Text → `HashSet`
4. **BuildRevealAt** — `last != -1`이면 `revealAt[last].Add(word)`
5. **CountImportantWords** — public / seen 스킵 후 answer++ 및 seen.Add

### C. 함수가 겹쳐 보여 헷갈림
- 구간 3만 보면 `IsOverlap` ← `FindLast` ← `IsOverlapAny` ← `BuildPublic`가 깊음
- 펼치면: 단어마다 구간 루프, 안 겹치면 public에 추가
- `FindLastOverlapRange`는 **구간 4 재사용** 때문에 미리 분리한 것

### D. FindLastOverlapRange
- `last = -1`로 시작, 겹칠 때마다 `last = i` (덮어쓰기)
- 끝나면 가장 늦은 겹침 인덱스 / 없으면 -1
- **버그 경험**: `last = -1`로 잘못 쓰면 전부 “안 겹침” → `secret`까지 public에 들어감 → 반드시 `last = i`

### E. HashSet
- Dictionary의 “키만”에 가깝다 (값 없음, 중복 없음)
- `Contains` / 중복 제거용. 순서 비보장
- `publicWords`, `seenSpoilerWords` 용도. 반환값은 `int`뿐, seen은 실행 중 상태용

### F. 로컬·도구
- 프로그래머스/로컬 모두 **입력을 넣어** 실행해야 함
- `LocalTest/` + `.gitignore` — 중간 실험은 Git에 안 남겨도 됨
- Main 테스트용 `static` ≠ 제출용 Solution 인스턴스 메서드
- VS: 인라인/전체 줄 완성 끄고, IntelliSense 이름 + Tab은 유지 (공부용)

### G. 제출 직전 오타
- `pulbic` → `public`
- `spoilderRanges` / `spoilerRanges` / `spoiler_ranges` 통일
- `BuildPulbicWords` → `BuildPublicWords`

---

## 최종 알고리즘 요약

```text
1) 단어 파싱 → List<WordInfo> (왼쪽순)
2) publicWords: 스포와 안 겹치는 출현의 Text
3) 각 스포 단어 last = 겹치는 최대 구간 인덱스 → revealAt[last]
4) j=0..R-1, revealAt[j] 왼쪽부터:
     public이면 skip / seen이면 skip / 아니면 answer++ 및 seen.Add
5) return answer
```

겹침: `wordStart <= rangeEnd && rangeStart <= wordEnd`

## 복잡도
- L ≤ 20,000, R ≤ 1,000
- 단어마다 구간 스캔 O(W·R) ≈ 2×10⁷ 수준 → **이 문제에서 충분**
- 투포인터로 O(W+R) 가능하나 필수는 아님

## 예제 체크
- 예1: 첫 `here` 공개 시 public에 `here` 있음 → 비중요 / `secret` → 중요 → **1**
- 예2: `phone`, `01012345678`, `may`, `i` → **4** (마지막 phone·number 탈락)

---

## 다음에 볼 것
1. 힌트 없이 조건만 읽고 `last` + `publicWords` + `seen` 뼈대 다시 세우기
2. 예1·예2를 `revealAt` 출력으로 한 번 더 시뮬레이션
3. (선택) 비슷한 “구간 클릭/공개 순서” 구현 문제 한 문제

## 추가 메모 (제출 후)
- 공식 프로그래머스 폴더가 repo에 생기면 이 메모를 그 `notes.md`로 옮기면 됨
- 진행이 느린 느낌은 정상: 조건 해석형 구현 문제라 첫 바퀴가 김. 패턴(`파싱+구간겹침+HashSet+시점버킷`)이 남으면 다음엔 짧아짐
