// 119. Pascal's Triangle II
// https://leetcode.com/problems/pascals-triangle-ii/

/*
    Time: O()
    Space: O()
*/
public class Solution {
    public List<Integer> getRow(int rowIndex) {
        if (rowIndex == 0)
            return List.of(1);

        var prevRow = getRow(rowIndex - 1);

        List<Integer> curRow = new ArrayList<>();

        curRow.add(1);

        for (int j = 1; j < rowIndex; j++) {
            curRow.add(prevRow.get(j - 1) + prevRow.get(j));
        }

        curRow.add(1);

        return curRow;
    }
}