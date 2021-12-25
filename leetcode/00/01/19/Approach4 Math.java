// 119. Pascal's Triangle II
// https://leetcode.com/problems/pascals-triangle-ii/

/*
    Time: O(n), where n is rowIndex
    Space: O(n)
*/
public class Solution {
    public List<Integer> getRow(int rowIndex) {
        List<Integer> ans = new ArrayList<>();
        long val = 1;
        for (int j = 0; j <= rowIndex; j++) {
            ans.add((int) val);
            val = val * (rowIndex - j) / (j + 1);
        }
        return ans;
    }
}