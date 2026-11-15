# 행렬의 덧셈 (12950)

## 상태
- 제출 완료. `int[,]`의 같은 칸을 더함
- 제출 파일: `프로그래머스/1/12950. 행렬의 덧셈/행렬의 덧셈.cs`
- LocalTest: `LocalTest/Program.cs`에 같은 반복. gitignore라 커밋되지 않음. `Main`은 비어 있음

## 내가 한 질문
- LocalTest에 작성한 코드를 확인해 달라.
- 더 개선할 지점이 있나?

## 막혔던 지점
- 막힌 오류는 없다. 같은 위치끼리 더하는 반복이 답이다.
- `GetLength`를 반복 밖으로 빼도 더하는 횟수는 같다. 행과 열이 500 이하라 최대 25만 칸이고, 호출만 줄어서 체감되지 않는다.
- 결과의 모든 칸이 두 행렬의 합이라, 칸마다 한 번씩 더하는 것이 하한이다.

## 문제 한 줄
크기가 같은 두 행렬의 같은 행, 같은 열을 더한다.

## 핵심 패턴
```text
answer = new int[행, 열]
answer[i, j] = arr1[i, j] + arr2[i, j]
```
- `GetLength(0)`이 행, `GetLength(1)`이 열. `int[,]`라 열 크기가 모든 행에서 같다.
- 예제 `[[1,2],[2,3]]` + `[[3,4],[5,6]]` → `[[4,6],[7,9]]`
- `[[1],[2]]` + `[[3],[4]]` → `[[4],[6]]`
- 두 행렬 크기는 같다고 되어 있어 `arr2`의 길이는 따로 보지 않는다.
- 시간 O(행 × 열).

## 대안별 구현 비교

더하는 값과 횟수는 같다. 차이는 `GetLength`를 반복마다 부르느냐다.

### A. 반복 안에서 `GetLength`
제출한 버전.

```csharp
int[,] answer = new int[arr1.GetLength(0), arr1.GetLength(1)];
for (int i = 0; i < arr1.GetLength(0); i++)
{
    for (int j = 0; j < arr1.GetLength(1); j++)
    {
        answer[i, j] = arr1[i, j] + arr2[i, j];
    }
}
return answer;
```

### B. 행 수, 열 수를 먼저 저장
호출 횟수만 줄고, 합은 A와 같다.

```csharp
int rowCount = arr1.GetLength(0);
int colCount = arr1.GetLength(1);
int[,] answer = new int[rowCount, colCount];
for (int i = 0; i < rowCount; i++)
{
    for (int j = 0; j < colCount; j++)
    {
        answer[i, j] = arr1[i, j] + arr2[i, j];
    }
}
return answer;
```

## 다음에 볼 것
- `int[,]`는 `GetLength`. 줄마다 길이가 다르면 `int[][]`와 `.Length`.
- 모든 칸이 답에 필요하면 그 칸을 한 번씩 보는 반복이 끝이다.
