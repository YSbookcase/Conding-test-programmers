# 올바른 괄호 (12909)

## 상태
- 제출 완료. 스택으로 제출. 정확성 69.5, 효율성 30.5, 합계 100. 메모리 46.4 MB, 시간 1.96 ms
- 제출 파일: `프로그래머스/2/12909. 올바른 괄호/올바른 괄호.cs`
- 고득점 Kit 스택/큐
- 대괄호까지 확장한 코드는 별도 문제가 아니라, 같은 스택에 짝 조건을 더한 연습이다

## 내가 한 질문
- 스택에 쌓다가 `()`가 되면 제거하는 방식으로 배웠던 문제다
- 대괄호나 중괄호가 추가되면 조건만 더하면 되나? 남은 카운터로 구별하는 것이 그대로 적용되나?
- `Pop`으로 확인하는 것이 아니라 맨 위를 보는 방법이 있었나? 괄호와 대괄호만 있는 코드를 작성해 달라
- `bracket == ')' && open == '('` 같은 조건을 생각하기 어렵다
- 경우의 수가 다 들어갔나?
- 다른 사람들은 스택보다 카운트를 많이 쓰네

## 막혔던 지점
- 제거는 문자열에서 지우는 것이 아니다. `'('`는 스택에 넣고, `')'`를 만나면 쌓인 `'('` 하나를 `Pop`한다. 꺼낼 것이 없거나, 끝에 남아 있으면 `false`다.
- 이 문제 다른 풀이에 카운터가 많은 이유는 스택에 `'('`만 들어가서다. 높이를 `openCount`로 세면 문자 스택과 같은 `true`, `false`다. `"()()"`는 `1, 0, 1, 0`이라 `true`, `"(()("`는 `1, 2, 1, 2`로 끝나 `false`다. 대괄호가 섞이면 이 숫자는 최근 종류를 기억하지 못한다.
- 대괄호가 섞이면 카운터는 그대로 쓸 수 없다. 숫자는 개수만 세고, 가장 최근에 열린 종류를 기억하지 못한다. `([)]`와 `([])`는 끝나면 개수가 둘 다 0인데, `([)]`는 `)`일 때 맨 위가 `[`라 실패다.
- `Peek`은 맨 위를 보기만 한다. `Pop`은 확인하면서 빼므로, 짝이 아닐 때도 이미 제거된다. `Peek`으로 맞는지 본 뒤 맞을 때만 `Pop`한다.
- `isRoundPair`처럼 `&&`로 한 줄에 만들 필요는 없다. 닫는 괄호마다 맨 위에 있어야 할 문자를 정하고, 맨 위와 다른지 보면 된다.
- 짝 비교의 경우는 네 가지다. `)`+`(`, `]`+`[`는 성공. `)`+`[`, `]`+`(`는 실패. 여는 괄호 넣기, 닫을 때 스택이 빔, 끝에 여는 괄호가 남음은 짝 비교 밖에서 처리한다.

## 문제 한 줄
`'('`와 `')'`만 있는 문자열이 올바른 괄호면 `true`, 아니면 `false`. 길이는 10만 이하.

## 핵심 패턴
```text
openCount = 0
'('면 +1
')'인데 0이면 false, 아니면 -1
끝나면 0이어야 true
```

스택으로 쓰면 `'('`만 `Push`하고 `')'`에서 `Pop`한다. 이 문제는 쌓이는 문자가 `'('`뿐이라 높이와 `openCount`가 같다. 코드는 아래 비교의 A, B다.

- `"()()"`, `"(())()"` → `true`
- `")()("`, `"(()("` → `false`

대괄호가 있으면 닫는 괄호마다 기대하는 여는 괄호를 정한다.

```csharp
if (bracket == '(' || bracket == '[')
{
    openBrackets.Push(bracket);
    continue;
}

if (openBrackets.Count == 0)
{
    return false;
}

char open = openBrackets.Peek();
char expectedOpen;

if (bracket == ')')
{
    expectedOpen = '(';
}
else
{
    expectedOpen = '[';
}

if (open != expectedOpen)
{
    return false;
}

openBrackets.Pop();
```

- `()`, `[]`, `([])` → `true`
- `([)]`, `)`, `(()` → `false`
- 중괄호는 표에 `'}'` → `'{'` 한 줄이면 된다. 종류마다 카운터를 두지 않는다.

## 대안별 구현 비교

`()`만 있으면 답은 같다. 갈리는 지점은 괄호 종류가 늘 때다.

| 방법 | 기억 | 읽기 | `()`만 | `([)]` |
|---|---|---|---|---|
| A. 스택 | 열린 `'('` 문자 | `Push`, `Pop` | 맞음 | 맨 위 종류로 거름 |
| B. 카운터 | 열린 개수 | 숫자 하나 | 맞음 | `([])`와 구별 못 함 |

A는 제출본이다. B는 이 문제 다른 풀이에 많다. 스택을 만들지 않고, 길이가 10만이어도 숫자 하나로 충분하다. `([)]`는 A에서 `)`일 때 맨 위가 `[`라 실패하고, B는 개수가 0으로 끝나 성공으로 본다.

### A. 스택

```csharp
public bool solution(string s)
{
    Stack<char> openBrackets = new Stack<char>();

    foreach (char bracket in s)
    {
        if (bracket == '(')
        {
            openBrackets.Push(bracket);
            continue;
        }

        if (openBrackets.Count == 0)
        {
            return false;
        }

        openBrackets.Pop();
    }

    return openBrackets.Count == 0;
}
```

### B. 카운터

```csharp
public bool solution(string s)
{
    int openCount = 0;

    foreach (char bracket in s)
    {
        if (bracket == '(')
        {
            openCount++;
            continue;
        }

        if (openCount == 0)
        {
            return false;
        }

        openCount--;
    }

    return openCount == 0;
}
```

## 다음에 볼 것
- 이 문제는 카운터로 내도 같은 답이다. 종류가 둘 이상이면 문자를 스택에 넣고 `Peek`으로 짝을 본다.
- 짝 조건이 한 줄로 안 떠오르면, 닫는 문자로 기대하는 여는 문자를 먼저 정한다.
