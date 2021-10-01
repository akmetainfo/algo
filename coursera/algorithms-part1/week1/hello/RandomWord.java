/* *****************************************************************************
 *  Name:              Ada Lovelace
 *  Coursera User ID:  123456
 *  Last modified:     October 16, 1842
 **************************************************************************** */

import edu.princeton.cs.algs4.StdIn;
import edu.princeton.cs.algs4.StdOut;
import edu.princeton.cs.algs4.StdRandom;

public class RandomWord {
    public static void main(String[] args) {
        if (StdIn.isEmpty())
            return;

        int i = 0;
        String result = "";
        while (!StdIn.isEmpty()) {
            i++;
            String possibleChampion = StdIn.readString();
            double p = (double) 1 / i;
            boolean isWinned = StdRandom.bernoulli(p);
            if (isWinned)
                result = possibleChampion;
        }
        StdOut.println(result);
    }
}
