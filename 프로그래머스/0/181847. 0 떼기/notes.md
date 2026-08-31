# 0 떼기 (181847)

## 내가 한 질문
- 정수로 변환했다가 다시 문자열로 되돌리는 방식(`int.Parse` ➔ `.ToString()`)으로 풀 수 있는가?
- 앞의 특정 문자(`'0'`)만 깔끔하게 제거하는 전용 문자열 메서드가 있는가?

## 막혔던 지점 및 개념 정리
- **정수 변환 방식의 장단점**:
  - `int.Parse(n_str).ToString()` 또는 `int.TryParse`:
    - 숫자로 바꾸면서 앞자리 `0`이 자연스럽게 날아가므로 이번 문제(길이 2~10)에서는 통과 가능.
    - 단, 자릿수가 10자리를 넘어가면 `int` 오버플로우 위험이 있으므로 문자열 자체를 처리하는 방식이 훨씬 안전함.
- **`TrimStart('0')` 문자열 전용 메서드**:
  - 문자열의 **시작 부분(왼쪽)**에 연속으로 등장하는 특정 문자(`'0'`)를 모두 제거해 줌.
  - 숫자 변환 오버헤드와 오버플로우 걱정 없이 원본 문자열 기반으로 가장 직관적이고 빠르게 동작함.
- **`Trim`, `TrimStart`, `TrimEnd` 비교**:
  - `Trim()`: 앞뒤 모든 공백(또는 지정 문자) 제거
  - `TrimStart('0')`: 왼쪽(시작)의 `'0'`만 제거
  - `TrimEnd('0')`: 오른쪽(끝)의 `'0'`만 제거

## 핵심 코드

### 1. `TrimStart` 활용 (문자열 전용 메서드 - 최종 제출 ⭐)
```csharp
public class Solution {
    public string solution(string n_str) {
        // 문자열 왼쪽의 0들을 모두 제거
        return n_str.TrimStart('0');
    }
}
```

### 2. 정수 변환 활용 (자릿수 제한이 작을 때의 우회 풀이)
```csharp
using System;

public class Solution {
    public string solution(string n_str) {
        // int로 변환하면서 0을 떼고 다시 문자열로 반환
        return int.Parse(n_str).ToString();
    }
}
```

## 다음에 볼 것
- 문자열에서 특정 접두사/접미사를 지울 때는 `TrimStart()`, `TrimEnd()` 적극 활용
- 숫자의 길이가 길어질 가능성이 있는 문제는 타입 변환보다 문자열 처리 메서드 우선 고려
