// 1266. Minimum Time Visiting All Points
// https://leetcode.com/problems/minimum-time-visiting-all-points/

/*
    Time: O(N)
    Space: O(1)
*/
class Solution {
    public int minTimeToVisitAllPoints(int[][] points) {
        var result = 0;
		for (int i = 0; i < points.length - 1; i++)
		{
			var point0 = points[i];
			var point1 = points[i+1];

			var dx = Math.abs(point0[0] - point1[0]);
			var dy = Math.abs(point0[1] - point1[1]);
			result += Math.max(dx, dy);
		}
		return result;
    }
}