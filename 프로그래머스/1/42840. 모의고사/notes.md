# 모의고사 (42840)

## 상태
- 제출 완료. `int[][]` 주기와 `scores[3]`, 최댓값인 번호를 `person + 1`로 담음
- 제출 파일: `프로그래머스/1/42840. 모의고사/모의고사.cs`
- LocalTest: `LocalTest/Program.cs`에 같은 다중 배열 버전. gitignore라 커밋되지 않음

## 내가 한 질문
- 규칙대로 찍기 배열을 만든 다음 `answers`와 비교하면 되나?
- 맞힌 개수 카운터는 배열로 만들고, 리턴 값은 어떻게 만드나?
- `patterns[person].Length`로 길이를 구하나? `GetLength`가 일반적이지 않나?
- LocalTest에 작성한 코드 확인.
- 다중 배열이 쉽지 않다. 배열을 한 겹만 쓸 수 있나?

## 막혔던 지점
- `answers` 길이만큼 찍기 배열을 만들 필요는 없다. 주기는 5, 8, 10이라 `i % 길이`면 된다.
- `patterns`는 `int[][]`이다. 줄 길이가 5, 8, 10으로 다르다. `patterns[person]`이 `int[]`라서 `.Length`다.
- `GetLength`는 `int[,]`처럼 열 크기가 고정된 배열용이다. `GetLength(0)`이 행, `GetLength(1)`이 열이다.
- 리턴 길이는 1일 수도 3일 수도 있다. 크기 3에 미리 넣지 않고, 최댓값과 같은 번호만 `List`에 담은 뒤 `ToArray()`한다.
- 프로그래머스에 붙일 때 `using System.Collections.Generic;`, `using System.Linq;`이 필요하다. LocalTest는 `ImplicitUsings`가 켜져 있어서 없어도 컴파일된다.

## 문제 한 줄
세 명의 찍기 주기와 정답을 비교해, 가장 많이 맞힌 번호를 오름차순으로 반환한다.

## 핵심 패턴
```text
1번: 1,2,3,4,5
2번: 2,1,2,3,2,4,2,5
3번: 3,3,1,1,2,2,4,4,5,5
i번 문제의 찍기 = pattern[i % pattern.Length]
최댓값과 같은 사람을 1번부터 담는다
```
- `[1,2,3,4,5]` → 점수 5,0,0 → `[1]`
- `[1,3,2,4,2]` → 2,2,2 → `[1,2,3]`
- 문제는 최대 10,000. 사람 3명을 한 번씩 보면 된다. 시간 O(answers 길이), 추가 메모리는 주기 배열뿐.

## 대안별 구현 비교

결과는 같다. 차이는 주기 세 개를 한 변수에 모으느냐, 변수를 나누느냐다.

### A. 주기마다 배열 하나
읽기는 이쪽이 편하다. `score1`이 1번 수포자 점수다.

```csharp
int[] pattern1 = { 1, 2, 3, 4, 5 };
int[] pattern2 = { 2, 1, 2, 3, 2, 4, 2, 5 };
int[] pattern3 = { 3, 3, 1, 1, 2, 2, 4, 4, 5, 5 };

int score1 = 0;
int score2 = 0;
int score3 = 0;
for (int i = 0; i < answers.Length; i++)
{
    if (answers[i] == pattern1[i % pattern1.Length]) score1++;
    if (answers[i] == pattern2[i % pattern2.Length]) score2++;
    if (answers[i] == pattern3[i % pattern3.Length]) score3++;
}

int maxScore = Math.Max(score1, Math.Max(score2, score3));
List<int> result = new List<int>();
if (score1 == maxScore) result.Add(1);
if (score2 == maxScore) result.Add(2);
if (score3 == maxScore) result.Add(3);
return result.ToArray();
```

### B. `int[][]`과 `scores[3]`
LocalTest에 둔 버전. `scores[0]`이 1번이라 넣을 때 `person + 1`이다. 0번부터 담아서 정렬은 따로 없다.

```csharp
int[][] patterns =
{
    new[] { 1, 2, 3, 4, 5 },
    new[] { 2, 1, 2, 3, 2, 4, 2, 5 },
    new[] { 3, 3, 1, 1, 2, 2, 4, 4, 5, 5 }
};

int[] scores = new int[3];
for (int i = 0; i < answers.Length; i++)
{
    for (int person = 0; person < patterns.Length; person++)
    {
        if (answers[i] == patterns[person][i % patterns[person].Length])
        {
            scores[person]++;
        }
    }
}

int maxScore = scores.Max();
List<int> result = new List<int>();
for (int person = 0; person < scores.Length; person++)
{
    if (scores[person] == maxScore)
    {
        result.Add(person + 1);
    }
}

return result.ToArray();
```

`patterns.Length`는 3이다. `patterns[person].Length`는 그 사람의 주기 길이다.

## 다음에 볼 것
- 반복 패턴은 전체를 펼치지 않고 `i % 길이`로 본다.
- 줄마다 길이가 다르면 `int[][]`와 `.Length`, 열이 같으면 `int[,]`와 `GetLength`.
