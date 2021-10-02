/* *****************************************************************************
 *  Name:              Ada Lovelace
 *  Coursera User ID:  123456
 *  Last modified:     October 16, 1842
 **************************************************************************** */

import edu.princeton.cs.algs4.StdRandom;
import edu.princeton.cs.algs4.StdStats;

public class PercolationStats {
    private static final double CONFID = 1.96;
    private final double[] tests;

    // perform independent trials on an n-by-n grid
    public PercolationStats(int n, int trials) {
        if (n <= 0)
            throw new IllegalArgumentException("n must be greater zero");

        if (trials <= 0)
            throw new IllegalArgumentException("trials must be greater zero");

        tests = new double[trials];
        for (int i = 0; i < trials; i++) {
            Percolation percolate = new Percolation(n);

            while (!percolate.percolates()) {
                int row = StdRandom.uniform(n) + 1;
                int col = StdRandom.uniform(n) + 1;
                percolate.open(row, col);
            }

            tests[i] = (percolate.numberOfOpenSites() / (double) (n * n));
        }
    }

    // sample mean of percolation threshold
    public double mean() {
        return StdStats.mean(tests);
    }

    // sample standard deviation of percolation threshold
    public double stddev() {
        return StdStats.stddev(tests);
    }

    // low endpoint of 95% confidence interval
    public double confidenceLo() {
        return (mean() - (CONFID * stddev()) / Math.sqrt(tests.length));
    }

    // high endpoint of 95% confidence interval
    public double confidenceHi() {
        return (mean() + (CONFID * stddev()) / Math.sqrt(tests.length));
    }

    // test client (see below)
    public static void main(String[] args) {
        int n = Integer.parseInt(args[0]);
        int trials = Integer.parseInt(args[1]);
        PercolationStats ps = new PercolationStats(n, trials);

        ps.showStat();
    }

    private void showStat() {
        System.out.println("mean                    = " + mean());
        System.out.println("stddev                  = " + stddev());
        System.out.println("95% confidence interval = [" + confidenceLo()
                                   + ", " + confidenceHi() + "]");
    }
}
