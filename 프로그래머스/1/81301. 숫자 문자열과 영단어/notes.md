# 숫자 문자열과 영단어 (81301)

## 상태
- 제출 완료. `Replace` 후 `int.Parse`
- 한 칸씩 건너뛰는 순회는 비교용
- 제출 파일: `프로그래머스/1/81301. 숫자 문자열과 영단어/숫자 문자열과 영단어.cs`

## 내가 한 질문
- 문자열을 찾아 숫자로 바꾼 뒤 정수로 반환하면 되나? `s` 길이만 보면 `int`가 넘치지 않나?
- 그 외에 더 볼 점은?
- 옹알이처럼 인덱스에서 단어를 맞추고 길이만큼 건너뛰면 더 최적화인가?
- 일단은 `Replace`로 가볍게 푸는 쪽이 맞지 않나?

## 막혔던 지점
- `s` 길이 50은 글자 수지 자릿수가 아니다. `three`, `seven`, `eight`는 5글자라 50글자가 전부 이런 단어면 자릿수는 10이다. 10자리 수는 `int`를 넘을 수 있지만, 반환 값이 1 이상 2,000,000,000 이하인 입력만 온다. 이 값은 `int` 최대값 2,147,483,647보다 작다.
- `Replace`는 원본을 바꾸지 않고 새 문자열을 반환한다. `s = s.Replace(...)`로 받아야 한다. 옹알이 (2)에서 이미 나온 지점이다.
- 단어 길이는 3, 4, 5가 섞여 있다. 3글자만 자르면 `three`가 맞지 않는다.
- 열 개 단어는 서로 포함되지 않는다. `Replace` 순서는 상관없고, 왼쪽에서 하나만 맞아도 해석이 하나로 정해진다.
- 한 칸씩 건너뛰는 코드는 옹알이 (2)의 `i += w.Length`와 같다. 다만 이 문제의 정답은 단어를 전부 숫자로 바꾸는 것이라 `Replace`가 조건과 맞다. `s`가 최대 50이라 열 번 치환도 충분하고, 순회의 `Substring`도 문자열을 새로 만들어서 할당이 더 가볍다고 보기 어렵다.
- 옹알이 (2)에서 순회가 필요했던 이유는 속도가 아니다. `Replace("ye", "")`는 `"yeye"`를 빈 문자열로 만들어 연속을 놓친다. 직전 토큰을 기억해야 할 때 그 순회를 다시 쓴다.

## 문제 한 줄
일부 자릿수가 `zero`~`nine`으로 바뀐 문자열을 원래 정수로 되돌린다. 앞이 `zero`나 `0`인 입력은 없다.

## 핵심 패턴
```text
zero~nine 을 "0"~"9" 로 Replace
int.Parse
```

`"one4seveneight"` → `"1478"` → 1478. 앞자리가 0인 입력이 없어서 `Parse` 결과가 그대로 원래 수다.

## 대안별 구현 비교

둘 다 같은 정수를 만든다. 차이는 단어를 통째로 바꾸느냐, 읽으면서 자릿수를 쌓느냐다. 이 문제는 A가 맞다.

| | A `Replace` (채택) | B 인덱스 순회 |
|---|---|---|
| 하는 일 | 단어 10개를 숫자 문자로 바꾼 뒤 `Parse` | 숫자 문자는 바로 넣고, 단어는 길이만큼 `i`를 이동 |
| 시간 | 길이 50 × 단어 10 | 길이 50 × 단어 10 |
| 할당 | 치환마다 새 문자열 | `Substring`마다 새 문자열 |
| 맞는 때 | 등장한 단어를 전부 숫자로 바꾸면 될 때 | 직전 토큰이 필요할 때. 옹알이 (2)의 연속 금지 |

### A. `Replace` 후 `int.Parse`
```csharp
string[] words = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
for (int digit = 0; digit <= 9; digit++)
    s = s.Replace(words[digit], digit.ToString());
return int.Parse(s);
```

`words[digit]`가 영단어, `digit.ToString()`이 그 자리의 문자다. `s`는 치환 결과가 쌓이는 문자열이다.

### B. 옹알이처럼 길이만큼 건너뛰기
```csharp
string[] words = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
int number = 0;

for (int i = 0; i < s.Length;)
{
    if (char.IsDigit(s[i]))
    {
        number = number * 10 + (s[i] - '0');
        i++;
        continue;
    }

    for (int digit = 0; digit <= 9; digit++)
    {
        if (!s.Substring(i).StartsWith(words[digit])) continue;
        number = number * 10 + digit;
        i += words[digit].Length;
        break;
    }
}

return number;
```

`number`는 지금까지 만든 정수다. 최종 값이 20억 이하라 `number * 10 + digit`도 `int`로 안전하다. `i`는 글자 위치라 `for`의 `i++`를 쓰지 않고 단어 길이만큼 더한다.

## 다음에 볼 것
- 입력 길이가 아니라 반환 상한으로 `int` 여부를 본다.
- 전부 치환하면 되는 문제는 `Replace`. 연속처럼 직전 조각이 필요하면 옹알이 (2) 순회.
- `Replace` 결과는 반드시 다시 받는다.
