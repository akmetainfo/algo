/* *****************************************************************************
 *  Name:              Ada Lovelace
 *  Coursera User ID:  123456
 *  Last modified:     October 16, 1842
 **************************************************************************** */

import edu.princeton.cs.algs4.StdDraw;

import java.util.Comparator;

public class Point implements Comparable<Point> {
    private final int x;     // x-coordinate of this point
    private final int y;     // y-coordinate of this point

    // constructs the point (x, y)
    public Point(int x, int y) {
        this.x = x;
        this.y = y;
    }

    // draws this point
    public void draw() {
        StdDraw.point(x, y);
    }

    // draws the line segment from this point to that point
    public void drawTo(Point that) {
        StdDraw.line(this.x, this.y, that.x, that.y);
    }

    // string representation
    public String toString() {
        return "(" + x + ", " + y + ")";
    }

    // compare two points by y-coordinates, breaking ties by x-coordinates
    public int compareTo(Point that) {
        // breaking ties by their x-coordinates
        if (y == that.y) {
            return x - that.x;
        }
        // compare points by their y-coordinates
        return y - that.y;
    }

    // the slope between this point and that point
    public double slopeTo(Point that) {
        // treat the slope of a degenerate line segment (between a point and itself) as negative infinity.
        if (x == that.x && y == that.y) {
            return Double.NEGATIVE_INFINITY;
        }
        // treat the slope of a vertical line segment as positive infinity;
        if (x == that.x) {
            return Double.POSITIVE_INFINITY;
        }
        // Treat the slope of a horizontal line segment as positive zero
        if (y == that.y) {
            return +0.0;
        }
        //  return the slope between the invoking point (x0, y0) and the argument point (x1, y1),
        //  which is given by the formula (y1 − y0) / (x1 − x0).
        return (double) (that.y - y) / (double) (that.x - x);
    }

    // compare two points by slopes they make with this point
    public Comparator<Point> slopeOrder() {
        return new SlopeComparator();
    }

    private class SlopeComparator implements Comparator<Point> {
        public int compare(Point p1, Point p2) {
            double s1 = Point.this.slopeTo(p1);
            double s2 = Point.this.slopeTo(p2);
            if (s1 > s2) {
                return 1;
            }
            else if (s1 < s2) {
                return -1;
            }
            return 0;
        }
    }

    /**
     * Unit tests the Point data type.
     */
    public static void main(String[] args) {
        // too trivial to test it
    }
}
