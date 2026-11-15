# 이상한 문자 만들기 (12930)

## 상태
- 제출 완료. 공백마다 `wordIndex`를 0으로 되돌리고, 짝수는 `ToUpper`, 홀수는 `ToLower`
- 제출 파일: `프로그래머스/1/12930. 이상한 문자 만들기/이상한 문자 만들기.cs`
- LocalTest는 쓰지 않음

## 내가 한 질문
- `s[i] - 'a' + 'A'`를 `Append`했는데 숫자로 들어간다. 뭐가 문제인가?
- 빈칸일 때 `continue`로 넘기면 되나?
- 전체 코드를 보여 달라. `wordIndex`는 왜 필요한가?
- 문자열 길이에 빈칸이 인덱스로 안 들어가는 건가?
- 문제를 잘못 봤다. 단어별로 짝수·홀수구나.
- `-'a' + 'A'` 방법으로는 어떻게 하나?
- 소문자만 온다는 제한이 없나? 그래서 대문자 판별도 한 건가?
- 추가로 주의할 점이 있나?

## 막혔던 지점
- `s[i] - 'a' + 'A'`는 `int`다. `'t'`는 `116 - 97 + 65`라 `84`다. `Append(84)`는 `'T'`가 아니라 `"84"`를 붙인다. `(char)84`가 `'T'`다.
- 짝수·홀수는 문자열 전체가 아니라 단어마다 0부터다. `"try hello world"`는 각 단어가 우연히 짝수 칸에서 시작해 예제만 맞을 수 있다. `"ab c"`에서 `c`는 문자열 3번 칸이라 홀수지만, 단어의 0번째라 `"Ab C"`가 되어야 한다.
- 공백도 문자열 인덱스에 있다. `"ab c"`의 길이는 4이고 `s[2]`가 공백이다. `wordIndex`만 공백을 세지 않고 0으로 되돌린다.
- `continue` 전에 공백을 붙여야 한다. 붙이기 전에 넘기면 `"try hello"`가 `"TrYHeLlO"`가 된다. 공백이 두 개면 두 칸 모두 넣고, 다음 글자는 다시 0이라 대문자다.
- 붙여 넣은 제한에는 소문자만 온다는 조건이 없다. 예제가 소문자일 뿐이다. 홀수 칸의 `'L'`은 `'l'`이 되어야 한다.
- `Split`으로 나누면 연속 공백이 사라진다. `"try  hello"`를 한 칸으로 다시 붙이면 `"TrY HeLlO"`가 된다.
- `StringBuilder`는 `using System.Text;`이 필요하다. LocalTest는 이 `using`이 자동이라 없어도 컴파일된다. 반복해서 붙이므로 여기서는 `StringBuilder`가 맞다.

## 문제 한 줄
단어마다 0부터 세어 짝수 칸은 대문자, 홀수 칸은 소문자로 바꾼다. 공백은 그대로 둔다.

## 핵심 패턴
```text
wordIndex = 0
글자마다:
  공백이면 공백을 넣고 wordIndex = 0, 다음 글자
  wordIndex가 짝수면 대문자, 홀수면 소문자
  wordIndex++
```
- `"try hello world"` → `"TrY HeLlO WoRlD"`
- `"ab c"` → `"Ab C"`
- 한 글자 단어는 0번째라 대문자 하나다. 앞뒤 공백도 지우지 않는다.

## 대안별 구현 비교

단어 인덱스를 쓰고 공백을 유지하면 결과가 같다. 전체 인덱스로 세거나, 공백을 `Split`으로 지우거나, `Append`에 `int`를 넣으면 달라진다.

### A. `ToUpper` / `ToLower`
제출한 버전.

```csharp
StringBuilder result = new StringBuilder();
int wordIndex = 0;
for (int i = 0; i < s.Length; i++)
{
    if (s[i] == ' ')
    {
        result.Append(' ');
        wordIndex = 0;
        continue;
    }

    if (wordIndex % 2 == 0)
    {
        result.Append(char.ToUpper(s[i]));
    }
    else
    {
        result.Append(char.ToLower(s[i]));
    }

    wordIndex++;
}
return result.ToString();
```

### B. `'a'`/`'A'` 차이로 케이스 바꾸기
소문자만 `'a'`를 빼고 `'A'`를 더한다. 홀수 칸의 대문자는 `'A'`를 빼고 `'a'`를 더한다. `(char)`가 빠지면 `"84"`가 붙는다. 이번 입력에서는 A와 같다.

```csharp
char letter = s[i];
if (wordIndex % 2 == 0)
{
    if (letter >= 'a' && letter <= 'z')
    {
        letter = (char)(letter - 'a' + 'A');
    }
}
else if (letter >= 'A' && letter <= 'Z')
{
    letter = (char)(letter - 'A' + 'a');
}
result.Append(letter);
wordIndex++;
```

### C. 문자열 전체 인덱스로 짝수·홀수
`"ab c"`가 `"Ab c"`가 된다. `c`가 전체 3번 칸이라 소문자로 남는다. 예제 `"try hello world"`는 단어 시작이 짝수 칸이라 우연히 맞을 수 있다.

```csharp
if (i % 2 == 0)
{
    result.Append(char.ToUpper(s[i]));
}
else
{
    result.Append(char.ToLower(s[i]));
}
```

## 다음에 볼 것
- 단어별 인덱스와 문자열 인덱스는 다르다. 공백도 `s[i]`에 있다.
- `char` 연산 결과는 `int`다. `Append`에 넣기 전에 `(char)`로 바꾸거나 `ToUpper`/`ToLower`를 쓴다.
- 연속 공백을 유지하려면 한 글자씩 본다. `Split` 후 한 칸으로 합치지 않는다.
