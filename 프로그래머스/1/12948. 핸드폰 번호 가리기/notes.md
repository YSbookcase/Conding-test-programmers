# 핸드폰 번호 가리기 (12948)

## 상태
- 제출 완료. 앞은 `new string('*', 길이 - 4)`, 뒤 4자리는 `Substring`
- 제출 파일: `프로그래머스/1/12948. 핸드폰 번호 가리기/핸드폰 번호 가리기.cs`
- LocalTest는 쓰지 않음

## 내가 한 질문
- 예전에 본 문자열 메서드로 될 것 같은데 기억이 안 난다.
- `StringBuilder`가 필요한가?
- `Substring` 말고 앞이나 뒤에서 뽑는 메서드가 있던 것 같다. `Trim`도 있었는데, 문자열 메서드에는 무엇이 있나?
- 메서드를 모르면 `for`로 깎아서 담아야 하지 않나?
- 추가로 주의할 점이 있나?

## 막혔던 지점
- 별은 직사각형 별찍기의 `new string('*', 개수)`, 뒷자리는 문자열 `Substring`이다. 배열에는 `Substring`이 없다.
- `Substring(시작)`은 그 칸부터 끝이다. `Substring(시작, 길이)`의 두 번째는 끝 인덱스가 아니라 길이다. `Substring(길이 - 4)`와 `Substring(길이 - 4, 4)`는 같다.
- `Trim`, `TrimStart`, `TrimEnd`는 개수로 자르지 않는다. 앞이나 뒤의 공백, 지정 문자를 다른 문자가 나올 때까지 지운다.
- `StringBuilder`는 반복에서 여러 번 이어 붙일 때 쓴다. 이번은 `*` 문자열과 뒷 4자리 두 조각이라 필요 없다. 길이는 4 이상 20 이하.
- `phone_number[i] = '*'`는 컴파일되지 않는다. 문자열 칸에는 넣을 수 없다.
- `long`으로 바꾸면 `"01033334444"`의 앞 `0`이 사라진다.
- 길이가 4이면 `*`는 0개다. `new string('*', 0)`은 빈 문자열이라 번호가 그대로다. 가리는 개수는 `Length - 4`다.

## 문제 한 줄
전화번호의 뒤 4자리를 제외한 앞부분을 `*`로 가린다.

## 핵심 패턴
```text
lastNum = Substring(길이 - 4)
masked = new string('*', 길이 - 4)
return masked + lastNum
```
- `"01033334444"` → `*` 7개 + `"4444"` → `"*******4444"`
- `"027778888"` → `*` 5개 + `"8888"` → `"*****8888"`

## 대안별 구현 비교

가린 결과는 같다. 차이는 별을 만드는 방식이다. `Trim`과 숫자 변환은 결과가 달라진다.

### A. `new string`과 `Substring`
제출한 버전. 조각이 두 개라 `StringBuilder`가 필요 없다.

```csharp
string lastNum = phone_number.Substring(phone_number.Length - 4);
string masked = new string('*', phone_number.Length - 4);
return masked + lastNum;
```

### B. `PadLeft`
뒷 4자리를 기준으로 전체 길이가 될 때까지 왼쪽에 `*`를 채운다. `"4444".PadLeft(11, '*')`는 `"*******4444"`다. `PadRight`는 오른쪽을 채운다.

```csharp
string lastNum = phone_number.Substring(phone_number.Length - 4);
return lastNum.PadLeft(phone_number.Length, '*');
```

### C. `char[]`에 직접 담기
메서드 없이 같은 결과. 인덱스 `길이 - 4` 미만은 `*`, 나머지는 원래 문자다.

```csharp
char[] answer = new char[phone_number.Length];
for (int i = 0; i < phone_number.Length; i++)
{
    if (i < phone_number.Length - 4)
    {
        answer[i] = '*';
    }
    else
    {
        answer[i] = phone_number[i];
    }
}
return new string(answer);
```

### D. `Trim`이나 숫자로 바꾸기
`Trim`은 4글자를 남기지 않는다. `"  010  ".Trim()`은 `"010"`이다. `long.Parse`는 앞의 `0`을 버린다.

끝에서 4칸은 메서드가 아니라 `phone_number[^4..]`다. `TakeLast`는 LINQ다.

## 다음에 볼 것
- 같은 문자를 개수만큼 만들 때는 `new string(문자, 개수)`.
- 뒤에서 n글자는 `Substring(길이 - n)`. 끝의 공백을 지우는 일은 `Trim`.
- 문자열은 칸에 대입하지 못하고, 전화번호는 숫자로 바꾸지 않는다.
