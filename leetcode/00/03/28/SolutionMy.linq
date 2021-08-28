<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

// 328. Odd Even Linked List
// https://leetcode.com/problems/odd-even-linked-list/

/*
    Time: O(N)
    Space: O(1)
*/
public class Solution
{
    public ListNode OddEvenList(ListNode head)
    {
        if (head == null || head.next == null)
            return head;
        
        var oddHead = head;
        var oddTail = oddHead;
        var evenHead = head.next;
        var evenTail = evenHead;
        
        while (evenTail != null && evenTail.next != null)
        {
            oddTail.next = evenTail.next;
            oddTail = oddTail.next;
            evenTail.next = oddTail.next;
            evenTail = evenTail.next;
        }
        
        oddTail.next = evenHead;
        return oddHead;
    }
}

/*
    Time: O(N)
    Space: O(1)
*/
public class Solution4
{
    public ListNode OddEvenList(ListNode head)
    {
        if (head == null || head.next == null)
            return head;
        
        var oddHead = head;
        var oddTail = oddHead;
        
        var evenHead = head.next;
        var evenTail = evenHead;
        
        var odd = true;
        while(head != null)
        {
            var next = head.next;
            head.next = null;
            if(odd)
            {
                oddTail.next = head;
                oddTail = oddTail.next;
            }
            else
            {
                evenTail.next = head;
                evenTail = evenTail.next;
            }

            odd = !odd;
            head = next;
        }
        
        oddTail.next = evenHead;
        
        return oddHead;        
    }
}

/*
    Time: O(N)
    Space: O(1)
*/
public class Solution3
{
    public ListNode OddEvenList(ListNode head)
    {
        var oddHead = new ListNode(42);
        var oddTail = oddHead;
        
        var evenHead = new ListNode(42);
        var evenTail = evenHead;
        
        var odd = true;
        while(head != null)
        {
            var next = head.next;
            head.next = null;
            if(odd)
            {
                oddTail.next = head;
                oddTail = oddTail.next;
            }
            else
            {
                evenTail.next = head;
                evenTail = evenTail.next;
            }

            odd = !odd;
            head = next;
        }
        
        evenHead = evenHead.next;
        oddTail.next = evenHead;
        
        return oddHead.next;        
    }
}

/*
    Time: O(N)
    Space: O(N)
*/
public class Solution2
{
    public ListNode OddEvenList(ListNode head)
    {
        var oddHead = new ListNode(42);
        var oddTail = oddHead;
        
        var evenHead = new ListNode(42);
        var evenTail = evenHead;
        
        var odd = true;
        while(head != null)
        {
            if(odd)
            {
                oddTail.next = new ListNode(head.val);
                oddTail = oddTail.next;
            }
            else
            {
                evenTail.next = new ListNode(head.val);
                evenTail = evenTail.next;
            }

            odd = !odd;
            head = head.next;
        }
        
        evenHead = evenHead.next;
        oddTail.next = evenHead;
        
        return oddHead.next;
    }
}

/*
    Time: O(N)
    Space: O(N)
*/
public class Solution1
{
    public ListNode OddEvenList(ListNode head)
    {
        var newHead = new ListNode(42);
        var tail = newHead;
        
        var node = head;
        var odd = true;
        while(node != null)
        {
            if(odd)
            {
                tail.next = new ListNode(node.val);
                tail = tail.next;
            }

            odd = !odd;
            node = node.next;
        }
        
        node = head;
        var even = false;
        while(node != null)
        {
            if(even)
            {
                tail.next = new ListNode(node.val);
                tail = tail.next;
            }

            even = !even;
            node = node.next;
        }
        
        
        return newHead.next;
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
[TestCase(new int[] { 1,2,3,4,5 }, new int[] { 1,3,5,2,4 })]
[TestCase(new int[] { 2,1,3,5,6,4,7 }, new int[] { 2,3,6,7,1,5,4 })]
public void SinglyListNodeTests(int[] arr, int[] expectedResult)
{
    var actual = new Solution().OddEvenList(ConstructLinkedList(arr));
    
    var actualResult = ToArray(actual);

    Assert.That(actualResult, Is.EqualTo(expectedResult));
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