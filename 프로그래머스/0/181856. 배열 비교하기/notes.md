# 배열 비교하기 (181856)

## 내가 한 질문
- 길이 비교 후 합을 구하는 정석 풀이 외에 더 나은 방법이 있는가?
- LINQ `Sum()`의 내부 동작 방식은 순수 `for`문 누적합보다 빠른가?
- 삼항 연산자와 `Sum()`을 조합한 조건 분기 작성 시 오류가 없는가?

## 막혔던 지점 및 개념 정리
- **`Sum()` vs `for`문 성능 비교**:
  - `Sum()`은 내부적으로 `foreach`를 순회하며 열거자(Enumerator) 생성 및 메서드 호출 오버헤드가 발생함.
  - 단순 속도는 컴파일러 최적화가 적용되는 **순수 `for`문이 가장 빠름**.
  - 다만 일반적인 코딩테스트(데이터 10만 개 이하)에서는 실행 시간 차이가 미미하므로, **가독성과 코드 축약을 위해 `Sum()`을 활용**하는 것이 실전적임 (`using System.Linq;` 필수).
- **대소 비교 내장 메서드 `CompareTo()`**:
  - C#의 숫자 타입에 내장된 `A.CompareTo(B)`는 $A > B$이면 `1`, $A < B$이면 `-1`, $A == B$이면 `0`을 반환.
  - 문제에서 요구하는 반환 규칙(`1, -1, 0`)과 정확히 일치하여 삼항 연산자나 if-else 분기를 극단적으로 줄일 수 있음.

## 핵심 패턴 및 코드 발전 과정
1. **1단계 (정석 `for`문)**:
   - `arr1.Length != arr2.Length` 비교 후, 같으면 `for`문으로 각각 `aSum`, `bSum` 누적하여 대소 비교.
2. **2단계 (LINQ `Sum()` + 삼항 연산자)**:
   - `if (arr1.Length != arr2.Length) return arr1.Length > arr2.Length ? 1 : -1;`
   - `return sum1 == sum2 ? 0 : (sum1 > sum2 ? 1 : -1);`
3. **3단계 (`CompareTo()` 활용 - 최종 제출)**:
   - `if (arr1.Length != arr2.Length) return arr1.Length.CompareTo(arr2.Length);`
   - `return arr1.Sum().CompareTo(arr2.Sum());`

## 대안별 구현 방식 정리
| 방식 | 길이 비교 | 합계 비교 | 특징 |
|---|---|---|---|
| **순수 `for`문** | `if (a < b) return -1;` | `for` 루프 2번 누적 후 if 분기 | 외부 라이브러리 없음, 실행 속도 최상 |
| **LINQ `Sum()` + 삼항 연산자** | `arr1.Length > arr2.Length ? 1 : -1` | `sum1 > sum2 ? 1 : -1` | 가독성 좋고 실수 여지 적음 |
| **`CompareTo()` (최종 제출)** | `arr1.Length.CompareTo(arr2.Length)` | `arr1.Sum().CompareTo(arr2.Sum())` | 문제 요구 반환값과 1:1 매핑되어 코드가 가장 간결 |

## 다음에 볼 것
- 값의 대소에 따라 `1, -1, 0`을 반환하는 요구조건을 보면 `CompareTo()` 떠올리기
- 성능 극대화가 필요한 대규모 데이터에서는 순수 `for`문, 가독성과 생산성이 우선일 때는 LINQ 활용
