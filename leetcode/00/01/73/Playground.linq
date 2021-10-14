<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

// 173. Binary Search Tree Iterator
// https://leetcode.com/problems/binary-search-tree-iterator/

public class BSTIterator
{
    /*
        Time: O()
        Space: O()
    */
    public BSTIterator(TreeNode root)
    {
        throw new NotImplementedException();
    }

    /*
        Time: O()
        Space: O()
    */
    public int Next()
    {
        throw new NotImplementedException();
    }

    /*
        Time: O()
        Space: O()
    */
    public bool HasNext()
    {
        throw new NotImplementedException();
    }
}

[Test]
[TestCase(
    new string[] { "BSTIterator", "next", "next", "hasNext", "next", "hasNext", "next", "hasNext", "next", "hasNext" },
    new object[] { new object[] { 7, 3, 15, null, null, 9, 20 }, new object[] { }, new object[] { }, new object[] { }, new object[] { }, new object[] { }, new object[] { }, new object[] { }, new object[] { }, new object[] { }, },
    new object[] { null, 3, 7, true, 9, true, 15, true, 20, false }
)]
public void SolutionTests(string[] actionsNames, object[] actionsParams, object[] expectedOutput)
{
    AssertInputIsCorrect(actionsNames, actionsParams, expectedOutput);
    var expectedResult = expectedOutput;
    object[] actualResult = new object[actionsNames.Length];
    BSTIterator testedObj = null;

    for (var i = 0; i < actionsNames.Length; i++)
    {
        switch (actionsNames[i].ToLower())
        {
            case "bstiterator":
                var data = (object[])actionsParams[i];
                var tree = CreateTree(data);
                testedObj = new BSTIterator(tree);
                actualResult[i] = null;
                break;

            case "next":
                if (testedObj == null)
                    throw new Exception("where is init?");
                actualResult[i] = testedObj.Next();
                break;

            case "hasnext":
                if (testedObj == null)
                    throw new Exception("where is init?");
                actualResult[i] = testedObj.HasNext();
                break;

            default:
                throw new ArgumentOutOfRangeException($"unknown command: {actionsNames[i]}");
        }
    }

    Assert.That(expectedResult, Is.EqualTo(actualResult));
}

public class TreeNode
{
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
    {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}

#region unit-tests helpers

private void AssertInputIsCorrect(string[] actionsNames, object[] actionsParams, object[] expectedOutput)
{
    if (actionsNames.Length != actionsParams.Length || actionsNames.Length != expectedOutput.Length)
        throw new ArgumentException($"actionsNames.Length={actionsNames.Length}, actionsParams.Length={actionsParams.Length}, expectedOutput.Length={expectedOutput.Length}.");
}

private TreeNode CreateTree(object[] data)
{
    if (data == null || data.Length == 0)
        return null;

    TreeNode[] nodes = data.Select(x => x == null ? null : new TreeNode((int)x, null, null)).ToArray();

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