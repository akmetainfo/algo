<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

// 206. Reverse Linked List
// https://leetcode.com/problems/reverse-linked-list/

/*
    Time: O(n) Assume that n is the list's length, the time complexity is O(n).
    Space: O(1)
*/
public class Solution
{
    public ListNode ReverseList(ListNode head)
    {
        ListNode prev = null;
        var curr = head;
        while (curr != null)
        {
            var nextTemp = curr.next;
            curr.next = prev;
            prev = curr;
            curr = nextTemp;
        }
        return prev;
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
[TestCase(new int[] { }, new int[] { })]
[TestCase(new int[] { 42 }, new int[] { 42 })]
[TestCase(new int[] { 1, 2 }, new int[] { 2, 1 })]
[TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { 5, 4, 3, 2, 1 })]
public void SolutionTests(int[] values, int[] expectedResult)
{
    var head = ConstructLinkedList(values);

    var actual = new Solution().ReverseList(head);

    var actualResult = ToArray(actual);

    Assert.That(actualResult, Is.EqualTo(expectedResult));
}

#region unit-tests helpers

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