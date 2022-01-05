// 155. Min Stack
// https://leetcode.com/problems/min-stack/

public class MinStack {

    private final Stack<Integer> values;
    private final Stack<Integer> min;

    public MinStack() {
        this.values = new Stack<Integer>();
        this.min = new Stack<Integer>();
    }

    public void push(int val) {
        if (values.size() == 0) {
            this.values.push(val);
            this.min.push(val);
        } else {
            this.values.push(val);
            int currMin = min.peek();
            this.min.push(Math.min(val, currMin));
        }
    }

    public void pop() {
        this.values.pop();
        this.min.pop();
    }

    public int top() {
        return this.values.peek();
    }

    public int getMin() {
        return this.min.peek();
    }
}
