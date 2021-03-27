<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

// 203. Remove Linked List Elements
// https://leetcode.com/problems/remove-linked-list-elements/

public class Solution
{
    public ListNode RemoveElements(ListNode head, int val)
    {
        var current = head;

        while (current != null)
        {
            if (head == current && current.val == val)
            {
                head = current.next;
                current = head;
            }
            else if (current.next != null && current.next.val == val)
            {
                current.next = current.next.next;
            }
            else
            {
                current = current.next;
            }
        }

        return head;
    }
}

public class ListNode
{
    public int val;
    public ListNode next;
    public ListNode(int x)
    {
        val = x;
        next = null;
    }
}

[Test]
[TestCase(new int[] { 1, 2, 6, 3, 4, 5, 6, 7 }, 6, new int[] { 1, 2, 3, 4, 5, 7 })]
[TestCase(new int[] { 6 }, 6, new int[] { })]
[TestCase(new int[] { 6, 6 }, 6, new int[] { })]
[TestCase(new int[] { 6, 6, 6 }, 6, new int[] { })]
[TestCase(new int[] { 6, 6, 6, 1, 2, 3 }, 6, new int[] { 1, 2, 3 })]
[TestCase(new int[] { 1, 2 }, 2, new int[] { 1 })]
public void SolutionTests(int[] values, int val, int[] expectedResult)
{
    var head = ConstructLinkedList(values);

    var actual = new Solution().RemoveElements(head, val);

    var actualResult = ToArray(actual);

    Assert.That(expectedResult, Is.EqualTo(actualResult));
}

#region unit-tests helpers

private ListNode ConstructLinkedList(int[] values)
{
    ListNode head = null;
    ListNode tail = null;

    for (int i = 0; i < values.Length; i++)
    {
        ListNode current = new ListNode(values[i]);
        if (head == null)
        {
            head = current;
            tail = current;
        }
        else
        {
            tail.next = current;
            tail = current;
        }
    }

    return head;
}

private int[] ToArray(ListNode head)
{
    var result = new List<int>();
    var tmp = head;
    while (tmp != null)
    {
        result.Add(tmp.val);
        tmp = tmp.next;
    }
    return result.ToArray();
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