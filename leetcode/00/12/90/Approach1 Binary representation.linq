<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

// 1290. Convert Binary Number in a Linked List to Integer
// https://leetcode.com/problems/convert-binary-number-in-a-linked-list-to-integer/

/*
    Time: O(N)
    Space: O(1)
*/
public class Solution
{
    public int GetDecimalValue(ListNode head)
    {
        var result = 0;
        
        if(head == null)
            return result;
        
        while(head != null)
        {
            result *= 2;
            result += head.val;
            head = head.next;
        }
        
        return result;
    }
}

/*
    Time: O(N)
    Space: O(1)
*/
public class Solution1
{
    public int GetDecimalValue(ListNode head)
    {
        int num = head.val;
        while (head.next != null)
        {
            num = num * 2 + head.next.val;
            head = head.next;
        }
        return num;
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
[TestCase(new int[] { 1, 0, 1 }, 5)]
[TestCase(new int[] { 0 }, 0)]
[TestCase(new int[] { 1 }, 1)]
[TestCase(new int[] { 1, 0, 0, 1, 0, 0, 1, 1, 1, 0, 0, 0, 0, 0, 0 }, 18880)]
[TestCase(new int[] { 0, 0 }, 0)]
public void SolutionTests(int[] values, int expectedResult)
{
    var head = ConstructLinkedList(values);

    var actual = new Solution().GetDecimalValue(head);

    Assert.That(actual, Is.EqualTo(expectedResult));
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