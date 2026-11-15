# 문자열 다루기 기본 (12918)

## 상태
- 제출 성공은 확인하지 못함. LocalTest에서 `TryParse`만 보다가 길이 조건을 빼먹은 것을 확인함
- 연습은 `LocalTest/Program.cs`. 이후 다른 문제 코드로 덮여 그 파일에는 이 풀이가 없음
- 공식 폴더가 없어 `프로그래머스/KYS24/문자열다루기기본_notes.md`에 둠. 폴더가 생기면 그쪽으로 옮긴다

## 내가 한 질문
- 로컬테스트에 작성했으니 확인해줘.
- 조건이 더 있었구나 놓쳤네.
- 조건으로 미리 거르는 편이 성능상 낫지 않나. bool 판단이 성능에 영향을 줄 정도면 어느 정도여야 하나. 요즘 컴퓨터에서는 천문학적인 수여야 하지 않나?

## 막혔던 지점
- 조건은 두 개다. 길이가 4 또는 6인 것, 글자가 전부 숫자인 것.
- 예제 `"a234"`와 `"1234"`는 둘 다 길이가 4라서 숫자 검사만 해도 결과가 같다. `"123"`은 숫자만이라 `TryParse`가 `true`인데 길이가 3이라 `false`다. `"12345678"`도 숫자만이고 길이가 8이라 `false`다.
- `int.TryParse`는 정수로 바뀌는지만 본다. `out` 값은 쓰지 않으면 버리면 된다.
- `"0000"`은 길이가 4이고 숫자만이라 `true`다. `"1e22"`는 길이가 4여도 `e`가 있어서 `false`다.
- bool 비교 자체는 가볍다. 이 PC에서 2천만 번 돌리면 길이 비교는 약 9 ms(1회 약 0.5 ns), `TryParse`는 약 308 ms(1회 약 15 ns)였다. 수백만 번이면 시계에 보이고, 화면 하나의 조건 수천 개로는 사람이 못 느낀다.
- 미리 거르는 효과는 bool 계산보다 뒤의 일을 빼는 쪽에 있다. 길이가 아니면 `TryParse`를 건너뛴 경우는 2천만 번에 약 52 ms, `TryParse`를 한 뒤 길이를 본 경우는 약 235 ms였다. 이 문제는 길이 8 이하를 한 번 보므로 둘 다 나노초다.
- `isNumber`를 먼저 변수에 담으면 길이가 달라도 `TryParse`는 이미 실행된다. `&&`나 `if` 안에 무거운 쪽을 뒤에 두어야 앞에서 멈춘다.

## 문제 한 줄
길이가 4 또는 6이고, 모든 문자가 숫자이면 `true`다.

## 핵심 패턴
```text
길이가 4도 6도 아니면 return false
각 문자가 '0'~'9'가 아니면 return false
return true
```
- `"a234"` → `false`
- `"1234"` → `true`
- `"123"` → `false`

## 대안별 구현 비교

예제 두 개는 길이가 4라 결과가 같다. `"123"`, `"12345678"`에서 길이 검사가 없는 쪽이 갈린다. `"0000"`과 `"1e22"`는 길이 검사와 숫자 검사를 같이 하면 같다.

### A. 길이로 거른 뒤 `TryParse`
길이가 아니면 `TryParse`를 호출하지 않는다.

```csharp
public class Solution {
    public bool solution(string s) {
        if (s.Length != 4 && s.Length != 6)
        {
            return false;
        }
        return int.TryParse(s, out _);
    }
}
```

### B. 두 bool을 만든 뒤 `&&`
결과 값은 A와 같다. 길이가 달라도 `TryParse`는 항상 실행된다.

```csharp
public class Solution {
    public bool solution(string s) {
        bool isFourOrSix = s.Length == 4 || s.Length == 6;
        bool isNumber = int.TryParse(s, out _);
        return isFourOrSix && isNumber;
    }
}
```

### C. 한 글자씩 `'0'`~`'9'`
`TryParse` 없이 같은 결과. `'e'`는 범위 밖이라 `"1e22"`는 `false`다.

```csharp
public class Solution {
    public bool solution(string s) {
        if (s.Length != 4 && s.Length != 6)
        {
            return false;
        }

        foreach (char ch in s)
        {
            if (ch < '0' || ch > '9')
            {
                return false;
            }
        }
        return true;
    }
}
```

## 다음에 볼 것
- 예제 길이가 같아서 통과해도, 다른 길이의 숫자 문자열을 한 번 더 본다.
- 싼 조건은 `if`나 `&&` 앞에 둔다. 변수에 미리 담으면 뒤 호출을 건너뛰지 못한다.
- 이 문제 크기에서 길이 선검사는 속도가 아니라 조건 순서다.
