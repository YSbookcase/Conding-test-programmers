# 전국 대회 선발 고사 (181851)

## 내가 한 질문
- `Array.IndexOf`는 배열의 속성인가? 메서드인가?
- 1등부터 순회하며 `Array.IndexOf`로 학생 번호를 찾는 풀이가 데이터가 많아질 때도 효율적인가?
- `Array.IndexOf`는 내부적으로 어떤 탐색 알고리즘을 사용하는가?
- 대규모 데이터에서 리스트 정렬이 최선의 선택인가?
- `studentOfRank[rank[i]] = i;` (역매핑 배열) 코드의 의미와 동작 원리는?
- `students.Sort((a, b) => rank[a].CompareTo(rank[b]));` 에서 람다 함수의 `(a, b)`는 어떻게 모든 원소를 정렬하는가?

## 막혔던 지점 및 문법 정리
- **`IndexOf`의 호출 방식**:
  - `Array`에서는 `arr.IndexOf()`가 불가하며 **`Array.IndexOf(arr, 값)`** 정적 메서드로 호출해야 함.
  - 문자열(`string`) 및 `List<T>`에서는 `str.IndexOf()`, `list.IndexOf()` 인스턴스 메서드로 점(`.`) 찍고 호출 가능.
- **`Array.IndexOf`의 내부 동작과 한계**:
  - 0번 인덱스부터 끝까지 하나씩 확인하는 **선형 탐색(Linear Search, $O(N)$)**.
  - $N$번 반복문 안에서 `IndexOf`를 호출하면 전체 시간 복잡도가 **$O(N^2)$**이 되어 $N=100,000$처럼 데이터가 클 때 시간 초과 위험.

## 핵심 패턴 및 코드 발전 과정

### 1. 1단계: 순차 `Array.IndexOf` 탐색 ($O(N^2)$)
- 1등부터 $N$등까지 순서대로 `Array.IndexOf(rank, i)`로 학생 번호를 찾고, 참석자(`attendance[index]`)인 경우 3명까지 계산.
```csharp
int result = 0, count = 0;
int[] multiplier = { 10000, 100, 1 };
for (int i = 1; i <= rank.Length; i++)
{
    int index = Array.IndexOf(rank, i);
    if (attendance[index])
    {
        result += index * multiplier[count++];
        if (count == 3) break;
    }
}
return result;
```

### 2. 2단계: 역매핑 배열 테크닉 ($O(N)$ - 최종 제출 ⭐)
- 등수가 1부터 $N$까지 고유하다는 점을 활용해 **"등수 ➔ 학생번호"**를 저장하는 역배열 `studentOfRank`를 단 1회 구축($O(N)$).
- 이후 1등부터 `studentOfRank[r]`로 $O(1)$ 즉시 조회.
```csharp
int[] studentOfRank = new int[rank.Length + 1];
for (int i = 0; i < rank.Length; i++)
{
    studentOfRank[rank[i]] = i; // i번 학생의 등수가 rank[i] -> rank[i]등은 i번 학생!
}

int count = 0, result = 0;
int[] score = { 10000, 100, 1 };
for (int r = 1; r <= rank.Length; r++)
{
    int studentId = studentOfRank[r];
    if (attendance[studentId])
    {
        result += studentId * score[count++];
        if (count == 3) break;
    }
}
return result;
```

## 추가 풀이 방법들 (대안 정리)

### 1. 커스텀 람다 정렬 (`List.Sort` - 실전 대규모 정석 ⭐)
```csharp
using System;
using System.Collections.Generic;

public int solution(int[] rank, bool[] attendance) {
    List<int> students = new List<int>();
    for (int i = 0; i < rank.Length; i++) {
        if (attendance[i]) students.Add(i);
    }
    
    // 학생 번호(a, b)를 rank[a]와 rank[b]의 등수 기준으로 오름차순 정렬
    students.Sort((a, b) => rank[a].CompareTo(rank[b]));
    
    return 10000 * students[0] + 100 * students[1] + students[2];
}
```
- **람다 정렬 원리**: `(a, b)`는 정렬 알고리즘이 내부적으로 비교를 위해 넘겨주는 임의의 두 학생 번호이며, 우리는 판정 규칙(`rank[a].CompareTo(rank[b])`)만 정의하면 전체 요소가 자동으로 정렬됨.

### 2. LINQ 파이프라인 풀이
```csharp
using System;
using System.Linq;

public int solution(int[] rank, bool[] attendance) {
    var top3 = Enumerable.Range(0, rank.Length)
        .Where(i => attendance[i])
        .OrderBy(i => rank[i])
        .Take(3)
        .ToArray();
        
    return 10000 * top3[0] + 100 * top3[1] + top3[2];
}
```

## 대안별 종합 비교
| 방식 | 시간 복잡도 | 공간 복잡도 | $N=100,000$일 때 연산량 | 특징 |
|---|---|---|---|---|
| **`IndexOf` 반복 탐색** | $O(N^2)$ | $O(1)$ | 약 100억 번 (시간 초과 위험) | 코드가 직관적이고 $N \le 100$에서 문제없음 |
| **커스텀 리스트 정렬** | $O(N \log N)$ | $O(N)$ | 약 170만 번 | 사람이 생각하는 자연스러운 의식 흐름과 일치 |
| **역매핑 배열 (최종 제출 ⭐)** | **$O(N)$** | $O(N)$ | **약 10만 번 (초고속)** | 등수가 1~$N$ 고유값일 때 가장 강력한 최적화 |

## 다음에 볼 것
- 값과 인덱스의 관계를 뒤집어 $O(1)$로 조회하는 **역매핑(Reverse Mapping) 배열/테이블** 발상 익숙해지기
- `List.Sort((a, b) => ...)` 또는 `OrderBy(i => ...)` 커스텀 정렬 문법 숙지
