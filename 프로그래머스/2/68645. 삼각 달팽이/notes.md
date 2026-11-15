# 삼각 달팽이 (68645)

## 상태
- 제출 완료. 정확성 100, 합계 100. 메모리 83.1 MB, 시간 6.03 ms
- 제출 파일: `프로그래머스/2/68645. 삼각 달팽이/삼각 달팽이.cs`
- 월간 코드 챌린지 시즌1. LocalTest에서 배열 선언, 이동, 이어 붙이기를 한 함수로 붙여 제출

## 내가 한 질문
- 각 숫자에 위치를 맵핑하는 방법이 좋은가. 일반적인 방법은 뭔가
- 이미지가 있어야 하는구나
- 작성해준 코드도 결국 위치를 구하는 것과 같지 않나. `triangle`은 정의가 없고, 문제와 같다면 `int` 2차원 배열 같다
- 정의와 이어 붙이기를 그 코드 위아래에 붙이면 답이 나오나
- 추가로 볼 점이 있나

## 막혔던 지점
- 채우는 순서는 본문 문장이 아니라 `examples.png`의 삼각형이 정한다. 맨 위 1에서 아래, 오른쪽, 왼쪽 위 순서로 돈다.
- 숫자마다 행·열을 정하는 것이 맞다. 그 위치를 담는 곳이 `triangle`이다. 칸의 기본값이 0이고 숫자는 1부터라, 0인 칸이 아직 안 넣은 칸이다. 좌표 딕셔너리는 없다.
- 첫 코드 조각에는 배열 선언과 반환용 이어 붙이기가 없었다. 선언을 위, 이어 붙이기를 아래에 두면 예제 답이 나온다.
- 행마다 칸 수가 달라 `int[][]`다. `triangle[line]`의 길이는 `line + 1`이다. 직사각형 `int[,]`로 두면 인덱스는 `triangle[row, col]`이고, 쓰는 칸은 `col <= row`뿐이다.
- 다음 칸이 밖이거나 0이 아니면 방향을 한 번만 바꾼다. 마지막 숫자를 넣은 뒤의 이동은 반복이 끝나서 그 칸을 읽지 않는다.

## 문제 한 줄
높이 `n`인 삼각형을 맨 위부터 반시계로 채운 뒤, 첫 행부터 이어 붙인 배열을 반환한다. `n`은 1 이상 1000 이하.

## 핵심 패턴
```text
행 길이는 1, 2, ..., n
방향은 아래, 오른쪽, 왼쪽 위
칸에 1부터 넣고, 막히면 방향을 한 번 바꾼다
첫 행부터 이어 붙인다
```

```csharp
int[] rowDelta = { 1, 0, -1 };
int[] colDelta = { 0, 1, -1 };
int lastNumber = n * (n + 1) / 2;
```

`n = 4`는 아래 4칸, 오른쪽 3칸, 왼쪽 위 2칸, 아래 1칸이다. 이어 붙이면 `[1, 2, 9, 3, 10, 8, 4, 5, 6, 7]`.

| n | 결과 |
|---|---|
| 1 | `[1]` |
| 4 | `[1, 2, 9, 3, 10, 8, 4, 5, 6, 7]` |
| 5 | `[1, 2, 12, 3, 13, 11, 4, 14, 15, 10, 5, 6, 7, 8, 9]` |

칸 수는 `n * (n + 1) / 2`다. 곱을 먼저 한다. `n`이 5일 때 `5 / 2 * 6`은 12가 되어 칸 3개가 빠진다. `n`이 1000이어도 칸 수는 500500이라 `int`에 들어간다.

## 대안별 구현 비교

답 배열은 같다. 제출본은 다음 칸이 막히면 방향을 바꾸고, 칸 수를 줄이는 방식은 아래 `n`칸, 오른쪽 `n - 1`칸처럼 길이를 미리 정한다. 둘 다 칸 수만큼만 돈다.

길이가 하나 어긋나면 B는 배열 밖을 쓴다. A는 막힌 칸을 보고 방향을 바꾼다. 방향을 `while`로 계속 바꾸면 마지막 숫자 뒤에서 세 방향이 모두 막혀 인덱스를 벗어난다.

| 방법 | 이동 | 메모 |
|---|---|---|
| A. 막히면 전환 | 다음 칸이 밖이거나 0이 아니면 방향 한 번 변경 | 제출본. 빈 칸은 0 |
| B. 길이를 1씩 줄임 | `n`칸부터 1칸까지, 세 방향 반복 | 0을 보지 않음. 길이 오차 시 배열 밖 |

### B. 길이를 1씩 줄임

```csharp
public int[] solution(int n)
{
    int[][] triangle = new int[n][];
    for (int line = 0; line < n; line++)
        triangle[line] = new int[line + 1];

    int[] rowDelta = { 1, 0, -1 };
    int[] colDelta = { 0, 1, -1 };
    int row = 0;
    int col = 0;
    int number = 1;
    int direction = 0;

    for (int length = n; length >= 1; length--)
    {
        for (int step = 0; step < length; step++)
        {
            triangle[row][col] = number++;
            if (step == length - 1)
                break;

            row += rowDelta[direction];
            col += colDelta[direction];
        }

        direction = (direction + 1) % 3;
        row += rowDelta[direction];
        col += colDelta[direction];
    }

    int[] answer = new int[number - 1];
    int index = 0;
    for (int line = 0; line < n; line++)
    {
        for (int column = 0; column < triangle[line].Length; column++)
            answer[index++] = triangle[line][column];
    }

    return answer;
}
```

## 다음에 볼 것
- `n = 1`이 `[1]`이 아니면 마지막 이동에서 배열 밖을 읽고 있는 것이다.
- 제출본의 `line`은 행 번호, `column`은 그 행 안의 열이다. `rowDelta`와 `colDelta`의 같은 인덱스가 한 방향이다.
