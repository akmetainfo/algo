/* *****************************************************************************
 *  Name:              Ada Lovelace
 *  Coursera User ID:  123456
 *  Last modified:     October 16, 1842
 **************************************************************************** */

import edu.princeton.cs.algs4.Point2D;
import edu.princeton.cs.algs4.RectHV;
import edu.princeton.cs.algs4.Stack;
import edu.princeton.cs.algs4.StdDraw;

public class KdTree {
    private Node root;
    private int size;
    private Stack<Point2D> points;

    private class Node {
        private final Point2D point;
        private Node left, right;
        private final int level;
        private RectHV rect;

        public Node(Point2D p, int level) {
            this.point = p;
            this.level = level;
            this.right = null;
            this.left = null;
            this.rect = null;
        }

        public int compareTo(Node input) {
            if (this.level % 2 == 0) {
                return Double.compare(input.point.x(), this.point.x());
            }

            return Double.compare(input.point.y(), this.point.y());
        }
    }

    // construct an empty set of points
    public KdTree() {
        root = null;
        size = 0;
    }

    // is the set empty?
    public boolean isEmpty() {
        return root == null;
    }

    // number of points in the set
    public int size() {
        return size;
    }

    // add the point to the set (if it is not already in the set)
    public void insert(Point2D p) {
        validatePoint(p);
        if (root == null || !contains(p)) {
            root = insert(root, null, p, 0, false);
            size++;
        }
    }

    private Node insert(Node x, Node prevNode, Point2D p, int count, boolean direction) {
        if (x == null) {
            Node newNode = new Node(p, count);
            initrectangle(newNode, prevNode, direction);
            return newNode;
        }

        if (x.point.equals(p)) return x;
        int cmp = x.compareTo(new Node(p, count));
        if (cmp < 0) {
            x.left = insert(x.left, x, p, count + 1, false);
            return x;
        }
        else {
            x.right = insert(x.right, x, p, count + 1, true);
            return x;
        }
    }

    // does the set contain point p?
    public boolean contains(Point2D p) {
        validatePoint(p);
        return containsPoint(root, p, 0);
    }

    private boolean containsPoint(Node x, Point2D p, int count) {
        if (x == null) return false;
        if (x.point.equals(p)) return true;
        int cmp = x.compareTo(new Node(p, count));
        if (cmp < 0) return containsPoint(x.left, p, count + 1);
        else return containsPoint(x.right, p, count + 1);
    }

    // draw all points to standard draw
    public void draw() {
        if (root != null) {
            RectHV unitSquare = new RectHV(0, 0, 1, 1);
            unitSquare.draw();
        }
        else
            return;
        StdDraw.clear();
        drawNode(root);
    }

    private void drawNode(Node x) {
        if (x.rect == null) return;
        if (x.left != null) drawNode(x.left);
        if (x.right != null) drawNode(x.right);
        drawPoint(x.point);
        if (x.level % 2 == 0)
            drawVertical(x.rect, x.point);
        else
            drawHorizontal(x.rect, x.point);
    }

    private void drawPoint(Point2D p) {
        StdDraw.setPenColor(StdDraw.BLACK);
        p.draw();
    }

    private void drawVertical(RectHV current, Point2D p) {
        StdDraw.setPenColor(StdDraw.RED);
        StdDraw.line(p.x(), current.ymin(), p.x(), current.ymax());
    }

    private void drawHorizontal(RectHV current, Point2D p) {
        StdDraw.setPenColor(StdDraw.BLUE);
        StdDraw.line(current.xmin(), p.y(), current.xmax(), p.y());
    }

    // all points that are inside the rectangle (or on the boundary)
    public Iterable<Point2D> range(RectHV rect) {
        validateRectangle(rect);
        points = new Stack<>();
        thePoints(root, rect);
        return points;
    }

    private void thePoints(Node x, RectHV rect) {
        if (x == null) return;
        if (rect.contains(x.point)) points.push(x.point);
        if (x.rect == null) return;
        if (x.left != null && rect.intersects(x.left.rect))
            thePoints(x.left, rect);
        if (x.right != null && rect.intersects(x.right.rect))
            thePoints(x.right, rect);
    }

    private void initrectangle(Node x, Node previousNode, boolean direction) {
        if (x == root)
            x.rect = new RectHV(0, 0, 1, 1);
        else if (x.rect == null) {
            x.rect = rectangeOfPoint(previousNode, x, direction);
        }
    }

    private RectHV rectangeOfPoint(Node prevNode, Node currNode, boolean direction) {
        if (currNode == root || prevNode == null)
            return new RectHV(0, 0, 1, 1);

        if (currNode.level % 2 != 0) {
            return direction
                   ? new RectHV(prevNode.point.x(), prevNode.rect.ymin(),
                                prevNode.rect.xmax(), prevNode.rect.ymax())
                   : new RectHV(prevNode.rect.xmin(), prevNode.rect.ymin(),
                                prevNode.point.x(), prevNode.rect.ymax());
        }
        else {
            return direction
                   ? new RectHV(prevNode.rect.xmin(), prevNode.point.y(),
                                prevNode.rect.xmax(), prevNode.rect.ymax())
                   : new RectHV(prevNode.rect.xmin(), prevNode.rect.ymin(),
                                prevNode.rect.xmax(), prevNode.point.y());
        }
    }

    // a nearest neighbor in the set to point p; null if the set is empty
    public Point2D nearest(Point2D p) {
        validatePoint(p);
        return root == null
               ? null
               : thePoint(root, p, root).point;
    }

    private Node thePoint(Node current, Point2D p, Node nearest) {
        if (current == null)
            return nearest;

        if (current.point.distanceSquaredTo(p) < nearest.point.distanceSquaredTo(p))
            nearest = current;

        Node left = thePoint(current.left, p, nearest);
        Node right = thePoint(current.right, p, nearest);

        if (left.point.distanceSquaredTo(p) < right.point.distanceSquaredTo(p)) {
            if (left.point.distanceSquaredTo(p) < nearest.point.distanceSquaredTo(p))
                nearest = left;
        }
        else {
            if (right.point.distanceSquaredTo(p) < nearest.point.distanceSquaredTo(p))
                nearest = right;
        }
        return nearest;
    }

    // unit testing of the methods (optional)
    public static void main(String[] args) {
        // TL;DR
    }

    private void validatePoint(Point2D point) {
        if (point == null)
            throw new IllegalArgumentException();
    }

    private void validateRectangle(RectHV rectHV) {
        if (rectHV == null)
            throw new IllegalArgumentException();
    }
}
