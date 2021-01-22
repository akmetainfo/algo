<Query Kind="Program" />

void Main()
{
	var stack = new MinStack();
	stack.Push(42);
	stack._data.Dump();
	stack.Pop();
	stack._data.Dump();
}

// Define other methods and classes here
public class MinStack
{
	public readonly IList<int> _data;

	/** initialize your data structure here. */
	public MinStack()
	{
		this._data = new List<int>();
	}

	public void Push(int x)
	{
		this._data.Add(x);
	}

	public void Pop()
	{
		this._data.RemoveAt(this._data.Count - 1);
	}

	public int Top()
	{
		return this._data[this._data.Count - 1];
	}

	public int GetMin()
	{
		var min = this._data[0];
		foreach (var element in this._data)
		{
			if (element < min)
			{
				min = element;
			}
		}

		return min;
	}
}

/**
 * Your MinStack object will be instantiated and called as such:
 * MinStack obj = new MinStack();
 * obj.Push(x);
 * obj.Pop();
 * int param_3 = obj.Top();
 * int param_4 = obj.GetMin();
 */
