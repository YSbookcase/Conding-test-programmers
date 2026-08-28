# 빈 배열에 추가, 삭제하기 (181860)

## 내가 한 질문
- 배열로도 구현 가능한가? 리스트가 더 적합한가?
- 요소 제거 시 `Remove(원소)`로 처리하면 되는가?
- `RemoveRange`를 모르면 풀기 어려운 문제인가?
- `RemoveAt`과 `Take`는 어떤 차이가 있는가? (`Take`는 LINQ 요소인가?)
- `Stack<T>`을 배열로 변환할 때는 어떻게 동작하는가?
- 고정 크기 배열로 풀 때 `size`만 줄여도 메모리나 동작에 문제가 없는가?

## 막혔던 지점 및 개념 정리
- `List.Remove(값)`: 특정 '값'과 일치하는 첫 번째 요소를 지움 (맨 뒤 N개 삭제 불가).
- `List.RemoveRange(시작인덱스, 개수)`: 특정 범위의 연속된 N개를 한 번에 삭제.
- `List.RemoveAt(인덱스)`: 특정 '위치'의 1개 요소 삭제 (`RemoveAt(Count - 1)` 반복으로 대체 가능).
- `arr[i] * 2`번 추가해야 하므로 반복문이나 Enumerable 생성이 필요함.

## 핵심 패턴
- **동적 추가 / 뒤쪽 연속 삭제**: `List<int>` + `Add` + `RemoveRange`
- **스택 활용**: `Stack<int>`에 `Push`, `Pop` 후 `stack.Reverse().ToArray()`로 반환
- **고정 배열 + 포인터(`size`)**:
  - 값을 실제로 지울 필요 없이 `size -= arr[i]`로 유효 범위만 축소
  - 새 값이 들어올 때 이전 값을 자연스럽게 덮어쓰기(Overwrite)

## 대안별 구현 방식 정리
| 방식 | 추가 (true) | 삭제 (false) | 특징 |
|---|---|---|---|
| **List (채택)** | `for`문 돌며 `x.Add(arr[i])` | `x.RemoveRange(x.Count - arr[i], arr[i])` | 가장 직관적이고 깔끔함 |
| **List (RemoveAt)** | `for`문 돌며 `x.Add(arr[i])` | `for`문 돌며 `x.RemoveAt(x.Count - 1)` | `RemoveRange`를 몰라도 가능 |
| **Stack** | `for`문 돌며 `stack.Push(arr[i])` | `for`문 돌며 `stack.Pop()` | 뒤집기(`Reverse()`) 필요 |
| **고정 배열** | `arr[size++] = arr[i]` | `size -= arr[i]` | 메모리 재할당 없이 가장 빠름 |

## 다음에 볼 것
- 리스트 요소 삭제 3형제 구분: `Remove(값)`, `RemoveAt(인덱스)`, `RemoveRange(시작, 개수)`
- 스택의 `ToArray()`는 최신 입력값부터 나오는 역순이라는 점 유의
