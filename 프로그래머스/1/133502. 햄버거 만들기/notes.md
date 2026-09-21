# 햄버거 만들기 (133502)

## 상태
- 제출 완료 (`List pack`, `Add` 후 끝 4개가 1-2-3-1이면 `RemoveRange`)
- 로컬 실험: `LocalTest/Program.cs` (`.gitignore`)

## 내가 한 질문
- 종류별 개수를 세고 `Min` 하면 안 되나?
- 예1에서 빵이 중간에 두 번 쓰여도 되나? 첫 햄버거 다음, 앞에 남은 빵으로 다음을 만드는 상황 아닌가?
- 제거 후 재조합까지 봐야 하나? 왼쪽 3+오른쪽 1, 2+2, 1+3 같은 경우의 수가 많지 않나?
- 다음에 `231`이 오면 남은 재료와 붙는 거 아닌가?
- 뒤에서 4개씩 계속 확인하나? 통이 짧아지면 기존에 쌓인 것도 보게 되는 거 아닌가?
- 처음에는 끝이 4개가 안 채워지기도 하지 않나?
- `List`가 맞나, 스택 느낌인데. 크기를 미리 주나?
- 끝 4개를 `&&`로 보고 `RemoveRange` 하면 되나?
- 다른 사람은 `Stack`, `RemoveAt`을 쓰더라.

## 막혔던 지점
- 개수(`빵/2`, 야채, 고기 `Min`)는 순서를 무시한다. 예2는 재료가 있어도 `1-2-3-1`이 안 붙어 정답 0인데, 개수면 2가 나온다.
- `ingredientCount[4]`의 `[0]`은 항상 0이라 `Min()`하면 예1도 0.
- 가운데를 잘라 왼쪽·오른쪽을 붙인다고 보면 `3+1` 같은 표를 만들어야 한다. 앞에서부터 쌓으면 완성되는 위치는 항상 맨 위 4개라 그 표가 필요 없다.
- 빼면 통이 짧아지고, 아래에 남은 빵이 끝 쪽으로 올라온다. 다음에 `2,3,1`이 붙는 상호작용은 **끝 4개 검사 한 번**에 들어간다. 배열 앞부터 다시 도는 게 아니다.

## 문제 한 줄
재료를 쌓다가 위가 빵-야채-고기-빵(`1-2-3-1`)이면 포장. 빠지면 아래와 다음 재료가 붙는다. 포장 개수.

## 핵심 패턴
```text
pack에 하나씩 Add
Count >= 4 이고 끝 4개가 1,2,3,1 이면 RemoveRange 4개, answer++
```

예1: `[2,1,1,2,3,1]`에서 끝 4개 제거 → `[2,1]`. 그다음 `2,3,1` → 남은 `1`과 붙어 두 번째 포장.

`ingredient` 길이 최대 100만. 문자열 `"1231"` 반복 삭제는 피한다.

## 제출 코드
```csharp
List<int> pack = new List<int>(ingredient.Length);
for (int i = 0; i < ingredient.Length; i++)
{
    pack.Add(ingredient[i]);
    if (pack.Count >= 4
        && pack[pack.Count - 4] == 1
        && pack[pack.Count - 3] == 2
        && pack[pack.Count - 2] == 3
        && pack[pack.Count - 1] == 1)
    {
        pack.RemoveRange(pack.Count - 4, 4);
        answer++;
    }
}
```

`pack`은 쌓는 통. `Count - 4`가 아래 빵, `Count - 1`이 위 빵. `Count >= 4`를 빼면 초반 인덱스 오류. 용량 `ingredient.Length`는 100만에서 배열 늘리기 복사 감소.

넣은 직후 한 번만 보면 된다. 완성된 햄버거 위에 재료가 쌓이지 않으므로 뺀 뒤 `while`은 필요 없다.

## 대안별 구현 비교

같은 통. 끝 4개를 보고 지우는 API만 다름. `n = 100만`에서 끝을 건드리면 속도는 비슷.

| | A List + RemoveRange (제출) | B RemoveAt 네 번 | C Stack |
|---|---|---|---|
| 확인 | `pack[Count-4]` ~ `[Count-1]` | 동일 | 네 번 `Pop` |
| 삭제 | `RemoveRange(Count-4, 4)` | 끝에서 `RemoveAt` 네 번 | 맞으면 그대로, 아니면 다시 `Push` |
| 주의 | 끝만 지우면 됨 | 가운데 `RemoveAt`은 뒤를 전부 당김 | `Pop` 순서가 위 빵부터라 1-2-3-1을 거꾸로 맞추기 쉬움 |

C# `Stack<int>`는 끝 네 칸을 인덱스로 못 본다. `List`를 스택처럼 쓰는 쪽이 덜 꼬인다.

### A. List + RemoveRange (제출)
위 제출 코드.

### B. RemoveAt 네 번
끝에서만 지울 때:
```csharp
pack.RemoveAt(pack.Count - 1);
pack.RemoveAt(pack.Count - 1);
pack.RemoveAt(pack.Count - 1);
pack.RemoveAt(pack.Count - 1);
```

### C. Stack
```csharp
Stack<int> pack = new Stack<int>();
pack.Push(ingredient[i]);
if (pack.Count >= 4)
{
    int topBread = pack.Pop();
    int meat = pack.Pop();
    int vegetable = pack.Pop();
    int bottomBread = pack.Pop();
    if (bottomBread == 1 && vegetable == 2 && meat == 3 && topBread == 1)
        answer++;
    else
    {
        pack.Push(bottomBread);
        pack.Push(vegetable);
        pack.Push(meat);
        pack.Push(topBread);
    }
}
```

## 다음에 볼 것
- 연속 패턴이 빠지면 앞뒤가 붙음 → 통에 넣고 끝만 보기.
- 개수 `Min`은 순서가 있는 조합에 쓰지 않기.
- `List` 끝 삭제: `RemoveRange`. `Stack`은 Pop 순서.
