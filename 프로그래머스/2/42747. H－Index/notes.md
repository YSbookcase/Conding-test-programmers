# H-Index (42747)

## 상태
- 제출 완료. 정확성 100, 메모리 46.1 MB, 시간 0.21 ms
- 제출 파일: `프로그래머스/2/42747. H－Index/H－Index.cs`
- 고득점 Kit 정렬. 제출본은 칸 세기. LocalTest 없음

## 내가 한 질문
- 정렬 후 접근이 좋나, 아니면 편수 중간 값으로 이분 탐색이 좋나
- 그보다 나은 방법이 있나. 정렬 없이 찾을 수 있나
- 길이 `n + 1` 칸에 편수를 넣고, 높은 쪽부터 더하다 조건에서 반환하는 건가
- 빈 값이 나올 수 있나. 루프 밖 `return`은 무엇으로 하나
- H-Index가 무엇인지, 수학적 정의와 용도는 무엇인가
- `Count(e => e >= i) >= i`는 어떻게 도나. 매 후보마다 전체 순회라 부하가 있나

## 막혔던 지점
- 이분 탐색은 정렬 뒤에만 된다. 오름차순에서 인덱스 `i`의 비교 대상은 위치가 아니라 `n - i`다. 총 100편에서 50은 `100 - 50 = 50`이라 위치와 편수가 같다. 75의 인용이 80이면 75가 아니라 남은 25와 비교한다.
- `citations[i] < n - i`면 그 `h`는 불가해서 오른쪽, `>=`면 가능한 `h = n - i`이고 더 큰 값은 왼쪽일 수 있다.
- `h`는 논문 수를 넘지 못한다. `[100]`도 1이다. 그래서 `n` 이상 인용은 칸 `n`에 몰아도 된다.
- `h >= 0`까지 내리면 `h = 0`에서 `논문 수 >= 0`이 항상 참이다. 밖 `return 0`은 컴파일용이고, 실제 답은 루프 안에서 나온다. `h > 0`까지만 돌리면 밖 0이 `[0]`, `[0, 0]`의 답이다.
- `Count` 한 번은 가볍다. 부하는 후보 `i`마다 배열을 다시 훑는 데 있다.

## 문제 한 줄
`h`번 이상 인용된 논문이 `h`편 이상인 `h`의 최댓값. 인용을 내림차순 `c1 ≥ … ≥ cn`으로 세우면 `c_h ≥ h`인 가장 큰 `h`다.

## 핵심 패턴
```text
길이 n+1 칸. 칸 값은 인용이 그 인덱스인 논문 수. n 이상은 칸 n
h = n부터 0까지 내려가며 누적
누적값 >= h 이면 그 h가 답
```

```csharp
int paperCount = citations.Length;
int[] citationCounts = new int[paperCount + 1];

foreach (int citation in citations)
{
    int capped = Math.Min(citation, paperCount);
    citationCounts[capped]++;
}

int papersAtLeast = 0;
for (int h = paperCount; h >= 0; h--)
{
    papersAtLeast += citationCounts[h];
    if (papersAtLeast >= h)
        return h;
}

return 0;
```

`[3, 0, 6, 1, 5]`는 칸 `[1, 1, 0, 1, 0, 2]`다. `h = 5`는 2편, `h = 4`는 2편, `h = 3`에서 3편이라 3.

## 대안별 구현 비교

답은 같다. 차이는 횟수와, 이분 탐색에서 `n - i`를 위치 번호로 착각하는 지점이다.

| 방법 | 횟수 | 메모 |
|---|---|---|
| A. 칸 세기 | `O(n)` | 제출본 |
| B. 오름차순 후 한 바퀴 | `O(n log n)` | 비교가 눈에 보임 |
| C. 오름차순 후 이분 탐색 | `O(n log n)` | 처음 떠올린 방향. 병목은 정렬 |
| D. `Max()`부터 `Count` | 후보마다 `O(n)` | 제한 안에서는 통과. 최악은 약 1,000만 번 |

### B. 오름차순 후 한 바퀴

```csharp
public int solution(int[] citations)
{
    Array.Sort(citations);

    int hIndex = 0;

    for (int index = 0; index < citations.Length; index++)
    {
        int papersFromHere = citations.Length - index;
        if (citations[index] >= papersFromHere)
            hIndex = Math.Max(hIndex, papersFromHere);
    }

    return hIndex;
}
```

### C. 오름차순 후 이분 탐색

가능한 뒤보는 더 큰 `h`를 위해 왼쪽으로 간다.

```csharp
public int solution(int[] citations)
{
    Array.Sort(citations);

    int paperCount = citations.Length;
    int left = 0;
    int right = paperCount - 1;
    int hIndex = 0;

    while (left <= right)
    {
        int mid = (left + right) / 2;
        int papersFromMid = paperCount - mid;

        if (citations[mid] >= papersFromMid)
        {
            hIndex = papersFromMid;
            right = mid - 1;
        }
        else
        {
            left = mid + 1;
        }
    }

    return hIndex;
}
```

### D. 큰 인용부터 `Count`

처음 성공한 `i`가 최댓값이다. `i > answer`라 갱신 직후 루프가 끝난다. 시작을 `Math.Min(citations.Max(), citations.Length)`로 잡아도 답은 같다.

```csharp
public int solution(int[] citations)
{
    int answer = 0;

    for (int h = citations.Max(); h > answer; h--)
    {
        if (citations.Count(citation => citation >= h) >= h)
            answer = h;
    }

    return answer;
}
```

## 다음에 볼 것
- `h`편 이상이 각각 `h`번 이상이면 총 인용은 적어도 `h²`이다.
- 분야마다 인용 규모가 다르고, 경력이 길수록 쌓인다. `h`를 이미 넘긴 논문의 인용이 더 올라도 `h`는 그대로다.
- `Count(조건)`은 참인 원소만 센다. 조건 없는 `Count()`는 전체 길이다.
