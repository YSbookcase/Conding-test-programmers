# l로 만들기 (181834)

## 내가 한 질문
- `ToCharArray` + 비교로 풀려 했는데 왜 안 되나? (`'I'`/`'l'`, `foreach`, 반환 방식)
- 원본을 바꾸려면 왜 `foreach`가 아니라 `for`인가?
- `for` + `char[]`와 `StringBuilder`의 성능 차이는?

## 막혔던 지점 및 개념 정리
- **문제 핵심**: `'l'`보다 앞선 문자(`a`~`k`)를 `'l'`로 바꾸고, `'l'` 이상은 유지.
- **초기 실수**:
  - `new char[myString]` 불가 → `myString.ToCharArray()` 사용.
  - 비교 대상은 대문자 `'I'`가 아니라 소문자 `'l'`.
  - `foreach`의 `chr`은 **복사본**이라 `chr = 'l'`해도 원본 `char[]`가 안 바뀜 → **인덱스 `for`** 필요.
  - `return chr.ToString()`은 마지막 글자만 반환 → `new string(chars)`.
- **`foreach` vs `for`**:
  - 배열 원소를 **직접 수정**하려면 `for` + `chars[i] = ...`.
  - `foreach`를 쓰려면 `StringBuilder`에 **새 결과를 조립**하는 방식이어야 함.
- **성능 (`길이 ≤ 100,000`)**:
  - `for` + `char[]`: `ToCharArray` 1번 + 제자리 수정 + `new string` → 보통 가장 유리.
  - `StringBuilder`: 조립 방식, 초기 용량을 길이로 주면 재할당 감소. 이 문제에서는 체감 차이 작음.
  - 공통: 입력 길이 = 출력 길이라 `+=` 반복은 비추천.

## 핵심 코드

### 1. `for` + `char[]` (최종 제출 ⭐)
```csharp
public class Solution {
    public string solution(string myString) {
        char[] chars = myString.ToCharArray();

        for (int i = 0; i < chars.Length; i++) {
            if (chars[i] < 'l') {
                chars[i] = 'l';
            }
        }

        return new string(chars);
    }
}
```

### 2. `StringBuilder` + `foreach` (대안)
```csharp
StringBuilder sb = new StringBuilder(myString.Length);

foreach (char c in myString) {
    sb.Append(c < 'l' ? 'l' : c);
}

return sb.ToString();
```

## 방식 비교
| 방식 | 원본 수정 | 특징 |
|---|---|---|
| **`for` + `char[]` (최종 제출 ⭐)** | ⭕ | 길이 고정 치환에 적합, 보통 더 빠름 |
| **`StringBuilder` + `foreach`** | 새 문자열 조립 | 읽으면서 결과 만들 때 자연스러움 |

## 다음에 볼 것
- 문자 비교는 `'l'` 같은 **문자 리터럴**로 사전순 비교 가능
- 배열 값 수정 → **`for`**, 읽기만/`StringBuilder` 조립 → **`foreach` 가능**
- 긴 문자열 치환은 `char[]` 제자리 수정 또는 `StringBuilder` 사용 (`+=` 금지)
