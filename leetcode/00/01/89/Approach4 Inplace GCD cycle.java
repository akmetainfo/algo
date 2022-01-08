// 189. Rotate Array
// https://leetcode.com/problems/rotate-array/

/*
    Time: O(N) N = nums.Length * d
    Space: O()
*/
public class Solution {
    public void rotate(int[] nums, int k) {
        k %= nums.length;

        if (k == 0 || nums.length < 2)
            return;

        var cycles = gcd(nums.length, k);

        for (int i = 0; i < cycles; i++) {
            var prev = nums[i];
            for (int j = 0; j < nums.length / cycles; j++) {
                var idx = (i + (j + 1) * k) % nums.length;
                var tmp = prev;
                prev = nums[idx];
                nums[idx] = tmp;
            }
        }
    }

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

/*
    Time: O()
    Space: O()
    
https://www.geeksforgeeks.org/array-rotation/
Note: This algo rotates left, not right!
Instead of moving one by one, divide the array in different sets where number of sets is equal to GCD of n and d and move the elements within sets.
*/
public class Solution1 {
    public void rotate(int[] nums, int d) {
        int i, j, k, temp;
        /* To handle if d >= n */
        d = d % nums.length;
        for (i = 0; i < gcd(d, nums.length); i++) {
            /* move i-th values of blocks */
            temp = nums[i];
            j = i;
            while (true) {
                k = j + d;
                if (k >= nums.length)
                    k = k - nums.length;
                if (k == i)
                    break;
                nums[j] = nums[k];
                j = k;
            }
            nums[j] = temp;
        }
    }

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