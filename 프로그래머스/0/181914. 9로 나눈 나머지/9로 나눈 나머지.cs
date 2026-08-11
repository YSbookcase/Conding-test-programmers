using System;

public class Solution {
    public int solution(string number) {
        
        //int answer = 0;
        // (int)digitChar 사용시 문자가 '7'일 경우 값 55로 변환됨 따라서 문자를 숫자로 변환하기 위해서는 코드 값을 알고 있어야 함. 문자열은 Parse가 가능하지만 단계를 더 추가하는 것으로 불필요하게 복잡해짐.
        int sum = 0;
        
        foreach(char digitChar in number)
        {
            sum += digitChar - '0';
        }
        
        
        
        return sum % 9;
    }
}