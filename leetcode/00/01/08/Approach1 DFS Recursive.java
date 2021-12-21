// 108. Convert Sorted Array to Binary Search Tree
// https://leetcode.com/problems/convert-sorted-array-to-binary-search-tree/

/*
    Time: O(N)
    Space: O(log N) for storing call stack
*/
public class Solution {
    public TreeNode sortedArrayToBST(int[] nums) {
        return toBST(nums, 0, nums.length - 1);
    }

    TreeNode toBST(int[] nums, int left, int right) {
        if (left > right) return null;
        var mid = left + (right - left) / 2;
        var result = new TreeNode(nums[mid]);
        result.left = toBST(nums, left, mid - 1);
        result.right = toBST(nums, mid + 1, right);
        return result;
    }
}