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
    public class Node
    {
      public int val;
      public int max;
      public TreeNode left;
      public TreeNode right;
      public Node(int val = 0, int max = 0, TreeNode left = null, TreeNode right = null)
      {
        this.val = val;
        this.max = max;
        this.left = left;
        this.right = right;
      }
    }
    public int GoodNodes(TreeNode root)
    {
      int noOfGoodNodes = 0;
      if (root == null) return noOfGoodNodes;
      Queue<Node> q = new Queue<Node>();
      Node first = new Node(root.val, root.val, root.left, root.right);
      q.Enqueue(first);
      noOfGoodNodes++;
      while (q.Count > 0)
      {
        int length = q.Count;
        while (length-- > 0)
        {
          Node node = q.Dequeue();
          int max = node.max;
          int val = node.val;
          TreeNode left = node.left;
          TreeNode right = node.right;
          if (left?.val >= val && left?.val >= max) noOfGoodNodes++;
          if (left != null)
          {
            Node newLeft = new Node(left.val, Math.Max(max, left.val), left.left, left.right);
            q.Enqueue(newLeft);
          }

          if (right?.val >= val && right?.val >= max) noOfGoodNodes++;
          if (right != null)
          {
            Node newRight = new Node(right.val, Math.Max(max, right.val), right.left, right.right);
            q.Enqueue(newRight);
          }
        }
      }

      return noOfGoodNodes;
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
      if (root.left != null)
        Helper(root.left, Math.Max(max, root.left.val));
      if (root.right != null)
        Helper(root.right, Math.Max(max, root.right.val));
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
      Console.WriteLine(p.GoodNodes_using_Recursion(root));
    }
  }
}
