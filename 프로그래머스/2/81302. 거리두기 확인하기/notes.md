# 거리두기 확인하기 (81302)

## 상태
- 제출 완료. 정확성 100, 합계 100. 메모리 45.9 MB, 시간 0.63 ms
- 제출 파일: `프로그래머스/2/81302. 거리두기 확인하기/거리두기 확인하기.cs`
- 2021 카카오 채용연계형 인턴십. `string[,]` + 방마다 `P` 주변 검사로 제출

## 내가 한 질문
- 작성해준 코드는 방향에 따라 `IsPerson`에 넣는 단계이고, 각 `P`의 1칸 탐색 예인가
- `IsPerson`이 2칸·대각 bool까지 판단하게 만드나
- 대각 4, 2칸 4, 1칸 4를 칸마다 조건문으로 두면 `for`로 구성 가능한가. 1칸은 가능해 보인다
- 거리 2 대각 표현이 애매하다. 맨해튼 거리 2인 대각인가
- 끼인 2칸은 무엇인가
- `false`가 아니라 괜찮으면 1, 아니면 0인 정수 배열이어야 한다
- 전체 모습은 어떻게 되나
- 문제는 `public int[] solution(string[,] places)`로 되어 있다
- 실제로 만나면 시간이 많이 걸릴 것 같다
- 처음 구한 것은 room 하나, 두 번째는 여러 룸인가
- 메모 정리해 달라

## 막혔던 지점
- `IsPerson`은 범위 안의 `P`인지만 본다. 거리 2·대각의 파티션 판단은 `IsPerson`이 참인 뒤 바깥에서 한다.
- 맨해튼 거리 2 대각도 `|행| + |열| = 2`이면서 행 1·열 1인 네 칸이다. `(r±2, c)`, `(r, c±2)` 직선과는 별개다.
- 끼인 두 칸은 대각 `P`와 `Q`를 잇는 가로·세로 한 칸씩이다. `P=(r,c)`, `Q=(r+1,c+1)`이면 `(r,c+1)`과 `(r+1,c)`이다. 코드에서는 `places[room, row][nextCol]`, `places[room, nextRow][col]`. 둘 다 `X`여야 허용이다.
- 안쪽은 `bool`로 두고, `solution`에서만 `1`/`0`으로 바꾼다. 사람 한 명이 위반이면 그 방 전체가 `0`이다.
- 프로그래머스 C#은 `string[][]`이 아니라 `string[,]`. 칸은 `places[room, row][col]`이다. 첫 예시 코드가 방 하나용 완성본이 아니라, 한 방을 `string[]`로 받는 형태였고, 시그니처에 맞게 방 번호를 같이 넘기도록 고친 것이다. 검사 규칙은 같다.
- 규칙은 세 가지뿐인데 코드가 길어 보인다. 시험에서는 거리 1 → 직선 2 → 대각 순으로 붙이는 편이 안전하다.

## 문제 한 줄
5×5 대기실 5개에서, 맨해튼 거리 2 이하인 `P`끼리 파티션 없이 있으면 그 방은 0, 지키면 1. 반환은 길이 5인 `int[]`.

## 핵심 패턴
```text
방마다
  각 P에 대해
    거리 1에 P → 실패
    거리 2 직선에 P인데 가운데가 X가 아님 → 실패
    거리 2 대각에 P인데 끼인 두 칸이 모두 X가 아님 → 실패
  통과면 1, 아니면 0
```

```csharp
answer[index] = IsKeepDistance(places, index) ? 1 : 0;
// places[room, row][col]
```

거리 1·직선 2는 같은 `rowDelta1`/`colDelta1`을 쓰고, 직선 2는 `* 2`와 가운데 `* 1`이다. 대각만 방향 배열이 따로 있다.

| 대기실 | 결과 | 확인 |
|---|---|---|
| 1 | 1 | 전부 지킴 |
| 2 | 0 | 인접·빈 테이블·바닥 옆자리 |
| 3~5 | 1 | 파티션 또는 응시자 없음 |

## 대안별 구현 비교

답 배열은 같다. 제출본은 세 경우를 직접 보고, BFS는 각 `P`에서 거리 2까지 퍼지며 `X`를 벽으로 둔다. 방 5×5라 둘 다 충분하다.

| 방법 | 구현 | 메모 |
|---|---|---|
| A. 주변 칸 직접 검사 | 거리 1·2 직선·대각 | 제출본. 경우만 외우면 됨 |
| B. BFS 거리 제한 | 큐, `X`는 이동 불가 | 경우 나눔이 줄고 큐 코드가 붙음 |

### B. BFS 거리 제한

```csharp
bool IsPersonSafe(string[,] places, int room, int startRow, int startCol)
{
    int[] rowDelta = { -1, 1, 0, 0 };
    int[] colDelta = { 0, 0, -1, 1 };
    bool[,] isVisited = new bool[5, 5];
    Queue<int[]> queue = new Queue<int[]>();

    queue.Enqueue(new int[] { startRow, startCol, 0 });
    isVisited[startRow, startCol] = true;

    while (queue.Count > 0)
    {
        int[] current = queue.Dequeue();
        int row = current[0];
        int col = current[1];
        int distance = current[2];

        if (distance >= 2)
            continue;

        for (int direction = 0; direction < 4; direction++)
        {
            int nextRow = row + rowDelta[direction];
            int nextCol = col + colDelta[direction];
            if (nextRow < 0 || nextRow >= 5 || nextCol < 0 || nextCol >= 5)
                continue;
            if (isVisited[nextRow, nextCol])
                continue;
            if (places[room, nextRow][nextCol] == 'X')
                continue;
            if (places[room, nextRow][nextCol] == 'P')
                return false;

            isVisited[nextRow, nextCol] = true;
            queue.Enqueue(new int[] { nextRow, nextCol, distance + 1 });
        }
    }

    return true;
}
```

## 다음에 볼 것
- 카카오 구현은 아이디어보다 조건을 코드로 옮기는 시간이 길다. 이 문제는 그 유형이다.
- 제출본의 `room`은 대기실 번호, `midRow`/`midCol`은 직선 거리 2의 가운데 칸이다.
