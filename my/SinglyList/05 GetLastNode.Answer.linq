<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

// get last node value (if -1 if linked list is empty)

/*
    Time: O(N)
    Space: O(N)
*/
public class Solution
{
    public int GetLastNodeVal(SinglyListNode head)
    {
        if(head == null)
            return -1;

        while (head.Next != null)
            head = head.Next;

        return head.Data;
    }
}

public SinglyListNode ToSinglyList(int[] arr)
{
    if (arr == null || arr.Length == 0)
        return null;

    var node = new SinglyListNode(arr[0]);
    var head = node;

    for (int i = 1; i < arr.Length; i++)
    {
        var next = new SinglyListNode(arr[i]);
        node.Next = next;
        node = next;
    }
    return head;
}

public int[] FromSinglyList(SinglyListNode head)
{
    var result = new List<int>();

    while (head != null)
    {
        result.Add(head.Data);

        head = head.Next;
    }

    return result.ToArray();
}

public class SinglyListNode
{
    public SinglyListNode(int data)
    {
        Data = data;
    }
    public int Data { get; set; }
    public SinglyListNode Next { get; set; }
}

[Test]
[TestCase(new int[] { }, -1)]
[TestCase(new int[] { 42 }, 42)]
[TestCase(new int[] { 5, 6 }, 6)]
[TestCase(new int[] { 5, 6, 7 }, 7)]
public void SolutionTests(int[] nums, int expected)
{
    var head = ToSinglyList(nums);
    var actual = new Solution().GetLastNodeVal(head);
    Assert.That(actual, Is.EqualTo(expected));
}

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