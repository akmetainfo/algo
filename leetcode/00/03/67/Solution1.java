// 367. Valid Perfect Square
// https://leetcode.com/problems/valid-perfect-square/

/*
    Time: O(log n)
    Space: O(1)
*/
public class Solution {
    // classic binary search, simplest form
    public boolean isPerfectSquare(int num) {
        var left = 1;
        var right = num;

        while (left <= right) {
            var mid = left + (right - left) / 2;

            long sq = (long) mid * (long) mid;

            if (sq == (long) num)
                return true;

            if (sq < (long) num)
                left = mid + 1;
            else
                right = mid - 1;
        }

        return false;
    }

    // we reduces the upper border from num to num/2
    // but we need to check edge case (for 1)
    public boolean isPerfectSquare2(int num) {
        if (num == 1)
            return true;

        var left = 1;
        var right = num / 2; // 2 * x < x ^ 2 when x > 2

        while (left <= right) {
            var mid = left + (right - left) / 2;

            long sq = (long) mid * (long) mid;

            if (sq == (long) num)
                return true;

            if (sq < (long) num)
                left = mid + 1;
            else
                right = mid - 1;
        }

        return false;
    }
}