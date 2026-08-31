# 부분 문자열 (181842)

## 내가 한 질문
- 이전 문제(`부분 문자열인지 확인하기`, 181843)와 완전히 동일한 문제인가?
- 풀이 시 특별히 주의해야 할 점은 무엇인가?

## 막혔던 지점 및 개념 정리
- **이전 문제와의 관계**:
  - `부분 문자열인지 확인하기 (181843)`와 문제의 논리 및 풀이 구조가 100% 동일함.
- **실전 주의 사항 (주어와 목적어의 순서)**:
  - 매개변수가 `(str1, str2)`로 주어질 때 문제 지문을 주의 깊게 읽어야 함:
    - 지문: **"str1이 str2의 부분 문자열인가?"**
    - 검사 대상(전체 문자열 / 주어): `str2`
    - 찾는 단어(부분 문자열 / 목적어): `str1`
  - 따라서 ❌ `str1.Contains(str2)`가 아니라 ⭕ **`str2.Contains(str1)`**로 호출해야 함.
- **`Contains` vs `IndexOf`**:
  - 단순 포함 여부(`bool`) 판단 시: `str2.Contains(str1)`
  - 위치(인덱스)까지 필요할 시: `str2.IndexOf(str1)` (없으면 `-1`)

## 핵심 코드

### 1. `string.Contains` 활용 (삼항 연산자 - 최종 제출 ⭐)
```csharp
public class Solution {
    public int solution(string str1, string str2) {
        // str2(전체) 안에 str1(부분)이 포함되어 있으면 1, 없으면 0
        return str2.Contains(str1) ? 1 : 0;
    }
}
```

### 2. `string.IndexOf` 활용 (인덱스 위치 기반 풀이)
```csharp
public class Solution {
    public int solution(string str1, string str2) {
        // str2 안에서 str1의 시작 인덱스를 찾아 -1이 아니면 포함된 것으로 판별
        return str2.IndexOf(str1) != -1 ? 1 : 0;
    }
}
```

## 다음에 볼 것
- 유사한 이름의 매개변수가 여러 개 주어질 때는 **"어느 것이 전체 문자열이고, 어느 것이 부분 문자열인지"** 주어/목적어 관계를 정확히 파악 후 메서드 호출
