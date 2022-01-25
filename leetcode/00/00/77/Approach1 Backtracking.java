// 77. Combinations
// https://leetcode.com/problems/combinations/

/*
    Time: O(C) where C = n! / ( k! * (n - k)! )
    Space: O(n*k)
*/
public class Solution {
    public List<List<Integer>> combine(int n, int k) {
        List<List<Integer>> result = new ArrayList<>();
        backtracking(1, n, k, new ArrayList<Integer>(), result);
        return result;
    }

    private void backtracking(int start, int n, int k, List<Integer> list, List<List<Integer>> result) {
        if (k == 0) {
            result.add(new ArrayList<Integer>(list));
            return;
        }

        for (int i = start; i <= n; i++) {
            list.add(i);
            backtracking(i + 1, n, k - 1, list, result);
            list.remove(list.size() - 1);
        }
    }
}
