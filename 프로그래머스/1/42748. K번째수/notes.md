# K번째수 (42748)

## 상태
- 제출 완료. 구간을 반복으로 복사한 뒤 정렬, `k - 1`
- 제출 파일: `프로그래머스/1/42748. K번째수/K번째수.cs`
- LocalTest는 쓰지 않음

## 내가 한 질문
- 자르고 정렬하고 k번째를 뽑기만 하면 되나? 문법을 물어보는 문제인가?
- `string`의 `Substring`처럼 배열을 자르는 메서드는 없나?
- 문제와 같은 동작을 만드는 게 생각보다 번거롭다.
- 성능 면에서 더 좋은 풀이가 있나?
- 원소가 100 이하라 구간을 세어 k번째에 닿는 수를 읽는 방법이구나. 과하지 않나?

## 막혔던 지점
- 연산은 자르기, 정렬, k번째 뽑기가 맞다. 번거로운 부분은 문제가 1번째부터 세고 배열은 0부터 센다는 점이다.
- `i`, `j`, `k`는 1부터다. 시작 인덱스는 `i - 1`, 자른 길이는 `j - i + 1`, 정렬 뒤 k번째는 `k - 1`이다.
- 배열에는 `Substring`이 없다. `array[(from - 1)..to]`의 오른쪽 `to`는 끝 인덱스이고 그 칸은 포함하지 않는다. `Substring`의 두 번째 인자는 길이다.
- `commands`는 칸이 3개로 같은 `int[,]`라 `GetLength(0)`과 `commands[c, 0]`을 쓴다.
- 원소가 1~100이라 구간 개수를 세어 k번째를 찾을 수 있다. `array` 100 이하, 명령 50 이하에서는 과하다.

## 문제 한 줄
각 명령 `[i, j, k]`마다 `array`의 i번째부터 j번째를 정렬한 뒤 k번째 수를 모은다.

## 핵심 패턴
```text
명령마다 from, to, kth
sliced = array[(from - 1)..to]
정렬
결과 = sliced[kth - 1]
```
- 예제 `[2, 5, 3]` → `array[1..5]` = `[5, 2, 6, 3]` → `[2, 3, 5, 6]`의 인덱스 2 = 5.
- `[4, 4, 1]` → `[6]`의 첫 수 6. `[1, 7, 3]` → 정렬 뒤 3번째 3. 답 `[5, 6, 3]`.
- 시간 O(명령 수 × 구간길이 log 구간길이). 추가 메모리는 자른 배열. 이 제한에서는 충분하다.

## 대안별 구현 비교

앞의 세 방법은 같은 정렬이라 결과가 같다. 차이는 자르는 문법이다. 개수를 세는 방법도 결과는 같고, 정렬을 하지 않는다.

### A. 범위로 자르고 정렬
`..`의 끝은 포함하지 않아서 `to`는 1부터 센 번호 그대로다. 제출본은 B다.

```csharp
int[] result = new int[commands.GetLength(0)];
for (int c = 0; c < result.Length; c++)
{
    int from = commands[c, 0];
    int to = commands[c, 1];
    int kth = commands[c, 2];

    int[] sliced = array[(from - 1)..to];
    Array.Sort(sliced);
    result[c] = sliced[kth - 1];
}
return result;
```

### B. 반복으로 복사
제출한 버전. `..` 없이 같은 구간을 만든다. 길이는 `to - from + 1`이다.

```csharp
int[] sliced = new int[to - from + 1];
for (int i = 0; i < sliced.Length; i++)
{
    sliced[i] = array[from - 1 + i];
}
Array.Sort(sliced);
result[c] = sliced[kth - 1];
```

### C. `Skip` / `Take`
`Skip`은 버릴 개수, `Take`는 가져올 개수다. `using System.Linq;`이 필요하다. 정렬해도 원래 `array`는 바뀌지 않는다.

```csharp
int[] sliced = array.Skip(from - 1).Take(to - from + 1).ToArray();
Array.Sort(sliced);
result[c] = sliced[kth - 1];
```

### D. 1~100 개수 세기
구간을 돌며 `counts[값]++`를 하고, 1부터 누적하다 `kth`에 닿는 수가 답이다. 예제 `[2, 5, 3]`은 2, 3, 5가 각 1개라 누적 3인 수가 5다. 한 명령은 `O(구간길이 + 100)`이라 긴 구간에서는 정렬보다 유리하다. 이 제한에서는 과하다.

```csharp
int[] counts = new int[101];
for (int i = from - 1; i < to; i++)
{
    counts[array[i]]++;
}

int seen = 0;
for (int number = 1; number <= 100; number++)
{
    seen += counts[number];
    if (seen >= kth)
    {
        result[c] = number;
        break;
    }
}
```

## 다음에 볼 것
- 1부터 세는 번호는 시작과 k번째만 `- 1`. 범위 `..`의 끝은 그대로 둔다.
- 원소 범위가 작고 구간이 길 때 개수 세기. 이번 제한은 잘라서 정렬.
