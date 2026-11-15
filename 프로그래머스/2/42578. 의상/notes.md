# 의상 (42578)

## 상태
- 제출 완료. 정확성 100, 합계 100. 메모리 45.6 MB, 시간 1.06 ms
- 제출 파일: `프로그래머스/2/42578. 의상/의상.cs`
- 코딩테스트 연습 > 해시
- `LocalTest/Program.cs`와 제출본이 같다. 종류가 없으면 `0`으로 칸을 만든 뒤 `++`한다
- `answer`를 `0`으로 시작했다가 한 번 실패했다. 곱의 시작은 `1`이다

## 내가 한 질문
- 부위별로 아무것도 안 입는 경우를 넣어 곱한 뒤, 전부 안 입은 경우만 `- 1`하면 되나?
- `countByType[type] = 0`에서 `type`이 키이고 값이 들어가는 건가?
- `ContainsKey`가 없으면 칸을 만드는 건가?
- `countByType[type]++`만으로 값을 올릴 수 있나?
- 딕셔너리는 키와 값을 같이 넣는 형태로 배웠다. `딕셔너리[키] = 값`도 되나?
- `foreach (string[] cloth in clothes)`에서 타입이 맞지 않는다
- `ContainsKey`로 `0`을 넣은 뒤 `++`해도 되나?
- `answer = 1` 대신 `0`을 넣어서 한 번 실패했다

## 막혔던 지점
- 같은 종류는 하나만 입는다. 종류마다 “옷을 고르는 수 + 안 입는 1가지”를 곱하고, 모든 종류를 안 입은 1가지를 뺀다.
- 예제 1은 머리 2개, 눈 1개라 `(2 + 1) × (1 + 1) - 1 = 5`다. 예제 2는 얼굴 3개뿐이라 `(3 + 1) - 1 = 3`이다. 의상 이름은 조합에 쓰이지 않는다.
- `countByType[type] = 0`은 키 `type`에 값 `0`인 칸을 만든다. 바로 다음 `++`가 그 칸을 `1`로 올린다. 같은 종류가 다시 오면 `ContainsKey`가 참이라 `0`으로 되돌리지 않고 `++`만 해서 `2`가 된다.
- `countByType[type]++`만 쓰면 들어 있는 값을 먼저 읽는다. 칸이 없으면 예외가 난다. `GetValueOrDefault(type)`은 칸이 없으면 `0`을 돌려줘서 `countByType[type] = countByType.GetValueOrDefault(type) + 1` 한 줄과 `ContainsKey` 방식이 같은 결과다.
- `Add("headgear", 1)`은 새 칸만 만든다. 같은 키를 `Add`로 다시 넣으면 예외가 난다. `countByType["headgear"] = 2`는 없으면 만들고, 있으면 값만 바꾼다. 개수는 옷이 나올 때마다 커지므로 값을 바꾸는 쪽을 쓴다.
- `clothes`는 `string[,]`다. `foreach`가 꺼내는 것은 옷 한 줄인 `string[]`이 아니라 칸 하나인 `string`이다. `clothes.GetLength(0)`이 옷의 개수이고, `clothes[index, 1]`이 종류다. 이름인 `clothes[index, 0]`은 세지 않는다.
- `answer`는 `1`에서 곱해야 한다. `0`에 `(개수 + 1)`을 곱하면 계속 `0`이라 `0 - 1`인 `-1`이 된다. 예제 1의 맞는 식은 `1 × 3 × 2 - 1 = 5`다. 더할 때의 시작이 `0`이고, 곱을 쌓을 때의 시작이 `1`이다.
- 의상은 최대 30개라 이 곱은 `int`에 들어간다.

## 문제 한 줄
종류마다 최대 한 벌만 입고, 하루에 한 벌 이상은 입을 때 서로 다른 옷 조합의 수. 의상은 1개 이상 30개 이하.

## 핵심 패턴
```text
종류별 개수를 센다
answer = 1
종류마다 answer *= 개수 + 1
answer - 1 반환
```

```csharp
string type = clothes[index, 1];

if (!countByType.ContainsKey(type))
    countByType[type] = 0;

countByType[type]++;
```

```csharp
int answer = 1;

foreach (int count in countByType.Values)
    answer *= count + 1;

return answer - 1;
```

- 머리 2, 눈 1 → `5`
- 얼굴 3 → `3`

## 대안별 구현 비교

A가 제출본이다. B는 없는 종류를 `0`으로 읽는 한 줄이다. 개수는 같다. `answer`를 `0`으로 시작하면 예제 1이 `-1`이다.

| 방법 | 처음 보는 종류 | 예제 1 |
|---|---|---|
| A. 없으면 `0`을 넣고 `++` | 칸을 만든 뒤 1 증가 | `5`. 제출본 |
| B. `GetValueOrDefault + 1` | 없으면 0으로 보고 1을 저장 | `5` |
| `answer = 0`에서 곱 | 개수와 무관 | `-1` |

### B. 한 줄로 개수 증가

```csharp
string type = clothes[index, 1];
countByType[type] = countByType.GetValueOrDefault(type) + 1;
```

`foreach (string[] cloth in clothes)`는 `string[,]`에서 칸이 `string`이라 컴파일이 되지 않는다. 행은 `GetLength(0)`, 종류는 `clothes[index, 1]`이다.

## 다음에 볼 것
- 백지에서는 종류별 개수, `answer = 1`, `(개수 + 1)`의 곱, 마지막 `- 1`만 적는다.
- 확인할 값은 머리 2·눈 1의 `5`, 얼굴만 3개의 `3`이다. 시작이 `0`이면 곱이 `0`으로 남는다.
