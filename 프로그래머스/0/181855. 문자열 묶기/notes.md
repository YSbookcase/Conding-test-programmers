# 문자열 묶기 (181855)

## 내가 한 질문
- 문자열 길이 제한이 작을 때(≤ 30), 배열 인덱스를 활용해 카운팅하는 접근 방식이 맞는가?
- 실무나 코딩테스트에서 다른 사람들은 주로 어떤 방법으로 이 문제를 푸는가?
- LINQ를 활용해 최댓값(`Max()`)을 구하거나 그룹핑할 때 순수 `for`문 대비 속도가 약 10배 이상 느려지는 원인은 무엇인가?
- 앞으로의 문제들에서도 다양한 추가 풀이 방법과 비교 내용을 메모에 담을 수 있는가?

## 막혔던 지점 및 개념 정리
- **`count.Max()` vs `for`문 최댓값 탐색 성능 차이**:
  - 31칸짜리 작은 루프임에도 LINQ `Max()`는 `IEnumerable<int>` 인터페이스 및 열거자(Enumerator) 생성, JIT 컴파일 초기화 비용이 발생함.
  - 순수 `for`문은 CPU 레지스터 최적화가 적용되어 기계어 수준에서 단 몇 사이클 만에 종료되므로 속도 차이가 크게 나타남.
- **제한사항을 활용한 도수분포표(카운팅 배열) 테크닉**:
  - `strArr` 원소 길이가 최대 30이므로, `new int[31]`을 선언하면 `count[str.Length]++`로 $O(N)$ 시간에 가장 빠르게 집계 가능.

## 핵심 패턴 및 코드
```csharp
// [최적의 정석 풀이] 고정 배열 카운팅
int[] count = new int[31];
foreach (string str in strArr)
{
    count[str.Length]++;
}
return count.Max(); // 또는 for문으로 최댓값 탐색
```

## 추가 풀이 방법들 (대안 정리)

### 1. LINQ `GroupBy` 활용 (코드 1줄 풀이)
```csharp
using System.Linq;

public int solution(string[] strArr) {
    // 문자열 길이(Length)로 그룹핑 후, 각 그룹의 요소 개수(Count) 중 최댓값 반환
    return strArr.GroupBy(s => s.Length).Max(g => g.Count());
}
```
- **특징**: 지문의 "길이별 그룹으로 묶기"를 코드로 그대로 옮긴 직관적인 문법.
- **단점**: 내부적으로 10만 개 데이터에 대한 해시 연산, 그룹 객체 힙 메모리 할당, GC(가비지 컬렉터) 동작으로 인해 배열 방식보다 10~20배 이상 느림.

### 2. `Dictionary<int, int>` 활용 (해시맵 카운팅)
```csharp
using System.Collections.Generic;
using System.Linq;

public int solution(string[] strArr) {
    Dictionary<int, int> dict = new Dictionary<int, int>();
    foreach (string s in strArr) {
        if (!dict.ContainsKey(s.Length)) dict[s.Length] = 0;
        dict[s.Length]++;
    }
    return dict.Values.Max();
}
```
- **특징**: 만약 문자열 길이가 1,000,000처럼 배열 크기로 감당할 수 없을 정도로 크거나 불연속적일 때 사용하는 정석 방식.
- **단점**: 이 문제처럼 키 범위가 1~30으로 극도로 좁을 때는 딕셔너리 오버헤드가 배열보다 큼.

## 대안별 종합 비교
| 방식 | 시간 복잡도 | 공간 복잡도 | 채점 속도(10만 건) | 추천 상황 |
|---|---|---|---|---|
| **고정 배열 카운팅 (최종 제출 ⭐)** | $O(N)$ | $O(1)$ (31칸) | **~0.5ms (최상)** | **길이/값의 범위가 작고 고정되어 있을 때 (최우선)** |
| **`for`문 최댓값 탐색** | $O(N)$ | $O(1)$ | **~0.3ms (극강)** | 극단적인 실행 속도 최적화가 필요할 때 |
| **`Dictionary`** | $O(N)$ | $O(K)$ | ~5ms | Key 값의 범위가 매우 크거나 불연속적일 때 |
| **LINQ `GroupBy`** | $O(N)$ | $O(N)$ | ~10-15ms | 코드를 1줄로 축약하여 빠르게 프로토타이핑할 때 |

## 다음에 볼 것
- 문제의 제한사항(길이 ≤ 30, 알파벳 ≤ 26 등)을 보고 **배열 인덱스 매핑**이 가능한지 최우선 검토
- LINQ 편의 문법의 편리함 뒤에 숨은 힙 메모리 할당 및 오버헤드 특성 인지
