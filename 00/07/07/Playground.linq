<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

// 707. Design Linked List
// https://leetcode.com/problems/design-linked-list/

public class MyLinkedList
{
    /** Initialize your data structure here. */
    public MyLinkedList()
    {
        throw new NotImplementedException();
    }

    /** Get the value of the index-th node in the linked list. If the index is invalid, return -1. */
    public int Get(int index)
    {
        throw new NotImplementedException();
    }

    /** Add a node of value val before the first element of the linked list. After the insertion, the new node will be the first node of the linked list. */
    public void AddAtHead(int val)
    {
        throw new NotImplementedException();
    }

    /** Append a node of value val to the last element of the linked list. */
    public void AddAtTail(int val)
    {
        throw new NotImplementedException();
    }

    /** Add a node of value val before the index-th node in the linked list. If index equals to the length of linked list, the node will be appended to the end of linked list. If index is greater than the length, the node will not be inserted. */
    public void AddAtIndex(int index, int val)
    {
        throw new NotImplementedException();
    }

    /** Delete the index-th node in the linked list, if the index is valid. */
    public void DeleteAtIndex(int index)
    {
        throw new NotImplementedException();
    }
}

/**
 * Your MyLinkedList object will be instantiated and called as such:
 * MyLinkedList obj = new MyLinkedList();
 * int param_1 = obj.Get(index);
 * obj.AddAtHead(val);
 * obj.AddAtTail(val);
 * obj.AddAtIndex(index,val);
 * obj.DeleteAtIndex(index);
 */

