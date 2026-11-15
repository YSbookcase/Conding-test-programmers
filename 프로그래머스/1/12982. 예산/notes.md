# 예산 (12982)

## 상태
- 제출 완료. 오름차순 정렬 후 예산 초과 전에 중단
- 제출 파일: `프로그래머스/1/12982. 예산/예산.cs`
- LocalTest는 쓰지 않음

## 내가 한 질문
- 내림차순으로 정렬하고, 합이 `budget`을 넘기 전까지 더하면 되나?
- 이론적으로 그 외에는 없나?
- 정렬 속도를 줄이는 것 외에 더 줄일 방법은 없나?

## 막혔던 지점
- 부서 수를 최대로 하려면 작은 신청액부터다. 내림차순은 큰 금액에 예산을 써서 부서 수가 줄어든다.
- 예제 `[1, 3, 2, 5, 4]`, 예산 9를 내림차순으로 보면 `5 + 4 = 9`에서 멈춰 2다. 정답은 3이다. `1 + 2 + 3 = 6`.
- 더 비싼 부서를 넣고 더 싼 부서를 빼면, 둘을 바꿨을 때 비용이 줄거나 같아서 부서 수는 늘지 않는다. 최댓값은 싼 쪽부터 예산 안에 들어가는 개수다.
- 같은 개수를 내는 다른 구현은 있다. k개를 지원하는 최소 비용이 `budget` 이하인 가장 큰 k. 시간은 O(부서 수²). 모든 조합은 부서 100에서 2¹⁰⁰이라 쓸 수 없다.
- 정렬 뒤 누적 합은 예산을 넘는 순간 끊긴다. 시간은 정렬이 거의 전부다. 안 본 부서가 1원일 수 있어서 O(부서 수) 아래로는 못 내려간다.

## 문제 한 줄
신청액 전액을 지원할 때만 인정하고, 예산 안에서 지원할 수 있는 부서 수의 최댓값을 구한다.

## 핵심 패턴
```text
오름차순 정렬
spent = 0, supportCount = 0
앞에서부터:
  spent + amount > budget 이면 중단
  아니면 spent에 더하고 supportCount++
```
- 예제 1: `1, 2, 3, 4, 5`. `6 + 4 = 10`에서 중단 → 3.
- 예제 2: `2 + 2 + 3 + 3 = 10` → 4.
- 부서는 100 이하. 시간 O(n log n), 추가 메모리는 정렬 공간.

## 대안별 구현 비교

A와 C의 답은 같다. B는 예제 1이 2가 되어 다르다. 나눔은 평균 시간이 다르고, 기준이 최악이면 느려진다.

### A. 오름차순으로 더하다 중단
제출용. `d`를 정렬하므로 원래 순서는 바뀐다. 문제에서는 순서 유지가 필요 없다.

```csharp
Array.Sort(d);
int spent = 0;
int supportCount = 0;
foreach (int amount in d)
{
    if (spent + amount > budget)
    {
        break;
    }

    spent += amount;
    supportCount++;
}
return supportCount;
```

### B. 내림차순으로 더하다 중단
예제 1이 2다. `5 + 4`에서 예산이 끝난다.

```csharp
Array.Sort(d);
Array.Reverse(d);
int spent = 0;
int supportCount = 0;
foreach (int amount in d)
{
    if (spent + amount > budget)
    {
        break;
    }

    spent += amount;
    supportCount++;
}
return supportCount;
```

### C. k개를 지원하는 최소 비용
정렬 없이 같은 개수. `minCost[count]`는 그 개수를 지원하는 최소 금액이다. 부서 100, 금액 합은 `int`에 들어간다. 시간 O(n²), 추가 메모리 O(n).

```csharp
int departmentCount = d.Length;
int[] minCost = new int[departmentCount + 1];
for (int count = 1; count <= departmentCount; count++)
{
    minCost[count] = int.MaxValue / 2;
}

foreach (int amount in d)
{
    for (int count = departmentCount; count >= 1; count--)
    {
        int nextCost = minCost[count - 1] + amount;
        if (nextCost < minCost[count])
        {
            minCost[count] = nextCost;
        }
    }
}

for (int count = departmentCount; count >= 1; count--)
{
    if (minCost[count] <= budget)
    {
        return count;
    }
}
return 0;
```

`count`를 뒤에서부터 갱신한다. 앞에서부터 하면 같은 부서를 한 번에 여러 번 센다.

### D. 예산이 끊기는 쪽만 나누기
싼 쪽 합이 예산을 넘으면 비싼 쪽은 버린다. 싼 쪽을 전부 살 수 있으면 남은 예산으로 비싼 쪽만 본다. 평균 O(n). 기준이 계속 한쪽으로 치우치면 O(n²). `n`이 100이면 A가 더 빠르다.

```csharp
int CountBySplit(int[] amounts, int remain)
{
    if (amounts.Length == 0 || remain <= 0)
    {
        return 0;
    }

    int pivot = amounts[0];
    List<int> smaller = new List<int>();
    List<int> equal = new List<int>();
    List<int> larger = new List<int>();
    foreach (int amount in amounts)
    {
        if (amount < pivot) smaller.Add(amount);
        else if (amount == pivot) equal.Add(amount);
        else larger.Add(amount);
    }

    int smallSum = 0;
    foreach (int amount in smaller)
    {
        smallSum += amount;
    }

    if (smallSum > remain)
    {
        return CountBySplit(smaller.ToArray(), remain);
    }

    int supportCount = smaller.Count;
    remain -= smallSum;
    foreach (int amount in equal)
    {
        if (remain < amount)
        {
            return supportCount;
        }

        remain -= amount;
        supportCount++;
    }

    return supportCount + CountBySplit(larger.ToArray(), remain);
}
```

## 다음에 볼 것
- 개수를 최대로 할 때는 작은 값부터. 큰 값부터는 개수가 줄어든다.
- 부서 100에서는 오름차순 정렬 한 번. 전체를 정렬하지 않는 나눔은 이론상 평균이 짧고, 이 제한에서는 느리다.
