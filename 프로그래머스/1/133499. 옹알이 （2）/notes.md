# 옹알이 (2) (133499)

## 상태
- 제출 완료 (`while`로 `part`를 앞에서 자르고 `last`로 연속 금지, 끝난 뒤 `canSpeak`이면 +1)
- 로컬 실험: `LocalTest/Program.cs` (`.gitignore`)
- 옹알이 (1): `프로그래머스/0/120956. 옹알이 (1)/` (각 발음 최대 한 번, `Substring` 매칭)

## 내가 한 질문
- (1)도 있지 않나? 네 가지를 제거하고 남는지로 세면 되나? `Substring` 말고 부분 제거는?
- `foreach`와 `while` 조합이 생각난다.
- 중복이 없으니까 앞에서 잘라도 되나?
- `while`을 어떻게 쓰나? `words`는 만들었는데 왼쪽부터 어떻게 비교하나?
- `for`가 나을까? 반복이 3개인가?
- `foreach` 스니펫에서 `in` 뒤로 가는 단축키는?
- `i + w.Length <= part.Length && Substring == w`가 핵심인데 복잡하다.
- 작성 코드 확인. `answer++` 위치.
- 두 개를 붙여 `Replace`로 확인하는 풀이도 있다.
- `Replace`는 같은 발음을 전부 바꾸나? 다른 사람 풀이가 유난히 제각각이다.

## 막혔던 지점
- (1)은 각 발음 최대 한 번. (2)는 여러 번 되되 **연속만 금지**. `"yeye"`는 (2)에서 불가.
- `Replace("ye", "")`는 그 조각을 **전부** 지운다. `"yeye"`가 `""`가 되어 연속을 놓친다.
- `while (i < words.Length)`는 발음 4개만 돈다. `i`는 `part` 안의 글자 위치여야 한다. `while (i < part.Length)`.
- `Replace`는 원본을 안 바꾸고 새 문자열을 반환한다. 결과를 안 받으면 삭제가 안 된다.
- `answer++`를 `while` 안에 두면 발음 조각마다 센다. `"ayaye"`가 2가 됨. `while` 끝난 뒤 `if (canSpeak) answer++`.
- `Substring` 조건은 (1) 길이 가드 + (2) 그 구간이 `w`와 같은지. `&&`는 앞이 거짓이면 뒤를 안 봐서 범위 오류를 막는다.

## 문제 한 줄
`aya`, `ye`, `woo`, `ma`만 이어 붙인 단어 개수. 같은 발음 연속은 제외.

## 핵심 패턴
```text
foreach part in babbling
  i = 0, last = "", canSpeak = true
  while i < part.Length
    words 중 i에서 시작하는 w가 있나
      없으면 실패
      w == last 이면 실패
      아니면 last = w, i += w.Length
  끝까지 갔으면 +1
```

네 발음은 시작 글자가 `a`/`y`/`w`/`m`으로 달라서 한 위치에서 둘 이상이 안 맞는다. 그래서 탐욕적으로 잘라도 된다. 같은 발음을 다시 쓰는 것(`ayayeaya`)은 되고, 연속(`ayaaya`)만 안 된다.

`i` 이동량은 2~3이라 `for (i++;)`보다 `while` + `i += w.Length`가 맞다. 반복 세 겹: `babbling` → `part` 위치 → 발음 4개. 크기가 작아 부담 없다.

## 제출 코드
```csharp
while (i < part.Length)
{
    bool isMatch = false;
    foreach (string w in words)
    {
        if (i + w.Length <= part.Length
            && part.Substring(i, w.Length) == w)
        {
            if (w == last) { canSpeak = false; break; }
            last = w;
            i += w.Length;
            isMatch = true;
            break;
        }
    }
    if (!isMatch) { canSpeak = false; break; }
}
if (canSpeak)
    answer++;
```

`part`는 조카 말 하나. `last`는 방금 발음. `canSpeak`는 그 말 가능 여부. `isMatch`는 이번 `i`에서 네 개 중 하나가 맞았는지. `w == last`의 `break`는 안쪽 `foreach`만 나가지만 `isMatch`가 false라 `while`도 끊긴다.

읽기만 보면 `part.Substring(i).StartsWith(w)`도 같다. 이 문제는 길이 최대 30.

## 대안별 구현 비교

하는 일은 토큰 네 개로 쪼개기 + 연속 금지. API만 다름.

| | A `while` + `last` (제출) | B 두 번 붙인 뒤 `Replace` |
|---|---|---|
| 쪼개기 | `i`에서 `Substring` | 네 단어를 `Replace(..., "")` |
| 연속 | `w == last` | `"ayaaya"`, `"yeye"` 등 `Contains` |
| 성공 | `i`가 끝이고 `canSpeak` | 연속 없고 지운 뒤 `Length == 0` |

B는 `Replace`가 전부 지워서 `"yeye"`가 빈 문자열이 되므로, **연속 문자열을 먼저** 본다. `Replace`는 왼쪽부터 겹치지 않게 모든 출현을 바꾼다. 원본은 그대로, `part = part.Replace(...)`로 받아야 한다.

다른 풀이(숫자 치환, 정규식)도 같은 두 조건이다. 네 발음이 안 겹쳐서 어느 도구든 통과하기 쉽다.

### B. 연속 패턴 후 Replace
```csharp
string[] doubles = { "ayaaya", "yeye", "woowoo", "mama" };
foreach (string w in doubles)
{
    if (part.Contains(w)) { canSpeak = false; break; }
}
part = part.Replace("aya", "").Replace("ye", "").Replace("woo", "").Replace("ma", "");
if (canSpeak && part.Length == 0)
    answer++;
```

## 다음에 볼 것
- (1) 각 발음 한 번, (2) 연속만 금지. 전부 `Replace`는 (2)에서 `"yeye"`를 놓친다.
- `i`는 `part` 위치. 네 발음은 안쪽 루프.
- 개수는 조각이 아니라 단어 단위. `answer++`는 `while` 밖.
- 풀이가 제각각이면 토큰 자르기·이전 토큰 저장만 찾으면 된다.
