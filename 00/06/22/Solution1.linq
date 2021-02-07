<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

// 622. Design Circular Queue
// https://leetcode.com/problems/design-circular-queue/

public class MyCircularQueue
{
    private int[] data;
    private int head;
    private int tail;
    private int size;

    public MyCircularQueue(int k)
    {
        data = new int[k];
        head = -1;
        tail = -1;
        size = k;
    }

    public bool EnQueue(int value)
    {
        if (IsFull())
            return false;

        if (IsEmpty())
        {
            head = 0;
        }

        tail = (tail + 1) % size;
        data[tail] = value;
        return true;
    }

    public bool DeQueue()
    {
        if (IsEmpty())
            return false;

        if (head == tail)
        {
            head = -1;
            tail = -1;
            return true;
        }
        
        head = (head + 1) % size;
        return true;
    }

    public int Front()
    {
        if (IsEmpty())
            return -1;

        return data[head];
    }

    public int Rear()
    {
        if (IsEmpty())
            return -1;

        return data[tail];
    }

    public bool IsEmpty()
    {
        return head == -1;
    }

    public bool IsFull()
    {
        return ((tail + 1) % size) == head;
    }
}

/**
 * Your MyCircularQueue object will be instantiated and called as such:
 * MyCircularQueue obj = new MyCircularQueue(k);
 * bool param_1 = obj.EnQueue(value);
 * bool param_2 = obj.DeQueue();
 * int param_3 = obj.Front();
 * int param_4 = obj.Rear();
 * bool param_5 = obj.IsEmpty();
 * bool param_6 = obj.IsFull();
 */

[Test]
[TestCase(
    new string[] { "MyCircularQueue", "enQueue", "enQueue", "enQueue", "enQueue", "Rear", "isFull", "deQueue", "enQueue", "Rear" },
    new object[] { 3, 1, 2, 3, 4, null, null, null, 4, null },
    new object[] { null, true, true, true, false, 3, true, true, true, 4 }
)]
[TestCase(
    new string[] { "MyCircularQueue", "enQueue", "Rear", "Rear", "deQueue", "enQueue", "Rear", "deQueue", "Front", "deQueue", "deQueue", "deQueue" },
    new object[] { 6, 6, null, null, null, 5, null, null, null, null, null, null },
    new object[] { null, true, 6, 6, true, true, 5, true, -1, false, false, false }
)]
public void SolutionTests(string[] actionsNames, object[] actionsParams, object[] expectedOutput)
{
    AssertInputIsCorrect(actionsNames, actionsParams, expectedOutput);
    var expectedResult = ConvertResult(actionsNames, expectedOutput);
    object[] actualResult = new object[actionsNames.Length];
    MyCircularQueue testedObj = null;

    for (var i = 0; i < actionsNames.Length; i++)
    {
        switch (actionsNames[i].ToLower())
        {
            case "mycircularqueue":
                testedObj = new MyCircularQueue((int)actionsParams[i]);
                actualResult[i] = null;
                break;

            case "front":
                if (testedObj == null)
                    throw new Exception("where is init?");
                actualResult[i] = testedObj.Front();
                break;

            case "rear":
                if (testedObj == null)
                    throw new Exception("where is init?");
                actualResult[i] = testedObj.Rear();
                break;

            case "enqueue":
                if (testedObj == null)
                    throw new Exception("where is init?");
                var aaaa = (int)actionsParams[i];
                actualResult[i] = testedObj.EnQueue(aaaa);
                break;

            case "dequeue":
                if (testedObj == null)
                    throw new Exception("where is init?");
                actualResult[i] = testedObj.DeQueue();
                break;

            case "isempty":
                if (testedObj == null)
                    throw new Exception("where is init?");
                actualResult[i] = testedObj.IsEmpty();
                break;

            case "isfull":
                if (testedObj == null)
                    throw new Exception("where is init?");
                actualResult[i] = testedObj.IsFull();
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

private object[] ConvertResult(string[] actionsNames, object[] expectedOutput)
{
    var result = new object[expectedOutput.Length];

    for (var i = 0; i < expectedOutput.Length; i++)
    {
        if (expectedOutput[i] == null)
        {
            result[i] = null;
        }
        else
        {
            var command = actionsNames[i];
            var commandType = GetTypeForCommand(command);
            switch (commandType.ToString())
            {
                case "object":
                    result[i] = (object)expectedOutput[i];
                    break;

                case "System.Boolean":
                    result[i] = (bool)expectedOutput[i];
                    break;

                case "System.Int32":
                    result[i] = (int)expectedOutput[i];
                    break;

                default:
                    throw new ArgumentOutOfRangeException($"unknown command: {commandType}");
            }
        }
    }

    return result;
}

private Type GetTypeForCommand(string command)
{
    switch (command.ToLower())
    {
        case "mycircularqueue":
            return typeof(object);

        case "front":
        case "rear":
            return typeof(int);

        case "enqueue":
        case "dequeue":
        case "isempty":
        case "isfull":
            return typeof(bool);

        default:
            throw new ArgumentOutOfRangeException($"unknown command: {command}");
    }
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