# 큰 수 만들기 (42883)

## 상태
- 제출 완료. 정확성 100, 메모리 50.2 MB, 시간 7.85 ms
- 제출 파일: `프로그래머스/2/42883. 큰 수 만들기/큰 수 만들기.cs`
- 탐욕법. 제출본은 `StringBuilder`로 한 번 훑기. LocalTest에 같은 코드를 작성함

## 내가 한 질문
- 모든 경우를 `List`에 담아 고르는 방식이 맞나
- 뒤에 더 큰 수가 남아 있으면 어떻게 동작하나
- 끝까지 봤는데 뺄 횟수가 남으면 어떻게 하나
- `k`가 자릿수 미만이라 숫자는 항상 남나
- `result.Length -= removeCount`는 무엇이고, 배열도 되나
- 다른 자료형은 `Substring`이나 구간 추출로 줄이나
- `Length`를 줄이면 잘린 칸이 바로 회수 대상인가
- `while (true)`로 뺀 다른 풀이는 일반적인가. 다른 작성은 없나

## 막혔던 지점
- 예제 길이는 짧아 조합이 가능하지만, `number`는 최대 100만 자리다. 뺄 자리를 모두 만들 수는 없다.
- 뒤의 큰 수는 그 자리에 도착했을 때만 처리한다. 남은 횟수가 있으면 바로 앞의 작은 숫자를 빼고, 횟수가 0이면 그대로 붙인다. `"1231234"`의 끝 `4`는 `3`보다 크지만 횟수가 없어 `"3234"`가 된다. `3`을 빼 `"234"`로 만들면 더 작다.
- 한 번도 빼지 못하면 뒤가 내림차순이다. 끝에서 남은 횟수만큼 뺀다. `"4321"`에서 2개를 빼면 `"43"`이다.
- `k`는 자릿수보다 작다. 결과 길이는 `number.Length - k`라 최소 한 자리다.
- 비교는 `<`다. `"776"`에서 1개를 뺄 때 같은 `7`까지 빼면 `"76"`이 된다. `<`이면 끝의 `6`만 빠져 `"77"`이다.
- 반환은 문자열이다. 100만 자리는 `int`나 `long`에 들어가지 않는다. `"1000"`에서 1개를 뺀 `"100"`의 앞자리도 유지한다. `"0"`에서 `0`을 지우면 빈 문자열이 된다.
- `StringBuilder.Length`를 줄이면 사용하는 문자 수만 줄고, `ToString()`은 그 길이만 복사한다. `Capacity`의 배열은 빌더가 계속 들고 있다. 잘린 칸은 `'\0'`이 되고, 빌더를 더 이상 참조하지 않을 때 회수 대상이 된다.
- 다른 풀이의 `sb.Remove(index, 1)`은 뺄 때마다 뒤 글자를 당긴다. 100만 자리에서 `k`번 반복하면 시간이 커진다.

## 문제 한 줄
왼쪽부터의 순서를 유지한 채 숫자 `k`개를 빼, 가장 큰 수를 문자열로 반환한다.

## 핵심 패턴
```text
앞에서부터 한 글자씩 쌓음
남은 횟수가 있고 맨 뒤가 현재 글자보다 작으면 맨 뒤를 뺌
끝까지 본 뒤 남은 횟수는 끝에서 자름
```

```csharp
StringBuilder result = new StringBuilder();
int removeCount = k;

foreach (char digit in number)
{
    while (removeCount > 0 && result.Length > 0 && result[result.Length - 1] < digit)
    {
        result.Length--;
        removeCount--;
    }

    result.Append(digit);
}

result.Length -= removeCount;
return result.ToString();
```

`"1924"`에서 2개를 빼면 `[1]`에서 `9`가 `1`을 빼고, `[9, 2]`에서 `4`가 `2`를 빼 `"94"`다.

## 대안별 구현 비교

답은 같다. 제출본은 각 글자를 최대 한 번 넣고 한 번 뺀다. 다른 풀이는 작은 글자 하나를 찾을 때마다 `Remove`로 뒤를 당긴다.

| 방법 | 횟수 | 메모 |
|---|---|---|
| A. 쌓으면서 앞자리 제거 | `O(n)` | 제출본. 각 글자는 최대 한 번 빠짐 |
| B. 오름차순 지점을 `k`번 `Remove` | 자리마다 뒤를 당김 | 앞에 `"9"`를 붙였다 마지막에 버림 |

### B. 오름차순 지점을 `k`번 제거

`while (true)`는 빠져나오는 조건이 중간에 있을 때 쓰는 형태다. 이 반복은 전진 조건을 머리에 둘 수 있다. 앞에 붙인 `"9"`는 실제 숫자가 아니다. `9`는 어떤 숫자보다 작지 않아 반복 안에서 빠지지 않고, `index`가 0 아래로 내려가지 않게 막는다.

```csharp
public string solution(string number, int k)
{
    StringBuilder result = new StringBuilder("9" + number);
    int index = 0;

    for (int removeCount = 0; removeCount < k; removeCount++)
    {
        while (index + 1 < result.Length && result[index] >= result[index + 1])
            index++;

        result.Remove(index, 1);
        index--;
    }

    result.Remove(0, 1);
    return result.ToString();
}
```

## 다음에 볼 것
- 배열 `Length`는 대입할 수 없다. `List<T>`는 `RemoveRange`로 구간을 지우고, `GetRange`는 그 구간을 복사한 새 리스트다.
- `string`은 `Substring`이나 `number[..^개수]`로 새 문자열을 만든다. 원본은 바뀌지 않는다.
