<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

// 116. Populating Next Right Pointers in Each Node
// https://leetcode.com/problems/populating-next-right-pointers-in-each-node/

/*
    Time: O(N)
    Space: O(N)
*/
public class Solution
{
    public Node Connect(Node root)
    {
        if (root == null)
            return root;

        var result = root;
        var queue = new Queue<Node>();
        queue.Enqueue(root);
        while (queue.Count != 0)
        {
            var size = queue.Count;
            Node prev = null;
            for (int i = 0; i < size; i++)
            {
                root = queue.Dequeue();

                if (i > 0)
                    prev.next = root;

                prev = root;

                if (root.left != null)
                    queue.Enqueue(root.left);

                if (root.right != null)
                    queue.Enqueue(root.right);
            }
        }
        return result;
    }
}

/*
    Time: O(N)
    Space: O(N)
*/
public class Solution2
{
    // Approach3 BFS
    public Node Connect(Node root)
    {
        if (root == null)
            return null;

        var queue = new Queue<Node>();
        queue.Enqueue(root);
        var result = root;
        while (queue.Count != 0)
        {
            Node dummy = null;

            var size = queue.Count;
            for (int i = 0; i < size; i++)
            {
                root = queue.Dequeue();

                if (i == 0)
                {
                    dummy = root;
                }
                else
                {
                    dummy.next = root;
                    dummy = dummy.next;
                }


                if (root.left != null)
                    queue.Enqueue(root.left);

                if (root.right != null)
                    queue.Enqueue(root.right);
            }
        }
        return result;
    }
}

/*
    Time: O(N)
    Space: O(N)
*/
public class Solution1
{
    public Node Connect(Node root)
    {
        if (root == null)
            return root;

        var result = root;
        var queue = new Queue<Node>();
        queue.Enqueue(root);
        while (queue.Count != 0)
        {
            var size = queue.Count;
            var dummy = new Node();
            for (int i = 0; i < size; i++)
            {
                root = queue.Dequeue();
                dummy.next = root;
                dummy = dummy.next;

                if (root.left != null)
                    queue.Enqueue(root.left);

                if (root.right != null)
                    queue.Enqueue(root.right);
            }
        }
        return result;
    }
}


[Test]
[TestCase(new object[] { 1, 2, 3, 4, 5, 6, 7 }, new object[] { 1, null, 2, 3, null, 4, 5, 6, 7, null })]
[TestCase(new object[] { }, new object[] { })]
public void SolutionTests(object[] data, object[] expected)
{
    var root = CreateTree(data);
    var newRoot = new Solution().Connect(root);
    int?[] actual = Travers(newRoot);
    int?[] expectedInt = Align(expected);
    Assert.That(actual, Is.EqualTo(expectedInt));
}

public class Node
{
    public int val;
    public Node left;
    public Node right;
    public Node next;

    public Node() { }

    public Node(int _val)
    {
        val = _val;
    }

    public Node(int _val, Node _left, Node _right, Node _next)
    {
        val = _val;
        left = _left;
        right = _right;
        next = _next;
    }
}

#region unit-tests helpers

// https://ru.stackoverflow.com/q/1247517/213987
private Node CreateTree(object[] data)
{
    if (data == null || data.Length == 0)
        return null;

    Node[] nodes = data.Select(x => x == null ? null : new Node((int)x, null, null, null)).ToArray();

    int current = 0;
    bool left = true;

    for (int i = 1; i < nodes.Length; i++)
    {
        if (left)
        {
            nodes[current].left = nodes[i];
            left = false;
        }
        else
        {
            nodes[current].right = nodes[i];
            left = true;

            current++;
            while (current < nodes.Length && nodes[current] == null)
                current++;
        }
    }

    return nodes[0];
}

private int?[] Travers(Node root)
{
    var result = new List<int?>();

    if (root == null)
        return result.ToArray();

    var queue = new Queue<Node>();
    queue.Enqueue(root);
    while (queue.Count != 0)
    {
        var size = queue.Count;
        var dummy = new Node();
        for (int i = 0; i < size; i++)
        {
            root = queue.Dequeue();

            result.Add(root.val);

            if (root.left != null)
                queue.Enqueue(root.left);

            if (root.right != null)
                queue.Enqueue(root.right);
        }
        result.Add(null);
    }

    return result.ToArray();
}

private int?[] Align(object[] expected)
{
    return expected.Select(x => (int?)x).ToArray();
}

#endregion

#region unit tests runner

void Main()
{
    var workDir = Path.Combine(Util.MyQueriesFolder, "nunit-work");

    var args = new string[]
    {
         "-noheader",
         $"--work={workDir}",
    };

    RunUnitTests(args);
}

void RunUnitTests(string[] args, Assembly assembly = null)
{
    Console.SetOut(new NoDisposeTextWriter(Console.Out));
    Console.SetError(new NoDisposeTextWriter(Console.Error));
    new AutoRun(assembly ?? Assembly.GetExecutingAssembly()).Execute(args);
}

// https://stackoverflow.com/q/52883672/5752652
class NoDisposeTextWriter : TextWriter
{
    private readonly TextWriter writer;
    public NoDisposeTextWriter(TextWriter writer) => this.writer = writer;

    public override Encoding Encoding => writer.Encoding;
    public override IFormatProvider FormatProvider => writer.FormatProvider;
    public override void Write(char value) => writer.Write(value);
    public override void Flush() => writer.Flush();
    // forward all other overrides as necessary

    protected override void Dispose(bool disposing)
    {
        // no nothing
    }
}

#endregion