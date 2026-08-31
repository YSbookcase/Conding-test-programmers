# 부분 문자열인지 확인하기 (181843)

## 내가 한 질문
- `string` 검색에 `Array.IndexOf`를 사용할 수 있는가?
- 데이터 타입(배열, 문자열, 리스트, 튜플, 딕셔너리 등)별 탐색 메서드가 헷갈리는데 어떻게 정리할 수 있는가?
- 딕셔너리(`Dictionary`)에서 키(Key)와 값(Value)의 존재 여부는 각각 어떻게 확인하는가?
- 단순 존재 여부 검사 시 `Dictionary` 대신 `HashSet`을 주로 언급한 이유는 무엇인가?
- '자료형(Data Type)'과 '자료구조(Data Structure)'라는 표현의 차이와 실무에서의 소통 방식은 어떠한가?

## 막혔던 지점 및 개념 정리
- **`Array.IndexOf` vs `string.Contains` / `string.IndexOf`**:
  - `Array.IndexOf(arr, item)`: 1차원 **배열(`T[]`)** 전용 정적 메서드로, `char[]` 형태의 글자 1개 단위는 찾을 수 있으나 `"ana"` 같은 **연속된 부분 문자열(단어)** 검색 불가.
  - `my_string.Contains(target)`: 문자열 인스턴스 전용 메서드로, 해당 단어가 포함되어 있는지 `bool`(`true`/`false`) 반환.
  - `my_string.IndexOf(target)`: 문자열 인스턴스 전용 메서드로, 부분 문자열이 시작하는 인덱스 반환 (없으면 `-1`).
- **`Dictionary` 탐색 메서드 및 시간 복잡도**:
  - `dict.ContainsKey(key)`: 키 존재 여부 확인 ➔ **$O(1)$ 초고속 (해시 조회)**.
  - `dict.TryGetValue(key, out val)`: 키 존재 확인과 동시에 안전하게 값 꺼내기 ➔ **$O(1)$ (실무 추천)**.
  - `dict.ContainsValue(val)`: 특정 값이 들어있는지 확인 ➔ **$O(N)$ (전체 순차 탐색)**.
- **`HashSet` vs `Dictionary` 용도 구분**:
  - `HashSet<T>`: 단순 **"존재 여부(출석 체크)"**만 확인할 때 사용 (메모리 절약, $O(1)$).
  - `Dictionary<TKey, TValue>`: **"키를 통해 연관된 값(성적표)"**을 매핑/조회할 때 사용.
- **자료형(타입) vs 자료구조 실무 소통**:
  - 문법/코드 레벨에서는 통칭 **'타입(Type)'** (`int 타입`, `List 타입`, `Dictionary 타입`) 사용.
  - 알고리즘/메모리/시간복잡도 논의 시 **'자료구조(Data Structure)'** 사용.
  - 기본 숫자/문자는 **'원시/값 타입(Primitive / Value Type)'**으로 명확히 구분.

## 핵심 코드

### 1. `string.Contains` 활용 (삼항 연산자 - 최종 제출 ⭐)
```csharp
public class Solution {
    public int solution(string my_string, string target) {
        // target 단어가 포함되어 있으면 1, 없으면 0 반환
        return my_string.Contains(target) ? 1 : 0;
    }
}
```

### 2. `string.IndexOf` 활용 (인덱스 위치 기반 풀이)
```csharp
public class Solution {
    public int solution(string my_string, string target) {
        // 못 찾으면 -1을 반환하므로 -1이 아니면 1, 맞으면 0
        return my_string.IndexOf(target) != -1 ? 1 : 0;
    }
}
```

## 데이터 타입별 탐색 치트시트
| 데이터 타입 | 존재 여부 (`bool`) | 위치 찾기 (`int` 인덱스) | 탐색 특징 |
|---|---|---|---|
| **문자열 (`string`)** | `s.Contains("단어")` | `s.IndexOf("단어")` | 인스턴스 메서드(점 찍고 바로 호출) |
| **배열 (`int[]`)** | `arr.Contains(item)` *(LINQ)* | `Array.IndexOf(arr, item)` | `Array.` 정적 클래스 메서드 사용 |
| **리스트 (`List<T>`)** | `list.Contains(item)` | `list.IndexOf(item)` | 인스턴스 메서드 |
| **해시셋 (`HashSet<T>`)** | `set.Contains(item)` | ❌ 지원 안 함 (순서 없음) | $O(1)$ 초고속 단순 존재 체크 |
| **딕셔너리 (`Dictionary`)** | `dict.ContainsKey(key)` ($O(1)$)<br>`dict.ContainsValue(val)` ($O(N)$) | ❌ 인덱스 없음 (키로 접근) | 키 탐색은 $O(1)$, 값 탐색은 $O(N)$ |

## 다음에 볼 것
- 문자열 부분 단어 검색은 **`Contains()`** 또는 **`IndexOf()`** 인스턴스 메서드 활용
- 키-값 매핑이 불필요한 단순 포함 여부 검사는 `Dictionary`보다 가벼운 **`HashSet`** 선택
