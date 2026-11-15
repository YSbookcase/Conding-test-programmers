# 소수 찾기 (42839)

## 상태
- 제출 완료. 정확성 100, 메모리 45.4 MB, 시간 4.34 ms
- 제출 파일: `프로그래머스/2/42839. 소수 찾기/소수 찾기.cs`
- 완전탐색. 제출본은 조각 위치 재귀와 `HashSet<int>`. LocalTest에서 소수 조건을 고침

## 내가 한 질문
- 모든 조합을 만든 뒤 소수를 확인하는 방식이 맞나
- 경우가 많아 보인다. 중복은 어떻게 빼고, 1자리·2자리로 나눠 만드는 편이 좋나
- `papers`는 무엇인가
- 재귀가 어떻게 모든 수를 `HashSet`에 넣나
- `hasDigit`과 `isUsed`의 역할은 무엇인가
- `current * 10`은 자리 올리기인가. 사용 취소 뒤 다른 순서는 어떻게 시작되나
- 세 장 이상이면 차례로 붙는 길 말고 어디서 갈라지나
- 로컬에서 `using System.Collections.Generic`이 필요한가
- 수정한 소수 판별을 확인해 달라

## 막혔던 지점
- 만들 수는 조합이 아니라 순열이고, 종이 전체를 다 쓰지 않은 짧은 수도 포함한다. `"17"`은 `1`, `7`, `17`, `71`이다.
- 길이가 7일 때 순서를 바꿔 붙이는 경우는 약 1만 4천 개다. 7자리만 전부 쓰는 경우는 `7! = 5040`이다.
- 같은 숫자 조각이 두 장이면 인덱스가 다르다. `"011"`의 1 두 장으로 `11`을 만들 수 있다. 사용 표시는 글자가 아니라 조각 위치다.
- `HashSet<int>`가 중복을 걷는다. `"011"`과 `"11"`은 정수 `11`이다. 문자열로 모으면 둘은 다르게 남는다.
- `hasDigit`가 거짓인 처음 `Collect(0, false)`는 빈 수라 넣지 않는다. 첫 조각이 `"0"`이면 `Collect(0, true)`라 만든 수 `0`은 들어간다.
- `isUsed[index] = false`는 집합에서 수를 빼는 일이 아니다. 그 조각을 다른 순서에서 다시 쓰려고 표시만 끈다.
- `current`는 호출의 매개변수다. `Collect(12)`가 끝나도 부모 `Collect(1)`의 수는 1이다. 다음 조각은 그 1 뒤에 붙는다.
- 처음 작성한 `IsPrime`은 `number > 2`라 `7`, `17`, `71`이 탈락했다. 조건은 `number < 2`다. `divisor * divisor < number`는 `9` 같은 제곱수를 놓친다. `<=`여야 한다.
- 로컬 프로젝트는 `ImplicitUsings`로 `System.Collections.Generic`이 열려 있다. 제출 파일에는 `using`이 필요하다.

## 문제 한 줄
종이 조각을 이어 붙여 만들 수 있는 소수 의 개수. 순서가 다르면 다른 수고, 앞의 0은 같은 정수다.

## 핵심 패턴
```text
조각 인덱스를 isUsed로 표시
이어 붙인 정수를 HashSet에 넣음
돌아오면 표시를 끔
집합의 수 중 2 이상이고 √수까지 나눠 떨어지지 않는 개수
```

```csharp
HashSet<int> madeNumbers = new HashSet<int>();
bool[] isUsed = new bool[numbers.Length];

void Collect(int current, bool hasDigit)
{
    if (hasDigit)
        madeNumbers.Add(current);

    for (int index = 0; index < numbers.Length; index++)
    {
        if (isUsed[index])
            continue;

        isUsed[index] = true;
        int digit = numbers[index] - '0';
        Collect(current * 10 + digit, true);
        isUsed[index] = false;
    }
}

Collect(0, false);
```

`"17"`은 `{1, 7, 17, 71}`에서 3개다. `"011"`은 `{0, 1, 10, 11, 101, 110}`에서 `11`, `101` 두 개다. `0`과 `1`은 소수가 아니다.

## 다음에 볼 것
- 1부터 `n`까지 소수의 개수(12921)는 체다. 이 문제는 만든 수 최대 약 1만 개만 확인하면 된다.
- `divisor * divisor`는 7자리 안에서는 `int`에 들어간다. 더 큰 수에서는 곱이 음수가 되며 반복이 끝나지 않을 수 있다.
