# 타겟 넘버 (43165)

## 상태
- 제출 완료. 정확성 100, 메모리 46.4 MB, 시간 3.95 ms
- 제출 파일: `프로그래머스/2/43165. 타겟 넘버/타겟 넘버.cs`
- DFS/BFS. 제출본은 부호를 고르는 재귀. LocalTest에 같은 코드를 작성함

## 내가 한 질문
- 감이 안 온다. 왜 DFS, BFS로 분류되나
- 다른 방법이 있나. 100만이면 괜찮지만 더 많으면, 미로가 커지면 어떻게 하나
- 표를 쓰는 방법도 시간·공간 복잡도를 따지면 결국 같은가
- 그래서 어떤 방법으로 푸는 편이 좋나
- `index == numbers.Length`는 무엇이고, `target`과 같은 개수는 어떻게 세나
- 로컬 코드에 추가할 조언이 있나

## 막혔던 지점
- 입력 배열은 그래프가 아니다. 각 숫자에서 더하기와 빼기로 갈라지는 트리를 끝까지 가며 `target`에 도착한 횟수를 센다. 순서는 바꾸지 않으므로 고르는 것은 부호뿐이다.
- 숫자는 최대 20개라 갈래는 `2^20`, 약 100만 개다. 이 제한은 그 재귀가 통과하도록 개수를 막아 둔 것이다.
- `index == numbers.Length`이면 부호를 모두 붙인 상태다. 그때의 `sum`이 `target`이면 1, 아니면 0을 반환한다. 부모는 더한 갈래와 뺀 갈래의 반환값을 더한다. 전역 카운터가 아니다.
- 방법 수를 클래스 필드에 누적하면 `solution`을 여러 번 호출할 때 이전 횟수가 남을 수 있다. 반환값으로 더하면 호출마다 따로 계산된다.
- 부호를 전부 가는 탐색의 시간은 `2^n`이다. 뺀 수들의 합을 세는 표는 `n × 가능한 합`이다. 이 제한에서는 약 100만 번과 약 2만 번이라 시간이 다르다. 재귀의 추가 공간은 깊이 `n`뿐이라 표의 1,000칸보다 작다.
- `(인덱스, 현재 합)`을 저장하는 재귀만 표와 횟수가 같다. 저장하지 않고 갈래만 내려가는 재귀와는 다르다.
- 미로는 같은 칸을 다시 넣지 않으면 비용이 칸 수에 비례한다. 갈래가 `2^(칸 수)`로 늘지 않는다.

## 문제 한 줄
숫자 순서를 유지한 채 각각 더하거나 빼서 `target`을 만드는 방법의 수.

## 핵심 패턴
```text
index가 길이와 같으면 sum == target 이면 1, 아니면 0
아니면 현재 수를 더한 호출과 뺀 호출의 반환값을 더함
처음 호출은 index 0, sum 0
```

```csharp
int Count(int[] numbers, int target, int index, int sum)
{
    if (index == numbers.Length)
        return sum == target ? 1 : 0;

    int addCount = Count(numbers, target, index + 1, sum + numbers[index]);
    int subtractCount = Count(numbers, target, index + 1, sum - numbers[index]);
    return addCount + subtractCount;
}
```

`[1, 1]`로 0을 만들면 `+1-1`과 `-1+1`이라 맨 위 반환은 2다. `[1, 1, 1, 1, 1]`과 3은 5, `[4, 1, 2, 1]`과 4는 2다.

## 대안별 구현 비교

이번 제한에서는 재귀가 제출본이다. 표는 개수가 20을 넘는데 수의 합은 작을 때 유리하다.

전체 합을 `S`라고 하면 `S - 2 × (뺀 수들의 합) = target`이다. 뺀 수들의 합은 `(S - target) / 2`다. 이 값이 정수가 아니거나 `S`보다 `target`이 크면 0이다.

`[1, 1, 1, 1, 1]`은 합 5, `(5 - 3) / 2 = 1`이라 1을 빼는 다섯 가지다. `[4, 1, 2, 1]`은 합 8, `(8 - 4) / 2 = 2`라 `{2}`와 `{1, 1}` 두 가지다.

| 방법 | 시간 | 공간 | 메모 |
|---|---|---|---|
| A. 부호 재귀 | `2^n` | 깊이 `n` | 제출본. `n`이 20이면 약 100만 |
| B. 뺀 합의 경우의 수 | `n × 합` | 합의 칸 수 | 합이 최대 1,000이면 약 2만 번 |

### B. 뺀 합의 경우의 수

```csharp
public int solution(int[] numbers, int target)
{
    int sum = numbers.Sum();
    if (sum < target || (sum - target) % 2 != 0)
        return 0;

    int negativeSum = (sum - target) / 2;
    int[] wayCounts = new int[negativeSum + 1];
    wayCounts[0] = 1;

    foreach (int number in numbers)
    {
        for (int current = negativeSum; current >= number; current--)
            wayCounts[current] += wayCounts[current - number];
    }

    return wayCounts[negativeSum];
}
```

## 다음에 볼 것
- 미로 최단거리는 방문한 칸을 다시 넣지 않는 BFS다. 목적지가 있고 거리를 짐작할 수 있으면 A*가 반대쪽 탐색을 줄인다.
- 개수와 수의 크기가 같이 커지면 정확한 해를 빠르게 구하는 일반 방법은 없다. 40개 근처까지는 반으로 나눠 `2^20`끼리 짝을 찾는다.
