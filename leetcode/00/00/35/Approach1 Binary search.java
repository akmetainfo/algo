// 35. Search Insert Position
// https://leetcode.com/problems/search-insert-position/

/*
    Time: O(logn)
    Space: O(1)
*/
// simplest form of binary search
public class Solution {
    public int searchInsert(int[] nums, int target) {
        var left = 0;
        var right = nums.length - 1;

        while (left <= right) {
            var mid = left + (right - left) / 2;

            if (nums[mid] == target)
                return mid;

            if (nums[mid] < target)
                left = mid + 1;
            else
                right = mid - 1;
        }

        return left;
    }
}

/*
    Time: O(logn)
    Space: O(1)
*/
// leftmost binary search
public class Solution1 {
    public int searchInsert(int[] nums, int target) {
        var left = 0;
        var right = nums.length - 1;

        while (left < right) {
            var mid = left + (right - left) / 2;

            if (nums[mid] < target)
                left = mid + 1;
            else
                right = mid;
        }

        if (nums[left] < target)
            return left + 1;

        return left;
    }
}

/*
    Time: O(logn)
    Space: O(1)
*/
// rightmost binary search
public class Solution2 {
    public int searchInsert(int[] nums, int target) {
        var left = 0;
        var right = nums.length - 1;

        while (left < right) {
            var mid = 1 + left + (right - left) / 2;

            if (nums[mid] > target)
                right = mid - 1;
            else
                left = mid;
        }

        if (nums[left] < target)
            return left + 1;

        return left;
    }
}
