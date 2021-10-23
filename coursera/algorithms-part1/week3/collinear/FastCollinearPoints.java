/* *****************************************************************************
 *  Name:              Ada Lovelace
 *  Coursera User ID:  123456
 *  Last modified:     October 16, 1842
 **************************************************************************** */

import java.util.Arrays;

public class FastCollinearPoints {
    private LineSegment[] segments;
    private int count;

    // finds all line segments containing 4 or more points
    public FastCollinearPoints(Point[] points) {
        if (points == null)
            throw new IllegalArgumentException();

        for (int i = 0; i < points.length; ++i) {
            if (points[i] == null)
                throw new IllegalArgumentException();
        }

        if (points.length == 0) {
            segments = new LineSegment[0];
            return;
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

        // assertHasSamePoints


        if (points.length < 4) {
            segments = new LineSegment[0];
            return;
        }

        segments = new LineSegment[2];
        Point[] slopeSorted = new Point[points.length];
        for (int j = 0; j < points.length; ++j) {
            slopeSorted[j] = points[j];
        }
        for (int i = 0; i < points.length - 1; ++i) {
            Arrays.sort(slopeSorted);
            Arrays.sort(slopeSorted, points[i].slopeOrder());
            int lowest = 1;
            int highest = 1;
            for (int j = 2; j < slopeSorted.length; ++j) {
                double s0 = points[i].slopeTo(slopeSorted[lowest]);
                double s1 = points[i].slopeTo(slopeSorted[j]);
                if (Math.abs(s0 - s1) < Double.MIN_NORMAL
                        || Double.isNaN(s0 - s1) && points[i].compareTo(slopeSorted[j]) < 0) {
                    highest = j;
                }
                else {
                    if (highest - lowest >= 2 && points[i].compareTo(slopeSorted[lowest]) < 0
                            && points[i].compareTo(slopeSorted[highest]) < 0) {
                        resizeSegments();
                        segments[count] = new LineSegment(points[i], slopeSorted[highest]);
                        count = count + 1;
                    }
                    lowest = j;
                    highest = j;
                }
            }
            if (highest - lowest >= 2 && points[i].compareTo(slopeSorted[lowest]) < 0
                    && points[i].compareTo(slopeSorted[highest]) < 0) {
                resizeSegments();
                segments[count] = new LineSegment(points[i], slopeSorted[highest]);
                count = count + 1;
            }
        }
        LineSegment[] finalSegments = new LineSegment[count];
        for (int i = 0; i < finalSegments.length; ++i) {
            finalSegments[i] = segments[i];
        }
        segments = finalSegments;

    }

    // the number of line segments
    public int numberOfSegments() {
        return count;
    }

    // the line segments
    public LineSegment[] segments() {
        return segments.clone();
    }

    private void resizeSegments() {
        if (count > segments.length / 2) {
            LineSegment[] newSegments = new LineSegment[segments.length * 2];
            for (int i = 0; i < count; ++i) {
                newSegments[i] = segments[i];
            }
            segments = newSegments;
        }
    }
}
