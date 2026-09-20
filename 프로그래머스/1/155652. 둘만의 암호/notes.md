# 둘만의 암호 (155652)

## 상태
- 제출 완료 (한 칸씩 `while (step < index)`)
- 학습용 다른 두 방법: `프로그래머스/1/155652. 둘만의 암호/둘만의암호_학습.cs`
- 로컬 실험: `LocalTest/Program.cs` (`.gitignore`)

## 내가 한 질문
- skip 존재 배열을 만들고 s를 순회? skip이 짧으니 문자열을 도는 게 낫나? 구간 안 skip 개수 + `% 26`까지 가면 복잡해 보인다.
- 존재만 보면 되니 `int[26]` 기본 0, 있으면 1? 문제 없나?
- `index`만큼 옮기는 일반 `for`가 안 맞는데 `i < index + skipCount`가 되나?
- 증감 없는 `for`도 있나? 안에서 증감해도 되나?
- `foreach`로 s를 돌며 안쪽 `char`를 이동?
- 전역에 StringBuilder가 필요?
- `step`을 `current`에 더해서 넣나?
- LocalTest 코드 검토. 변수명이 어렵다. VS Community Rename?
- 한 칸씩 말고 다른 방법? skip 제외 원이 반복을 줄이는 개선 같고, 글자→암호 맵핑/표도 괜찮아 보인다.
- 두 방법 코드. 구조가 비슷해 보인다. 메모에 넣을 것. 코드는 주석으로 구별.

## 막혔던 지점
- 한 번에 `index`칸 + 구간 skip 개수 + 원형 래핑을 같이 계산하면 꼬임. **유효 글자만 `index`번** 전진이 단순.
- `i < index + skipCount`는 skip 개수를 걷기 전에 모름. `while (step < index)`가 맞음.
- `foreach`의 `c`에는 대입 불가 → `char current = ch` 복사.
- `step`은 횟수. `Append(current)`이지 `current + step`이 아님.
- `skipIndex`는 위치가 아니라 존재 → `isSkip`. `sb`보다 `result`.
- StringBuilder는 클래스 필드가 아니라 `solution` 상단. 필드로 두면 테스트에 이전 문자 잔류.

## 문제 한 줄
`s`의 각 소문자를 skip이 아닌 글자만 세며 `index`칸 뒤(z 다음은 a)로 바꾼 문자열.

## 핵심 패턴 (제출)
```text
isSkip[26]: skip이면 1
s의 각 ch:
  current = ch, step = 0
  step < index 동안 한 칸 전진 (% 26)
  skip이 아니면 step++
  result에 current
```

## 다른 두 방법 (구조는 같음)
공통: `isSkip` + skip 뺀 `circle` (a~z 순서 유지).

| | 점프 시점 | 학습 함수 |
|---|---|---|
| A 원에서 점프 | `s` 글자마다 `(pos+index)%circle.Length` | `EncodeByCircle` |
| B 암호 표 | `'a'~'z'`마다 점프해 `cipher[26]` 채움, `s`는 조회 | `EncodeByCipherTable` |

B는 A의 점프를 글자 종류만큼 미리 한 것. `k`가 두 번 나와도 점프는 한 번. `%`는 원 길이이지 26이 아님.

한 칸씩 vs 원/표: 제한이 작아 성능 차이는 작음. “구간 skip 개수”만 피하면 됨.

## 변수·도구
- Rename: VS Community에서 심볼 위 F2 또는 Ctrl+R, Ctrl+R. 같은 글자 전부가 아니라 **그 선언의 참조**만.
- `Index`는 위치, `is`는 여부, `Count`는 개수, `result`는 결과 통.

## 다음에 볼 것
- 유효한 다음만 세며 이동 / 허용 문자 원에서 점프
- 같은 입력이 반복되면 표로 캐시
