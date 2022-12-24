using System.Windows;
using System.Windows.Controls;

namespace BinaryTreeEditor
{
	public partial class MainWindow : Window
	{
		private readonly BinaryTree tree;

		public MainWindow()
		{
			InitializeComponent();
			
			tree = new BinaryTree();
		}

		private void AddButton_Click(object sender, RoutedEventArgs e)
		{
			if (int.TryParse(ValueTextBox.Text, out int value))
			{
				tree.Insert(value);
				
				UpdateTreeView();
			}
		}

		private void RemoveButton_Click(object sender, RoutedEventArgs e)
		{
			if (int.TryParse(ValueTextBox.Text, out int value))
			{
				tree.Remove(value);
				
				UpdateTreeView();
			}
		}

		private void UpdateTreeView()
		{
			TreeView.Items.Clear();
			
			_ = TreeView.Items.Add(CreateTreeViewItem(tree.Root!));
		}

		private TreeViewItem? CreateTreeViewItem(BinaryTreeNode node)
		{
			if (node == null)
			{
				return null;
			}

			TreeViewItem item = new()
			{
				Header = node.Value
			};

			_ = item.Items.Add(CreateTreeViewItem(node.Left!));

			_ = item.Items.Add(CreateTreeViewItem(node.Right!));
			
			return item;
		}
	}

	internal class BinaryTreeNode
	{
		public int Value { get; set; }
		
		public BinaryTreeNode? Left { get; set; }
		
		public BinaryTreeNode? Right { get; set; }

		public BinaryTreeNode(int value)
		{
			Value = value;
		}
	}

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