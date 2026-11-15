# 영어 끝말잇기 (12981)

## 상태
- 제출 완료. 정확성 100, 합계 100. 메모리 46.1 MB, 시간 0.24 ms
- 제출 파일: `프로그래머스/2/12981. 영어 끝말잇기/영어 끝말잇기.cs`
- Summer/Winter Coding(~2018)
- 제출본은 `HashSet`으로 이미 나온 단어를 본다. `LocalTest/Program.cs`와 같다

## 내가 한 질문
- 한 사이클 안에 파악이 끝나나? `[0, 0]`이 나오려면 단어 수가 `n`으로 나누어떨어져야 하나?
- 순회하면서 차례와 사람 번호를 세면 되나?
- `HashSet`과 `List`의 차이는?

## 막혔던 지점
- 탈락은 여러 바퀴 뒤에 나온다. 예제 1은 3바퀴의 3번이 `tank`를 다시 말해 `[3, 3]`이다. 단어는 최대 100개, 사람은 2명 이상 10명 이하다.
- `[0, 0]`은 배열을 끝까지 봐도 규칙이 깨지지 않을 때의 답이다. 단어 개수가 `n`으로 나누어떨어질 필요는 없다. 예제 2는 15개가 모두 규칙을 지켜 `[0, 0]`이다.
- 사람 번호와 그 사람의 차례는 0부터 센 `index`로 구한다. `index % n + 1`이 번호, `index / n + 1`이 차례다.
- 예제 1의 두 번째 `tank`는 위치 8이다. `8 % 3 + 1`은 3번, `8 / 3 + 1`은 3번째 차례다.
- 예제 3의 `now`는 위치 4다. 앞 단어 `never`의 끝은 `r`인데 `now`는 `n`으로 시작한다. `4 % 2 + 1`은 1번, `4 / 2 + 1`은 3번째 차례라 `[1, 3]`이다.
- 깨지는 규칙은 두 가지다. 이미 나온 단어이거나, 앞 단어의 마지막 글자와 지금 단어의 첫 글자가 다를 때다. 처음 단어는 `index > 0`이 아니라 앞 글자 검사를 하지 않는다.
- 탈락이 나오면 그 자리에서 반환한다. 뒤 단어는 보지 않는다.
- 단어 길이는 2 이상 50 이하라 한 글자 검사는 따로 두지 않는다.
- `HashSet`은 그 단어가 이미 들어 있는지만 본다. `Contains`가 그 대답이고, 같은 단어를 다시 `Add`하면 한 개만 남는다. 말한 순서는 `words`에 있다.
- `List`의 `Contains`는 앞에서부터 비교한다. 단어가 최대 100개라 답은 같다. 이 문제는 나온 단어의 순서를 다시 쓰지 않는다.

## 문제 한 줄
순서대로 말한 단어에서 처음 탈락한 사람의 `[번호, 차례]`. 탈락이 없으면 `[0, 0]`.

## 핵심 패턴
```text
index를 0부터 끝까지
  이미 나온 단어이거나
  index > 0 이고 첫 글자 != 앞 단어의 마지막 글자
    이면 [index % n + 1, index / n + 1] 반환
  아니면 나온 단어에 추가
끝까지 오면 [0, 0]
```

```csharp
HashSet<string> usedWords = new HashSet<string>();

for (int index = 0; index < words.Length; index++)
{
    string word = words[index];
    bool isDuplicate = usedWords.Contains(word);
    bool isWrongStart = index > 0 && word[0] != words[index - 1][words[index - 1].Length - 1];

    if (isDuplicate || isWrongStart)
        return new int[] { index % n + 1, index / n + 1 };

    usedWords.Add(word);
}

return new int[] { 0, 0 };
```

- `3`, `tank`가 다시 나온 위치 8 → `[3, 3]`
- `2`, `now`가 위치 4 → `[1, 3]`
- 예제 2 → `[0, 0]`

## 대안별 구현 비교

A가 제출본이다. B는 나온 단어를 `List`에 넣는다. 이 제한에서는 답이 같다.

| 방법 | 나온 단어 확인 | 단어 100개 |
|---|---|---|
| A. `HashSet` | `Contains`가 포함 여부 | 제출본. 0.24 ms |
| B. `List` | 앞에서부터 같은 문자열 비교 | 답은 같다. 순서는 이 문제에서 쓰지 않는다 |

### B. `List`

```csharp
List<string> usedWords = new List<string>();

for (int index = 0; index < words.Length; index++)
{
    string word = words[index];
    bool isDuplicate = usedWords.Contains(word);
    bool isWrongStart = index > 0 && word[0] != words[index - 1][words[index - 1].Length - 1];

    if (isDuplicate || isWrongStart)
        return new int[] { index % n + 1, index / n + 1 };

    usedWords.Add(word);
}

return new int[] { 0, 0 };
```

번호와 차례 식은 같다. `index % n + 1`에서 `+ 1`을 빼면 번호가 0부터 시작한다. `index / n`에서 `+ 1`을 빼면 차례가 0부터 시작한다.

## 다음에 볼 것
- 백지에서는 `index % n + 1`, `index / n + 1`과 탈락 즉시 반환만 먼저 적는다.
- 확인할 값은 `[3, 3]`, `[1, 3]`, `[0, 0]`이다. 단어 수가 `n`의 배수가 아니어도 규칙만 지키면 `[0, 0]`이다.
