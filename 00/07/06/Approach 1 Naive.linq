<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

// 706. Design HashMap
// https://leetcode.com/problems/design-hashmap/

public class MyHashMap
{
    private const int CAPACITY = 1000000;
    private int?[] hasharray;

    public MyHashMap()
    {
        hasharray = new int?[CAPACITY];
    }

    public void Put(int key, int value)
    {
        if (key < 0 || key > CAPACITY)
            throw new ArgumentOutOfRangeException("Key out of range");

        hasharray[key] = value;
    }

    public int Get(int key)
    {
        if (key < 0 || key > CAPACITY)
            throw new ArgumentOutOfRangeException("Key out of range");

        return hasharray[key] == null ? -1 : (int)hasharray[key];
    }

    public void Remove(int key)
    {
        if (key < 0 || key > CAPACITY)
            throw new ArgumentOutOfRangeException("Key out of range");

        hasharray[key] = null;
    }
}

/**
 * Your MyHashMap object will be instantiated and called as such:
 * MyHashMap obj = new MyHashMap();
 * obj.Put(key,value);
 * int param_2 = obj.Get(key);
 * obj.Remove(key);
 */

[Test]
[TestCase(
    new string[] { "MyHashMap", "put", "put", "get", "get", "put", "get", "remove", "get" },
    new object[] { null, new[] { 1, 1 }, new[] { 2, 2 }, 1, 3, new[] { 2, 1 }, 2, 2, 2 },
    new object[] { null, null, null, 1, -1, null, 1, null, -1 }
)]
public void SolutionTests(string[] actionsNames, object[] actionsParams, object[] expectedOutput)
{
    AssertInputIsCorrect(actionsNames, actionsParams, expectedOutput);
    var expectedResult = ConvertResult(expectedOutput);
    int?[] actualResult = new int?[actionsNames.Length];
    MyHashMap testedObj = null;

    for (var i = 0; i < actionsNames.Length; i++)
    {
        switch (actionsNames[i].ToLower())
        {
            case "myhashmap":
                testedObj = new MyHashMap();
                actualResult[i] = null;
                break;

            case "put":
                if (testedObj == null)
                    throw new Exception("where is init?");
                int[] parameters = (int[])actionsParams[i];
                testedObj.Put(parameters[0], parameters[1]);
                break;

            case "get":
                if (testedObj == null)
                    throw new Exception("where is init?");
                actualResult[i] = testedObj.Get((int)actionsParams[i]);
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