[Test]
// leetcode unit-tests below:
[TestCase(
   new string[] { "MyLinkedList", "addAtHead", "addAtTail", "addAtIndex", "get", "deleteAtIndex", "get" },
   new object[] { null, 1, 3, new int[] { 1, 2 }, 1, 1, 1 },
   new object[] { null, null, null, null, 2, null, 3 }
)]
[TestCase(
   new string[] { "MyLinkedList", "addAtIndex", "addAtIndex", "addAtIndex", "get" },
   new object[] { null, new int[] { 0, 10 }, new int[] { 0, 20 }, new int[] { 1, 30 }, 0 },
   new object[] { null, null, null, null, 20 }
)]
[TestCase(
   new string[] { "MyLinkedList", "addAtHead", "deleteAtIndex", "addAtHead", "addAtHead", "addAtHead", "addAtHead", "addAtHead", "addAtTail", "get", "deleteAtIndex", "deleteAtIndex" },
   new object[] { null, 2, 1, 2, 7, 3, 2, 5, 5, 5, 6, 4 },
   new object[] { null, null, null, null, null, null, null, null, null, 2, null, null, }
)]
// my own unit tests below:
// step 1: unit tests for ctor
[TestCase(
   new string[] { "MyLinkedList" },
   new object[] { null, },
   new object[] { null, }
)]
// step 2: unit tests for Get
[TestCase(
   new string[] { "MyLinkedList", "get", "get", "get", "get" },
   new object[] { null, -1, 0, 1, 1000 },
   new object[] { null, -1, -1, -1, -1 }
)]
// step 3: unit tests for Get and AddAtHead
[TestCase(
   new string[] { "MyLinkedList", "get", "get", "get", "get", "addAtHead", "get", "get", "get", "get" },
   new object[] { null, -1, 0, 1, 1000, 42, -1, 0, 1, 1000 },
   new object[] { null, -1, -1, -1, -1, null, -1, 42, -1, -1 }
)]
[TestCase(
   new string[] { "MyLinkedList", "get", "get", "get", "get", "addAtHead", "get", "get", "get", "get", "addAtHead", "get", "get", "get", "get" },
   new object[] { null, -1, 0, 1, 1000, 42, -1, 0, 1, 1000, 5, -1, 0, 1, 2 },
   new object[] { null, -1, -1, -1, -1, null, -1, 42, -1, -1, null, -1, 5, 42, -1 }
)]
//step 4: unit tests for Get and AddAtTail
[TestCase(
   new string[] { "MyLinkedList", "get", "get", "get", "get", "addAtTail", "get", "get", "get", "get" },
   new object[] { null, -1, 0, 1, 1000, 42, -1, 0, 1, 1000 },
   new object[] { null, -1, -1, -1, -1, null, -1, 42, -1, -1 }
)]
[TestCase(
   new string[] { "MyLinkedList", "get", "get", "get", "get", "addAtTail", "get", "get", "get", "get", "addAtTail", "get", "get", "get", "get" },
   new object[] { null, -1, 0, 1, 1000, 42, -1, 0, 1, 1000, 5, -1, 0, 1, 2 },
   new object[] { null, -1, -1, -1, -1, null, -1, 42, -1, -1, null, -1, 42, 5, -1 }
)]
//step 5: unit tests for Get, AddAtHead, AddAtTail and DeleteAtIndex
[TestCase(
   new string[] { "MyLinkedList", "deleteatindex", "get", "get", "get" },
   new object[] { null, -1, -1, 0, 1 },
   new object[] { null, null, -1, -1, -1, }
)]
[TestCase(
   new string[] { "MyLinkedList", "deleteatindex", "get", "get", "get" },
   new object[] { null, 0, -1, 0, 1 },
   new object[] { null, null, -1, -1, -1, }
)]
[TestCase(
   new string[] { "MyLinkedList", "deleteatindex", "get", "get", "get" },
   new object[] { null, 1, -1, 0, 1 },
   new object[] { null, null, -1, -1, -1, }
)]
[TestCase(
   new string[] { "MyLinkedList", "addAtHead","deleteatindex", "get", "get", "get" },
   new object[] { null, 42, -1, -1, 0, 1},
   new object[] { null, null, null, -1, 42, -1 }
)]
[TestCase(
   new string[] { "MyLinkedList", "addAtHead","deleteatindex", "get", "get", "get" },
   new object[] { null, 42, 0, -1, 0, 1},
   new object[] { null, null, null, -1, -1, -1 }
)]
[TestCase(
   new string[] { "MyLinkedList", "addAtHead","deleteatindex", "get", "get", "get" },
   new object[] { null, 42, 1, -1, 0, 1},
   new object[] { null, null, null, -1, 42, -1 }
)]
// deleting at head, index = 0
[TestCase(
   new string[] { "MyLinkedList", "addAtHead", "addAtHead", "addAtHead", "get", "get", "get", "get", "get", "deleteatindex", "get", "get", "get", "get", "get" },
   new object[] { null, 3, 2, 1, -1, 0, 1, 2, 3, 0, -1, 0, 1, 2, 3},
   new object[] { null, null, null, null, -1, 1, 2, 3, -1, null, -1, 2, 3, -1, -1 }
)]

