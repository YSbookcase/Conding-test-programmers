# 배달 (12978)

## 상태
- 제출 완료. 정확성 100, 합계 100. 메모리 45.6 MB, 시간 1.76 ms
- 제출 파일: `프로그래머스/2/12978. 배달/배달.cs`
- Summer/Winter Coding(~2018)
- 연습은 `LocalTest/Program.cs`. 제출본과 같은 배치다
- 매개변수는 `N`, `K`다. 선언한 이름 그대로 함수 안에서 쓴다
- `pick`은 고른 마을 번호가 아니다. 마을을 `N`번 고르려고 센 횟수다. 고른 마을은 `current`다

## 내가 한 질문
- 게임 맵처럼 너비 우선으로 노드를 확인하고, 길이를 구한 뒤 개수를 늘리면 되나?
- `bool` 배열의 기본값은?
- 문제 설명이 `N`, `K` 대문자다. 매개변수도 대문자로 받아야 하나?
- 매개변수 이름이 대문자면 함수 안에서도 대문자여야 값이 맞지 않나?
- `pick`은 무엇을 의미하나?
- 처음에는 `dist[1]`이 `0`이라 `current`가 `1`이 되고, 1번이 `true`가 되나?
- `graph[current]`는 직접 만드는 건가?
- 양쪽으로 `Add`하는 것은 양방향인가? 겹치지는 않나?
- `isVisited`의 `true` 개수만 세면 되나?
- 로컬 코드에 문제가 있나?
- 어느 줄인지 코드로 보여 달라
- 수정본을 다시 봐 달라
- 추가로 볼 점이 있나?

## 막혔던 지점
- 세는 것은 1번 마을에서 각 마을까지 가장 짧은 배달 시간이 `K` 이하인 마을의 수다. 1번은 시간이 `0`이라 포함된다. 예제 1은 `1, 2, 4, 5`라서 `4`다.
- 게임 맵은 한 칸이 `1`이라 큐에서 처음 꺼낸 거리가 최단이었다. 이 문제는 도로마다 시간이 다르다. 아직 확정하지 않은 마을 중 시간이 가장 짧은 마을을 고르고, 이웃에 적힌 시간보다 작을 때만 고친다.
- `new bool[N + 1]`의 기본값은 전부 `false`다. `true`는 `isVisited[current] = true`로 넣은 마을뿐이다. 그 `true`는 최단 시간을 확정했다는 뜻이다.
- 문제 설명의 대문자와 코드 이름이 따로 연결되지는 않는다. `solution(int N, int[,] road, int K)`로 받았으면 안에서는 `N`, `K`다. `n`, `k`로 받았으면 안에서는 `n`, `k`다. 채점은 순서와 타입 `int`, `int[,]`, `int`를 본다.
- 첫 바퀴의 `dist[1]`만 `0`이고 나머지는 `int.MaxValue`다. `current`는 `0`에서 시작하고 `dist[0]`도 `int.MaxValue`라, `0 < int.MaxValue`가 되어 `current`는 `1`이 된다. 그다음 `isVisited[1] = true`다. 이어서 1번에 연결된 마을의 `dist`를 고친다.
- `graph`는 `road`로 검색 전에 만든다. 마을 번호가 1부터라 길이는 `N + 1`이고, 각 칸은 `new List`로 비워 둔다. `road` 한 줄의 `0, 1, 2`칸이 두 마을과 시간이다.
- `graph[from].Add((to, time))`와 `graph[to].Add((from, time))`은 도로 하나를 양쪽 목록에 넣는 것이다. `[1, 2, 1]`이면 `graph[1]`에는 `(2, 1)`, `graph[2]`에는 `(1, 1)`만 생긴다. 입력은 같은 도로의 반대 방향을 다시 주지 않는다. 시간이 다른 도로가 둘이면 둘 다 남고, `nextDist < dist[next]`가 더 짧은 시간만 `dist`에 남긴다.
- `isVisited`를 세면 안 된다. 마을은 모두 이어져 있어서 끝나면 `true`가 `N`개가 된다. 예제 1은 마을이 5개라 `isVisited`는 5개이고, 시간이 3 이하인 마을은 4개다. 세는 조건은 `dist[village] <= K`다.
- `isVisited[current] = true`와 `foreach`가 마을을 고르는 `for` 안에 있으면, 마을을 하나 볼 때마다 그때의 `current`를 확정한다. 1번이 확정된 다음 바퀴에서 `current`는 `0`으로 남고 `graph[0]`을 탄다. `graph[0]`은 만들지 않아서 `NullReferenceException`이 난다. 예제 1과 예제 2 모두 여기서 멈췄다.
- `foreach`만 밖으로 내리고 `isVisited[current] = true`가 안쪽 `for`에 남아 있어도 같은 예외가 났다. 1번부터 `N`번까지 비교가 끝난 뒤에 그 줄을 한 번 실행해야 한다.
- 개수 반복이 `village < N`이면 마지막 마을이 빠진다. 예제 1의 5번은 시간이 `3`이라 포함되고, 1번부터 4번만 세면 `3`이 된다. 답은 `4`다. 조건은 `village <= N`이다.
- `dist[0]`은 마을이 아니다. `int.MaxValue`로 “아직 고른 마을이 없다”는 비교 기준이다. 개수는 1번부터 센다.
- 예제 2에서 빠지는 마을은 4번과 6번이다. 둘 다 시간이 `5`라 `K = 4` 밖이다. `3`번과 `5`번 도로는 시간 `2`와 `3`이 같이 있고, 비교가 `2`를 남긴다.

