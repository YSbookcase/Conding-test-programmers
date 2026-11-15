# 최댓값과 최솟값 (12939)

## 상태
- 제출 완료. 한 번 순회로 제출. 정확성 100, 합계 100. 메모리 48 MB, 시간 0.83 ms
- 제출 파일: `프로그래머스/2/12939. 최댓값과 최솟값/최댓값과 최솟값.cs`
- 고득점 Kit 연습문제

## 내가 한 질문
- 한 번 순회하며 최대·최소를 담나, 배열로 만든 뒤 `Min`/`Max`를 쓰나? 변환하면서 비교하는 게 좋나?
- `min`과 `max`에 첫 값을 넣고 시작하나?
- `return min + " " + max`에서 `" "` 때문에 문자열이 되나?
- LINQ로 `string[]`가 아니라 `int[]`로 바꾸는 것은 어떤가?
- 다른 사람 풀이 `Select(int.Parse)`, `ToString()`, `temp`는 어떤가?

## 막혔던 지점
- 숫자로 바꾼 뒤 비교한다. 문자열인 채로 비교하면 `"-1"`이 `"-4"`보다 작다고 나와 최솟값을 놓친다.
- 첫 숫자를 `min`과 `max`에 같이 넣는다. 0으로 시작하면 음수 예제의 최댓값이 맞지 않는다. 반복은 두 번째 값, 인덱스 1부터다.
- 반복을 0부터 돌리려면 `min`은 `int.MaxValue`, `max`는 `int.MinValue`로 시작한다. 첫 숫자 시작과 0부터 반복을 섞으면 비교 기준이 어긋난다.
- `+`의 한쪽이 문자열이면 정수 쪽도 문자열로 바뀐다. `"-4" + " " + "-1"`은 `"-4 -1"`이다. 부호는 숫자 문자열에 들어 있다.
- 최솟값과 최댓값이 같아도 둘 다 적는다. `"-1 -1"`의 답은 `"-1 -1"`이다.
- LINQ로 `int[]`를 만들어 `Min`, `Max`를 써도 답은 같다. `ToArray`를 해야 변환이 한 번이다.
- 다른 사람 풀이의 `ToString()`은 빼도 같은 문자열이다. `answer = ""`는 다음 줄에서 덮인다. `temp`는 숫자 목록이라는 역할이 안 보인다. `Select(int.Parse)`는 채점기에서 통과하는 표기이고, 이 PC의 .NET에서는 `int.Parse`가 여러 개라 `token => int.Parse(token)`이 안전하다.

## 문제 한 줄
공백으로 구분된 정수 중 최솟값과 최댓값을 `"최솟값 최댓값"` 문자열로 반환. 정수는 둘 이상.

## 핵심 패턴
```text
첫 숫자로 min = max
두 번째부터 더 작으면 min, 더 크면 max
return min + " " + max
```

## 대안별 구현 비교

답은 같다. A는 제출본이다. B는 최솟값·최댓값을 직접 갱신하지 않아서 짧다.

| 방법 | 순회 | 읽기 |
|---|---|---|
| A. 변환하며 갱신 | 숫자마다 한 번 | `min`, `max`가 보인다 |
| B. `int[]` 후 `Min`/`Max` | 변환 한 번, 그다음 최솟값·최댓값 각 한 번 | 짧다 |

### A. 변환하며 갱신

```csharp
public string solution(string s)
{
    string[] tokens = s.Split(' ');
    int min = int.Parse(tokens[0]);
    int max = min;

    for (int index = 1; index < tokens.Length; index++)
    {
        int number = int.Parse(tokens[index]);

        if (number < min)
        {
            min = number;
        }

        if (number > max)
        {
            max = number;
        }
    }

    return min + " " + max;
}
```

### B. LINQ

```csharp
using System.Linq;

public string solution(string s)
{
    int[] numbers = s.Split(' ').Select(token => int.Parse(token)).ToArray();

    return numbers.Min() + " " + numbers.Max();
}
```

- `"1 2 3 4"` → `"1 4"`
- `"-1 -2 -3 -4"` → `"-4 -1"`
- `"-1 -1"` → `"-1 -1"`

## 다음에 볼 것
- 첫 값으로 `min`과 `max`를 시작하면 반복은 1부터다.
- 정렬해서 양 끝을 꺼내도 답은 같다. 이 문제는 한 번 비교로 충분하다.
- 로컬에서 LINQ를 쓸 때는 `token => int.Parse(token)`으로 변환한다.
