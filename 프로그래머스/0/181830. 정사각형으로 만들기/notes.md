# 정사각형으로 만들기 (181830)

## 내가 한 질문
- 빈 칸에 0을 직접 넣지 않고, 더 긴 변 길이로 틀을 만든 뒤 `arr`를 덮어쓰는 방향이 맞는가?
- 초기 코드에서 `result` 스코프 / 행==열 미처리 문제는?

## 막혔던 지점 및 개념 정리
- **문제 의미**: 직사각형 `arr`를 **더 긴 쪽 길이**에 맞춰 정사각 행렬로 패딩(부족한 쪽은 0).
  - 행 > 열 → 각 행 끝에 0 추가 (열을 행 길이에 맞춤)
  - 열 > 행 → 아래에 0 행 추가 (행을 열 길이에 맞춤)
  - 행 == 열 → 그대로 반환
- **좋은 접근**: `size = max(행, 열)`인 `new int[size, size]`를 만들면 `int` 기본값이 0이므로 **패딩을 따로 채울 필요 없음**. 원본만 복사하면 됨.
- **초기 코드 문제**:
  - `result`를 `if` / `else if` **안에서** 선언 → `return result`에서 스코프 밖.
  - 행 == 열인 경우 분기가 없어 반환할 배열이 없음 → `return arr` 필요.
- **분기 단순화**: 행이 길든 열이 길든 복사 로직은 동일하므로 `Math.Max`로 size만 정하면 `if/else`로 배열 크기를 나눌 필요 없음.

## 핵심 코드

### 최종 제출 ⭐
```csharp
using System;

public class Solution {
    public int[,] solution(int[,] arr) {
        int row = arr.GetLength(0);
        int col = arr.GetLength(1);

        if (row == col) {
            return arr;
        }

        int size = Math.Max(row, col);
        int[,] result = new int[size, size]; // 나머지 칸은 기본값 0

        for (int i = 0; i < row; i++) {
            for (int j = 0; j < col; j++) {
                result[i, j] = arr[i, j];
            }
        }

        return result;
    }
}
```

## 아이디어 요약
| 단계 | 내용 |
|---|---|
| 1 | `row`, `col` 구하기 (`GetLength`) |
| 2 | 같으면 원본 반환 |
| 3 | `size = Math.Max(row, col)` 정사각 생성 |
| 4 | 원본 영역만 복사 (패딩은 0 자동) |

## 다음에 볼 것
- `int[,]` 패딩 문제는 **큰 배열(기본 0) + 부분 복사**가 단순하고 안전
- 지역 변수는 **사용할 스코프 바깥**에서 선언해야 `return` 가능
- `Math.Max` / `Math.Abs` 등은 `using System;`만으로 사용 가능