// deleting in the middle, index = 1
[TestCase(
   new string[] { "MyLinkedList", "addAtHead", "addAtHead", "addAtHead", "get", "get", "get", "get", "get", "deleteatindex", "get", "get", "get", "get", "get" },
   new object[] { null, 3, 2, 1, -1, 0, 1, 2, 3, 1, -1, 0, 1, 2, 3},
   new object[] { null, null, null, null, -1, 1, 2, 3, -1, null, -1, 1, 3, -1, -1 }
)]
// deleting at tail, index = 2
[TestCase(
   new string[] { "MyLinkedList", "addAtHead", "addAtHead", "addAtHead", "get", "get", "get", "get", "get", "deleteatindex", "get", "get", "get", "get", "get" },
   new object[] { null, 3, 2, 1, -1, 0, 1, 2, 3, 2, -1, 0, 1, 2, 3},
   new object[] { null, null, null, null, -1, 1, 2, 3, -1, null, -1, 1, 2, -1, -1 }
)]
// deleting 3, then 2, then 1
[TestCase(
   new string[] { "MyLinkedList", "addAtHead", "addAtHead", "addAtHead", "get", "get", "get", "get", "get", "deleteatindex", "get", "get", "get", "get", "get", "deleteatindex", "get", "get", "get", "get", "get", "deleteatindex", "get", "get", "get", "get", "get" },
   new object[] { null, 3, 2, 1, -1, 0, 1, 2, 3, 2, -1, 0, 1, 2, 3, 1, -1, 0, 1, 2, 3, 0, -1, 0, 1, 2, 3 },
   new object[] { null, null, null, null, -1, 1, 2, 3, -1, null, -1, 1, 2, -1, -1, null, -1, 1, -1, -1, -1, null, -1, -1, -1, -1, -1, }
)]
// deleting 3, then 1, then 2
[TestCase(
   new string[] { "MyLinkedList", "addAtHead", "addAtHead", "addAtHead", "get", "get", "get", "get", "get", "deleteatindex", "get", "get", "get", "get", "get", "deleteatindex", "get", "get", "get", "get", "get", "deleteatindex", "get", "get", "get", "get", "get" },
   new object[] { null, 3, 2, 1, -1, 0, 1, 2, 3, 2, -1, 0, 1, 2, 3, 0, -1, 0, 1, 2, 3, 0, -1, 0, 1, 2, 3 },
   new object[] { null, null, null, null, -1, 1, 2, 3, -1, null, -1, 1, 2, -1, -1, null, -1, 2, -1, -1, -1, null, -1, -1, -1, -1, -1, }
)]


// yet another test
[TestCase(
   new string[] { "MyLinkedList", "addAtHead", "deleteAtIndex", "get" },
   new object[] { null, 2, 1, 2 },
   new object[] { null, null, null, -1 }
)]
public void SolutionTests(string[] actionsNames, object[] actionsParams, object[] expectedOutput)
{
    AssertInputIsCorrect(actionsNames, actionsParams, expectedOutput);
    var expectedResult = ConvertResult(expectedOutput);
    int?[] actualResult = new int?[actionsNames.Length];
    MyLinkedList testedObj = null;

    for (var i = 0; i < actionsNames.Length; i++)
    {
        switch (actionsNames[i].ToLower())
        {
            case "mylinkedlist":
                testedObj = new MyLinkedList();
                actualResult[i] = null;
                break;

            case "get":
                if (testedObj == null)
                    throw new Exception("where is init?");
                actualResult[i] = testedObj.Get((int)actionsParams[i]);
                break;

            case "addathead":
                if (testedObj == null)
                    throw new Exception("where is init?");
                testedObj.AddAtHead((int)actionsParams[i]);
                break;

            case "addattail":
                if (testedObj == null)
                    throw new Exception("where is init?");
                testedObj.AddAtTail((int)actionsParams[i]);
                break;

            case "addatindex":
                if (testedObj == null)
                    throw new Exception("where is init?");
                int[] parameters = (int[])actionsParams[i];
                testedObj.AddAtIndex(parameters[0], parameters[1]);
                break;

            case "deleteatindex":
                if (testedObj == null)
                    throw new Exception("where is init?");
                testedObj.DeleteAtIndex((int)actionsParams[i]);
                break;

            default:
                throw new ArgumentOutOfRangeException($"unknown command: {actionsNames[i]}");
        }
    }

    Assert.That(expectedResult, Is.EqualTo(actualResult));
}

#region unit-tests helpers

private void AssertInputIsCorrect(string[] actionsNames, object[] actionsParams, object[] expectedOutput)
{
    if (actionsNames.Length != actionsParams.Length || actionsNames.Length != expectedOutput.Length)
        throw new ArgumentException($"actionsNames.Length={actionsNames.Length}, actionsParams.Length={actionsParams.Length}, expectedOutput.Length={expectedOutput.Length}.");
}

private int?[] ConvertResult(object[] expectedOutput)
{
    var result = new int?[expectedOutput.Length];

    for (var i = 0; i < expectedOutput.Length; i++)
    {
        if (expectedOutput[i] == null)
        {
            result[i] = null;
        }
        else
        {
            result[i] = (int)expectedOutput[i];
        }
    }

    return result;
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