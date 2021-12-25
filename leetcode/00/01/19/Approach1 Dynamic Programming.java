// 119. Pascal's Triangle II
// https://leetcode.com/problems/pascals-triangle-ii/

/*
    Time: O(n^2), where n is rowIndex
    Space: O(n)
*/
public class Solution {
    public List<Integer> getRow(int rowIndex) {
        List<Integer> result = new ArrayList<>();
        result.add(1);

        if (rowIndex == 0)
            return result;

        for (int i = 1; i <= rowIndex; i++) {
            List<Integer> row = new ArrayList<>();
            row.add(1);

            for (int j = 0; j < result.size() - 1; j++) {
                row.add(result.get(j) + result.get(j + 1));
            }

            row.add(1);

            result = row;
        }

        return result;
    }
}