## 문제 한 줄
1번 마을에서 배달 시간이 `K` 이하인 마을의 수. 마을은 1 이상 50 이하, 도로는 양방향이고 시간이 있다. 예제 둘 다 답은 `4`.

## 핵심 패턴
```text
graph[마을]에 (이어진 마을, 시간)을 양쪽으로 넣는다
dist는 int.MaxValue, dist[1] = 0
N번 반복
  확정되지 않은 마을 중 dist가 가장 짧은 current를 고른다
  isVisited[current] = true
  이어진 마을의 dist를 더 작을 때만 고친다
dist[village] <= K 인 마을 수를 반환
```

```csharp
isVisited[current] = true;

foreach ((int next, int time) in graph[current])
{
    int nextDist = dist[current] + time;
    if (nextDist < dist[next])
        dist[next] = nextDist;
}
```

이 두 블록은 마을을 찾는 `for`가 끝난 뒤에 둔다.

- `N = 5`, `K = 3` → `4`. 시간은 `0, 1, 4, 2, 3`
- `N = 6`, `K = 4` → `4`. `4`번과 `6`번은 `5`

## 대안별 구현 비교

A가 제출본이다. B는 확정 줄이 마을을 찾는 `for` 안에 있어 예제에서 예외가 난다. 개수 조건 `village < N`은 거리 계산이 맞아도 예제 1이 `3`이 된다.

| 방법 | 예제 1 | 예제 2 |
|---|---|---|
| A. 비교가 끝난 뒤 확정, `village <= N` | `4` | `4` |
| B. 마을을 하나 볼 때마다 확정 | `graph[0]`에서 예외 | 같은 예외 |
| 개수만 `village < N` | `3`. 5번이 빠진다 | 6번이 빠져 예제와 다르게 맞을 수 있다 |

### B. 확정이 안쪽 반복 안에 있음

```csharp
for (int village = 1; village <= N; village++)
{
    if (!isVisited[village] && dist[village] < dist[current])
        current = village;

    isVisited[current] = true;

    foreach ((int next, int time) in graph[current])
    {
        int nextDist = dist[current] + time;
        if (nextDist < dist[next])
            dist[next] = nextDist;
    }
}
```

1번을 확정한 다음 바퀴의 첫 마을은 이미 확정이라 `current`가 `0`이다. `graph[0]`은 `null`이다.

## 다음에 볼 것
- 백지에서는 `graph`를 먼저 만들고, `isVisited[current] = true`를 마을 비교 `for`의 `}` 아래에 둔다.
- 확인할 값은 예제 둘의 `4`다. 1번은 시간 `0`으로 포함되고, `isVisited`의 개수는 세지 않는다.
- 게임 맵은 칸 비용이 `1`이라 처음 도착이 최단이다. 도로 시간이 제각각이면 가장 짧은 `dist`를 가진 마을을 다음에 고른다.
