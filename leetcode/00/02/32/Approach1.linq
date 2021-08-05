<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

// 232. Implement Queue using Stacks
// https://leetcode.com/problems/implement-queue-using-stacks/

public class MyQueue
{
    private int front;
    private Stack<int> s1;
    private Stack<int> s2;
    
    /*
        Time: O(1)
        Space: O(1)
    */
    /** Initialize your data structure here. */
    public MyQueue()
    {
        s1 = new Stack<int>();
        s2 = new Stack<int>();
    }
    
    /*
        Time: O(N)
        Space: O(N)
    */
    /** Push element x to the back of queue. */
    public void Push(int x)
    {
        if (s1.Count == 0)
            front = x;
            
        while (s1.Count != 0)
            s2.Push(s1.Pop());
            
        s2.Push(x);
        
        while (s2.Count != 0)
            s1.Push(s2.Pop());
    }
        
    /*
        Time: O(1)
        Space: O(1)
    */
    /** Removes the element from in front of queue and returns that element. */
    public int Pop()
    {
        var result = s1.Pop();
        
        if (s1.Count != 0)
            front = s1.Peek();
            
        return result;
    }
    
    /*
        Time: O(1)
        Space: O(1)
    */
    /** Get the front element. */
    public int Peek()
    {
        return front;
    }
    
    /*
        Time: O(1)
        Space: O(1)
    */
    /** Returns whether the queue is empty. */
    public bool Empty()
    {
        return s1.Count == 0;
    }
}

/**
 * Your MyQueue object will be instantiated and called as such:
 * MyQueue obj = new MyQueue();
 * obj.Push(x);
 * int param_2 = obj.Pop();
 * int param_3 = obj.Peek();
 * bool param_4 = obj.Empty();
 */

[Test]
[TestCase(
    new string[] { "MyQueue", "push", "push", "peek", "pop", "empty" },
    new object[] { new int[0], new[]{1}, new[] {2}, new int[0], new int[0], new int[0] },
    new object[] { null, null, null, 1, 1, false }
)]
public void SolutionTests(string[] actionsNames, object[] actionsParams, object[] expectedResult)
{
    AssertInputIsCorrect(actionsNames, actionsParams, expectedResult);
    object[] actualResult = new object[actionsNames.Length];
    MyQueue testedObj = null;

    for (var i = 0; i < actionsNames.Length; i++)
    {
        switch (actionsNames[i].ToLower())
        {
            case "myqueue":
                testedObj = new MyQueue();
                actualResult[i] = null;
                break;

            case "push":
                if (testedObj == null)
                    throw new Exception("where is init?");
                var parameters = (int[])actionsParams[i];
                testedObj.Push(parameters[0]);
                actualResult[i] = null;
                break;

            case "pop":
                if (testedObj == null)
                    throw new Exception("where is init?");
                actualResult[i] = testedObj.Pop();
                break;

            case "peek":
                if (testedObj == null)
                    throw new Exception("where is init?");
                actualResult[i] = testedObj.Peek();
                break;

            case "empty":
                if (testedObj == null)
                    throw new Exception("where is init?");
                actualResult[i] = testedObj.Empty();
                break;

            default:
                throw new ArgumentOutOfRangeException($"unknown command: {actionsNames[i]}");
        }
    }

    Assert.That(actualResult, Is.EqualTo(expectedResult));
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