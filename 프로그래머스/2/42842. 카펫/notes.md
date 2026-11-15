# 카펫 (42842)

## 상태
- 제출 완료. 정확성 100, 메모리 45.6 MB, 시간 0.17 ms
- 제출 파일: `프로그래머스/2/42842. 카펫/카펫.cs`
- 완전탐색. 제출본은 노란색 약수 반복. LocalTest에서 `<` 때문에 테스트 2가 빠졌고 `<=`로 고침

## 내가 한 질문
- `[8, 6]`에서 노란색이 중앙에 다 들어가야 하나. 남는 칸은 안 넣는 건가
- 둘레를 만들면 항상 들어가나. 모양도 중요한가
- 다항식의 해로 구해야 하나
- 로컬 테스트에서 테스트 2를 통과하지 못함
- 다른 풀이는 근의 공식을 `long`으로 계산한 뒤 정수로 되돌리더라

## 막혔던 지점
- 노란색은 테두리 한 줄 안의 직사각형을 빈칸 없이 채운다. 덜 넣거나 칸을 비우는 경우는 없다.
- 둘레를 아무 크기로 두면 안쪽이 노란색 개수와 어긋난다. `[8, 6]`만 갈색 24, 노란색 24가 동시에 맞다. `24×1`은 전체 `26×3`, 갈색 54다.
- 테스트 2는 `brown = 8`, `yellow = 1`, 답 `[3, 3]`이다. 조건이 `innerHeight * innerHeight < yellow`이면 `1 * 1 < 1`이 거짓이라 루프가 한 번도 안 돌고 `[0, 0]`을 반환한다. 제곱수 안쪽은 `<=`여야 한다.
- 루프 끝 `[0, 0]`은 컴파일용이다. 입력에는 맞는 카펫이 항상 하나 있다.
- `√yellow`까지만 보면 `innerWidth >= innerHeight`라 가로가 세로 이상이다. 가로 검사를 따로 두지 않아도 된다.
- `yellow` 최대 200만이면 루프는 1414 근처에서 끝난다. `innerHeight * innerHeight`는 이번 제한에서 `int`에 들어간다.

## 문제 한 줄
갈색 테두리 한 줄, 안쪽은 노란색으로 가득 찬 직사각형. 가로가 세로 이상인 `[가로, 세로]`를 반환한다.

## 핵심 패턴
```text
안쪽 세로를 1부터 √yellow까지
yellow의 약수일 때만 안쪽 가로 = yellow / 안쪽 세로
전체 가로는 안쪽 가로 + 2, 전체 세로는 안쪽 세로 + 2
갈색 2 * (가로 + 세로 - 2)가 brown이면 그 짝이 답
```

```csharp
for (int innerHeight = 1; innerHeight * innerHeight <= yellow; innerHeight++)
{
    if (yellow % innerHeight != 0)
        continue;

    int innerWidth = yellow / innerHeight;
    int width = innerWidth + 2;
    int height = innerHeight + 2;

    if (2 * (width + height - 2) == brown)
        return new int[] { width, height };
}

return new int[] { 0, 0 };
```

노란색 24의 약수 짝은 `1×24`, `2×12`, `3×8`, `4×6`이다. 갈색이 24가 되는 것은 안쪽 `6×4`, 전체 `[8, 6]`뿐이다.

| 안쪽 | 전체 | 갈색 |
|---|---|---|
| 24 × 1 | 26 × 3 | 54 |
| 12 × 2 | 14 × 4 | 32 |
| 8 × 3 | 10 × 5 | 26 |
| 6 × 4 | 8 × 6 | 24 |

## 대안별 구현 비교

답 짝은 같다. 약수 반복은 안쪽 직사각형을 하나씩 확인하고, 근의 공식은 합과 곱으로 그 짝을 한 번에 계산한다.

가로·세로의 합은 `brown / 2 + 2`, 곱은 `brown + yellow`다. `t² - 합·t + 곱 = 0`의 두 근이 가로와 세로는 맞다. 큰 근이 가로다.

`brown = 24`, `yellow = 24`이면 합 14, 곱 48, 판별식 `196 - 192 = 4`다. `(14 + 2) / 2 = 8`, `(14 - 2) / 2 = 6`.

`long`은 제곱과 `4 * product`가 `int`를 넘길 때를 대비한 여유다. 이 제한에서는 합의 제곱이 약 626만, 곱의 4배가 약 802만이라 `int`에도 들어간다. `Math.Sqrt`는 `double`이라 완전제곱을 확인한 뒤 정수로 되돌린다.

| 방법 | 계산 | 메모 |
|---|---|---|
| A. 약수 반복 | `O(√yellow)` | 제출본. 제곱수 경계는 `<=` |
| B. 근의 공식 | 곱셈 몇 번 | 합·곱이 같은 식. `long`은 여유 |

### B. 근의 공식

```csharp
public int[] solution(int brown, int yellow)
{
    long sum = brown / 2 + 2;
    long product = (long)brown + yellow;
    long discriminant = sum * sum - 4 * product;
    long root = (long)Math.Sqrt(discriminant);

    int width = (int)((sum + root) / 2);
    int height = (int)((sum - root) / 2);

    return new int[] { width, height };
}
```

## 다음에 볼 것
- 같은 루프를 더 큰 수에 쓸 때는 `innerHeight <= yellow / innerHeight`로 끊으면 제곱이 `int`를 넘는 일을 피한다.
- 소수 찾기(12921)에서 `number * number`가 음수가 되며 반복이 안 끝난 것과 같은 종류의 경계다. 이번 카펫 제한에서는 그 경계까지 가지 않는다.
