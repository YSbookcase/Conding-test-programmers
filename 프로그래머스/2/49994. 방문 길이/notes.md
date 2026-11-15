# 방문 길이 (49994)

## 상태
- 제출 완료. 정확성 100, 메모리 48.2 MB, 시간 1.32 ms
- 제출 파일: `프로그래머스/2/49994. 방문 길이/방문 길이.cs`
- Summer/Winter Coding. 제출본은 명령 맵과 길 `HashSet`. LocalTest에 같은 코드를 작성함

## 내가 한 질문
- 좌표 이동은 쉬운데, 처음 걸어본 길을 중복 없이 세려면 어떻게 접근하나. `HashSet`이 떠오른다
- `dirs`를 맵핑해야 하나
- `HashSet` 개수를 `/2` 하면 되나
- 로컬 코드 확인
- 다른 사람 풀이가 길고 복잡해 보인다
- 프로그래머스 풀이 URL로 확인이 가능한가
- 붙여 넣은 두 풀이 비교

## 막혔던 지점
- 세는 것은 밟은 좌표가 아니라 두 좌표를 잇는 길이다. `"ULURRDLLU"`는 명령 9번이지만 8·9번은 2·3번 길을 되돌아와서 처음 길은 7이다.
- 같은 길을 반대 방향으로 걸어도 한 번이다. 출발·도착 문자열을 양방향으로 넣고 마지막에 `Count / 2`를 한다.
- 경계 `-5~5` 밖이면 이동도, 길 추가도 하지 않는다. `"LULLLLLLU"`는 왼쪽 끝에서 `L` 두 번이 무시되고 답은 7이다.
- `"UD"`는 같은 길을 왕복해서 1이다. `"UUUUUU"`는 `y = 5`에서 마지막 `U`가 무시되어 5이다.
- 프로그래머스 `solution_groups` URL은 로그인 세션이 없으면 풀이가 안 보인다. 코드를 붙여야 비교할 수 있다.
- 다른 풀이가 길어 보이는 이유는 길을 객체로 나누거나, 칸마다 4방향 표시를 두기 때문이다. 답이 더 나은 것은 아니다.

## 문제 한 줄
`(0, 0)`에서 `U`/`D`/`R`/`L`로 움직이며, 경계 안을 처음 지나간 길의 개수. 같은 길을 다시 걸으면 세지 않는다.

## 핵심 패턴
```text
명령 → (dx, dy) 맵
다음 칸이 -5~5 밖이면 continue
길 문자열을 양방향으로 HashSet에 넣음
위치 갱신
Count / 2
```

```csharp
HashSet<string> roads = new HashSet<string>();
int currentX = 0;
int currentY = 0;

Dictionary<char, int[]> moves = new Dictionary<char, int[]>
{
    ['U'] = new int[] { 0, 1 },
    ['D'] = new int[] { 0, -1 },
    ['R'] = new int[] { 1, 0 },
    ['L'] = new int[] { -1, 0 },
};

foreach (char direction in dirs)
{
    int nextX = currentX + moves[direction][0];
    int nextY = currentY + moves[direction][1];

    if (nextX < -5 || nextX > 5 || nextY < -5 || nextY > 5)
        continue;

    roads.Add($"{currentX},{currentY},{nextX},{nextY}");
    roads.Add($"{nextX},{nextY},{currentX},{currentY}");

    currentX = nextX;
    currentY = nextY;
}

return roads.Count / 2;
```

## 대안별 구현 비교

세 방법 모두 「새 길이면 1, 양방향을 같은 길」이다. 제출본이 가장 짧다.

| 방법 | 길 표현 | 처음인지 | 메모 |
|---|---|---|---|
| A. 문자열 `HashSet` | 출발·도착 양방향 | `Add` 후 `Count / 2` | 제출본. `dirs` 500 이하에 충분 |
| B. `Way`/`Position` 객체 | `Equals`에서 뒤집어도 같음 | `List.Any` | 클래스·Clone이 김. 비교는 길이에 비례 |
| C. 11×11 칸의 4방향 표시 | 좌표를 0~10으로 옮김 | 칸의 `u`/`d`/`l`/`r` | 문자열 없음. `switch`가 김 |

### B. Way Equals

`Equals`가 시작·끝을 뒤집어 같은 길로 친다. `List`를 매번 훑으므로 명령이 늘면 비교가 커진다. 이 제한 500에서는 통과한다.

```csharp
private bool Equals(Way other)
{
    return (Equals(Start, other.Start) && Equals(End, other.End))
        || (Equals(Start, other.End) && Equals(End, other.Start));
}
```

### C. 칸마다 4방향

위로 가면 현재 칸의 `u`와 위 칸의 `d`를 같이 찍는다. 새 길일 때만 `newpaths++`한다.

```csharp
Path[,] paths = new Path[11, 11];
int x = 5;
int y = 5;
int newPaths = 0;

// 'U'일 때
if (y < 10)
{
    if (paths[y, x].u == 0)
    {
        paths[y, x].u = 1;
        paths[y + 1, x].d = 1;
        newPaths++;
    }
    y++;
}
```

## 다음에 볼 것
- 제출 코드에는 `using System.Collections.Generic;`이 필요하다. 로컬 `ImplicitUsings`와 다르다.
- `Dictionary` 대신 `switch`로 `nextX`/`nextY`만 바꿔도 같다.
