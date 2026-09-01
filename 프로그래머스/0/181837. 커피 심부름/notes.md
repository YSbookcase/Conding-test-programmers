# 커피 심부름 (181837)

## 내가 한 질문
- `switch` 문으로 푸는 것이 좋을까?
- `Contains` 방식이 단순하지만, 가격 분류가 세분화되면 기존 방식을 확장하는 게 나을까, 아니면 `Dictionary` 등으로 전환하는 게 나을까?
- 설계 방향을 결정할 때 어떤 점을 고려해야 하는가?

## 막혔던 지점 및 개념 정리
- **문제의 핵심**: 가격은 온도(hot/ice)와 무관하고 **음료 종류(아메리카노/라테)**만으로 결정됨.
  - 아메리카노 계열: 4500원 (`americano` 포함, `anything` 포함)
  - 카페 라테 계열: 5000원 (`latte` 또는 `cafelatte` 포함)
- **`switch` vs `Contains`**:
  - `switch` + case 묶기: 11개 메뉴를 명시적으로 처리 가능하지만 코드가 길어짐.
  - `Contains`: 가격이 2종류뿐인 현재 문제에서는 가장 간결하고 충분함.
- **설계 결정 기준 (YAGNI vs 확장성)**:
  - **지금**: 가격 2종류 고정 → `Contains` 유지 (단순함이 최선).
  - **변화 신호**: 메뉴 5종 이상, 가격 각각 다름, 온도/사이즈별 가격 → `Dictionary` 또는 설정 기반 구조로 리팩토링.
  - **고려할 5가지**: 변화 가능성, 변경 비용 vs 유지 비용, 변경 주체(개발자/기획), 코드 수명, 오류 영향도.
  - **실무 원칙**: "미리 확장 가능하게"보다 **"바뀔 때 확장하기 쉽게"** 시작.

## 핵심 코드

### 1. `Contains` 활용 (최종 제출 ⭐)
```csharp
public class Solution {
    public int solution(string[] order) {
        int total = 0;

        foreach (string menu in order) {
            if (menu == "anything" || menu.Contains("americano")) {
                total += 4500;
            } else {
                total += 5000;
            }
        }

        return total;
    }
}
```

### 2. `switch` + case 묶기 (명시적 처리)
```csharp
foreach (string menu in order) {
    switch (menu) {
        case "iceamericano":
        case "americanoice":
        case "hotamericano":
        case "americanohot":
        case "americano":
        case "anything":
            total += 4500;
            break;
        default:
            total += 5000;
            break;
    }
}
```

### 3. `Dictionary` (메뉴·가격이 많아질 때)
```csharp
var priceMap = new Dictionary<string, int> {
    { "iceamericano", 4500 }, { "americanoice", 4500 },
    // ... 메뉴별 가격 등록
};
total += priceMap[menu];
```

## 방식별 선택 기준
| 방식 | 적합한 상황 |
|---|---|
| **`Contains` (최종 제출 ⭐)** | 가격이 음료 종류 2가지로만 나뉠 때 |
| **`switch` + case 묶기** | 케이스별 처리 로직이 다를 때 |
| **`Dictionary`** | 메뉴 종류가 많고 가격이 각각 다를 때 |

## 다음에 볼 것
- 가격이 2종류뿐이면 **`Contains`**로 충분, 메뉴가 늘어나면 그때 **`Dictionary`**로 전환
- 설계는 **"지금 필요한 만큼만"** 시작하고, 변화 신호가 오면 리팩토링
