<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

// 234. Palindrome Linked List
// https://leetcode.com/problems/palindrome-linked-list/

/*
    Time: O()
    Space: O()
*/
public class Solution
{
    public bool IsPalindrome(ListNode head)
    {
        var middle = FindMiddle(head);

        var list1 = head;
        var list2 = ReverseList(middle);

        while (list1 != middle) // or while(list2 != null)
        {
            if (list1.val != list2.val)
                return false;

            list1 = list1.next;
            list2 = list2.next;
        }

        return true;
    }

    private static ListNode FindMiddle(ListNode head)
    {
        var slow = head;
        var fast = head;

        while (fast != null && fast.next != null)
        {
            slow = slow.next;
            fast = fast.next.next;
        }

        return slow;
    }

    private static ListNode ReverseList(ListNode head)
    {
        ListNode prev = null;
        ListNode curr = head;
        while (curr != null)
        {
            var next = curr.next;

            curr.next = prev;
            prev = curr;
            curr = next;
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
[TestCase(new int[] { 1,2,3,2,1 }, true)]
[TestCase(new int[] { 1,2,2,1 }, true)]
[TestCase(new int[] { 1,2 }, false)]
[TestCase(new int[] { 0,0 }, true)]
[TestCase(new int[] { 1,1,2,1 }, false)]
public void SolutionTests(int[] values, bool expectedResult)
{
    var head = ConstructLinkedList(values);

    var actual = new Solution().IsPalindrome(head);

    Assert.That(actual, Is.EqualTo(expectedResult));
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