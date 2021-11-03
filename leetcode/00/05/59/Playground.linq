<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

// 559. Maximum Depth of N-ary Tree
// https://leetcode.com/problems/maximum-depth-of-n-ary-tree/

/*
    Time: O()
    Space: O()
*/
public class Solution
{
    public int MaxDepth(Node root)
    {
        throw new NotImplementedException();
    }
}

[Test]
[TestCase(new object[] { 1, null, 3, 2, 4, null, 5, 6 }, 3)]
//[TestCase(new object[] { 1, null, 2, 3, 4, 5, null, null, 6, 7, null, 8, null, 9, 10, null, null, 11, null, 12, null, 13, null, null, 14 }, 5)]
[TestCase(new object[] { }, 0)]
[TestCase(new object[] { 42 }, 1)]
[TestCase(new object[] { 42, null, 1, 2, 3, 4, 5 }, 2)]
public void SolutionTests(object[] data, int expected)
{
    var root = CreateTree(data);
    var actual = new Solution().MaxDepth(root);
    Assert.That(actual, Is.EqualTo(expected));
}

public class Node
{
    public int val;
    public IList<Node> children;

    public Node() { }

    public Node(int _val)
    {
        val = _val;
    }

    public Node(int _val, IList<Node> _children)
    {
        val = _val;
        children = _children;
    }
}

#region unit-tests helpers

// https://ru.stackoverflow.com/q/1247517/213987
// algo is a) too ugly and verbose b) does'nt handle testcase when node = 11
private Node CreateTree(object[] data)
{
    if (data == null || data.Length == 0)
        return null;

    var root = new Node(0, new List<Node> { });
    Node parent = null;
    var index = -1;

    var row = new List<Node>();

    for (int i = 0; i < data.Length; i++)
    {
        if (data[i] == null)
        {
            if (parent == null)
            {
                //root.children = row.ToList();
                parent = root;
            }
            else if (index == -1)
            {
                parent.children = row.Select(x => new Node(x.val, new List<Node> { })).ToList();
                index++;
            }
            else if (index == parent.children.Count)
            {
                index = 0;
                parent = parent.children[index];

                parent.children = row.Select(x => new Node(x.val, new List<Node> { })).ToList();
            }
            else
            {
                parent.children[index].children = row.Select(x => new Node(x.val, new List<Node> { })).ToList();
                index++;
            }
            row = new List<Node>();
            //root.Dump();
        }
        else
        {
            var cellValue = (int)data[i];
            if (parent == null)
            {
                root.val = cellValue;
            }
            else
            {
                row.Add(new Node(cellValue, new List<Node> { }));
            }
        }
    }

    if (parent == null)
    {
        root.children = row.Select(x => new Node(x.val, new List<Node> { })).ToList();
    }
    else if (index == -1)
    {
        parent.children = row.Select(x => new Node(x.val, new List<Node> { })).ToList();
        index++;
    }
    else if (index == parent.children.Count)
    {
        index = 0;
        parent = parent.children[index];

        parent.children[index].children = row.ToList();
        index++;
    }
    else
    {
        parent.children[index].children = row.ToList();
        index++;
    }

    return root;
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