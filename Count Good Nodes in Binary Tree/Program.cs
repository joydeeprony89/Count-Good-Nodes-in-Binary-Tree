using System;
using System.Collections.Generic;

namespace Count_Good_Nodes_in_Binary_Tree
{
  class Program
  {
    public class TreeNode
    {
      public int val;
      public TreeNode left;
      public TreeNode right;
      public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
      {
        this.val = val;
        this.left = left;
        this.right = right;
      }
    }
    public int GoodNodes_Tupple(TreeNode root)
    {
      int noOfGoodNodes = 0;
      if (root == null) return noOfGoodNodes;
      // Placeholder for max value in any given path.
      Queue<(TreeNode, int)> q = new Queue<(TreeNode, int)>();
      q.Enqueue((root, root.val));
      noOfGoodNodes++;
      while (q.Count > 0)
      {
        int length = q.Count;
        while (length-- > 0)
        {
          var (node, max) = q.Dequeue();
          var left = node.left;
          var right = node.right;
          if (left?.val >= max) noOfGoodNodes++;
          if (left != null)
          {
            q.Enqueue((left, Math.Max(max, left.val)));
          }
          if (right?.val >= max) noOfGoodNodes++;
          if (right != null)
          {
            q.Enqueue((right, Math.Max(max, right.val)));
          }
        }
      }
      return noOfGoodNodes;
    }
    int noOfGoodNodes = 0;
    public int GoodNodes_using_Recursion(TreeNode root)
    {
      Helper(root, root.val);
      return noOfGoodNodes;
    }

    void Helper(TreeNode root, int max)
    {
      if (root == null) return;
      if (root.val >= max) noOfGoodNodes++;
      // In exampe 1, from path 3->1->3 we send
      //     maximum value for comparision.
      //     Why? Because if we send 1 (i.e. don't
      //     send max value), we'll count 1 as the 
      //     start of the path and increment count.
      //     This is not correct because we are not
      //     considering the already present maximum
      //     value (i.e. 3)
      Helper(root.left, Math.Max(max, root.val));
      Helper(root.right, Math.Max(max, root.val));
    }
    static void Main(string[] args)
    {
      TreeNode root = new TreeNode(3);
      root.left = new TreeNode(1);
      root.right = new TreeNode(4);
      root.left.left = new TreeNode(3);
      root.right.left = new TreeNode(1);
      root.right.right = new TreeNode(5);
      Program p = new Program();
      Console.WriteLine(p.GoodNodes(root));
    }

    public int GoodNodes(TreeNode root)
    {
      if (root == null) return noOfGoodNodes;
      GoodNodesHelper(root, root.val);
      return noOfGoodNodes;
    }

    private void GoodNodesHelper(TreeNode root, int max)
    {
      if (root == null) return;
      if (root.val >= max) noOfGoodNodes++;
      max = Math.Max(max, root.val);
      GoodNodesHelper(root.left, max);
      GoodNodesHelper(root.right, max);
    }
  }
}
