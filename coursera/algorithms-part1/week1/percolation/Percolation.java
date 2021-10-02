/* *****************************************************************************
 *  Name:              Ada Lovelace
 *  Coursera User ID:  123456
 *  Last modified:     October 16, 1842
 **************************************************************************** */

import edu.princeton.cs.algs4.StdOut;
import edu.princeton.cs.algs4.WeightedQuickUnionUF;

public class Percolation {
    private final int size;
    private boolean[][] sites;
    private final WeightedQuickUnionUF network;
    private int opensites;

    // creates n-by-n grid, with all sites initially blocked
    public Percolation(int n) {
        if (n < 1)
            throw new IllegalArgumentException();

        this.size = n;
        this.sites = new boolean[n][n];

        network = new WeightedQuickUnionUF(n * n + 2);

        for (int i = 0; i < n; i++) {
            for (int j = 0; j < n; j++) {
                sites[i][j] = false;
            }
        }

        opensites = 0;
    }

    // opens the site (row, col) if it is not open already
    public void open(int row, int col) {
        if (isInvalid(row) || isInvalid(col))
            throw new IllegalArgumentException();

        if (isOpen(row, col))
            return;

        sites[row - 1][col - 1] = true;
        opensites++;

        int index = cellIndex(row, col);

        if (row == 1) {
            network.union(index, virtTopIndex());
        }

        if (row == size) {
            network.union(index, virtBottomIndex());
        }

        if (col != size && isOpen(row, col + 1)) {
            network.union(index, cellIndex(row, col + 1));
        }

        if (col != 1 && isOpen(row, col - 1)) {
            network.union(index, cellIndex(row, col - 1));
        }

        if (row != size && isOpen(row + 1, col)) {
            network.union(index, cellIndex(row + 1, col));
        }

        if (row != 1 && isOpen(row - 1, col)) {
            network.union(index, cellIndex(row - 1, col));
        }
    }

    // is the site (row, col) open?
    public boolean isOpen(int row, int col) {
        if (isInvalid(row) || isInvalid(col))
            throw new IllegalArgumentException();

        return sites[row - 1][col - 1];
    }

    // is the site (row, col) full?
    public boolean isFull(int row, int col) {
        if (isInvalid(row) || isInvalid(col))
            throw new IllegalArgumentException();

        int index = cellIndex(row, col);
        return network.find(index) == network.find(virtTopIndex());
    }

    // returns the number of open sites
    public int numberOfOpenSites() {
        return opensites;
    }

    // does the system percolate?
    public boolean percolates() {
        return network.find(virtTopIndex()) == network.find(virtBottomIndex());
    }

    // test client (optional)
    public static void main(String[] args) {
        int size = 1;

        Percolation percolate = new Percolation(size);

        StdOut.println("(1,1) is open: " + percolate.isOpen(1, 1));
        StdOut.println("(1,1) is full: " + percolate.isFull(1, 1));

        percolate.open(1, 1);
        StdOut.println("(1,1) is open: " + percolate.isOpen(1, 1));
        StdOut.println("(1,1) is full: " + percolate.isFull(1, 1));
    }

    private boolean isInvalid(int n) {
        return n < 1 || n > this.size;
    }

    // mapping 2D -> 1D coordinates
    private int cellIndex(int row, int col) {
        return (row - 1) * this.size + (col - 1);
    }

    // index for virtual top cell
    private int virtTopIndex() {
        return size * size;
    }

    // index for virtual bottom cell
    private int virtBottomIndex() {
        return size * size + 1;
    }
}
