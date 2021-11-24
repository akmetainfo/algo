// 1281. Subtract the Product and Sum of Digits of an Integer
// https://leetcode.com/problems/subtract-the-product-and-sum-of-digits-of-an-integer/

/*
    Time: O(log n)
    Space: O(1)
*/
public class Solution {
    public int subtractProductAndSum(int n) {
        {
            var sum = 0;
            var prod = 1;

            while (n > 0) {
                var digit = n % 10;
                sum += digit;
                prod *= digit;
                n /= 10;
            }

            return prod - sum;
        }
    }
}
