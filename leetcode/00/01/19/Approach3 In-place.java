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


/*
    Time: O(n^2)
    Space: O()
*/
public class Solution1 {
    public List<Integer> getRow(int rowIndex) {
        var capacity = rowIndex + 1;
        List<Integer> result = new ArrayList<Integer>(capacity);

        result.add(1);

        for (int i = 1; i <= rowIndex; i++) {
            for (int j = i - 1; j >= 1; j--) {
                var tmp = result.get(j - 1) + result.get(j);
                result.set(j, tmp);
            }
            result.add(1);
        }

        return result;
    }
}
