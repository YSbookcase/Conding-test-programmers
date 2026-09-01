# 그림 확대 (181836)

## 내가 한 질문
- 2중 `for`문과 `Replace`를 활용해 풀고 싶은데, 반복은 변수 `k`로 처리하면 되는가?
- Python의 `"x" * 3`처럼 문자열을 k번 반복하는 C# 문법이 있는가?
- `StringBuilder`는 새 결과를 조립하는 느낌이고 `Replace`는 기존 것을 바꾸는 느낌인데, 왜 `StringBuilder`가 더 깔끔하게 느껴지는가?
- 성능 면에서 `StringBuilder`와 `Replace` 방식의 차이는 얼마나 되는가?

## 막혔던 지점 및 개념 정리
- **Python `*` vs C# 대응**:
  - Python: `"x" * 3` → `"xxx"`
  - C#: **`new string('x', 3)`** → `"xxx"` (문자 1개를 k번 반복)
- **가로 확대 vs 세로 확대**:
  - **가로**: 각 픽셀(문자)을 k번 반복 → `new string(pixel, k)` 또는 `Replace`
  - **세로**: 완성된 한 줄을 `for (int i = 0; i < k; i++)`로 k번 `Add`
- **`Replace` vs `StringBuilder` (불변성)**:
  - C# `string`은 **불변(Immutable)** → `Replace`도 기존 문자열을 수정하지 않고 **새 문자열을 생성**.
  - `StringBuilder`는 "새 그림을 조립한다"는 의도가 문제 흐름과 더 잘 맞아 가독성이 좋음.
- **성능 비교 (이 문제: picture ≤ 20×20, k ≤ 10)**:
  - 최대 결과 약 4만 글자 → **두 방식 모두 0.1ms 안쪽, 체감 차이 거의 없음**.
  - `Replace` 2번: 중간 문자열 1~2개 생성, 런타임 최적화로 짧은 문자열에서 빠름.
  - `StringBuilder` + `Append` 반복: 버퍼 1개 + 최종 1개, 픽셀마다 `new string` 없이 붙이면 가장 효율적.
  - **`+=` 반복**: O(N²) 성능 저하 → 반복문 내 문자열 결합 시 절대 비추천.

## 핵심 코드

### 1. `StringBuilder` 활용 (최종 제출 ⭐)
```csharp
using System.Collections.Generic;
using System.Text;

public class Solution {
    public string[] solution(string[] picture, int k) {
        List<string> answer = new List<string>();

        foreach (string row in picture) {
            StringBuilder expandedRow = new StringBuilder();

            // 가로 k배: 각 픽셀을 k번 반복
            foreach (char pixel in row) {
                expandedRow.Append(new string(pixel, k));
            }

            // 세로 k배: 완성된 줄을 k번 추가
            for (int i = 0; i < k; i++) {
                answer.Add(expandedRow.ToString());
            }
        }

        return answer.ToArray();
    }
}
```

### 2. `Replace` 활용 (가로 확대에 적합한 대안)
```csharp
foreach (string row in picture) {
    string expandedRow = row
        .Replace(".", new string('.', k))
        .Replace("x", new string('x', k));

    for (int i = 0; i < k; i++) {
        answer.Add(expandedRow);
    }
}
```

### 3. `StringBuilder` + `Append` 반복 (성능 최적화 버전)
```csharp
foreach (char pixel in row) {
    for (int rep = 0; rep < k; rep++) {
        expandedRow.Append(pixel); // new string 없이 문자만 k번 추가
    }
}
```

## 방식별 비교
| 방식 | 가독성 | 성능 (이 문제) | 추천 상황 |
|---|---|---|---|
| **`StringBuilder` (최종 제출 ⭐)** | 높음 (조립 의도 명확) | 충분히 빠름 | 반복문으로 결과를 쌓아갈 때 |
| **`Replace` + `new string`** | 중간 (치환 느낌) | 충분히 빠름 | 문자 종류가 고정이고 적을 때 |
| **`StringBuilder` + `Append` 반복** | 중간 | 가장 효율적 | 대용량 문자열 조립 시 |

## Python vs C# 문자열 반복
| Python | C# |
|---|---|
| `"x" * 3` | `new string('x', 3)` |
| `"abc" * 2` | `string.Concat(Enumerable.Repeat("abc", 2))` |

## 다음에 볼 것
- 문자 1개 k번 반복: **`new string(문자, k)`**
- 반복문 내 문자열 결합: **`StringBuilder`** 필수, `+=` 금지
- 가로는 픽셀 확대, 세로는 **같은 줄 k번 복사**로 분리해서 생각
