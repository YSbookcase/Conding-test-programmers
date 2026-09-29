# 두 개 뽑아서 더하기 (68644)

## 상태
- 제출 완료. 가능한 합 0~200을 `bool[201]`에 표시한 뒤 앞에서부터 결과에 추가
- 제출 파일: `프로그래머스/1/68644. 두 개 뽑아서 더하기/두 개 뽑아서 더하기.cs`
- 로컬 확인: `LocalTest/Program.cs` (`.gitignore`)

## 내가 한 질문
- 모든 쌍의 합을 만든 뒤 중복 제거와 정렬을 하는 것보다 나은 방법이 있는가?
- 중복 제거와 정렬 없이 작성한 로컬 코드의 방향이 맞는가?
- 일반적인 방법은 LINQ로 `Distinct`와 정렬을 하는 것인가?
- `HashSet`은 범용적이고 `bool[]`은 범위가 작고 고정된 경우에 쓰는가?
- 다른 사람 풀이의 `List.Contains()`는 어떤 값을 반환하는가?

## 막혔던 지점
- 처음 코드에서는 `index`가 바깥 반복마다 0으로 초기화되어 앞에서 저장한 합을 덮어썼다. `index`를 바깥으로 옮겨도 중복과 정렬은 처리되지 않는다.
- `count * (count - 1) / 2`는 모든 인덱스 쌍의 개수다. 정답 배열 길이는 고유한 합의 개수라 같지 않을 수 있다. 고정 길이 배열을 만들면 중복을 제거한 뒤 남은 칸에 기본값 0도 생길 수 있다.
- 서로 다른 인덱스를 골라야 하므로 안쪽 반복은 `j = i + 1`에서 시작한다. 같은 값이라도 인덱스가 다르면 고를 수 있어 `[1, 1]`은 합 2를 만든다.
- 모든 쌍은 확인해야 한다. 길이 최대 100이면 최대 `100 × 99 / 2 = 4,950`쌍이라 이중 반복으로 충분하다.
- 두 원소는 각각 0~100이므로 합은 0~200이다. `bool[201]`에서 합을 인덱스로 쓰면 같은 합을 여러 번 표시해도 `true` 하나만 남는다. 0부터 200까지 읽으면 정렬된 결과가 된다.
- `List<T>.Contains(value)`의 반환형은 `bool`이다. 있으면 `true`, 없으면 `false`이며 C#에서 자동으로 1이나 0이 되지 않는다. 앞에서부터 찾는 선형 탐색이라 O(k)다.
- `HashSet<T>.Add(value)`도 `bool`을 반환한다. 새로 추가되면 `true`, 이미 있으면 `false`다. 중복 없이 모으기만 할 때는 반환값을 받지 않아도 된다.

## 문제 한 줄
서로 다른 두 인덱스의 값을 더해 만들 수 있는 모든 고유한 합을 오름차순으로 반환한다.

## 핵심 패턴
```text
hasSum[0..200] = false
i = 0..n-2
  j = i+1..n-1
    hasSum[numbers[i] + numbers[j]] = true
sum = 0..200
  hasSum[sum]이면 결과에 추가
```

시간 O(n² + 201), 추가 메모리 O(201). 제한 안에서는 상수 크기다.

## 제출 코드
```csharp
bool[] hasSum = new bool[201];

for (int i = 0; i < numbers.Length - 1; i++)
{
    for (int j = i + 1; j < numbers.Length; j++)
        hasSum[numbers[i] + numbers[j]] = true;
}

List<int> result = new List<int>();

for (int sum = 0; sum <= 200; sum++)
{
    if (hasSum[sum])
        result.Add(sum);
}

return result.ToArray();
```

`hasSum[7]`은 합 7을 만들 수 있는지 나타낸다. `result`는 0부터 읽어 추가하므로 이미 오름차순이다.

## 대안별 구현 비교

값의 범위가 작고 고정되면 `bool[]`, 범위를 모르거나 매우 크면 `HashSet`이 적합하다.

### A. `bool[201]` (제출)
- 중복 표시: O(1)
- 정렬 호출 불필요
- 값의 범위만큼 배열 필요
- 음수 범위가 작으면 `hasValue[value - minValue]`처럼 보정 가능

### B. `HashSet` 후 정렬
```csharp
HashSet<int> sums = new HashSet<int>();

for (int i = 0; i < numbers.Length - 1; i++)
{
    for (int j = i + 1; j < numbers.Length; j++)
        sums.Add(numbers[i] + numbers[j]);
}

int[] result = sums.ToArray();
Array.Sort(result);
return result;
```

합의 범위를 몰라도 실제로 나온 값만 저장한다. `Add`는 평균 O(1)이지만 `HashSet` 자체는 정렬 상태가 아니어서 마지막 정렬이 필요하다. `ToArray()`에는 `using System.Linq;`이 필요하다.

### C. `List` 후 LINQ
```csharp
List<int> sums = new List<int>();

for (int i = 0; i < numbers.Length - 1; i++)
{
    for (int j = i + 1; j < numbers.Length; j++)
        sums.Add(numbers[i] + numbers[j]);
}

return sums.Distinct().OrderBy(sum => sum).ToArray();
```

모든 합과 중복을 먼저 저장한다. `Distinct`, `OrderBy`, `ToArray`는 `System.Linq` 확장 함수다.

### D. `List.Contains`
```csharp
int sum = numbers[i] + numbers[j];
if (!result.Contains(sum))
    result.Add(sum);
```

없을 때만 추가하므로 중복을 막지만, `Contains`는 현재 목록을 선형 탐색한다. 이 문제는 고유한 합이 최대 201개라 충분하지만 값 종류가 많으면 `HashSet`이 더 알맞다. 마지막에 `result.Sort()`가 필요하다.

### E. `SortedSet`
삽입하면서 중복 제거와 정렬을 모두 유지한다. 각 삽입은 O(log k)이고, 작은 고정 범위에서는 `bool[]`보다 구조가 무겁다.

## 다음에 볼 것
- 값 범위가 작고 알려져 있으면 값 자체를 `bool[]` 인덱스로 쓴다.
- 범위를 모르면 `HashSet`, 삽입 중 정렬도 필요하면 `SortedSet`.
- `List.Contains`는 `bool` 반환이지만 내부 탐색은 O(k).
- 조합 쌍은 `i < j`, 즉 `j = i + 1` 패턴.
