# 스킬트리 (49993)

## 상태
- 제출 완료. 정확성 100, 메모리 45.7 MB, 시간 0.22 ms
- 제출 파일: `프로그래머스/2/49993. 스킬트리/스킬트리.cs`
- Summer/Winter Coding. 제출본은 트리마다 `step`으로 다음 선행 스킬만 확인

## 내가 한 질문
- `indexOf`로 위치를 뽑아 비교하는 편이 좋나. 다른 방식은 무엇인가
- 한 번 순회하며 위치를 저장한 뒤 비교하면 되나
- 단순한 방법은 선행 스킬 인덱스와 비교하며 `step`을 올리는 것 아닌가
- `foreach`는 스킬트리 하나를 보므로 바깥 반복이 더 필요하지 않나
- 한 번 순회가 시간·공간에서 더 나은가
- `IndexOf`가 반복되면 오래 걸리지 않나
- 제출 뒤 추가할 조언이 있나

## 막혔던 지점
- 트리에 나온 스킬의 위치만 비교하면 `"BDA"`를 놓친다. `B`가 `D`보다 앞이어도 그 앞의 `C`가 없으면 불가능이다.
- `step`은 지금 배워야 하는 `skill`의 인덱스다. 트리 위치와 비교하는 것이 아니다. 선행 스킬이 나오면 `skill.IndexOf` 결과가 `step`과 같아야 하고, 맞으면 1 올린다. `"CBD"`에 없는 글자는 건너뛴다.
- 안쪽 `foreach`는 트리 문자열 하나다. `skill_trees` 바깥에서 통과한 개수를 센다.
- `"AECB"`는 `C`에서 1, `B`에서 2가 된다. `D`가 없어도 가능하다. `"BDA"`는 처음 나온 선행 스킬 `B`의 인덱스가 1이라 기다리는 0과 달라 실패한다.
- 선행 스킬이 하나도 없는 `"AEF"`는 가능하다. `step`이 0인 채로 통과한다. `"D"`와 `"BD"`는 실패한다.
- `break`는 안쪽 반복만 끝낸다. `possibleCount`는 바깥에 있어 다음 트리를 이어서 센다.
- 위치 배열과 `step`의 시간 차수는 같다. 둘 다 글자마다 `IndexOf`를 호출한다. `step`은 위치 배열과 그 배열을 다시 보는 반복이 없다.
- `skill`과 트리는 최대 26글자, 트리는 최대 20개다. `IndexOf`를 모두 더해도 약 1만 3천 번이다.

## 문제 한 줄
선행 스킬 순서 `skill`을 지킨 스킬트리의 개수. 순서에 없는 스킬은 사이에 있어도 된다. 선행 스킬은 건너뛰면 안 되고, 아직 안 배운 뒤 스킬은 없어도 된다.

## 핵심 패턴
```text
트리마다 step = 0
선행 스킬이 아니면 건너뜀
skill에서의 인덱스가 step과 다르면 그 트리는 실패
같으면 step을 1 올림
실패하지 않은 트리 개수
```

```csharp
int possibleCount = 0;

foreach (string tree in skill_trees)
{
    int step = 0;
    bool isPossible = true;

    foreach (char learned in tree)
    {
        int order = skill.IndexOf(learned);
        if (order == -1)
            continue;

        if (order != step)
        {
            isPossible = false;
            break;
        }

        step++;
    }

    if (isPossible)
        possibleCount++;
}

return possibleCount;
```

`"CBD"`와 `["BACDE", "CBADF", "AECB", "BDA"]`에서는 `"CBADF"`, `"AECB"` 두 개가 가능하다.

## 대안별 구현 비교

가능·불가능은 같다. `step`은 추가 배열이 없고, 위치 배열은 선행 스킬이 트리의 몇 번째인지를 저장한 뒤 한 번 더 본다.

| 방법 | 추가 공간 | 메모 |
|---|---|---|
| A. `step` | 정수 몇 개 | 제출본 |
| B. 위치 배열 | `skill` 길이의 정수 배열 | 뒤 스킬이 있으면 앞 스킬도 있고 위치가 더 작아야 함 |

`"CBD"` 위치는 `C`, `B`, `D` 순이다. 없으면 `-1`이다. `"BACDE"`는 `2, 0, 3`, `"CBADF"`는 `0, 2, 3`, `"AECB"`는 `2, 3, -1`, `"BDA"`는 `-1, 0, 1`이다.

### B. 위치 배열

```csharp
bool IsPossible(string skill, string tree)
{
    int[] positions = new int[skill.Length];
    Array.Fill(positions, -1);

    for (int index = 0; index < tree.Length; index++)
    {
        int order = skill.IndexOf(tree[index]);
        if (order >= 0)
            positions[order] = index;
    }

    for (int order = 0; order < positions.Length - 1; order++)
    {
        if (positions[order + 1] == -1)
            continue;

        if (positions[order] == -1 || positions[order] > positions[order + 1])
            return false;
    }

    return true;
}
```

## 다음에 볼 것
- 길이가 훨씬 커지면 대문자 26칸에 순서를 한 번 적고 `orders[learned - 'A']`로 꺼낸다. 이번 길이에서는 `IndexOf`와 차이가 나지 않는다.
