# 행렬의 곱셈 (12949)

## 상태
- 제출 완료. 정확성 100, 합계 100. 메모리 47.7 MB, 시간 2.22 ms
- 제출 파일: `프로그래머스/2/12949. 행렬의 곱셈/행렬의 곱셈.cs`
- 고득점 Kit 연습문제

## 내가 한 질문
- 생각보다 복잡하다. 4중 반복인가?
- 단순한데 백지에서 직접 쓰려면 쉽지 않다

## 막혔던 지점
- 반복은 세 겹이다. 바깥 둘은 결과 칸의 행과 열이고, 안쪽 하나가 그 칸의 곱의 합이다. 두 행렬의 행과 열을 각각 따로 돌리는 네 겹이 아니다.
- 결과 크기는 `arr1`의 행 수와 `arr2`의 열 수다. 이어 주는 길이는 `arr1`의 열 수이고, 이 값은 `arr2`의 행 수와 같다. 곱할 수 있는 배열만 들어온다.
- `index`는 `arr1`에서는 열, `arr2`에서는 행이다.
- 백지에서는 반복 세 개보다 결과 칸 하나의 식을 먼저 적는다. 예제 `(0, 0)`은 `1×3 + 4×3 = 15`다.
- 행과 열은 최대 100이라 세 겹이어도 계산량은 100만 번 안쪽이다.

## 문제 한 줄
`arr1`에 `arr2`를 곱한 행렬. 행·열 길이는 2 이상 100 이하. 원소는 -10 이상 20 이하.

## 핵심 패턴
```text
rowCount = arr1 행
colCount = arr2 열
sharedCount = arr1 열
answer[row, col] += arr1[row, index] * arr2[index, col]
```

```csharp
int rowCount = arr1.GetLength(0);
int sharedCount = arr1.GetLength(1);
int colCount = arr2.GetLength(1);
int[,] answer = new int[rowCount, colCount];

for (int row = 0; row < rowCount; row++)
{
    for (int col = 0; col < colCount; col++)
    {
        int sum = 0;

        for (int index = 0; index < sharedCount; index++)
        {
            sum += arr1[row, index] * arr2[index, col];
        }

        answer[row, col] = sum;
    }
}
```

- `[[1, 4], [3, 2], [4, 1]]`와 `[[3, 3], [3, 3]]` → 모든 칸 `15`
- `[[2, 3, 2], [4, 2, 4], [3, 1, 4]]`와 `[[5, 4, 3], [2, 4, 1], [3, 1, 1]]` → `[[22, 22, 11], [36, 28, 18], [29, 20, 14]]`

## 다음에 볼 것
- 백지 순서는 크기 세 개, 결과 배열, `row`와 `col`, 그다음 `index`다.
- `(0, 0)` 한 칸을 `1×3 + 4×3`으로 먼저 검산한다.
