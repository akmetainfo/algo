// 119. Pascal's Triangle II
// https://leetcode.com/problems/pascals-triangle-ii/

/*
    Time: O(n^2)
    Space: O()
*/
public class Solution {
    public List<Integer> getRow(int rowIndex) {
        int[] result = new int[rowIndex + 1];

        result[0] = 1;

        for (int i = 1; i <= rowIndex; i++) {
            for (int j = i; j > 0; j--)
                result[j] += result[j - 1];
        }

        return Arrays.stream(result).boxed().collect(Collectors.toList());
    }
}
