/* *****************************************************************************
 *  Name:              Ada Lovelace
 *  Coursera User ID:  123456
 *  Last modified:     October 16, 1842
 **************************************************************************** */

import edu.princeton.cs.algs4.Point2D;
import edu.princeton.cs.algs4.RectHV;

import java.util.ArrayList;
import java.util.List;
import java.util.TreeSet;

public class PointSET {
    private final TreeSet<Point2D> treeSet;

    // construct an empty set of points
    public PointSET() {
        treeSet = new TreeSet<>();
    }

    // is the set empty?
    public boolean isEmpty() {
        return treeSet.isEmpty();
    }

    // number of points in the set
    public int size() {
        return treeSet.size();
    }

    // add the point to the set (if it is not already in the set)
    public void insert(Point2D p) {
        validatePoint(p);
        treeSet.add(p);
    }

    // does the set contain point p?
    public boolean contains(Point2D p) {
        validatePoint(p);
        return treeSet.contains(p);
    }

    // draw all points to standard draw
    public void draw() {
        for (Point2D point2D : treeSet)
            point2D.draw();
    }

    // all points that are inside the rectangle (or on the boundary)
    public Iterable<Point2D> range(RectHV rect) {
        validateRectangle(rect);
        List<Point2D> result = new ArrayList<>();
        for (Point2D p : treeSet) {
            if (rect.contains(p))
                result.add(p);
        }
        return result;
    }

    // a nearest neighbor in the set to point p; null if the set is empty
    public Point2D nearest(Point2D p) {
        validatePoint(p);
        Point2D nearest = null;
        double min = Double.POSITIVE_INFINITY;
        for (Point2D current : treeSet) {
            double distance = p.distanceSquaredTo(current);
            if (distance < min) {
                nearest = current;
                min = distance;
            }
        }
        return nearest;
    }

    private void validatePoint(Point2D point) {
        if (point == null)
            throw new IllegalArgumentException();
    }

    private void validateRectangle(RectHV rectHV) {
        if (rectHV == null)
            throw new IllegalArgumentException();
    }

    // unit testing of the methods (optional)
    public static void main(String[] args) {
        // TL;DR
    }
}
