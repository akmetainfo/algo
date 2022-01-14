// 34. Find First and Last Position of Element in Sorted Array
// https://leetcode.com/problems/find-first-and-last-position-of-element-in-sorted-array/

/*
    Time: O(log n)
    Space: O(1)
*/
public class Solution {
    public int[] searchRange(int[] nums, int target) {
        if (nums.length == 0) return new int[]{-1, -1};

        return new int[]{leftmostBinarySearch(nums, target), rightmostBinarySearch(nums, target)};
    }

    private int leftmostBinarySearch(int[] nums, int target) {
        var left = 0;
        var right = nums.length - 1;

        while (left < right) {
            var mid = left + (right - left) / 2;

            if (nums[mid] < target)
                left = mid + 1;
            else
                right = mid;
        }

        if (nums[left] == target)
            return left;

        return -1;
    }

    private int rightmostBinarySearch(int[] nums, int target) {
        var left = 0;
        var right = nums.length - 1;

        while (left < right) {
            var mid = 1 + left + (right - left) / 2;

            if (nums[mid] > target)
                right = mid - 1;
            else
                left = mid;
        }

        if (nums[left] == target)
            return left;

        return -1;
    }
}