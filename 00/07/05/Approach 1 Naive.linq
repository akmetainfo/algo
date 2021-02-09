<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

// 705. Design HashSet
// https://leetcode.com/problems/design-hashset/

// Using space to trade O(1) time complexity
// However, this solution is not practical in real projects.
public class MyHashSet
{
    private const int CAPACITY = 1000001;
    private bool[] arr;

    public MyHashSet()
    {
        arr = new bool[CAPACITY];
    }

    // O(1)
    public void Add(int key)
    {
        if (key < 0 || key > CAPACITY)
            return;
            
        arr[key] = true;
    }

    // O(1)
    public void Remove(int key)
    {
        if (key < 0 || key > CAPACITY)
            return;
   
        arr[key] = false;
    }

    // O(1)
    public bool Contains(int key)
    {
        if (key < 0 || key > CAPACITY)
            return false;
            
        return arr[key];
    }
}

// Same approach, just less space ugins bit array
public class MyHashSet1
{
    private const int MaxValue = 1000001;
    private const int BitsPerInt = sizeof(int) * 8;
    private const int ArrayLength = ((MaxValue - 1) / BitsPerInt) + 1;

    private int[] array;

    public MyHashSet1()
    {
        array = new int[ArrayLength];
    }

    public void Add(int key)
    {
        array[key / 32] |= (1 << (key % 32));
    }

    public void Remove(int key)
    {
        array[key / 32] &= ~(1 << (key % 32));
    }

    public bool Contains(int key)
    {
        return (array[key / 32] & (1 << (key % 32))) != 0;
    }
}

// Same approach, just using 2 bool array to support both positive and negative values
public class MyHashSet2
{
    private const int CAPACITY = 1000001;
    
    private bool[] _p = new bool[CAPACITY];
    private bool[] _n = new bool[CAPACITY];

    public void Add(int key)
    {
        Set(key, true);
    }

    private void Set(int key, bool flag)
    {
        if (key < 0)
        {
            _n[Math.Abs(key)] = flag;
        }
        else
        {
            _p[key] = flag;
        }
    }

    public void Remove(int key)
    {
        Set(key, false);
    }

    public bool Contains(int key)
    {
        if (key < 0)
        {
            return _n[Math.Abs(key)];
        }
        else
        {
            return _p[key];
        }
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