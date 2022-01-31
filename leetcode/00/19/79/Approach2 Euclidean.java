// 1979. Find Greatest Common Divisor of Array
// https://leetcode.com/problems/find-greatest-common-divisor-of-array/

/*
    Time: O(N)
    Space: O(1)
*/
public class Solution {
    public int findGCD(int[] nums) {
        var min = Arrays.stream(nums).min().getAsInt();
        var max = Arrays.stream(nums).max().getAsInt();

        return gcd(min, max);
    }

    // https://en.wikipedia.org/wiki/Greatest_common_divisor
    // https://en.wikipedia.org/wiki/Euclidean_algorithm
    // https://stackoverflow.com/a/41766138/5752652
    // https://stackoverflow.com/q/3980416/5752652
    /*
        Time: O(log N) worst case, O(1) best case
        Space: O(1)
    */
    private static int gcd(int a, int b) {
        while (a != 0 && b != 0) {
            if (a > b)
                a %= b;
            else
                b %= a;
        }

        return a | b;
    }
}
