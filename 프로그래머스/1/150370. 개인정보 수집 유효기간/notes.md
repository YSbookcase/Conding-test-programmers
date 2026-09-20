# 개인정보 수집 유효기간 (150370)

## 상태
- 제출 완료 (`ChangeDay` + `Dictionary<char, int>` + `todayDays >= collectDays + months * 28`)
- 로컬 실험: `LocalTest/Program.cs` (`.gitignore`, 커밋 안 함)
- 공식 폴더: `프로그래머스/1/150370. 개인정보 수집 유효기간/`

## 내가 한 질문
- 약관은 Dictionary? 28일 달력이라 일로 환산? `Split`에 `.`과 공백을 한 번에?
- `Split` 옵션이 뭐가 있나?
- `termsTable` Dictionary 파싱이 맞나?
- 한글자인데도 `tokens[0][0]`을 해야 하나? (`string`이라서?)
- `privacies`도 `char`로 통일하면 되나? `char`는 숫자처럼 비교되나?
- `Split`한 `string`을 정수로 바꾸는 게 난감하다.
- `today`도 똑같이 일수로 바꿔야 하나?
- 일반적으로는 `DateTime`으로 크기 비교 가능하지 않나? 이번만 28일이 특수?
- 파싱은 했는데 비교는 어떻게? 개인정보 파싱을 어디에 담나?
- 변수 선언이 아래 있으면 안 되나?
- 제출 전 조언.
- 방어 코드는 어떻게 바꾸나?
- 코드가 긴데 최선인가?
- `using` Text/Generic/Linq를 습관적으로 넣으면 실수가 줄나?

## 막혔던 지점
- `Split` 결과는 항상 `string[]`. `"A"`와 `'A'`는 다른 타입. `Dictionary<char, int>`면 `tokens[0][0]`. 키를 `string`으로 두면 `tokens[0]` 그대로.
- 개인정보를 다른 배열에 모을 필요 없음. 한 줄 읽고 `ChangeDay` → 바로 비교.
- `todayDays`는 비교 루프 **앞**에서 한 번. 사용보다 아래 선언은 컴파일 오류.
- `DateTime.AddMonths`는 실제 달력(28~31일). 이 문제는 한 달 = 28일, `07.01` 전날은 `06.28`.
- `TryParse` + `if`는 실패를 건너뛰어 약관이 빠질 수 있음. 형식이 보장되면 `int.Parse`.
- `int[] answer = new int[] { }`는 길이 고정. 파기 개수를 모르면 `List<int>` 후 `ToArray()`.
- 번호는 `privacies` 0부터 → `i + 1`. `foreach`만 쓰면 번호가 안 나옴.

## 문제 한 줄
수집일 + 약관 개월이 지난 개인정보 번호를 오름차순으로. 유효기간 **시작날 = 파기**. 매달 28일.

## 핵심 패턴
```text
termMonths[종류] = 개월
todayDays = ChangeDay(today)
privacies i:
  collectDays = ChangeDay(날짜)
  todayDays >= collectDays + months * 28 이면 i+1
ChangeDay: year * 12 * 28 + month * 28 + day
```
- `"05"` → `int.Parse`는 5. 문자열 `+`는 이어 붙임.
- `Split('.', ' ')` 한 번에 가능. 처음엔 공백으로 날짜/약관 가른 뒤 날짜만 `.`으로.
- `StringSplitOptions.RemoveEmptyEntries`는 이 입력에 없어도 됨.
- `>=` : 오늘이 파기 시작날이면 파기. `>`만 쓰면 예1의 3번이 남음.

## 변수·using
- `expired`는 역할이 보임. `termsMonths`보다 `termMonths`(약관 하나 → 개월).
- 함수는 `ChangeDay`. `todays`는 복수처럼 보임 → `todayDays`.
- `using Generic`은 `List`/`Dictionary`라 습관 OK. `Linq`/`Text`는 쓸 때만. 안 쓰는 `using`은 실수 방지 아님.

## 다음에 볼 것
- 가상 달력(한 달 28일, 1년 360일) → 단위를 일로 접기. 실제 달력만 `DateTime`.
- 파싱 문제: 표 먼저, 한 건씩 변환 후 비교. 중간 배열에 쌓지 않기.
