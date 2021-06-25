<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

// 141. Linked List Cycle
// https://leetcode.com/problems/linked-list-cycle/

/*
    Time: O()
    Space: O()
*/
public class Solution
{
    public bool HasCycle(ListNode head)
    {
        throw new NotImplementedException();
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
[TestCase(new int[] { 3, 2, 0, -4 }, 1, true)]
[TestCase(new int[] { 3, 2, 0, -4 }, -1, false)]
[TestCase(new int[] { 1, 2 }, 0, true)]
[TestCase(new int[] { 1 }, -1, false)]
public void SinglyListNodeTests(int[] values, int pos, bool expectedResult)
{
    var head = ConstructCycledLinkedList(values, pos);

    var actual = new Solution().HasCycle(head);

    Assert.That(actual, Is.EqualTo(expectedResult));
}

#region unit-tests helpers

private ListNode ConstructCycledLinkedList(int[] values, int pos)
{
    ListNode head = null;
    ListNode tail = null;
    ListNode target = null;

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
        if (i == pos)
        {
            target = current;
        }
    }

    if (pos != -1)
    {
        tail.next = target;
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