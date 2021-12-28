// 39. Combination Sum
// https://leetcode.com/problems/combination-sum/

/*
    Time: O()
    Space: O()
*/
public class Solution {
    public List<List<Integer>> combinationSum(int[] candidates, int target) {
        List<List<Integer>> result = new ArrayList<>();
        Arrays.sort(candidates);
        combinationSum(candidates, target, result, new ArrayList<Integer>(), 0);
        return result;
    }

    public void combinationSum(int[] candidates, int target, List<List<Integer>> result, List<Integer> choices, int start) {
        if (target == 0) {
            result.add(new ArrayList<Integer>(choices));
            return;
        }

        for (int i = start; i < candidates.length; i++) {
            if (target < candidates[i]) break;
            choices.add(candidates[i]);
            combinationSum(candidates, target - candidates[i], result, choices, i);
            choices.remove(choices.size() - 1);
        }
    }
}


/*
    Time: O()
    Space: O()
*/
public class Solution1 {
    public List<List<Integer>> combinationSum(int[] candidates, int target) {
        List<List<Integer>> result = new ArrayList<>();
        Arrays.sort(candidates);
        combinationSum(candidates, target, result, new ArrayList<Integer>(), 0);
        return result;
    }

    public void combinationSum(int[] candidates, int target, List<List<Integer>> result, List<Integer> choices, int start) {
        if (target == 0) {
            result.add(new ArrayList<Integer>(choices));
            return;
        }

        for (int i = start; i < candidates.length && target >= candidates[i]; i++) {
            choices.add(candidates[i]);
            combinationSum(candidates, target - candidates[i], result, choices, i);
            choices.remove(choices.size() - 1);
        }
    }
}