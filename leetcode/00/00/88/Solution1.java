// 88. Merge Sorted Array
// https://leetcode.com/problems/merge-sorted-array/

/*
    Time: O(m + n)
    Space: O(1)
*/
public class Solution {
    public void merge(int[] nums1, int m, int[] nums2, int n) {
        var i = m - 1;
        var j = n - 1;
        var index = m + n - 1; // don't use nums1.Length - 1 becouse edge cases when more zero space than m + n

        while (i >= 0 && j >= 0) {
            if (nums1[i] > nums2[j]) {
                nums1[index] = nums1[i];
                i--;
            } else {
                nums1[index] = nums2[j];
                j--;
            }

            index--;
        }

        // No need to handle i >= 0 case. If it's the case, the remaining numbers are already in nums1.
        while (j >= 0) {
            nums1[index] = nums2[j];
            index--;
            j--;
        }
    }
}


/*
    Time: O(m + n)
    Space: O(1)
*/
public class Solution1 {
    public void merge(int[] nums1, int m, int[] nums2, int n) {
        var i = m - 1;
        var j = n - 1;
        var index = m + n - 1; // don't use nums1.Length - 1 becouse edge cases when more zero space than m + n

        while (i >= 0 && j >= 0) {
            if (nums1[i] > nums2[j])
                nums1[index--] = nums1[i--];
            else
                nums1[index--] = nums2[j--];
        }

        // No need to handle i >= 0 case. If it's the case, the remaining numbers are already in nums1.
        while (j >= 0) {
            nums1[index--] = nums2[j--];
        }
    }
}