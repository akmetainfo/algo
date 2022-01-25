// 74. Search a 2D Matrix
// https://leetcode.com/problems/search-a-2d-matrix/

/*
    Time: O(log N) where N is number of element in matrix
    Space: O(1)
*/
public class Solution {
    public boolean searchMatrix(int[][] matrix, int target) {
        var m = matrix.length;
        var n = matrix[0].length;
        var left = 0;
        var right = m * n - 1;
        while (left <= right) {
            var mid = left + (right - left) / 2;
            var val = matrix[mid / n][mid % n];
            if (val == target) return true;
            if (val < target)
                left = mid + 1;
            else
                right = mid - 1;
        }
        return false;
    }
}
