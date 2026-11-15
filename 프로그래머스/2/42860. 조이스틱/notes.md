# 조이스틱 (42860)

## 상태
- 제출 완료. 정확성 100, 메모리 46.1 MB, 시간 0.19 ms
- 제출 파일: `프로그래머스/2/42860. 조이스틱/조이스틱.cs`
- 탐욕법. LocalTest에서 `Min` 인자를 잘못 넣은 뒤 고침

## 내가 한 질문
- 좌우의 `A` 처리는 처음 변경 후 왼쪽을 먼저 가느냐, 오른쪽으로 계속 가느냐의 차이인가
- 되돌릴 지점은 어떻게 찾나. `A` 구간이 여러 개일 수 있다
- 시작하자마자 끝으로 가서 역으로만 올라가는 경우도 있지 않나
- 세 방향으로 구성하면 모든 경로가 대응되나
- 앞이나 뒤에 `A`가 이어져 도중에 끝날 수 있나. 그 값은 `moveRightThenLeft`, `moveLeftThenRight`에 있나
- 루프가 끝난 `moveCount`가 최솟값인가. `nextIndex`와 두 이동 비용은 칸마다 바뀌나
- `while`이 같은 구간을 다시 보는 것 같다. 더 줄여야 하나
- 로컬 코드 확인. `Min` 작성 실수가 있었나

## 막혔던 지점
- `"JAN"`처럼 한쪽만 고치면 방향 선택으로 끝난다. 양쪽에 고칠 글자가 있으면 한쪽을 끝낸 뒤 시작점으로 돌아와 반대쪽을 간다.
- 빼는 것은 `A` 한 글자가 아니다. 들르지 않아도 되는 연속 구간이고, 한 경로에서는 그 구간을 하나만 뺀다. 두 구간을 동시에 빼면 그 사이의 글자가 이어지지 않는다.
- 되돌릴 칸은 미리 정하지 않는다. 모든 `index`를 「오른쪽에서 마지막으로 들르는 칸」으로 두고, 바로 뒤의 `A`만 `nextIndex`로 건너뛴다.
- 시작하자마자 끝으로 가서 역으로만 가는 경로는 `index = 0`일 때 `moveRightThenLeft`다. 왕복이 없다. 끝에 도착한 뒤 오른쪽을 다시 덮을 때만 그 거리를 두 배로 친다.
- 앞이나 뒤의 `A` 때문에 일찍 멈추는 값도 두 식 안에 있다. 뒤가 `A`이면 `nextIndex`가 길이와 같아져 왼쪽 우회가 0이다. `"JJA"`는 오른쪽으로 1번만 간다.
- `moveCount`는 마지막 칸의 비용이 아니다. 칸마다 두 비용을 새로 구하고, 더 작을 때만 갱신한다. `"JAN"`은 `index = 0`에서 1이 된 뒤 3, 4, 2가 나와도 1을 유지한다.
- `Min`에 `moveRightThenLeft`를 두 번 넣으면 `moveLeftThenRight`가 빠진다. `"JEROEN"` 56, `"JAN"` 23은 그대로 맞다. `"JJA"`는 19가 20이 되고, `"BBBBAAAABA"`는 12가 13이 된다.
- `while`은 앞 칸이 이미 본 `A` 구간의 뒤를 다시 밟는다. 길이가 20 이하라 전체를 합쳐도 수백 번이라 줄이지 않았다.

## 문제 한 줄
`A`로 채워진 칸에서 목표 이름을 만드는 위아래·좌우 조작의 최솟값. 위아래는 글자마다 고정이고, 좌우는 고쳐야 하는 칸을 모두 지나는 최단 이동이다.

## 핵심 패턴
```text
위아래는 글자마다 min(위로, 아래로). A는 0, Z는 1
moveCount 초기값 = 길이 - 1. 한 방향 직진
각 index에서 뒤의 A를 건너뛴 nextIndex를 구함
오른쪽 갔다가 왼쪽: index * 2 + (길이 - nextIndex)
왼쪽 갔다가 오른쪽: (길이 - nextIndex) * 2 + index
셋 중 최솟값 + 위아래 합
```

```csharp
int changeCount = 0;
int moveCount = name.Length - 1;

for (int index = 0; index < name.Length; index++)
{
    int up = name[index] - 'A';
    int down = 'Z' - name[index] + 1;
    changeCount += Math.Min(up, down);

    int nextIndex = index + 1;
    while (nextIndex < name.Length && name[nextIndex] == 'A')
        nextIndex++;

    int moveRightThenLeft = index * 2 + (name.Length - nextIndex);
    int moveLeftThenRight = (name.Length - nextIndex) * 2 + index;
    moveCount = Math.Min(moveCount, Math.Min(moveRightThenLeft, moveLeftThenRight));
}

return changeCount + moveCount;
```

`"JAN"`의 좌우 후보는 이렇다. 위아래 22번에 이동 1번을 더해 23이다.

| index | nextIndex | 오른쪽 갔다가 왼쪽 | 왼쪽 갔다가 오른쪽 | moveCount |
|---|---|---|---|---|
| 0 | 2 | 1 | 2 | 1 |
| 1 | 2 | 3 | 3 | 1 |
| 2 | 3 | 4 | 2 | 1 |

`"JEROEN"`에는 `A`가 없어 직진 5가 남는다. 위아래 51과 더해 56이다.

## 다음에 볼 것
- 기본 예제는 오른쪽을 갔다가 왼쪽으로 가는 식만으로도 맞다. 제출 전에는 `"JJA"` 19, `"BBBBAAAABA"` 12를 본다.
- 길이가 1이면 초기 `moveCount`가 0이다. `"A"`는 0, `"J"`는 9다.
- 가까운 `A`가 아닌 칸만 반복해서 찾는 방식으로 줄이면, 왼쪽을 먼저 가야 하는 경우를 놓친다.
