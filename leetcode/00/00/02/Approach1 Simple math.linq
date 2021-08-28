<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

// 2. Add Two Numbers
// https://leetcode.com/problems/add-two-numbers/

/*
    Time: O(N) where N = max(l1.length, l2.length)
    Space: O(1) The length of the new list is at most max⁡(l1.length, l2.length) + 1.
*/
public class Solution
{
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
    {
        var head = new ListNode(0);
        var tail = head;
        
        if(l1 == null && l2 == null)
            return head;
            
        var carry = 0;
        
        while(l1 != null || l2 != null || carry != 0)
        {
            var v1 = l1 == null ? 0 : l1.val;
            var v2 = l2 == null ? 0 : l2.val;
            var sum = v1 + v2 + carry;
            var digit = sum % 10;
            carry = sum / 10;
            
            var newNode = new ListNode(digit);
            
            tail.next = newNode;
            tail = tail.next;
            
            if(l1 != null)
                l1 = l1.next;
                
            if(l2 != null)
                l2 = l2.next;
        }
            
        return head.next;
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
[TestCase(new int[] { 2,4,3 }, new int[] { 5,6,4 }, new int[] { 7,0,8 })]
[TestCase(new int[] { 0 }, new int[] { 0 }, new int[] { 0 })]
[TestCase(new int[] { 9,9,9,9,9,9,9 }, new int[] { 9,9,9,9 }, new int[] { 8,9,9,9,0,0,0,1 })]
public void SinglyListNodeTests(int[] arr1, int[] arr2, int[] expectedResult)
{
    var actual = new Solution().AddTwoNumbers(ConstructLinkedList(arr1), ConstructLinkedList(arr2));
    
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