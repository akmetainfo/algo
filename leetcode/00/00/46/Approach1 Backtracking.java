// 46. Permutations
// https://leetcode.com/problems/permutations/

/*
    Time: O()
    Space: O()
*/
public class Solution {
    public List<List<Integer>> permute(int[] nums) {
        List<List<Integer>> result = new ArrayList<>();
        backtracking(nums, new ArrayList<>(), result);
        return result;
    }

    private void backtracking(int[] nums, List<Integer> tempList, List<List<Integer>> result) {
        if (tempList.size() == nums.length) {
            result.add(new ArrayList<>(tempList));
            return;
        }

        for (int i = 0; i < nums.length; i++) {
            if (tempList.contains(nums[i])) // O(N) operation!
                continue;

            tempList.add(nums[i]);
            backtracking(nums, tempList, result);
            tempList.remove(tempList.size() - 1);
        }
    }
}
