# 뒤에서 5등 위로 (181852)

## 내가 한 질문
- `Array.Copy`를 사용해서 특정 구간만 지정해 복사할 수 있는가?
- `Array.Copy` 매개변수 사용법이 기억나지 않을 때는 `for`문으로 어떻게 해결할 수 있는가?
- `Array.Copy` 매개변수 중 '시작 인덱스'와 '복사할 길이(개수)'의 구분 시 주의점은?
- C# 8.0의 슬라이싱 범위 연산자(`..`)와 데이터 모델링(UML/DB) 카디널리티 표기법과의 연관성은?

## 막혔던 지점 및 문법 정리
- **`new` 배열 생성 시 타입 누락**:
  - `new [크기]` ❌ ➔ `new int[크기]` ⭕
- **`Array.Copy`의 5개 매개변수 오버로딩 규칙**:
  - `Array.Copy(원본, 원본시작인덱스, 대상, 대상시작인덱스, 복사할개수)`
  - 마지막 매개변수는 전체 길이가 아니라 **실제 복사할 개수(`num_list.Length - 5`)**를 전달해야 범위 초과 에러를 방지할 수 있음.

## 핵심 패턴 및 코드 발전 과정

### 1. `Array.Copy` 활용 (최종 제출 ⭐)
```csharp
Array.Sort(num_list);
int[] result = new int[num_list.Length - 5];
Array.Copy(num_list, 5, result, 0, num_list.Length - 5);
return result;
```

### 2. `for`문 직접 복사 (메서드가 기억나지 않을 때의 대안)
```csharp
Array.Sort(num_list);
int[] result = new int[num_list.Length - 5];
int index = 0;
for (int i = 5; i < num_list.Length; i++)
{
    result[index++] = num_list[i]; // 또는 result[i - 5] = num_list[i]
}
return result;
```

## 추가 풀이 방법들 (대안 정리)

### 1. C# 8.0 범위 연산자(슬라이싱 `..`) 활용
```csharp
using System;

public int[] solution(int[] num_list) {
    Array.Sort(num_list);
    return num_list[5..]; // 5번 인덱스부터 끝까지 잘라내기
}
```
- **개념 연결**: 데이터 모델링/UML에서 범위(`0..5` 등)를 나타내듯, C# 코드에서도 `[5..]`로 인덱스 범위를 간결하게 슬라이싱 가능.

### 2. LINQ `Skip` 활용 (1줄 풀이)
```csharp
using System;
using System.Linq;

public int[] solution(int[] num_list) {
    return num_list.OrderBy(x => x).Skip(5).ToArray();
}
```

## LINQ 대칭 비교: `Take` vs `Skip`
| 메서드 | 의미 | 활용 문제 |
|---|---|---|
| **`Take(N)`** | 앞에서부터 N개를 **가져오기** | 뒤에서 5등까지 (`OrderBy().Take(5)`) |
| **`Skip(N)`** | 앞에서부터 N개를 **건너뛰고 나머지 가져오기** | 뒤에서 5등 위로 (`OrderBy().Skip(5)`) |

## 다음에 볼 것
- `Array.Copy`의 `(..., 시작인덱스, ..., 복사할개수)` 매개변수 순서 명확히 숙지
- 특정 구간 복사 시 `for`문, 슬라이싱(`[5..]`), LINQ `Skip(5)` 등 상황별 무기 선택
