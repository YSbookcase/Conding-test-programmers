# 신고 결과 받기 (92334)

## 상태
- 공식 폴더로 이동함
- 로컬 실험: `LocalTest/Program.cs` (예제 `[2,1,1,0]`, `[0,0]`, `.gitignore`)
- 두 방법 코드: `프로그래머스/1/92334. 신고 결과 받기/신고결과받기_학습.cs`

## 내가 한 질문
- 신고를 세면 되나? 튜플이 필요한가?
- 한 번에 끝내야 하나? 중복 제거·횟수·k 비교를 세 번 돌면 `3*N*N`인가?
- `Dictionary`+`HashSet`이면 `k` 비교와 자료 업데이트를 언제 하나?
- `HashSet`의 `Add`가 추가인가? 같은 값이 있으면 안 들어가나?
- `Dictionary`에 `HashSet`까지 동시에 선언하나?
- `reportedBy` / `Of`로 정한 이유는?
- 신고자를 모으느냐 신고된 사람을 모으느냐에 따라 처리가 달라지나?
- `for`마다 `HashSet`을 `new`하나? `foreach`인 이유는? `id_list` 키를 먼저 여나?
- 전체 코드. 딕셔너리가 둘인 이유. 신고자 기준만으로 되나?
- 정지는 `targetToReporters`가 낫지 않나? 둘 다 둬도 되나? 한 `for`에 둘을 채우면 시간 괜찮은가?
- 자료구조가 많고 `bannedIds`까지 따로인 게 어렵다. 메모리 vs 연산. 매직 넘버.
- 안에 배열/`HashSet`을 두면 바깥에서 따로 `new` 해야 하나?

## 막혔던 지점
- 횟수만 세면 정지는 나와도 **누가 누구를 신고했는지**가 없어서 메일을 못 맞춘다. 같은 사람·같은 대상은 1회라 `HashSet`이 먼저다. 예2 `ryan con` 네 번도 `con`은 1회.
- 세 번 도는 것 자체는 된다. `report` 20만·`id_list` 1000이라 한 줄씩이면 `O(신고 수)`이지 `N*N`이 아니다. 바깥 20만 × 안쪽 1000이 부담이다.
- `k` 비교는 **넣는 도중이 아니라** 고유 쌍을 다 넣은 뒤 `Count >= k`. 도중에 비교하면 나중에 들어온 신고가 빠진다.
- `Add`는 이미 있으면 `false`이고 `Count`는 그대로. `++`를 따로 할 필요 없다.
- `Dictionary<string, HashSet<string>>`는 바깥만 빈 딕셔너리다. 안쪽 집합은 **키당 한 번** `new`. 신고 한 줄마다 `new`하면 그 대상의 목록이 매번 비워진다. 공유 `HashSet` 하나를 모든 키에 넣으면 전원이 같은 집합을 본다.
- `reportedBy`/`Of`는 방향이 뒤집혀 읽힌다. `targetToReporters`(대상→신고자들), `reporterToTargets`(신고자→대상들)이 역할이 드러난다.
- 모으는 방향이 바뀌면 **나중에 무엇을 먼저 꺼내 보느냐**가 달라진다. 쌍 자체는 같다. 하나만 두면 나머지 질문은 순회로 만든다.
- `report`만으로 키를 열면 신고에 안 나온 유저(`apeach` 당한 적 없음, `neo` 한 적 없음)를 빼먹기 쉽다. `id_list`로 빈 집합을 먼저 두면 `ContainsKey` 없이 `Add`/`Count`만 하면 된다.
- `foreach`는 인덱스가 없어서. 성격 유형은 `survey[i]`와 `choices[i]`를 맞춰야 해서 `for`. 마지막 메일 배열은 `id_list` 순서라 `for`가 맞다.
- 딕셔너리 둘은 정지를 보기 쉽게·메일을 보기 쉽게 나눠 둔 것. 신고자→대상만 있어도 횟수를 한 번 뒤집으면 된다. `bannedIds`도 필수는 아니다. 메일 루프에서 `Count >= k`를 바로 봐도 된다.
- 느려지는 건 딕셔너리 개수가 아니라, 신고마다 `id_list`를 다시 훑는 이중 루프. 한 순회에 `Add` 두 번은 상수 두 배라 20만에서 체감되지 않는다.
- 중첩 자료는 타입이 안에 들어가는 것이지, 객체가 자동으로 생기지는 않는다. 바깥 `new Dictionary` ≠ 안쪽 `new HashSet`.

