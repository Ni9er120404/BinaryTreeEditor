namespace BinaryTreeEditor
{
	internal class BinaryTree
	{
		public BinaryTreeNode? Root { get; set; }

		public void Insert(int value)
		{
			if (Root == null)
			{
				Root = new BinaryTreeNode(value);
			}
			else
			{
				InsertRecursive(Root, value);
			}
		}

		private void InsertRecursive(BinaryTreeNode current, int value)
		{
			if (value < current.Value)
			{
				if (current.Left == null)
				{
					current.Left = new BinaryTreeNode(value);
				}
				else
				{
					InsertRecursive(current.Left, value);
				}
			}
			else
			{
				if (current.Right == null)
				{
					current.Right = new BinaryTreeNode(value);
				}
				else
				{
					InsertRecursive(current.Right, value);
				}
			}
		}

		public void Remove(int value)
		{
			Root = RemoveRecursive(Root!, value);
		}

		private BinaryTreeNode? RemoveRecursive(BinaryTreeNode current, int value)
		{
			if (current == null)
			{
				return null;
			}

			if (value == current.Value)
			{
				if (current.Left == null && current.Right == null)
				{
					return null;
				}
				if (current.Right == null)
				{
					return current.Left;
				}
				if (current.Left == null)
				{
					return current.Right;
				}

				int smallestValue = FindSmallestValue(current.Right);
				
				current.Value = smallestValue;
				
				current.Right = RemoveRecursive(current.Right, smallestValue);
				
				return current;
			}
			if (value < current.Value)
			{
				current.Left = RemoveRecursive(current.Left!, value);
				
				return current;
			}
			else
			{
				current.Right = RemoveRecursive(current.Right!, value);
				return current;
			}
		}

		private int FindSmallestValue(BinaryTreeNode root)
		{
			return root.Left == null ? root.Value : FindSmallestValue(root.Left);
		}
	}
}