// 566. Reshape the Matrix
// https://leetcode.com/problems/reshape-the-matrix/

/*
    Time: O(M*N) where M is mat.Length, N is mat[0].Length
    Space: O(M*N)
*/
public class Solution {
    public int[][] matrixReshape(int[][] mat, int r, int c) {
        var m = mat.length;
        var n = mat[0].length;
        if (m * n != r * c) return mat;

        var result = new int[r][];
        for (var i = 0; i < r; i++) result[i] = new int[c];

        int x = 0, y = 0;
        for (int i = 0; i < r; i++) {
            for (int j = 0; j < c; j++) {
                if ((x < m) || (y < n)) {
                    if (y >= n) {
                        y = 0;
                        x++;
                    }
                    result[i][j] = mat[x][y];
                    y++;
                }
            }
        }
        return result;
    }
}
