using System;

public class Solution {
    public int solution(int chicken) {
                int service = 0;
                int coupons = chicken;

                while (coupons >= 10)
                {
                    int free = coupons / 10;
                    service += free;
                    coupons = (coupons % 10) + free;
                }

                return service;
    }
}