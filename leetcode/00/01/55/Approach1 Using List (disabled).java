// 155. Min Stack
// https://leetcode.com/problems/min-stack/

public class MinStack {

    public final List<Integer> _data;

    public MinStack() {
        this._data = new ArrayList<Integer>();
    }

    public void push(int val) {
        this._data.add(val);
    }

    public void pop() {
        this._data.remove(this._data.size() - 1);
    }

    public int top() {
        return this._data.get(this._data.size() - 1);
    }

    // O(n) instead of O(1), so this solution based on List<int> is disabled!
    public int getMin() {
        return Collections.min(this._data);
    }
}
