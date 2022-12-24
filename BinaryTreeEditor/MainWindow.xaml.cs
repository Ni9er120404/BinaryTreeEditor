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
}