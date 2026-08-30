# 배열의 길이를 2의 거듭제곱으로 만들기 (181857)

## 내가 한 질문
- 2의 거듭제곱 값들을 배열에 하드코딩하고 `if/else if`로 분기하는 접근이 맞는가? 다른 방식이 있는가?
- 배열을 리스트로 변환할 때 선언 시 생성자(`new List<int>(arr)`) 외에 다른 방법이 있는가?
- `.ToList()`와 `.AddRange()`, 생성자 전달 방식의 네임스페이스(`LINQ`) 필요 여부 차이는?
- 2의 거듭제곱 목표 길이를 구하고 처리할 때 추가로 알아두면 좋은 요소는?

## 막혔던 지점 및 개념 정리
- **2의 거듭제곱 시작값**: 2의 0제곱은 `1` ($2^0 = 1$)이므로 $\{1, 2, 4, 8, 16...\}$ 수열임 (`0`은 거듭제곱이 아님).
- **타입 대입 오류**: `List<int> result = arr;`는 배열과 리스트의 타입 불일치로 불가 ➔ `new List<int>(arr)` 또는 `arr.ToList()` 사용 필요.
- **분기문 축약**: 일일이 분기하지 않고 `while (targetLen < arr.Length) targetLen *= 2;`로 목표 길이를 바로 산출 가능.

## 핵심 패턴 및 개념
- **2의 거듭제곱 목표 길이 탐색**:
  - `int targetLen = 1; while (targetLen < arr.Length) targetLen *= 2;` (또는 `targetLen <<= 1;`)
- **배열을 리스트로 변환하는 3가지 방법**:
  1. `arr.ToList()` : `using System.Linq;` 필수
  2. `list.AddRange(arr)` : `System.Collections.Generic`만으로 가능 (기존 리스트에 추가)
  3. `new List<int>(arr)` : `System.Collections.Generic`만으로 가능 (생성자 복사)
- **배열 크기 변경 편의 메서드**:
  - `Array.Resize(ref arr, targetLen)`: 한 줄로 배열 크기를 늘릴 수 있으며, 늘어난 빈자리는 자동으로 `0`으로 채워짐.
- **비트 연산 응용**:
  - 2의 거듭제곱 판별 공식: `(N & (N - 1)) == 0` (단, $N > 0$)

## 대안별 구현 방식 정리
| 방식 | 목표 길이 탐색 | 0 채우기 | 특징 |
|---|---|---|---|
| **List (최종 제출)** | `targetLen *= 2` | `while (result.Count < targetLen) result.Add(0);` | 직관적이고 안전한 리스트 방식 |
| **고정 배열 + `Array.Copy`** | `targetLen *= 2` | `int[] result = new int[targetLen]; Array.Copy(arr, result, arr.Length);` | 배열 생성 시 기본값 0 자동 채움 활용 |
| **`Array.Resize`** | `targetLen *= 2` | `Array.Resize(ref arr, targetLen);` | 가장 코드가 짧고 별도 배열 생성 불필요 |

## 다음에 볼 것
- 규칙적인 증가 수열은 배열 나열보다 `while` 루프로 목표값 도달 조건 작성
- `Array.Resize`와 C#의 기본값 자동 채움(`int`는 `0`) 특성 기억하기
