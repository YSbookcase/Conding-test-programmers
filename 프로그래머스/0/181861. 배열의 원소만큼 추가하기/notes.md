# 배열의 원소만큼 추가하기 (181861)

## 내가 한 질문
- List로 풀었는데 뭐가 문제인지?
- 다른 더 좋은 방법이 있는지?
- 결과 길이 = arr 원소 합이니까 배열로도 가능한지?
- LINQ `SelectMany`, `Enumerable.Repeat` 설명
- `Enumerable` 발음 (넘버러블이 아님)

## 막혔던 지점
- `index++` 뒤 세미콜론 누락
- `x.ToArray` → `x.ToArray()` 메서드 호출 필요
- 알고리즘 자체(List + 반복 Add)는 처음 접근이 맞았음

## 핵심 패턴
- 각 원소 `a`를 맨 뒤에 `a`번 추가
- **결과 배열 길이 = arr 원소들의 합** → 길이를 미리 알 수 있음
- `List`도 가능하지만, 이 문제는 **배열 + index**가 더 자연스러움

## 최종 풀이 방향
1. `totalLength`에 arr 합계 계산
2. `int[] answer = new int[totalLength]`
3. 이중 for문으로 `answer[index++] = arr[i]`

## 대안 정리
| 방식 | 특징 |
|------|------|
| List + Add | 읽기 쉬움, 학습용 적합 |
| 배열 + index | 길이를 알 때 효율적, 최종 채택 |
| LINQ | `arr.SelectMany(num => Enumerable.Repeat(num, num)).ToArray()` |

## LINQ 메모
- `Enumerable.Repeat(값, 횟수)` : 같은 값을 횟수만큼 반복한 시퀀스
- `SelectMany` : 각 원소가 만든 시퀀스들을 하나로 펼침 (for 이중루프 + 합치기)
- `Enumerable` 발음 : **이뉴머러블** (enumerate = 열거하다)

## 다음에 볼 것
- `Repeat` / `SelectMany` 단독 예제로 한 번 더 익히기
- 비슷한 유형: 결과 크기를 먼저 구할 수 있는지 확인하는 습관
