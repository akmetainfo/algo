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
    var root = arr.FromArray();
    root.Display();
    root.ToArray().Dump();
}

public static class TreeOrderHelper
{
    public static void Display(this TreeNode root)
    {
        var canvas = new Canvas().Dump();
        
        if(root == null)
            return;
            
        //LevelOrderTraversal(root, canvas);
        
        var arr = root.ToArray();
        Display(arr, canvas);
    }
    
    private static void Display(int[] arr, Canvas canvas)
    {
        var total = TreeNodeExtension.LevesTotal(arr.Length).Dump();
        for (int i = 0; i < arr.Length; i++)
        {
            $"{i.ToString("00")} {arr[i]} ==> {TreeNodeExtension.CurrentLevel(i)}".Dump();
            DrawNode(arr[i].ToString(), canvas, 200 + 50 * (i - 2*  TreeNodeExtension.CurrentLevel(i)) + 0, 50 * TreeNodeExtension.CurrentLevel(i));
        }
        
    }
    
    private static void LevelOrderTraversal(TreeNode root, Canvas canvas)
    {
        var levelOrder = 1;
        var totalLevels = 5;
        var queue = new Queue<TreeNode>();
        if (root != null) queue.Enqueue(root);
        while (queue.Count != 0)
        {
            var levelSize = queue.Count;
            var levelNums = new List<int>();
            var nodeAtLevelNum = 0;
            var totalNodesAtLevel = (int)Math.Pow(2, levelOrder) - 1;
            for (int i = 0; i < levelSize; i++)
            {
                var dequeued = queue.Dequeue();

                levelNums.Add(dequeued.val);
                
                var padder = 100 * (totalLevels - levelOrder) * (nodeAtLevelNum +1);

                DrawNode(dequeued.val.ToString(), canvas, 20 + 50 * i + padder, 50 * levelOrder);
                nodeAtLevelNum++;

                if (dequeued.left != null)
                    queue.Enqueue(dequeued.left);

                if (dequeued.right != null)
                    queue.Enqueue(dequeued.right);
            }
            levelOrder++;
        }
    }

    private static void DrawNode(string val, Canvas canvas, int x, int y)
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
            Text = val,
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

public static class TreeNodeExtension
{
    public static TreeNode FromArray(this int[] arr)
    {
        if (!ValidateLength(arr.Length))
            throw new ArgumentOutOfRangeException(nameof(arr.Length));

        return CreateTree(arr);
    }

    public static int[] ToArray(this TreeNode root)
    {
        var result = new List<int>();
        var queue = new Queue<TreeNode>();
        if (root != null) queue.Enqueue(root);
        while (queue.Count != 0)
        {
            var levelSize = queue.Count;
            for (int i = 0; i < levelSize; i++)
            {
                var dequeued = queue.Dequeue();

                result.Add(dequeued.val);

                if (dequeued.left != null)
                    queue.Enqueue(dequeued.left);

                if (dequeued.right != null)
                    queue.Enqueue(dequeued.right);
            }
        }
        return result.ToArray();
    }

    // Vesion 2
    private static TreeNode CreateTree(int[] data)
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

    public static bool ValidateLength(int length)
    {
        var total = 0;
        for (int i = 0; i < 32; i++)
        {
            total = (1 << i) - 1;
            if (length <= total)
                break;
        }
        return length == total;
    }
    public static int LevesTotal(int length)
    {
        var total = 0;
        var i = 0;
        while(i < 32)
        {
            total = (1 << i) - 1;
            if (length <= total)
                break;
            i++;
        }
        if(length != total)
            throw new Exception();
            
        return i;
    }

    public static int CurrentLevel(int length)
    {
        var i = 1;
        var sum = 0;
        while (i < 32)
        {
            sum += 1 << (i -1);
            if (length + 1 <= sum)
                break;
            i++;
        }

        return i;
    }
}






