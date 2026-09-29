# 숫자 짝꿍 (131128)

## 상태
- 제출 완료 (0~9 개수 `min` → 9부터 `Append(문자, 횟수)`, 빈 문자열 `-1`, 앞이 `0`이면 `"0"`)
- 로컬 실험: `LocalTest/Program.cs` (`.gitignore`)

## 내가 한 질문
- 공통 정수를 추출한 뒤 내림차순 정렬해서 문자열로 바꾸면 되나?
- 배열 두 개로 세고 `min`으로 공통 개수 배열을 만든 다음, 9→0으로 `StringBuilder`에 붙이면 되나?
- `X[i] - '0'`은 문자에서 숫자를 빼는 건가? 위치 0이 지워지나?
- `xNumCount[X[i] - '0']++` 루프 확인.
- `Y` 루프와 `min` 배열 다음, 조합은 `while`? `[0]==0` 플래그로 끝내나?
- `[9]`부터 붙일 때 카운팅해서 `for`로 하나씩 붙이나?
- `ToString()` 후 `"0"` / `""` 보고 `"-1"` 붙이면 되나?
- 코드 확인. 추가 조언. `pairCount`로 하면 넣는 동작은? 안쪽 `for` 대신 쓰는 건?

## 막혔던 지점
- 자릿수 최대 300만. 공통 숫자를 리스트에 모아 정렬해도 되지만, 0~9 개수 + 9부터 붙이면 큰 정렬이 필요 없다.
- `X[i] - '0'`은 문자열을 지우지 않는다. 문자 `'3'`을 정수 `3`으로 바꿔 개수 배열 인덱스로 쓴다. `'0'-'0'=0`은 숫자 0의 개수 칸이다.
- `yNumCount[X[i] - '0']`는 `Y`가 아니라 `X`를 한 번 더 센다. `Y[i]`여야 한다. `Y`가 더 길면 범위 오류.
- `collectNumCount[0]==0`으로 `while`을 끊으면 안 된다. 그건 “숫자 0 짝이 없다”이지 9~1을 다 붙였다는 뜻이 아니다. 끝은 `digit < 0`.
- 빈 문자열에 `"-1"`을 이어 붙이는 게 아니라 대신 반환. 0이 여러 개면 `ToString()`이 `"000"`이므로 `== "0"`이 아니라 첫 글자 `'0'`이면 `"0"`.

## 문제 한 줄
두 수에서 짝 지을 수 있는 공통 숫자로 만들 수 있는 가장 큰 수. 없으면 `-1`, 0뿐이면 `0`. 문자열 반환.

## 핵심 패턴
```text
X, Y 각각 0~9 개수
pairCount[d] = min(X개수, Y개수)
digit = 9..0, pairCount[digit]번 붙이기
길이 0 → "-1"
앞이 '0' → "0"
```

짝 개수는 `min`. 예5: `5`가 X 3개 Y 2개 → 2개. 가장 큰 수는 큰 숫자부터.

## 제출 코드
```csharp
int[] pairCount = new int[10];
for (int digit = 0; digit < 10; digit++)
    pairCount[digit] = Math.Min(xNumCount[digit], yNumCount[digit]);

for (int digit = 9; digit >= 0; digit--)
    result.Append((char)('0' + digit), pairCount[digit]);

answer = result.ToString();
if (answer.Length == 0) return "-1";
if (answer[0] == '0') return "0";
return answer;
```

`xNumCount` / `yNumCount`는 각 숫자의 개수. `pairCount[5]`는 숫자 5 짝이 몇 개인지(문자가 아님). `result`는 짝꿍 문자열. `Append(문자, 횟수)`는 안쪽 `for`와 같고, 횟수 0이면 안 붙는다.

`new StringBuilder(Math.Min(X.Length, Y.Length))`는 짝 길이 상한. 300만에서 버퍼 늘리기 감소.

## 대안별 구현 비교

안쪽을 한 글자씩 도는 것과 횟수 `Append`는 결과가 같다.

```csharp
for (int i = 0; i < pairCount[digit]; i++)
    result.Append(digit);
```

`Append(digit)`은 `int`라 `"5"`를 한 번 넣으므로 횟수만큼 반복이 필요하다.

## 다음에 볼 것
- 숫자 0~9만 있으면 카운트 후 큰 것부터. 긴 문자열 정렬보다 우선.
- `char - '0'`은 변환이지 삭제 아님.
- 짝 없음 `-1`, 0만 `"0"` (`"000"` 금지).
