# 성격 유형 검사하기 (118666)

## 상태
- 제출 완료 (`Dictionary<char,int>`로 8유형 점수, `choice-4`로 동의/비동의, 네 쌍을 `if`로 붙임)
- 로컬 실험: `LocalTest/Program.cs` (`.gitignore`)
- 쌍 배열로 줄인 결과 조립: `성격유형검사하기_학습.cs`

## 내가 한 질문
- `Dictionary` 안에 길이 2 배열을 두나? 왜 26칸 배열인가?
- `Dictionary`가 나아 보인다. 넣고 빼고 수정이 익숙하지 않다.
- 4와 연산해 음수/양수로 동의·비동의를 가리고, 넣을 때는 절댓값인가?
- 0점 예외와 알파벳 순은 문자 값 비교인가?
- `survey`와 `choices` 길이 중 `for`에는 뭘 쓰나?
- 작성 중인 코드 확인. `value == 0`은 어디에 두나? 연산을 줄이는가?
- 작성본 확인. 추가 조언. 판별을 배열로 줄이려면 어떻게 구성하나?
- 같은 형태 `if`가 반복되면 길이가 문제다. 메모에 넣자.

## 막혔던 지점
- 유형은 8글자라 `Dictionary<char,int>`면 충분. `int[26]`은 `'R'-'A'`로 인덱스를 쓰려는 편법이지 필수가 아님. 쌍마다 `int[2]`를 두면 `"TR"`을 `"RT"` 칸에 뒤집어 더해야 해서 더 꼬임.
- `choice - 4`가 음수면 비동의(`survey[i][0]`), 양수면 동의(`[1]`), 0이면 점수 없음. 넣는 값은 `Math.Abs(choice - 4)` (1~3).
- 0점은 별도 예외가 아님. **동점**(0대 0 포함)일 때 사전 순. 점수가 다르면 높은 쪽. 사전 순은 `char` 비교. `RT`처럼 왼쪽이 이미 앞선 글자라 동점이면 `>=`로 왼쪽.
- `for` 길이는 둘 다 같지만, 질문 개수라 `survey.Length`가 읽기 맞음.
- 네 쌍을 `else if`로 이으면 `R`을 고른 뒤 `C/F`를 안 봄. 쌍마다 독립 `if / else`.
- `value == 0`은 점수 더하기 **전**에 `continue`. 마지막 판별에 넣지 않음. `n ≤ 1000`이라 속도보다 “모르겠음은 더하지 않는다”가 드러나는 이득.
- 제출본은 `if` 네 번이라 맞고, 같은 비교가 길어짐. 출력 순서 쌍만 배열로 두면 루프 하나로 줄어듦.

## 문제 한 줄
문항마다 비동의/동의 유형에 1~3점을 더하고, 지표 네 쌍에서 높은 쪽(동점이면 사전 앞)을 이어 붙인다.

## 핵심 패턴
```text
8유형 점수를 0으로
각 문항: value = choice - 4
  0이면 건너뜀
  >0 이면 뒤 글자에 value
  <0 이면 앞 글자에 Abs(value)
결과: RT, CF, JM, AN 각각 점수 큰 쪽(같으면 왼쪽)
```

`survey`의 `"TR"`은 그 문항의 앞/뒤일 뿐. 결과는 항상 R vs T 순으로 가린다.

## 제출 코드 (점수 + 네 if)
`typeScore`에 글자별 점수. `types`로 여덟 칸을 0으로. `result`에 네 쌍을 각각 붙임.

`value == 0`이면 `continue`. 동점은 `>=`로 왼쪽 글자.

## 대안별 구현 비교

제출의 네 `if`는 규칙이 눈에 잘 들어온다. 다만 같은 비교가 네 번이라 길다. 출력 쌍만 `string[]`로 두면 길이가 줄어들고, 동점 때 왼쪽을 고르는 규칙이 한곳에 모인다.

| | 네 번 `if` (제출) | 쌍 배열 + 루프 |
|---|---|---|
| 비교 | RT, CF, JM, AN을 풀어 씀 | `"RT","CF","JM","AN"`을 순회 |
| 길이 | 김 | 짧음 |
| 읽기 | 각 지표가 보임 | 규칙이 한 번만 |

`survey` 순서와 결과 순서는 다름. 배열은 **출력 순서**다.

### 쌍 배열 (학습)
```csharp
string[] pairs = { "RT", "CF", "JM", "AN" };
foreach (string pair in pairs)
{
    char leftType = pair[0];
    char rightType = pair[1];
    if (typeScore[leftType] >= typeScore[rightType])
        result.Append(leftType);
    else
        result.Append(rightType);
}
```

`Dictionary` 기본: `typeScore[type] = 0`으로 넣기, `typeScore[type] += score`로 수정, `typeScore['R']`로 읽기. 없는 키에 `+=`하면 예외. 이 문제는 `Remove`를 안 씀.

점수 더하기를 한 줄로 모으면 `char type = value > 0 ? survey[i][1] : survey[i][0]; typeScore[type] += Math.Abs(value);`

## 다음에 볼 것
- 글자 키면 `Dictionary<char,int>`. 26칸은 문자 인덱스 편법.
- 4 기준으로 부호=누구, 절댓값=몇 점. 0은 문항 `continue`.
- 같은 `if`가 지표마다면 쌍 배열. `else if`로 지표를 잇지 않기.
