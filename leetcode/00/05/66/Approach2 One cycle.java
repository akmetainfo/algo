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

        for (var i = 0; i < m * n; i++)
            result[i / c][i % c] = mat[i / n][i % n];

        return result;
    }
}
