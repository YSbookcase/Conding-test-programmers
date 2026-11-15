# 나누어 떨어지는 숫자 배열 (12910)

## 상태
- 제출 성공은 확인하지 못함. 수정 후 예제 세 개는 맞았고 LocalTest 빌드도 됨
- 연습 파일: `LocalTest/Program.cs`. `List`에 `Add`하고, 개수가 0이면 `[-1]`, 아니면 `Sort` 후 `ToArray`
- 공식 폴더가 없어 `프로그래머스/KYS24/나누어떨어지는숫자배열_notes.md`에 둠. 폴더가 생기면 그쪽으로 옮긴다

## 내가 한 질문
- 로컬테스트에 작성했으니 확인해줘. 조언도.
- 수정 전에 본 것이니 다시 확인해줘.
- `List` 개수로 보는 게 낫겠다. 배열을 새로 만드는 편이 더 좋나, `Add`로 넣는 편이 좋나. `ToArray()`가 없으면 더 괜찮은가?
- 추가로 조언할 것이 있나?
- LINQ를 쓰면 배열도 `Count()`로 개수를 구하나?

## 막혔던 지점
- 첫 코드는 맨 아래 `}`가 하나 더 있어 컴파일이 안 됐다. `% divisor == 0`으로 거르는 것은 맞았다.
- 정렬이 없고, 하나도 없을 때 빈 배열을 반환했다. `[5, 9, 7, 10]`과 `5`는 고른 순서가 이미 `5`, `10`이라 정렬 없이도 맞았다. `[2, 36, 1, 3]`과 `1`은 `[2, 36, 1, 3]`이 나왔고 정답은 `[1, 2, 3, 36]`이다. `[3, 2, 6]`과 `10`은 빈 배열이었고 정답은 `[-1]`이다.
- `ishave`는 값을 넣었는지 보는 플래그였다. `result.Count == 0`과 같다. 이름은 `hasDivisible`처럼 `has`로 시작하는 편이 읽기 쉽다.
- 나누어 떨어지는 개수는 돌기 전에는 모른다. `List`에 통과한 값만 `Add`하는 쪽이 맞다. 반환 타입은 `int[]`라 마지막에 배열이 필요하다. `ToArray()`는 `List`를 그 배열로 복사한다. 배열을 직접 만들면 `ToArray()` 대신 같은 복사를 손으로 한다. 원본 `arr`은 길이도 내용도 달라서 그대로 반환하지 않는다.
- 채점 코드에는 `using System.Collections.Generic;`가 있어야 `List`를 쓴다. LINQ는 `using System.Linq;`이 필요하다.
- 배열 개수는 `Length`다. LINQ의 `arr.Count()`는 괄호 있는 메서드이고 `Length`와 같다. `arr.Count(number => number % divisor == 0)`은 조건에 맞는 개수만 센다. `List`의 `result.Count`는 괄호 없는 속성이다. `Where` 결과에 `Count()`를 호출하면 그 목록을 한 번 훑는다. `ToArray()`로 만든 뒤에는 `Length`를 본다.
- 인덱스를 쓰지 않으면 `foreach (int number in arr)`로 원소만 본다. `arr`의 원소는 자연수다. `-1`은 입력 값이 아니라, 나누어 떨어지는 수가 없을 때만 반환하는 표시다.

## 문제 한 줄
`divisor`로 나누어 떨어지는 값을 오름차순으로 반환한다. 하나도 없으면 `[-1]`을 반환한다.

## 핵심 패턴
```text
나누어 떨어지면 result에 Add
Count가 0이면 return { -1 }
Sort
return ToArray()
```
- `[5, 9, 7, 10]`, `5` → `[5, 10]`
- `[2, 36, 1, 3]`, `1` → `[1, 2, 3, 36]`
- `[3, 2, 6]`, `10` → `[-1]`

## 대안별 구현 비교

수정 후 세 예제는 같다. 정렬이 없으면 두 번째 예제의 순서가 달라지고, `-1`이 없으면 세 번째 예제가 빈 배열이 된다. 개수를 먼저 세고 배열을 만드는 것과 LINQ도 결과는 같다.

### A. `List`에 `Add`
LocalTest에 둔 버전. 개수를 모르므로 통과한 값만 담는다.

```csharp
using System.Collections.Generic;

public class Solution {
    public int[] solution(int[] arr, int divisor) {
        List<int> result = new List<int>();
        foreach (int number in arr)
        {
            if (number % divisor == 0)
            {
                result.Add(number);
            }
        }

        if (result.Count == 0)
        {
            return new int[] { -1 };
        }

        result.Sort();
        return result.ToArray();
    }
}
```

### B. 개수를 먼저 세고 배열 생성
결과는 A와 같다. 배열을 두 번 본다. `ToArray()` 대신 칸을 직접 채운다.

```csharp
public class Solution {
    public int[] solution(int[] arr, int divisor) {
        int count = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] % divisor == 0)
            {
                count++;
            }
        }

        if (count == 0)
        {
            return new int[] { -1 };
        }

        int[] answer = new int[count];
        int index = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] % divisor == 0)
            {
                answer[index] = arr[i];
                index++;
            }
        }

        System.Array.Sort(answer);
        return answer;
    }
}
```

### C. LINQ `Where`와 `OrderBy`
결과는 A와 같다. `ToArray()` 뒤의 개수는 `Length`다. `using System.Linq;`이 필요하다.

```csharp
using System.Linq;

public class Solution {
    public int[] solution(int[] arr, int divisor) {
        int[] answer = arr.Where(number => number % divisor == 0).OrderBy(number => number).ToArray();
        if (answer.Length == 0)
        {
            return new int[] { -1 };
        }
        return answer;
    }
}
```

## 다음에 볼 것
- 첫 예제만 보면 정렬이 빠져도 맞다. 순서가 뒤섞인 예제와 빈 결과 예제를 같이 본다.
- 거를 때는 `List.Add`. 반환이 `int[]`이면 마지막에 `ToArray()`로 복사한다.
- 배열 개수는 `Length`, LINQ 메서드는 `Count()`, `List` 속성은 `Count`다.
