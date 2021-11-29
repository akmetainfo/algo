// 226. Invert Binary Tree
// https://leetcode.com/problems/invert-binary-tree/

/*
    Time: O(N)
    Space: O(H)
*/
class Solution {
    public TreeNode invertTree(TreeNode root) {
        if(root == null)
            return root;
            
        var node = root;
        
        var stack = new Stack<TreeNode>();
        stack.push(root);
        
        while(!stack.isEmpty())
        {
            root = stack.pop();
            
            if(root.left != null)
                stack.push(root.left);
            
            if(root.right != null)
                stack.push(root.right);
            
            var tmp = root.left;
            root.left = root.right;
            root.right = tmp;
        }
        
        return node;
    }
}
