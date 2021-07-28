<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

// 234. Palindrome Linked List
// https://leetcode.com/problems/palindrome-linked-list/

/*
    Time: O(N)
    Space: O(1)
*/
public class Solution
{
    public bool IsPalindrome(ListNode head)
    {
        // part1. Found a middle of list
        
        var slow = head;
        var fast = head;
        
        while(fast != null && fast.next != null)
        {
            slow = slow.next;
            fast = fast.next.next;
        }
        
        var middle = slow;
        
        // part2. Invert second half of list
        
        ListNode prev = null;
        ListNode curr = slow;
        while(curr != null)
        {
            var temp = curr.next;
            
            curr.next = prev;
            prev = curr;
            curr = temp;
        } // in that point prev is new head (head of inverted half)
        
        // part3. Compare inverted half with second
        
        var list1 = head;
        var list2 = prev;
        
        //while(list2 != null) // or (while(list1 != middle)
        while(list1 != middle) // or (while(list1 != middle)
        {
            if(list1.val != list2.val)
                return false;
                
            list1 = list1.next;
            list2 = list2.next;
        }
        
        return true;
    }
}
/*
    Time: O(N)
    Space: O(1)
*/
public class Solution5
{
    public bool IsPalindrome(ListNode head)
    {
        // part1. Found a middle of list
        
        var slow = head;
        var fast = head;
        
        while(fast != null && fast.next != null)
        {
            slow = slow.next;
            fast = fast.next.next;
        }
        
        var middle = slow;
        
        // part2. Invert first half of list
        
        ListNode prev = null;
        ListNode curr = head;
        while(curr != slow)
        {
            var temp = curr.next;
            
            curr.next = prev;
            prev = curr;
            curr = temp;
        } // in that point prev is new head (head of inverted half)
        
        // part3. Compare inverted half with second
        
        var list1 = prev;
        var list2 = fast == null ? middle : middle.next;
        
        while(list1 != null)
        {
            if(list1.val != list2.val)
                return false;
                
            list1 = list1.next;
            list2 = list2.next;
        }
        
        return true;
    }
}

/*
    Time: O()
    Space: O()
*/
// time limit exceed
public class Solution4
{
    public bool IsPalindrome(ListNode head)
    {
        while(true)
        {
            if(head == null || head.next == null)
                return true;
                
            var prevLast = head;
            while(prevLast.next.next != null)
            {
                prevLast = prevLast.next;
            }
            
            var last = prevLast.next;
            
            if(head.val != last.val)
                return false;
                
            prevLast.next = null;

            head = head.next;
        }
    }
}

// time limit exceed
public class Solution3
{
    public bool IsPalindrome(ListNode head)
    {
        if(head == null || head.next == null)
            return true;
            
        var prevLast = head;
        while(prevLast.next.next != null)
        {
            prevLast = prevLast.next;
        }
        
        var last = prevLast.next;
        
        if(head.val != last.val)
            return false;
            
        prevLast.next = null;

        return IsPalindrome(head.next);
    }
}

// time limit exceed
public class Solution2
{
    public bool IsPalindrome(ListNode head)
    {
        if(head == null || head.next == null)
            return true;
            
        if(head.next.next == null && head.next.val != head.val)
            return false;
            
        var node = ReverseList(head.next);
        
        if(node.val != head.val)
            return false;
            
        return IsPalindrome(node.next);
    }
    
    public ListNode ReverseList(ListNode head)
    {
        if (head == null || head.next == null)
            return head;
            
        var node = ReverseList(head.next);
        head.next.next = head;
        head.next = null;
        return node;
    }
}

public class Solution1
{
    // Time: O(n) two pass
    // Space: O(n) because of list
    public bool IsPalindrome(ListNode head)
    {
        var list = new List<int>();
        while(head != null)
        {
            list.Add(head.val);
            head = head.next;
        }
        var left = 0;
        var right = list.Count() - 1;
        while(left< right)
        {
            if(list[left] != list[right])
                return false;
            
            left++;
            right--;
        }
        return true;
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