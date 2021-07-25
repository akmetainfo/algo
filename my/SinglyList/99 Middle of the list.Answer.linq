<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

// It's looks like 876. Middle of the Linked List
// https://leetcode.com/problems/middle-of-the-linked-list/
// but you need to find FIRST element when length is EVEN

/*
    Time: O(N), where N is length of list.
    Space: O(1)
*/
public class Solution
{
    public ListNode MiddleNode(ListNode head)
    {
        var fast = head;
        var unusedVal = 0;
        var dummyNode = new ListNode(unusedVal);
        dummyNode.next = head;
        var slow = dummyNode;
        while(fast != null && fast.next != null)
        {
            slow = slow.next;
            fast = fast.next.next;
        }
        
        return fast != null ? slow.next : slow;
    }
}

/*
    Time: O(N), where N is length of list.
    Space: O(1)
*/
public class Solution3
{
    public ListNode MiddleNode(ListNode head)
    {
        var fast = head;
        ListNode slow = null;
        while(fast != null && fast.next != null)
        {
            slow = slow == null ? head : slow.next;
            fast = fast.next.next;
        }
        
        return fast != null ? slow.next : slow;
    }
}

/*
    Time: O(N), where N is length of list.
    Space: O(1)
*/
public class Solution2
{
    public ListNode MiddleNode(ListNode head)
    {
        var slow = head;
        ListNode prevSlow = null;
        var fast = head;
        while(fast != null && fast.next != null)
        {
            prevSlow = slow;
            slow = slow.next;
            fast = fast.next.next;
        }
        
        return fast != null ? slow : prevSlow;
    }
}

/*
    Time: O(N), where N is length of list. It's TWO-PASS solution
    Space: O(1)
*/
public class Solution1
{
    public ListNode MiddleNode(ListNode head)
    {
        var counter = 0;
        var node = head;
        while(node != null)
        {
            counter++;
            node = node.next;
        }
    
        var slow = head;
        ListNode prevSlow = null;
        var fast = head;
        while(fast != null && fast.next != null)
        {
            prevSlow = slow;
            slow = slow.next;
            fast = fast.next.next;
        }
        
        return counter % 2 == 1 ? slow : prevSlow;
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
[TestCase(new int[] { 1 }, new int[] { 1 })]
[TestCase(new int[] { 1,2 }, new int[] { 1,2 })]
[TestCase(new int[] { 1,2,3 }, new int[] { 2,3 })]
[TestCase(new int[] { 1,2,3,4 }, new int[] { 2,3,4 })]
[TestCase(new int[] { 1,2,3,4,5 }, new int[] { 3,4,5 })]
[TestCase(new int[] { 1,2,3,4,5,6 }, new int[] { 3,4,5,6 })]
public void SolutionTests(int[] values, int[] expectedResult)
{
    var head = ConstructLinkedList(values);

    var actual = new Solution().MiddleNode(head);

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