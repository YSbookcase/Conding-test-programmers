# 체육복 (42862)

## 상태
- 제출 완료. 번호별 벌 수 배열, 0벌이면 왼쪽 여벌부터
- 제출 파일: `프로그래머스/1/42862. 체육복/체육복.cs`
- LocalTest는 쓰지 않음

## 내가 한 질문
- `lost`로 각 번호의 주변 HashSet을 만들고, `reserve`와 겹치면 `n - lost`에 겹치는 수만큼 더하면 되지 않나?
- 다른 조언은?
- 다른 방법은 있나?
- 단순히 조건으로만 해도 되지 않나?
- 다른 사람 풀이(Queue로 빌려준 번호를 표시)를 확인해도 되나?

## 막혔던 지점
- 주변 번호를 한 집합으로 모으면, 여벌 하나가 양쪽 도난에 두 번 센다. `n = 5`, `lost = [2, 4]`, `reserve = [1, 3, 5]`는 겹침이 3이라 `3 + 3 = 6`이 된다. 학생은 5명이다.
- 도난과 여벌이 같은 학생은 자기 옷만 입고 빌려주지 못한다. `n = 5`, `lost = [1, 2]`, `reserve = [2, 3]`의 정답은 4다. 2번 옆의 여벌까지 세면 5가 된다.
- 0벌인 학생의 양옆에 여벌이 있으면 왼쪽을 먼저 쓴다. 벌 수 `[2, 0, 2, 0]`에서 오른쪽을 먼저 가져가면 마지막 학생이 못 구한다.
- 집합으로 풀 때 `lost`를 정렬하지 않으면 달라진다. `lost = [5, 3]`, `reserve = [4, 6]`을 5번부터 보면 5번이 4번을 가져가서 3번이 남는다.

## 문제 한 줄
번호가 인접한 학생끼리만 여벌을 빌려, 수업을 듣는 학생 수의 최댓값을 구한다.

## 핵심 패턴
```text
clothes[1..n] = 1
lost는 -1, reserve는 +1
1번부터:
  0벌이고 왼쪽이 2벌이면 왼쪽에서 1 가져옴
  아니면 오른쪽이 2벌이면 오른쪽에서 1 가져옴
  그래도 0벌이면 인원에서 뺌
```
- 둘 다 해당하면 `1 - 1 + 1 = 1`. 빌려줄 수 없다.
- `n`은 30 이하. 배열 한 번 순회면 된다. 시간 O(n), 추가 메모리 O(n).

## 대안별 구현 비교

답은 같다. 차이는 여벌을 “벌 수”로 기억하느냐, “아직 안 쓴 번호 집합”으로 기억하느냐다. 주변 집합의 교집합 크기로 더하는 방법만 결과가 다르다.

### A. 벌 수 배열과 조건
시간 O(n), 추가 메모리 O(n). 정렬이 필요 없다. 번호 순서가 배열 순서다.

```csharp
int[] clothes = new int[n + 1];
for (int i = 1; i <= n; i++)
{
    clothes[i] = 1;
}

foreach (int student in lost)
{
    clothes[student]--;
}

foreach (int student in reserve)
{
    clothes[student]++;
}

int attendCount = n;
for (int i = 1; i <= n; i++)
{
    if (clothes[i] > 0)
    {
        continue;
    }

    if (i > 1 && clothes[i - 1] == 2)
    {
        clothes[i - 1]--;
        clothes[i]++;
    }
    else if (i < n && clothes[i + 1] == 2)
    {
        clothes[i + 1]--;
        clothes[i]++;
    }
    else
    {
        attendCount--;
    }
}

return attendCount;
```

`clothes[0]`은 비운다. 학생 번호가 1부터다. 여벌은 최대 2벌이라 `== 2`와 `> 1`은 이 문제에서 같다.

### B. 도난·여벌 집합
시간 O(n log n), 추가 메모리 O(n). 도난과 여벌이 겹치는 학생을 양쪽에서 뺀 뒤, 오름차순으로 왼쪽 여벌부터 `Remove`한다.

```csharp
HashSet<int> lostSet = new HashSet<int>(lost);
HashSet<int> reserveSet = new HashSet<int>(reserve);

HashSet<int> selfCovered = new HashSet<int>(lostSet);
selfCovered.IntersectWith(reserveSet);
lostSet.ExceptWith(selfCovered);
reserveSet.ExceptWith(selfCovered);

int savedCount = 0;
foreach (int student in lostSet.OrderBy(number => number))
{
    if (reserveSet.Remove(student - 1) || reserveSet.Remove(student + 1))
    {
        savedCount++;
    }
}

return n - lostSet.Count + savedCount;
```

`OrderBy`를 빼면 `lost = [5, 3]`, `reserve = [4, 6]`에서 A와 결과가 달라진다.

### C. 다른 사람 풀이. Queue에 이미 빌려준 번호
`n` 2~8의 모든 도난·여벌 조합에서 A와 같았다. `que`는 꺼내지 않고 `Contains`만 한다. 빌려준 학생 집합이다.

```csharp
int answer = 0;
Queue<int> que = new Queue<int>();
for (int i = 1; i <= n; i++)
{
    if (lost.Contains(i))
    {
        if (reserve.Contains(i))
        {
            answer++;
            que.Enqueue(i);
        }
        else if (reserve.Contains(i - 1) && lost.Contains(i - 1) == false && que.Contains(i - 1) == false)
        {
            answer++;
            que.Enqueue(i - 1);
        }
        else if (reserve.Contains(i + 1) && lost.Contains(i + 1) == false && que.Contains(i + 1) == false)
        {
            answer++;
            que.Enqueue(i + 1);
        }
    }
    else
    {
        answer++;
    }
}

return answer;
```

`lost.Contains`는 배열을 매번 처음부터 찾는다. `n`이 30 이하라 통과한다. 조회용이면 `HashSet`이 맞다.

### D. 주변 HashSet 교집합 개수를 더함
`n - lost`에 교집합 크기를 더하면 예제 2는 우연히 4가 된다. 예제 1은 6, `lost = [1, 2]`, `reserve = [2, 3]`은 5가 되어 틀린다.

## 다음에 볼 것
- 직접 넣어 볼 경우: `[2, 4]/[1, 3, 5]` → 5, `[2, 4]/[3]` → 4, `[3]/[1]` → 2, `[1, 2]/[2, 3]` → 4.
- 마지막 줄이 핵심. 2번은 자기 옷만 입고, 3번은 2번에게만 줄 수 있어 1번은 못 듣는다.
