# [PCCP 기출] 동영상 재생기 (340213)

## 상태
- 제출·논의 완료
- 학습용: `프로그래머스/KYS24/동영상재생기_학습.cs`
- 공식 폴더가 생기면 그 `notes.md`로 이동

## 내가 한 질문
- 의사코드부터. 기준은 현재 위치. 앞 10초·끝 10초·오프닝·오프닝 끝 근처가 중요해 보인다. string이라 Parse 필요. 숫자→문자 변환은?
- 예제에서 오프닝 끝 직전일 때 next 한 번에 오프닝 끝으로 간 뒤 또 10초 가는 이유는? 설명에 있나?
- 코드 작성해 줘. Substring으로 잘라 정수 변환하는 거지?
- (제출 코드) 컴파일 오류 — 뭐지?
- 시간을 초로 바꿔 다루는 게 일반적? 다른 방식? 단위가 너무 크면?

## 문제 한 줄
`prev`(-10초)/`next`(+10초)와 **오프닝 자동 스킵**을 적용한 뒤 최종 위치를 `"mm:ss"`로 반환.

## 핵심 규칙
1. 모든 시각을 **초(int)** 로 통일
2. **시작 시** + **매 명령 후** `opStart ≤ cur ≤ opEnd`이면 `cur = opEnd`
3. prev: `max(0, cur-10)` / next: `min(videoLen, cur+10)`
4. 최적화 불필요 (`commands` ≤ 100)

### 예3가 “next가 끝+10”처럼 보이는 이유
```text
pos=04:05 ∈ 오프닝 → 먼저 04:07로 스킵
그다음 next → 04:17
```
특수 규칙이 아니라 **시작 시 SkipOpening → next** 순서. 문제 예제 설명에 명시됨.

## 문자열 ↔ 초
```text
"mm:ss" 길이 5
Substring(0,2) → 분  Parse
Substring(3,2) → 초  Parse  (index 2는 ':')
총초 = 분*60 + 초

되돌리기: $"{minute:D2}:{second:D2}"
(ToString만 하면 "4" → 형식 불일치)
```
대안: `Split(':')` 후 Parse.

## 컴파일 오류 (제출 시 오타)
| 잘못 | 고침 |
|------|------|
| `ToSecond` | `ToSeconds` |
| `SkipOpending` | `SkipOpening` |
| `commend` | `command` |
| `ToTimeString` 호출 vs `TotimeString` 정의 | 대소문자·철자 통일 |

## 시간 다루 일반론
- 코테: **한 단위(초/분)로 평탄화 후 정수 연산**이 정석
- 분·초를 따로 ± 하면 자리 올림 실수 많음
- 대안: `TimeSpan`, 분 통일, (형식 고정 시) 문자열 비교는 계산용으로 비추천
- 범위가 크면 `long` 초; 날짜·윤년·타임존이면 날짜 API

## 의사코드 요약
```text
cur, videoLen, opStart, opEnd ← ToSeconds(...)
cur ← SkipOpening(cur)
for command in commands:
  prev/next + clamp
  cur ← SkipOpening(cur)
return ToTimeString(cur)
```

## 다음에 볼 것
- SkipOpening을 **시작·명령 후 둘 다** 호출하는지 복습
- `D2` 포맷 / Substring 인덱스 다시 손코딩
