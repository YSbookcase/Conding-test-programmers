# 최소직사각형 (86491)

## 상태
- 제출 완료. 긴 변 최댓값 × 짧은 변 최댓값, 한 번 순회
- 제출 파일: `프로그래머스/1/86491. 최소직사각형/최소직사각형.cs`

## 내가 한 질문
- 명함마다 긴 변을 가로에 두고, 짧은 변은 더 작은 값으로 갱신해서 한 번 순회로 끝낼 수 있나?
- 그 방법 말고 다른 방법, 더 좋은 방법이 있나?

## 막혔던 지점
- 짧은 변을 더 작은 값으로 내리면 안 된다. 예1에서 세로 50을 다음 명함의 30으로 바꾸면 첫 명함의 50이 들어가지 않는다. 짧은 변도 지금까지의 최댓값으로만 키운다.
- 회전 없이 전체 가로 최댓값 × 전체 세로 최댓값은 예1이 80×70=5600이다. 2번 명함(30, 70)을 눕히면 80×50=4000이다.

## 문제 한 줄
명함을 각각 90도 회전할 수 있을 때, 모든 명함이 들어가는 가장 작은 지갑의 넓이.

## 핵심 패턴
```text
명함마다 longSide = max(w, h), shortSide = min(w, h)
maxLong = 긴 변들의 최댓값
maxShort = 짧은 변들의 최댓값
return maxLong * maxShort
```

예1: (60,50) → (70,50) → (70,50) → (80,50) = 4000. 예2는 15×8=120. 예3은 19×7=133.

한 번 순회가 최선이다. 명함을 한 번은 봐야 해서 시간은 O(n), 저장은 정수 두 개라 추가 메모리는 O(1). n은 최대 10,000.

지갑의 한 변은 어떤 명함의 긴 변 이상이어야 하므로, 그 변은 긴 변들의 최댓값으로 고정된다. 나머지 변은 짧은 변들의 최댓값이다.

## 대안별 구현 비교

결과와 복잡도가 같다. 차이는 배열을 몇 번 읽느냐다. `longSide`/`shortSide`는 이번 명함, `maxLong`/`maxShort`는 지갑의 두 변이다.

### A. 한 번 순회
시간 O(n), 추가 메모리 O(1).

```csharp
int maxLong = 0;
int maxShort = 0;
for (int i = 0; i < sizes.GetLength(0); i++)
{
    int longSide = Math.Max(sizes[i, 0], sizes[i, 1]);
    int shortSide = Math.Min(sizes[i, 0], sizes[i, 1]);
    if (longSide > maxLong) maxLong = longSide;
    if (shortSide > maxShort) maxShort = shortSide;
}
return maxLong * maxShort;
```

### B. 두 번 순회
같은 곱. 긴 변과 짧은 변을 배열을 나눠 읽는다.

```csharp
int maxLong = 0;
int maxShort = 0;
for (int i = 0; i < sizes.GetLength(0); i++)
{
    int longSide = Math.Max(sizes[i, 0], sizes[i, 1]);
    if (longSide > maxLong) maxLong = longSide;
}
for (int i = 0; i < sizes.GetLength(0); i++)
{
    int shortSide = Math.Min(sizes[i, 0], sizes[i, 1]);
    if (shortSide > maxShort) maxShort = shortSide;
}
return maxLong * maxShort;
```

### C. 회전 없이 가로 최댓값 × 세로 최댓값
예1이 80×70=5600이 된다. 눕히기가 반영되지 않는다.

### D. 명함마다 회전 여부를 전부 시도
경우의 수가 2^n이다. n=10000에서는 불가.

## 다음에 볼 것
- 짧은 변 갱신은 최댓값. 더 작게 줄이면 이전 명함이 빠진다.
- 회전 조합을 찾지 말고, 긴 변/짧은 변으로 맞춘 뒤 각 축의 최댓값을 곱한다.