## 문제 한 줄
같은 신고는 1회로 모은 뒤, `k`명 이상에게 신고당한 사람을 정지하고, 각 유저가 신고한 정지 인원 수를 `id_list` 순서로 반환한다.

## 핵심 패턴
```text
id_list로 키를 열고 빈 HashSet
report Split → 고유 쌍 Add (중복이면 무시)
정지: 대상별 Count >= k
메일: 내가 신고한 대상 중 정지된 수
```

예1 `k=2`: frodo·neo 정지. muzi는 {frodo, neo} → 메일 2.

## 학습 코드 (두 딕셔너리)
`targetToReporters`로 정지, `reporterToTargets`로 메일. `HashSet`은 아이디당 루프 밖에서 한 번만 `new`. `k` 비교는 모든 `Add` 다음.

```csharp
foreach (string id in idList)
{
    targetToReporters[id] = new HashSet<string>();
    reporterToTargets[id] = new HashSet<string>();
}

foreach (string row in report)
{
    string[] parts = row.Split(' ');
    targetToReporters[parts[1]].Add(parts[0]);
    reporterToTargets[parts[0]].Add(parts[1]);
}
```

`id_list` 매개변수 이름은 제출 시그니처 그대로. 학습 헬퍼는 `idList`.

## 대안별 구현 비교

둘 다 고유 쌍만 남긴 뒤 정지·메일을 본다. 차이는 **정지를 바로 보느냐, 한 번 뒤집느냐**.

| | A 딕셔너리 둘 (학습 기본) | B 신고자→대상만 |
|---|---|---|
| 자료 | 대상→신고자 + 신고자→대상 | 신고자→대상 + 횟수 `int` |
| 정지 | `targetToReporters[id].Count >= k` | 집합을 뒤집어 `reportCount[target]++` |
| 메일 | `reporterToTargets[나]` 중 정지 | 같음. `reportCount[target] >= k`로 `bannedIds` 생략 가능 |
| 메모리 | 쌍을 두 벌 | 쌍 한 벌 + 횟수 |
| 읽기 | 질문마다 자기 딕셔너리 | 정지는 한 단계 더 |

`n` 1000·신고 20만에서는 둘 다 충분하다. 대상→신고자만 두면 정지는 바로, 메일은 “내가 그 집합에 들어 있나”를 찾아야 한다.

### B. 한 딕셔너리 (학습)
```csharp
foreach (string reporter in idList)
{
    foreach (string target in reporterToTargets[reporter])
        reportCount[target]++;
}

for (int i = 0; i < idList.Length; i++)
{
    int mailCount = 0;
    foreach (string target in reporterToTargets[idList[i]])
    {
        if (reportCount[target] >= k)
            mailCount++;
    }
    result[i] = mailCount;
}
```

이미 `HashSet`이라 같은 쌍은 한 번만 있다. `reportCount`는 고유 신고자 수.

`new HashSet<string>(report)`로 문자열 전체를 먼저 중복 제거해도 된다. 튜플 `(신고자, 대상)` `HashSet`도 같은 역할이다.

## 다음에 볼 것
- 같은 키 쌍은 `HashSet.Add`. 횟수는 `Count`. `k`는 다 넣은 뒤.
- 안쪽 집합은 키당 `new` 한 번. 줄마다 `new` 금지, 공유 객체 금지.
- 키는 `id_list`로 먼저. 신고에 안 나온 사람도 메일 0.
- 이름에 방향이 보이게: `targetToReporters` / `reporterToTargets`.
- 공간으로 방향을 나눠 두면 조회가 짧다. 느린 건 중첩 순회.
- 매직 넘버보다 키·변수 이름. `>= k`의 `k`는 매개변수라 해당 없음.
