# 공원 산책

## 상태
- 학습용: `프로그래머스/KYS24/공원산책_학습.cs`
- LocalTest로 경로 검사·Main 위치 디버깅함
- 공식 폴더가 생기면 그 `notes.md`로 이동

## 내가 한 질문
- 좌표 문제. park를 어떻게 두고 장애물 검사? Dictionary? 시작 배열 + switch로 연산, 경로 검사는 어디에?
- S 찾기는 park 전체 순회? 이동 전 스캔 후 최종 반영 방식인가?
- 코드 작성해 줘
- 테스트 코드 확인 / 다시 수정했는데 틀렸나?
- `park[nextRow][nextCol]`이 일반 2차원과 다른데 설명?
- 저런 `[][]` 형태는 문자열 배열 문자 검색 말고 다른 데도?
- 그 구조로 선언하면 배열 메서드·초기값은 어떻게?

## 문제 한 줄
`routes`의 `"방향 칸수"`를 순서대로 수행. 경로가 밖이거나 `X`를 만나면 **그 명령 전체 무시**. 최종 `[세로, 가로]` 반환.

## 접근
- Dictionary 불필요 (맵 불변, 이름 키 없음) → `park` + 현재 `(row, col)`
- `S` 한 번 찾기 (최대 50×50)
- 명령마다: Split → switch로 `(dRow, dCol)` → **n칸 미리 스캔** → 전부 OK일 때만 위치 갱신

```text
next = 현재
canMove = true
n번:
  next += 방향
  밖 or X → canMove=false, break
canMove이면 현재 = next   // 루프 밖에서만!
```

## 버그로 겪었던 것 (LocalTest)
1. 검사 루프에서 좌표 안 옮기고 `canMove=false`만 함 → 항상 실패
2. `if (canMove) row/col 갱신`을 **for 안**에 둠 → 부분 이동 (예2 오답)
3. `Main` 안에 `Main` 중첩 → 테스트 미실행
4. `'X'`/`break`를 foreach 쪽으로 잘못 두면 이후 명령 스킵

## `park[r][c]` 정리
- `park`는 `string[]` (진짜 `char[,]` 아님)
- `park[r]` = r행 문자열, `park[r][c]` = 그 글자
- `park[r, c]`는 `string[]`에 사용 불가
- `height = park.Length`, `width = park[0].Length`

## `[][]` / jagged 일반
- 문자열 격자뿐 아니라 `int[][]`, `List<List<T>>`, 인접 리스트 등 **두 단계 인덱스**면 동일
- `new int[h][]` 후 행마다 `new int[w]`
- `Length` = 행 수, 열 = `arr[i].Length`
- `Array.Fill`/`Sort` 등은 **행 단위**
- `string`은 불변 → 칸 수정 필요 시 `ToCharArray()`로 `char[][]`

## 성능
- H,W ≤ 50, routes ≤ 50, n ≤ 9 → 최적화 불필요

## 다음에 볼 것
- “경로 미리 스캔 → 성공 시에만 반영” 다시 손코딩
- `string[]` 격자와 `int[,]` / `int[][]` 차이 한 줄로 설명하기
