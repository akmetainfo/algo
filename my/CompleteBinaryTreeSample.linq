<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\Accessibility.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\WPF\PresentationCore.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\WPF\PresentationFramework.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\WPF\PresentationUI.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\WPF\ReachFramework.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Configuration.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Deployment.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\WPF\System.Printing.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Xaml.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\WPF\UIAutomationProvider.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\WPF\UIAutomationTypes.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\WPF\WindowsBase.dll</Reference>
  <NuGetReference>Newtonsoft.Json</NuGetReference>
  <NuGetReference>SharpDX</NuGetReference>
  <NuGetReference>SharpDX.D3DCompiler</NuGetReference>
  <Namespace>Newtonsoft.Json</Namespace>
  <Namespace>System.Globalization</Namespace>
  <Namespace>System.Security.Cryptography</Namespace>
  <Namespace>System.Windows</Namespace>
  <Namespace>System.Windows.Controls</Namespace>
  <Namespace>System.Windows.Media</Namespace>
  <Namespace>System.Windows.Media.Effects</Namespace>
  <Namespace>System.Windows.Shapes</Namespace>
  <Namespace>SharpDX.D3DCompiler</Namespace>
</Query>

void Main()
{
    var i = 3;
    var arr = Enumerable.Range(1, (2 << i) - 1).ToArray();
    var root = CreateTree(arr);
    root.Display();
    ToArray(root).Dump();
}

public static class TreeOrderHelper
{
    public static void Display(this TreeNode root)
    {
        var canvas = new Canvas().Dump();
        
        if(root == null)
            return;
            
        LevelOrderTraversal(root, canvas);
    }
    
    private static void LevelOrderTraversal(TreeNode root, Canvas canvas)
    {
        var levelOrder = 1;
        var queue = new Queue<TreeNode>();
        if (root != null) queue.Enqueue(root);
        while (queue.Count != 0)
        {
            var levelSize = queue.Count;
            var levelNums = new List<int>();
            for (int i = 0; i < levelSize; i++)
            {
                var dequeued = queue.Dequeue();

                levelNums.Add(dequeued.val);

                DrawNode(dequeued, canvas, 20 + 50 * i,  50 * levelOrder);

                if (dequeued.left != null)
                    queue.Enqueue(dequeued.left);

                if (dequeued.right != null)
                    queue.Enqueue(dequeued.right);
            }
            levelOrder++;
        }
    }

    private static void DrawNode(TreeNode root, Canvas canvas, int x, int y)
    {
        const double PT_DM = 10;
        var e = new Ellipse
        {
            Width = PT_DM,
            Height = PT_DM,
            Margin = new Thickness(x - PT_DM / 2, y, 0, 0),
            Stroke = Brushes.Transparent,
            Fill = Brushes.SteelBlue,
            StrokeThickness = 0.5d,
        };

        var t = new TextBlock()
        {
            Text = root.val.ToString(),
            Margin = new Thickness(x + PT_DM / 2, y + PT_DM / 2, 0, 0),
            Foreground = Brushes.Gray,
        };

        canvas.Children.Add(e);
        canvas.Children.Add(t);
    }
}

// Define other methods and classes here

public class TreeNode 
{
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}

public bool ValidateLength(int length)
{
    var total = 0;
    for (int i = 0; i < 32; i++)
    {
        total = (1 << i) - 1;
        if(length <= total)
            break;
    }
    return length == total;
}

public TreeNode FromArray(int[] arr)
{
    if(!ValidateLength(arr.Length))
        throw new ArgumentOutOfRangeException(nameof(arr.Length));
    
    return CreateTree(arr);
}

public int[] ToArray(TreeNode root)
{
    var result = new List<int>();
    var queue = new Queue<TreeNode>();
    if (root != null) queue.Enqueue(root);
    while (queue.Count != 0)
    {
        var levelSize = queue.Count;
        var levelNums = new List<int>();
        for (int i = 0; i < levelSize; i++)
        {
            var dequeued = queue.Dequeue();

            levelNums.Add(dequeued.val);

            if (dequeued.left != null)
                queue.Enqueue(dequeued.left);

            if (dequeued.right != null)
                queue.Enqueue(dequeued.right);
        }
        levelOrder.Add(levelNums);
    }
    return levelOrder;
}


// Vesion 2
private TreeNode CreateTree(int[] data)
{
    var nodes = new Dictionary<int, TreeNode>();

    for (int i = data.Length - 1; i >= 0; i--)
    {
        object val = data[i];
        if (val == null) continue;
        int index = i + 1;

        nodes.TryGetValue(index * 2, out TreeNode left);
        nodes.TryGetValue(index * 2 + 1, out TreeNode right);

        var node = new TreeNode((int)val, left, right);
        nodes[index] = node;
    }

    nodes.TryGetValue(1, out TreeNode root);
    return root;
}