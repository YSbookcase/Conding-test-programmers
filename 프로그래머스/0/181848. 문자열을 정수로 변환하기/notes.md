# 문자열을 정수로 변환하기 (181848)

## 내가 한 질문
- `int.Parse` 대신 `int.TryParse`를 사용하는 것이 더 안정적인가?
- `int.Parse`와 `int.TryParse` 사이에 실제 성능 차이가 있는가?

## 막혔던 지점 및 개념 정리
- **이전 문제와의 자릿수 차이**:
  - 이전 문제(`문자열 정수의 합`): 길이 최대 100자리 ➔ `int` 파싱 불가
  - 이번 문제(`문자열을 정수로 변환하기`): 길이 최대 5자리 ➔ `int` 파싱 완벽 가능 (최대 99,999)
- **`int.Parse` vs `int.TryParse`의 성능과 안정성 비교**:
  - **정상 입력 시**: 두 방식의 실행 속도는 나노초 단위로 사실상 100% 동일함.
  - **비정상 입력("abc", null) 시**:
    - `int.Parse`: 무거운 `FormatException` 예외 객체를 생성하고 던져서 **수천 배 느려지고 앱/서버가 다운**될 위험.
    - `int.TryParse`: 예외 없이 즉시 `false`를 반환하고 안전하게 기본값 `0` 대입.
  - 실무 및 프로덕션 환경에서는 `TryParse`를 쓰는 것이 권장되는 모범 습관(Best Practice)임.

## 핵심 코드

### 1. `int.TryParse` 활용 (안전한 실무형 풀이 - 최종 제출 ⭐)
```csharp
using System;

public class Solution {
    public int solution(string n_str) {
        int.TryParse(n_str, out int num);
        return num;
    }
}
```

### 2. `int.Parse` 활용 (코딩테스트 1줄 풀이)
```csharp
using System;

public class Solution {
    public int solution(string n_str) {
        return int.Parse(n_str);
    }
}
```

## 파싱 메서드 종합 비교
| 메서드 | 정상 숫자 변환 | 잘못된 형식 ("abc") | `null` 입력 | 추천 상황 |
|---|---|---|---|---|
| **`int.TryParse` (최종 제출 ⭐)** | 정상 변환 | 🛡️ 에러 없이 `false` (`num=0`) | 🛡️ 에러 없이 `false` (`num=0`) | **실무 프로덕션, 안전한 입력 검증** |
| **`int.Parse`** | 정상 변환 | 💥 `FormatException` 예외 | 💥 `ArgumentNullException` 예외 | 코딩테스트처럼 입력이 100% 보장될 때 |

## 다음에 볼 것
- 정상 입력이 100% 보장된 코테에서는 `int.Parse`, 실무에서는 `int.TryParse` 습관화
- 입력 크기가 `int` 범위(-21억 ~ +21억, 약 10자리) 내인지 항상 체크
