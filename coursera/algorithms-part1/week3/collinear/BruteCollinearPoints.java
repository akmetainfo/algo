/* *****************************************************************************
 *  Name:              Ada Lovelace
 *  Coursera User ID:  123456
 *  Last modified:     October 16, 1842
 **************************************************************************** */

import java.util.Arrays;

public class BruteCollinearPoints {
    private final Point[] points;
    private int numberOfSegments;

    // finds all line segments containing 4 points
    public BruteCollinearPoints(Point[] points) {
        if (points == null)
            throw new IllegalArgumentException();

        for (int i = 0; i < points.length; ++i) {
            if (points[i] == null)
                throw new IllegalArgumentException();
        }

        // assertHasSamePoints

        Point[] pointsForCheck = points.clone();
        Arrays.sort(pointsForCheck);
        Point last = pointsForCheck[0];
        for (int i = 1; i < pointsForCheck.length; ++i) {
            if (last.compareTo(pointsForCheck[i]) == 0)
                throw new IllegalArgumentException();
            last = pointsForCheck[i];
        }

        numberOfSegments = 0;
        this.points = points.clone();
    }

    // the number of line segments
    public int numberOfSegments() {
        return numberOfSegments;
    }

    // the line segments
    public LineSegment[] segments() {
        int n = points.length;
        LineSegment[] ls = new LineSegment[n];
        int lsIndex = 0;
        Point[] tmpPoints = points.clone();
        for (int i = 0; i < n; ++i) {
            for (int j = i + 1; j < n; j++) {
                for (int k = j + 1; k < n; k++) {
                    for (int m = k + 1; m < n; m++) {
                        double slopeJ = tmpPoints[i].slopeTo(tmpPoints[j]);
                        double slopeK = tmpPoints[i].slopeTo(tmpPoints[k]);
                        double slopeM = tmpPoints[i].slopeTo(tmpPoints[m]);
                        if (Double.compare(slopeJ, slopeK) == 0
                                && Double.compare(slopeK, slopeM) == 0) {
                            Point[] pointsInLine = new Point[4];
                            pointsInLine[0] = tmpPoints[i];
                            pointsInLine[1] = tmpPoints[j];
                            pointsInLine[2] = tmpPoints[k];
                            pointsInLine[3] = tmpPoints[m];

                            int min = min(pointsInLine);
                            int max = max(pointsInLine);

                            ls[lsIndex++] = new LineSegment(pointsInLine[min], pointsInLine[max]);
                            numberOfSegments++;
                        }
                    }
                }
            }
        }
        LineSegment[] result = new LineSegment[numberOfSegments];
        for (int i = 0; i < numberOfSegments; ++i) {
            result[i] = ls[i];
        }
        return result;
    }

    private int min(Point[] pointArray) {
        int min = 0;
        for (int i = 0; i < pointArray.length; ++i) {
            if (pointArray[i].compareTo(pointArray[min]) < 0) {
                min = i;
            }
        }
        return min;
    }

    private int max(Point[] pointArray) {
        int max = 0;
        for (int i = 0; i < pointArray.length; ++i) {
            if (pointArray[i].compareTo(pointArray[max]) > 0) {
                max = i;
            }
        }
        return max;
    }
}
