# 가장 가까운 같은 글자 (142086)

## 상태
- 제출 완료 (`lastIndex[26]` + `Array.Fill(-1)`, 거리는 `answer`에만)
- 로컬 실험: `LocalTest/Program.cs` (`.gitignore`)
- 공식 폴더: `프로그래머스/1/142086. 가장 가까운 같은 글자/`
- 2.14 ms, 47.8 MB

## 내가 한 질문
- 모든 값을 -1로 만들 때 `for`를 돌려야 하나?
- 문자열 글자 접근이 `s[i]` 아닌가?
- `char`에 대입해야 하나? `s[i] - 'a'`를 바로 쓰면 숫자로 안 보이나?
- `answer[i] = 값`이면 그 칸이 바뀌나?
- LocalTest 코드 확인 / 수정 후 재확인.
- 어려운 문제는 아닌 것 같다. `Array.Fill`은 처음 본다. `for`는 성능보다 타이핑?
- 딕셔너리로 푼 사람도 있다.
- `LastIndexOf`로 탐색하는 건 나쁜가?

## 막혔던 지점
- `new int[26]` 기본값 `0`은 없음이 아님. `0`은 `s[0]`에 있다는 뜻 → “없음”은 `-1`. 자판 문제와 같음.
- 첫 코드에서 `lastIndex`에 **거리**를 넣음. 표에는 **위치 `i`만**. 거리는 `answer[i] = i - lastIndex[index]`.
  `banana` 마지막 `a`에서 표에 거리 2가 남아 `5-2=3`이 됨. 정답은 `5-3=2`.
- `lastIndex[index] = i`는 `if`/`else` **둘 다 끝난 뒤**. 지금 칸이 다음번 가장 가까운 앞글자.
- `else if (lastIndex != -1)`은 `if == -1`의 반대라 `else`면 됨.

## 문제 한 줄
각 위치에서 앞에 나온 같은 글자 중 가장 가까운 거리. 없으면 `-1`.

## 핵심 패턴 (제출)
```text
lastIndex[26] = -1
i = 0 .. s.Length-1:
  index = s[i] - 'a'
  lastIndex[index] == -1 → answer[i] = -1
  아니면 answer[i] = i - lastIndex[index]
  lastIndex[index] = i
```
- `s[i]`는 `char`. `s[i] - 'a'`는 바로 `int` 칸 번호. 중간 `char` 변수는 선택.
- `answer[i] =` 는 그 칸 덮어쓰기. `List.Add`가 아님. 길이는 `new int[s.Length]`.
- `Array.Fill(lastIndex, -1)` = 26칸 `for`. 성능 차이 없음. 타이핑만 짧음.

## 다른 방식
| | |
|---|---|
| `int[26]` | 소문자 고정. 이번 제출 |
| `Dictionary<char, int>` | 키를 글자 그대로. `ContainsKey`가 “없음”. 종류를 모를 때 |
| `LastIndexOf(ch, i-1)` | 맞을 수 있음. 매번 앞을 재탐색 `O(N²)`. `i==0`에서 `i-1` 예외. 인자 없으면 문자열 전체(뒤까지) 검색 |

이 문제는 앞에서 뒤로 한 번 읽는 중이라 표가 정석.

## 다음에 볼 것
- “직전 등장 위치” → 배열/딕셔너리. 매 칸 `LastIndexOf` 재탐색은 후순위.
- 기본값 `0` vs 유효 인덱스 `0` → 없음은 `-1`.
