# 배열의 원소 삭제하기 (181844)

## 내가 한 질문
- 순서를 유지하면서 삭제 대상을 효율적으로 걸러내려면 어떻게 접근해야 하는가?
- 해시 탐색(`HashSet`)의 단점으로 잦은 추가/삭제에 비효율적이라고 들었는데 왜 그런가?
- 데이터 크기가 작은 현재 문제(100개 이하)에서는 `HashSet`을 쓰는 것이 오히려 더 느린가?
- LINQ(`Where` + `Contains`)를 통한 탐색 및 필터가 성능 면에서 많은 시간을 소모하는 이유는 무엇인가?
- 게임 서버나 고성능 실무 백엔드에서는 실제로 LINQ 사용을 지양하는가?
- 프로그램의 4대 메모리 영역(코드, 데이터, 힙, 스택)의 특징과 가비지 컬렉터(GC)의 관계는 무엇인가?

## 막혔던 지점 및 개념 정리
- **순서 유지 제약 조건**:
  - `arr`의 기존 순서를 유지해야 하므로, 정렬 후 비교하는 방식보다 `arr`을 순차적으로 순회하며 필터링하는 것이 가장 직관적임.
- **`HashSet`의 장단점 및 사용 시점**:
  - **단점**: 객체 생성 오버헤드, 해시 버킷 메모리 낭비(일반 배열의 2~4배), 리사이징(Rehashing) 비용, CPU 캐시 비친화적.
  - **단점이 상쇄되는 시점**: 데이터가 수천~수십만 개 이상이고, 생성 후 **조회(`Contains`)만 압도적으로 많이 반복**될 때 $O(1)$ 탐색으로 폭발적인 성능 향상.
  - **작은 데이터(100개 이하)**: 단순 배열 `for`문 순회가 CPU L1 캐시 적중률(Cache Locality) 덕분에 객체 생성/해시 연산보다 더 빠름.
- **LINQ의 성능 오버헤드 원인**:
  1. 열거자(`IEnumerator`) 힙 객체 생성으로 인한 GC 압박.
  2. 람다 함수(델리게이트) 간접 호출 비용.
  3. `ToArray()` 호출 시 크기를 늘려가며 배열을 재할당하고 복사하는 버퍼 오버헤드.
- **실무 영역별 LINQ 사용 기준**:
  - **게임 루프(`Update`), 게임 서버 패킷 처리**: 프레임 드랍(GC Stop-the-World/스터터링) 방지를 위해 **LINQ 금지 / `for`문 및 제로 할당(Zero Allocation)** 지향.
  - **웹 백엔드, 초기 로딩 데이터 파싱, 코딩테스트**: 생산성과 가독성이 우선이므로 **LINQ 적극 활용**.
- **메모리 구조 (스택 vs 힙)**:
  - **스택(Stack)**: 함수 내 값 타입/주소값 저장, 함수 종료 시 즉시 자동 소멸 (초고속, 제로 GC).
  - **힙(Heap)**: `new`로 생성된 참조 객체 저장, GC가 주기적으로 수거 (할당/해제 비용 큼, 렉 유발 원인).

## 핵심 코드

### 1. `HashSet` + LINQ 활용 (대용량 데이터 대비 최적화 - 최종 제출 ⭐)
```csharp
using System.Collections.Generic;
using System.Linq;

public class Solution {
    public int[] solution(int[] arr, int[] delete_list) {
        // delete_list를 탐색 속도 O(1)인 HashSet으로 변환
        HashSet<int> deleteSet = new HashSet<int>(delete_list);
        
        // arr의 순서를 유지하며 O(1)로 삭제 대상 확인
        return arr.Where(x => !deleteSet.Contains(x)).ToArray();
    }
}
```

### 2. `List<int>` + `Array.IndexOf` 활용 (소규모 데이터 최적 풀이)
```csharp
using System;
using System.Collections.Generic;

public class Solution {
    public int[] solution(int[] arr, int[] delete_list) {
        List<int> result = new List<int>();
        
        foreach (int num in arr) {
            // delete_list에 없는 원소만 순서대로 추가
            if (Array.IndexOf(delete_list, num) == -1) {
                result.Add(num);
            }
        }
        
        return result.ToArray();
    }
}
```

## 방식별 시간 복잡도 및 특징 비교
| 방식 | 시간 복잡도 | 메모리 할당 | 추천 상황 |
|---|---|---|---|
| **`List` + `Array.IndexOf`** | $O(N \times M)$ | 적음 | $N, M \le 100$ 이하 소규모 데이터, CPU 캐시 극대화 |
| **`HashSet` + `Where` (최종 제출 ⭐)** | $O(N + M)$ | 중간 | $N, M \ge 1,000$ 이상 대규모 데이터 탐색 |
| **순수 LINQ (`Where` + `Contains`)** | $O(N \times M)$ | 많음 (GC 발생) | 간결한 1줄 코드가 필요할 때 |

## 다음에 볼 것
- 원소 포함 여부를 수만 번 이상 반복 검사할 때는 **`HashSet<T>`** 고려
- 성능과 메모리가 극도로 중요한 핫 패스(Hot Path) 구간에서는 **LINQ 대신 `for`문과 스택 기반 연산** 활용
