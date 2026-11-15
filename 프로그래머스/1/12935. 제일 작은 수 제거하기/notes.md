# 제일 작은 수 제거하기 (12935)

## 상태
- 제출 완료. 최소 인덱스를 찾아 그 칸만 건너뛴 새 배열. 길이 1이면 `[-1]`
- 제출 파일: `프로그래머스/1/12935. 제일 작은 수 제거하기/제일 작은 수 제거하기.cs`
- LocalTest는 쓰지 않음

## 내가 한 질문
- 작은 수는 하나하나 비교해서 갱신하면 되나? 제거는 어떻게 하나?
- 배열에서는 특정 위치 제거가 불가능한가? 다른 자료구조에서는 되나?
- 쉽게 가려면 `List`로 바꾼 뒤 `ToArray()` 하지 않나?
- 최소값은 그 방법뿐인가? 리스트로 하면 LINQ의 `Math.Min`으로 구할 수 있지 않나?

## 막혔던 지점
- `int[]`는 만들 때 길이가 고정이다. 인덱스를 빼면서 길이를 줄이는 메서드는 없다. 칸을 덮어써도 `[4, 3, 2, 1]`의 길이는 4로 남는다.
- 최소 인덱스를 건너뛴 새 배열을 만들거나, `List`의 `RemoveAt`으로 뒤를 당긴 뒤 `ToArray()` 한다. 남은 순서는 원래 순서다.
- 길이가 1이면 지운 결과가 빈 배열이다. 그 전에 `[-1]`을 반환한다. `[10]`이 그 경우다. `RemoveAt` 뒤에 `ToArray()`를 하면 빈 배열이 되어 틀린다.
- `Math.Min`은 수 두 개 중 작은 쪽이다. 배열 전체의 최소값은 `arr.Min()`이다. `Min()`도 모든 칸을 비교한다. 비교를 생략하지는 않는다.
- 원소는 서로 다르다. 최소값이 하나라 인덱스가 없어도 `Remove(최솟값)`으로 뺄 수 있다.

## 문제 한 줄
가장 작은 수를 하나 제거한다. 결과가 비면 `[-1]`을 반환한다.

## 핵심 패턴
```text
길이 1이면 [-1]
minIndex를 앞에서부터 더 작은 쪽으로 갱신
길이-1 배열에 minIndex만 건너뛰고 담는다
```
- `[4, 3, 2, 1]` → `minIndex` 3 → `[4, 3, 2]`
- `[10]` → `[-1]`

## 대안별 구현 비교

남은 값과 순서는 같다. 차이는 최소 위치를 인덱스로 기억하느냐, 값으로 지우느냐다. 길이가 1인데 지운 뒤 `ToArray()`만 하면 빈 배열이 되어 달라진다.

### A. 최소 인덱스를 건너뛴 새 배열
제출한 버전.

```csharp
if (arr.Length == 1)
{
    return new int[] { -1 };
}

int minIndex = 0;
for (int i = 1; i < arr.Length; i++)
{
    if (arr[i] < arr[minIndex])
    {
        minIndex = i;
    }
}

int[] result = new int[arr.Length - 1];
int resultIndex = 0;
for (int i = 0; i < arr.Length; i++)
{
    if (i == minIndex)
    {
        continue;
    }

    result[resultIndex] = arr[i];
    resultIndex++;
}
return result;
```

### B. `List.RemoveAt` 후 `ToArray`
`RemoveAt`은 그 칸 뒤를 한 칸씩 당긴다. `ToArray`는 그 결과를 새 배열로 다시 복사한다. 건너뛰며 담는 것과 하는 일은 같다.

```csharp
if (arr.Length == 1)
{
    return new int[] { -1 };
}

int minIndex = 0;
for (int i = 1; i < arr.Length; i++)
{
    if (arr[i] < arr[minIndex])
    {
        minIndex = i;
    }
}

List<int> numbers = new List<int>(arr);
numbers.RemoveAt(minIndex);
return numbers.ToArray();
```

### C. `Min()`으로 값을 찾아 `Remove`
`using System.Linq`. 최소 위치 대신 값을 뺀다. 원소가 서로 달라 A와 같다. `Math.Min(arr)`은 메서드가 없다.

```csharp
if (arr.Length == 1)
{
    return new int[] { -1 };
}

List<int> numbers = new List<int>(arr);
numbers.Remove(arr.Min());
return numbers.ToArray();
```

반복에서 값만 갱신할 때는 `Math.Min`을 쓸 수 있다. 위치는 남지 않는다.

```csharp
int minValue = arr[0];
for (int i = 1; i < arr.Length; i++)
{
    minValue = Math.Min(minValue, arr[i]);
}
```

## 다음에 볼 것
- 배열 길이를 줄이려면 새 배열을 만들거나 `List`에서 뺀 뒤 `ToArray()` 한다.
- 전체 최소값은 `Min()`. `Math.Min`은 두 수다.
- 비면 `[-1]`. 지우기 전에 길이를 본다.
