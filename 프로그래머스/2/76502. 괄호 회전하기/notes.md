# 괄호 회전하기 (76502)

## 상태
- 제출 완료. 정확성 100, 합계 100. 메모리 46.6 MB, 시간 12.68 ms
- 제출 파일: `프로그래머스/2/76502. 괄호 회전하기/괄호 회전하기.cs`
- 월간 코드 챌린지 시즌2. LocalTest에서 큐 회전 + 스택 검사로 작성해 제출
- 올바른 괄호(12909)의 스택 검사를 `()`, `[]`, `{}`로 확장한 형태

## 내가 한 질문
- 큐로 돌리고 검사는 스택으로 판별하는 함수를 만들려 한다. 방향이 맞나
- 큐 대신 `Substring`을 쓰는 것과 시간·공간 복잡도는 어떻나
- LocalTest에 작성한 코드를 확인해 달라

## 막혔던 지점
- 방향은 맞다. 0부터 길이-1까지 왼쪽으로 한 칸씩 돌리며, 그때마다 올바른 괄호인지 센다. 회전은 큐의 맨 앞을 뒤로 보내면 되고, 판별은 스택이다.
- 이번 문자열은 `()`, `[]`, `{}`가 섞인다. 12909처럼 개수만 세면 `([)]`와 `([])`를 구별하지 못한다. 닫는 괄호마다 맨 위가 짝인지 본 뒤 `Pop`한다.
- LocalTest의 `IsValid`가 큐가 아니라 방금 만든 빈 스택을 순회했다. `foreach (char bracket in openBrackets)`라 반복이 한 번도 안 돌고 항상 `true`가 된다. `"[](){}"`면 6, `"[)(]"`도 4가 나온다. 순회 대상은 매개변수 `brackets`다. 매개변수 이름 `brackkets`도 `brackets`로 맞춘다.
- 큐와 `Substring` 모두 회전 `n`번 × 검사 `O(n)`이라 시간은 `O(n²)`다. 큐는 회전이 `O(1)`이고 문자 `n`개만 유지한다. `s.Substring(rotate) + s.Substring(0, rotate)`는 회전마다 길이 `n` 문자열을 새로 만든다. `n`이 1000이라 둘 다 통과한다.

## 문제 한 줄
`s`를 왼쪽으로 0칸부터 길이-1칸까지 돌렸을 때, 올바른 괄호 문자열이 되는 회전 횟수를 반환한다. 길이는 1000 이하.

## 핵심 패턴
```text
큐에 s를 넣는다
0부터 길이-1까지
  지금 큐가 올바른지 검사
  맞으면 개수 +1
  맨 앞을 뒤로 보낸다
```

```csharp
for (int rotate = 0; rotate < s.Length; rotate++)
{
    if (IsValid(brackets))
        validCount++;

    char front = brackets.Dequeue();
    brackets.Enqueue(front);
}
```

`IsValid`는 여는 괄호만 스택에 넣고, 닫는 괄호는 맨 위와 짝이 아니면 거짓이다. 끝나면 스택도 비어 있어야 참이다.

| s | result |
|---|---|
| `"[](){}"` | 3 |
| `"}]()[{"` | 2 |
| `"[)(]"` | 0 |
| `"}}}"` | 0 |

## 대안별 구현 비교

답 개수는 같다. 제출본은 큐로 한 칸씩 밀고, `Substring`은 회전마다 새 문자열을 만든다. 검사 스택은 어느 쪽이든 최대 `O(n)`이다.

| 방법 | 회전 | 시간 | 추가 공간 |
|---|---|---|---|
| A. 큐 | `Dequeue`/`Enqueue` | `O(n²)` | 큐 `O(n)` |
| B. `Substring` | 문자열 연결 | `O(n²)` | 회전마다 `O(n)` 문자열 |

### B. Substring

```csharp
public int solution(string s)
{
    int validCount = 0;

    for (int rotate = 0; rotate < s.Length; rotate++)
    {
        string rotated = s.Substring(rotate) + s.Substring(0, rotate);
        if (IsValid(rotated))
            validCount++;
    }

    return validCount;
}

bool IsValid(string brackets)
{
    Stack<char> openBrackets = new Stack<char>();

    foreach (char bracket in brackets)
    {
        if (bracket == '(' || bracket == '[' || bracket == '{')
        {
            openBrackets.Push(bracket);
            continue;
        }

        if (openBrackets.Count == 0)
            return false;

        char open = openBrackets.Pop();
        if (bracket == ')' && open != '(')
            return false;
        if (bracket == ']' && open != '[')
            return false;
        if (bracket == '}' && open != '{')
            return false;
    }

    return openBrackets.Count == 0;
}
```

## 다음에 볼 것
- 올바른 괄호(12909)와 같이 보면, 종류가 하나일 때는 카운터로도 되고, 세 종류면 스택이 필요하다.
- 제출본의 `front`는 왼쪽으로 한 칸 돌릴 때 맨 앞에서 뒤로 가는 문자다. `open`은 닫는 괄호와 짝을 맞출 맨 위 문자다.
