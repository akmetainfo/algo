<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

// 146. LRU Cache
// https://leetcode.com/problems/lru-cache/

/*
    Time: O()
    Space: O()
*/
public class LRUCache1
{
    public LRUCache1(int capacity)
    {
        throw new NotImplementedException();
    }

    public int Get(int key)
    {
        throw new NotImplementedException();
    }

    public void Put(int key, int value)
    {
        throw new NotImplementedException();
    }
}

public class LRUCache
{
    private int _capacity;
    private Dictionary<int, (int?, int)> _data;
    private int _least;

    public LRUCache(int capacity)
    {
        _capacity = capacity;
        _data = new Dictionary<int, (int?, int)>(capacity);
    }

    public int Get(int key)
    {
        if(!_data.ContainsKey(key))
            return -1;
            
        return _data[key].Item1 == null ? -1 : (int)_data[key].Item1;
    }

    public void Put(int key, int value)
    {
        if (_data.Count != _capacity)
        {
            if(!_data.ContainsKey(key))
                _data.Add(key, );
            
            
        }
        else
        {
            return -1;
        }
    }
}

public class LRUCache2
{
    private int _capacity;
    private int?[] _data;

    public LRUCache2(int capacity)
    {
        _capacity = capacity;
        _data = new int?[capacity+1];
    }

    public int Get(int key)
    {
        if (key < 0 || key > _capacity)
            return -1;

        return _data[key] == null ? -1 : (int)_data[key];
    }

    public void Put(int key, int value)
    {
        if (key < 0)
            return;
            
        if (key > _capacity)
        {
            _data[_capacity] = value;
        }
        else
        {
            _data[key] = value;
        }
    }
}


[Test]
[TestCase(
    new string[] { "LRUCache", "put", "put", "get", "put", "get", "put", "get", "get", "get" },
    new object[] { new int[] { 2 }, new int[] { 1, 1 }, new int[] { 2, 2 }, new int[] { 1 }, new int[] { 3, 3 }, new int[] { 2 }, new int[] { 4, 4 }, new int[] { 1 }, new int[] { 3 }, new int[] { 4 } },
    new object[] { null, null, null, 1, null, -1, null, -1, 3, 4 }
)]
public void SolutionTests(string[] actionsNames, object[] actionsParams, object[] expectedOutput)
{
    AssertInputIsCorrect(actionsNames, actionsParams, expectedOutput);
    var expectedResult = ConvertResult(expectedOutput);
    int?[] actualResult = new int?[actionsNames.Length];
    LRUCache testedObj = null;

    for (var i = 0; i < actionsNames.Length; i++)
    {
        switch (actionsNames[i].ToLower())
        {
            case "lrucache":
                var p1 = (int[])actionsParams[i];
                testedObj = new LRUCache(p1[0]);
                actualResult[i] = null;
                break;

            case "get":
                if (testedObj == null)
                    throw new Exception("where is init?");
                var p2 = (int[])actionsParams[i];
                actualResult[i] = testedObj.Get(p2[0]);
                break;

            case "put":
                if (testedObj == null)
                    throw new Exception("where is init?");
                var p3 = (int[])actionsParams[i];
                testedObj.Put(p3[0], p3[1]);
                actualResult[i] = null;
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