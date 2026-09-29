# 음양 더하기 (76501)

## 상태
- 제출 완료. `signs[i]`에 따라 `absolutes[i]`를 더하거나 뺌
- 제출 파일: `프로그래머스/1/76501. 음양 더하기/음양 더하기.cs`
- 로컬 확인: `LocalTest/Program.cs` (`.gitignore`)

## 내가 한 질문
- 로컬에 작성한 풀이가 맞는가?
- 이런 간단한 문제가 레벨 1이 맞는가?

## 막혔던 지점
- 로직이나 문법에서 막힌 부분은 없었다. `absolutes`와 `signs`는 같은 인덱스끼리 짝이므로 한 번 순회하면 된다.
- `signs[i]`는 이미 `bool`이라 `signs[i] == true`라고 쓰지 않고 `if (signs[i])`로 판별한다.
- 두 배열 중 하나만 정렬하면 절댓값과 부호의 짝이 깨지므로 정렬하지 않는다.
- 길이 최대 1,000, 절댓값 최대 1,000이므로 합의 범위는 -1,000,000부터 1,000,000까지다. `int`로 충분하다.
- 프로그래머스 76501은 레벨 1이 맞다. 배열 두 개를 같은 인덱스로 순회하고 조건에 따라 더하거나 빼는 기본 문제다.

## 문제 한 줄
절댓값 배열과 같은 위치의 부호 배열을 이용해 실제 정수들의 합을 구한다.

## 핵심 패턴
```text
answer = 0
i = 0..길이-1
  signs[i]가 true면 absolutes[i] 더하기
  false면 absolutes[i] 빼기
```

시간 O(n), 추가 메모리 O(1).

## 제출 코드
```csharp
int answer = 0;

for (int i = 0; i < absolutes.Length; i++)
{
    if (signs[i])
        answer += absolutes[i];
    else
        answer -= absolutes[i];
}

return answer;
```

`answer`는 지금까지 부호를 적용한 값의 합이다. `i`는 `absolutes`와 `signs`에서 같은 위치를 가리킨다.

## 대안별 구현 비교

삼항 연산자로 같은 로직을 한 줄에 표현할 수도 있다.

```csharp
int answer = 0;
for (int i = 0; i < absolutes.Length; i++)
    answer += signs[i] ? absolutes[i] : -absolutes[i];
return answer;
```

둘 다 시간 O(n), 추가 메모리 O(1)이다. 제출한 `if/else`가 양수와 음수 처리를 처음 볼 때 더 분명하다.

## 다음에 볼 것
- 서로 연관된 배열은 같은 인덱스로 함께 순회한다.
- `bool`은 그 자체를 조건식으로 쓴다.
- 최댓값뿐 아니라 음수 최솟값까지 계산해 정수형 범위를 확인한다.
