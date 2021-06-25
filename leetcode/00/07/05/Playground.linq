<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

// 705. Design HashSet
// https://leetcode.com/problems/design-hashset/

public class MyHashSet
{
    /** Initialize your data structure here. */
    public MyHashSet()
    {
        throw new NotImplementedException();
    }

    public void Add(int key)
    {
        throw new NotImplementedException();
    }

    public void Remove(int key)
    {
        throw new NotImplementedException();
    }

    /** Returns true if this set contains the specified element */
    public bool Contains(int key)
    {
        throw new NotImplementedException();
    }
}

/**
 * Your MyHashSet object will be instantiated and called as such:
 * MyHashSet obj = new MyHashSet();
 * obj.Add(key);
 * obj.Remove(key);
 * bool param_3 = obj.Contains(key);
 */

[Test]
[TestCase(
    new string[] { "MyHashSet", "add", "add", "contains", "contains", "add", "contains", "remove", "contains" },
    new object[] { null, 1, 2, 1, 3, 2, 2, 2, 2 },
    new object[] { null, null, null, true, false, null, true, null, false }
)]
public void SolutionTests(string[] actionsNames, object[] actionsParams, object[] expectedOutput)
{
    AssertInputIsCorrect(actionsNames, actionsParams, expectedOutput);
    var expectedResult = ConvertResult(expectedOutput);
    bool?[] actualResult = new bool?[actionsNames.Length];
    MyHashSet testedObj = null;

    for (var i = 0; i < actionsNames.Length; i++)
    {
        switch (actionsNames[i].ToLower())
        {
            case "myhashset":
                testedObj = new MyHashSet();
                actualResult[i] = null;
                break;

            case "add":
                if (testedObj == null)
                    throw new Exception("where is init?");
                testedObj.Add((int)actionsParams[i]);
                break;

            case "contains":
                if (testedObj == null)
                    throw new Exception("where is init?");
                actualResult[i] = testedObj.Contains((int)actionsParams[i]);
                break;

            case "remove":
                if (testedObj == null)
                    throw new Exception("where is init?");
                testedObj.Remove((int)actionsParams[i]);
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

private bool?[] ConvertResult(object[] expectedOutput)
{
    var result = new bool?[expectedOutput.Length];

    for (var i = 0; i < expectedOutput.Length; i++)
    {
        if (expectedOutput[i] == null)
        {
            result[i] = null;
        }
        else
        {
            result[i] = (bool)expectedOutput[i];
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