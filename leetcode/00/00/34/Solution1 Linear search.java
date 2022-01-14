// 34. Find First and Last Position of Element in Sorted Array
// https://leetcode.com/problems/find-first-and-last-position-of-element-in-sorted-array/

/*
    Time: O(n)
    Space: O(1)
*/
public class Solution {
    public int[] searchRange(int[] nums, int target) {
        var result = new int[]{-1, -1};

        var i = 0;
        var j = nums.length - 1;
        while (i < nums.length) {
            if (result[0] == -1 && nums[i] == target)
                result[0] = i;

            if (result[1] == -1 && nums[j] == target)
                result[1] = j;

            i++;
            j--;
        }
        return result;
    }
}

/*
    Time: O(N)
    Space: O(1)
*/
public class Solution1 {
    public int[] searchRange(int[] nums, int target) {
        var result = new int[]{-1, -1};

        for (int i = 0; i < nums.length; i++) {
            if (nums[i] == target) {
                if (result[0] == -1) {
                    result[0] = i;
                    result[1] = i;
                } else {
                    result[1] = i;
                }
            }
        }

        return result;
    }
}


/*
    Time: O(N)
    Space: O(1)
*/
public class Solution2 {
    public int[] searchRange(int[] nums, int target) {
        var result = new int[]{-1, -1};

        for (var i = 0; i < nums.length; i++)
            if (nums[i] == target) {
                result[0] = i;
                break;
            }

        if (result[0] == -1)
            return result;

        for (var i = nums.length - 1; i >= result[0]; i--)
            if (nums[i] == target) {
                result[1] = i;
                break;
            }

        return result;
    }
}

/*
    Time: O(N)
    Space: O(1)
*/
public class Solution3 {
    public int[] searchRange(int[] nums, int target) {
        var found = false;

        var i = 0;
        while (i < nums.length) {
            if (nums[i] == target) {
                found = true;
                break;
            }
            i++;
        }

        if (!found)
            return new int[]{-1, -1};

        var j = i;
        while (j < nums.length) {
            if (nums[j] != target)
                break;

            j++;
        }

        return new int[]{i, j - 1};
    }
}
