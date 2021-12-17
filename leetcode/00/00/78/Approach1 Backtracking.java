// 78. Subsets
// https://leetcode.com/problems/subsets/

/*
    Time: O()
    Space: O()
*/
public class Solution {
    public List<List<Integer>> subsets(int[] nums) {
        List<List<Integer>> result = new ArrayList<>();
        Arrays.sort(nums);
        backtracking(result, new ArrayList<>(), nums, 0);
        return result;
    }

    private void backtracking(List<List<Integer>> result, List<Integer> choices, int[] nums, int start) {
        result.add(new ArrayList<>(choices));
        for (int i = start; i < nums.length; i++) {
            choices.add(nums[i]);
            backtracking(result, choices, nums, i + 1);
            choices.remove(choices.size() - 1);
        }
    }
}
