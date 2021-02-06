<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

// 155. Min Stack
// https://leetcode.com/problems/min-stack/

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

    // O(n) instead of O(1), so this solution based on List<int> is disabled!
    public int GetMin()
    {
        return _data.Min();
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

[Test]
[TestCase(
    new string[] { "MinStack", "push", "push", "push", "getMin", "pop", "top", "getMin" },
    new object[] { null, -2, 0, -3, null, null, null, null },
    new object[] { null,null,null,null,-3,null,0,-2 }
)]
public void SolutionTests(string[] actionsNames, object[] actionsParams, object[] expectedOutput)
{
    AssertInputIsCorrect(actionsNames, actionsParams, expectedOutput);
    var expectedResult = ConvertResult(expectedOutput);
    int?[] actualResult = new int?[actionsNames.Length];
    MinStack testedObj = null;

    for (var i = 0; i < actionsNames.Length; i++)
    {
        switch (actionsNames[i].ToLower())
        {
            case "minstack":
                testedObj = new MinStack();
                actualResult[i] = null;
                break;

            case "push":
                if (testedObj == null)
                    throw new Exception("where is init?");
                testedObj.Push((int)actionsParams[i]);
                break;

            case "pop":
                if (testedObj == null)
                    throw new Exception("where is init?");
                testedObj.Pop();
                break;

            case "top":
                if (testedObj == null)
                    throw new Exception("where is init?");
                actualResult[i] = testedObj.Top();
                break;

            case "getmin":
                if (testedObj == null)
                    throw new Exception("where is init?");
                actualResult[i] = testedObj.GetMin();
                break;

            default:
                throw new ArgumentOutOfRangeException($"unknown command: {actionsNames[i]}");
        }
    }

    Assert.That(expectedResult, Is.EqualTo(actualResult));
}

#region unit-tests helpers

private void AssertInputIsCorrect(string[] actionsNames, object[] actionsParams, object[] expectedOutput)
{
    if (actionsNames.Length != actionsParams.Length || actionsNames.Length != expectedOutput.Length)
        throw new ArgumentException($"actionsNames.Length={actionsNames.Length}, actionsParams.Length={actionsParams.Length}, expectedOutput.Length={expectedOutput.Length}.");
}

private int?[] ConvertResult(object[] expectedOutput)
{
    var result = new int?[expectedOutput.Length];

    for (var i = 0; i < expectedOutput.Length; i++)
    {
        if (expectedOutput[i] == null)
        {
            result[i] = null;
        }
        else
        {
            result[i] = (int)expectedOutput[i];
        }
    }

    return result;
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