# 두 수의 합 (181846)

## 내가 한 질문
- 입력 문자열의 길이가 최대 100,000자리일 때 `int`, `long`, `double`로 처리가 불가능한데 어떻게 접근해야 하는가?
- 무제한 크기의 정수를 다루는 `BigInteger`는 메모리만 있으면 정말 무제한인가?
- `BigInteger`도 `TryParse` 사용이 가능한가?
- 다른 언어(Python, Java, C++)에서는 큰 수를 어떻게 다루는가?
- 직접 문자열 세로셈(Simulation)을 구현할 때 흔히 발생하는 컴파일 에러와 네이밍 실수는 무엇인가?

## 막혔던 지점 및 개념 정리
- **자료형의 한계 파악**:
  - `int`: 약 21억 (최대 10자리)
  - `long`: 약 900경 (최대 19자리)
  - 문자열 길이 최대 100,000자리는 기본 정수형/실수형 타입의 범위를 아득히 초과함.
- **해결책 1: `BigInteger` (`System.Numerics`)**:
  - C#에서 무제한 크기의 정수를 지원하는 구조체.
  - 내부적으로 32비트 단위(`uint[]`) 배열을 동적으로 늘려가며 숫자를 저장하므로 메모리가 허용하는 한 무제한 연산 가능.
  - `BigInteger.Parse()`, `BigInteger.TryParse()` 모두 지원.
- **해결책 2: 직접 세로셈 시뮬레이션 (`StringBuilder`)**:
  - 초등학교 때 배운 덧셈처럼 일의 자리부터(`Length - 1`) 역순으로 더해가며 올림수(`carry`)를 다음 자리에 넘기는 방식.
  - 문자열 이어붙이기가 빈번하므로 `StringBuilder`를 사용하고, 마지막에 `Array.Reverse()`로 결과를 뒤집음.
- **자주 실수하는 C# 문법 및 네이밍 규칙**:
  - **클래스 및 메서드는 무조건 파스칼 표기법(첫 글자 대문자)**:
    - ❌ `stringBuilder` ➔ ⭕ `StringBuilder`
    - ❌ `Tostring()` ➔ ⭕ `ToString()`
    - ❌ `reverse()` ➔ ⭕ `Array.Reverse()`
  - **필수 `using` 네임스페이스 및 `s` 복수형 주의**:
    - `using System.Text;` (`StringBuilder`)
    - `using System.Numerics;` (`BigInteger` - 끝에 `s` 붙음)

## 핵심 코드

### 1. 직접 세로셈 시뮬레이션 구현 (알고리즘 정석 풀이 - 최종 제출 ⭐)
```csharp
using System;
using System.Text;

public class Solution {
    public string solution(string a, string b) {
        StringBuilder sb = new StringBuilder();
        
        int i = a.Length - 1;
        int j = b.Length - 1;
        int carry = 0;
        
        // 두 문자열을 모두 소진하고 올림수(carry)까지 없을 때까지 반복
        while (i >= 0 || j >= 0 || carry > 0) {
            int sum = carry;
            
            // 각 자리 숫자를 '0'을 빼서 정수로 변환 후 덧셈
            if (i >= 0) sum += a[i--] - '0';
            if (j >= 0) sum += b[j--] - '0';
            
            carry = sum / 10;
            sb.Append(sum % 10);
        }
        
        // 일의 자리부터 추가되었으므로 결과를 뒤집어서 반환
        char[] result = sb.ToString().ToCharArray();
        Array.Reverse(result);
        return new string(result);
    }
}
```

### 2. `BigInteger` 활용 (C# 표준 라이브러리 풀이)
```csharp
using System.Numerics;

public class Solution {
    public string solution(string a, string b) {
        // BigInteger를 사용하여 초거대 정수 덧셈 수행
        BigInteger numA = BigInteger.Parse(a);
        BigInteger numB = BigInteger.Parse(b);
        
        return (numA + numB).ToString();
    }
}
```

## 언어별 큰 수(Big Integer) 지원 비교
| 언어 | 지원 방식 | 특징 |
|---|---|---|
| **C#** | `System.Numerics.BigInteger` | 수동 임포트 필요, 무제한 정밀도 지원 |
| **Python** | 기본 `int` 타입 내장 | 3.x 버전부터 `int`가 자동으로 무제한 자릿수 지원 |
| **Java** | `java.math.BigInteger` | 불변 객체(Immutable), 메서드로 사칙연산(`add`, `multiply`) 수행 |
| **C / C++** | 표준 라이브러리 없음 | 직접 문자열 세로셈을 구현하거나 외부 라이브러리(`Boost`) 사용 |

## 다음에 볼 것
- 100자리 이상의 초대형 숫자는 기본 정수형이 불가능하므로 **`BigInteger`** 또는 **세로셈 시뮬레이션** 적용
- C# 메서드/클래스는 항상 **파스칼 표기법(`StringBuilder`, `ToString`)** 준수
