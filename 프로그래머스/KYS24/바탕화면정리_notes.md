# 바탕화면 정리

## 상태
- 학습용: `프로그래머스/KYS24/바탕화면정리_학습.cs`
- LocalTest에서 min/max·+1 실수 점검함
- 공식 폴더가 생기면 그 `notes.md`로 이동

## 내가 한 질문
- #을 순회하며 x/y min·max. E는 max에 +1?
- 성능 이슈가 있다면 개선법이 따로 있나?
- 갱신 초기값은 길이 기준? if vs Math? 코드 작성
- 작성분 검토
- 실수가 계속 나오는데 이 방법이 일반적? 더 나은 방법?
- (메타) 채팅창을 새로 파는 게 나은가?

## 문제 한 줄
모든 `#`을 덮는 최소 드래그 사각형의 `[lux, luy, rdx, rdy]`  
(거리 최소 = bounding box). `lux < rdx`, `luy < rdy`.

## 정석 풀이
```text
minRow/minCol ← height/width (큰 값)
maxRow/maxCol ← -1

#마다:
  min ← Math.Min
  max ← Math.Max

return [minRow, minCol, maxRow+1, maxCol+1]
```
칸 `(r,c)` → 격자점 `(r,c)~(r+1,c+1)` 이라 끝점 **+1**.

## 성능
- H,W ≤ 50, O(HW) 한 번 순회가 최선. 별도 최적화 불필요.

## 겪었던 실수
1. `maxRow/maxCol`에 `Math.Min` 사용 → 최댓값 갱신 실패  
2. 반환 시 `+1` 누락  
3. (참고) min 초기값을 0으로 두면 위험 — 길이 또는 MaxValue가 안전

## 학습 메모
- 이 유형 = **bounding box**, 다른 고난도 대안 거의 없음
- 제출 전 체크: Max인지 / +1 있는지 / 예4 `[1,0,2,1]`

## 다음에 볼 것
- 안 보고 min/max/+1 한 번에 손코딩
- 예1·예4로 격자점 의미만 다시 그리기
