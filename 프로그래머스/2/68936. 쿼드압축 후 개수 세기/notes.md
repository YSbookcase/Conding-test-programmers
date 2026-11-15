# 쿼드압축 후 개수 세기 (68936)

## 상태
- 제출 완료. 정확성 100, 합계 100. 메모리 66.6 MB, 시간 11.63 ms
- 제출 파일: `프로그래머스/2/68936. 쿼드압축 후 개수 세기/쿼드압축 후 개수 세기.cs`
- 월간 코드 챌린지 시즌1. LocalTest에서 지역 함수로 작성해 제출
- 제출본은 `zeroCount`, `oneCount`를 `solution`의 지역 변수로 둔다. `Compress`와 `IsSame`은 호출보다 위에 정의되어 있다

## 내가 한 질문
- 구획을 나눠 값이 같으면 합치는 것 같다. 모든 값을 계속 참조해야 하니 딕셔너리로 압축하면 되나
- 재귀인가. 내부 4개는 4분할의 1개씩을 맡나
- `IsSame`은 어떻게 구성되나
- 로컬 테스트에서 뭐가 문제인가
- 내부 함수를 아래에 두고, 정의와 호출과 반환을 위에 두는 배치가 맞나
- 사람들은 보통 어떻게 쓰나
- `zeroCount`와 `oneCount`를 밖에 선언하고 함수들이 같이 쓰나
- 함수 안에 함수를 두지 않아서 클래스 메서드가 흔한가
- 사용성과 표현의 차이이기만 한 건가
- 추가로 볼 점이 있나

## 막혔던 지점
- 압축 결과를 다른 자료구조에 다시 담을 필요가 없다. `arr`은 그대로 두고, 재귀에는 시작 행, 시작 열, 한 변 길이만 넘긴다. 문제는 트리 모양이 아니라 남은 0의 개수와 1의 개수만 묻는다.
- 같은 값인 구역은 칸이 여러 개여도 1이다. 예제 1의 오른쪽 위 2×2는 0이 네 칸이지만 0 하나다. 배열 전체의 0은 7칸이고, 답은 `[4, 9]`다.
- 전체가 섞여 있으면 한 변을 반으로 나눈 네 호출이 각 구역을 맡는다. 그 안이 같으면 거기서 끝나고, 섞여 있으면 다시 넷으로 나눈다. 한 칸은 항상 그 값 하나다.
- `IsSame`은 `arr[row, col]`을 기준으로 `size`칸씩 본다. 다른 값이 나오면 바로 거짓이다. 개수는 세지 않는다.
- LocalTest는 `zeroCount++` 전에 값이 없었다. 지역 변수는 0으로 둔 뒤에 더한다. `return new int[,]`는 2차원 배열이라 반환 타입 `int[]`와 맞지 않는다. `new int[] { zeroCount, oneCount }`다.
- 지역 함수는 `return` 아래에 두어도 된다. 그 자리에서 실행되는 문장이 아니라서다. 제출본은 소수 찾기와 같이 함수를 먼저 정의하고 호출과 반환을 아래에 두었다. 동작은 같다.
- 클래스 메서드가 흔한 이유는 함수 중첩을 피해서가 아니다. 재귀가 풀이 자체이고, 개수를 필드로 두면 `solution`에는 초기화와 호출과 반환만 남기 때문이다. 소수 찾기는 `solution` 안에 지역 함수를 둔다.
- 결과 개수는 같다. 지역 함수는 이번 호출의 `zeroCount`를 직접 보고, 호출이 끝나면 변수도 사라진다. 클래스 필드는 객체가 살아있는 동안 남으므로 `solution` 시작에서 0으로 다시 둔다. 빼먹으면 이전 테스트의 개수가 더해진다. `IsSame`은 어느 쪽이든 개수를 바꾸지 않는다.

## 문제 한 줄
한 변이 2의 거듭제곱인 0과 1 정사각형을 쿼드트리로 압축한 뒤, 남은 0의 개수와 1의 개수를 반환한다. 한 변은 1 이상 1024 이하.

## 핵심 패턴
```text
영역이 모두 같으면 그 값을 1개로 센다
섞여 있으면 한 변을 반으로 나눠 네 구역을 같은 함수로 본다
반환은 [0의 개수, 1의 개수]
```

```csharp
int half = size / 2;
Compress(arr, row, col, half);
Compress(arr, row, col + half, half);
Compress(arr, row + half, col, half);
Compress(arr, row + half, col + half, half);
```

네 호출의 순서를 바꿔도 개수는 같다. 한 칸은 `IsSame`이 참이라 `half`가 0이 되는 호출은 생기지 않는다.

| arr | 결과 | 확인 |
|---|---|---|
| `[[0]]` | `[1, 0]` | 한 칸 |
| `[[0, 0], [0, 0]]` | `[1, 0]` | 네 칸을 0 하나 |
| 예제 1 | `[4, 9]` | 오른쪽 위 2×2만 압축 |
| 예제 2 | `[10, 15]` | 더 큰 구역 |

2×2가 전부 0인데 `[4, 0]`이 나오면 블록이 아니라 칸 수를 더한 것이다.

## 대안별 구현 비교

답 배열은 같다. 제출본은 개수를 `solution`의 지역 변수로 두고 지역 함수가 그 변수를 더한다. 클래스 필드는 `Compress`가 필드를 더하고, `solution`이 시작할 때 0으로 맞춘다.

0으로 맞추지 않은 채 `solution`을 다시 부르면 B만 이전 개수가 남는다. A는 호출마다 지역 변수가 새로 생긴다.

| 방법 | 개수 위치 | 메모 |
|---|---|---|
| A. 지역 함수 | `solution` 지역 변수 | 제출본. 호출마다 0에서 시작 |
| B. 클래스 필드 | `Solution` 필드 | 시작에서 0으로 다시 둔다 |

### B. 클래스 필드

```csharp
public class Solution
{
    int zeroCount;
    int oneCount;

    public int[] solution(int[,] arr)
    {
        zeroCount = 0;
        oneCount = 0;
        Compress(arr, 0, 0, arr.GetLength(0));
        return new int[] { zeroCount, oneCount };
    }

    void Compress(int[,] arr, int row, int col, int size)
    {
        if (IsSame(arr, row, col, size))
        {
            if (arr[row, col] == 0)
                zeroCount++;
            else
                oneCount++;
            return;
        }

        int half = size / 2;
        Compress(arr, row, col, half);
        Compress(arr, row, col + half, half);
        Compress(arr, row + half, col, half);
        Compress(arr, row + half, col + half, half);
    }

    bool IsSame(int[,] arr, int row, int col, int size)
    {
        int startValue = arr[row, col];

        for (int currentRow = row; currentRow < row + size; currentRow++)
        {
            for (int currentCol = col; currentCol < col + size; currentCol++)
            {
                if (arr[currentRow, currentCol] != startValue)
                    return false;
            }
        }

        return true;
    }
}
```

## 다음에 볼 것
- 한 변이 1024여도 재귀 깊이는 10이다. 매번 반으로 줄고, 호출 한 번은 그 정사각형만 본다.
- 제출본 지역 함수의 `arr`은 바깥 `arr`과 같은 배열을 받는 매개변수다. `startValue`는 그 구역의 첫 칸이다.
