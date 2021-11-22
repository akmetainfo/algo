// 46. Permutations
// https://leetcode.com/problems/permutations/

/*
    Time: O(N!)
    Space: O(N!) for call stack
*/
public class Solution {
    public List<List<Integer>> permute(int[] nums) {
        List<List<Integer>> result = new ArrayList<>();
        permute(nums, result, 0);
        return result;
    }

    private void permute(int[] nums, List<List<Integer>> result, int start) {
        if (start == nums.length - 1) {
            // error: cannot infer type arguments for ArrayList<>
            result.add(new ArrayList<>(nums));
            return;
        }

        for (var i = start; i < nums.length; i++) {
            var temp = nums[start];
            nums[start] = nums[i];
            nums[i] = temp;

            permute(nums, result, start + 1);

            temp = nums[start];
            nums[start] = nums[i];
            nums[i] = temp;
        }
    }
}
