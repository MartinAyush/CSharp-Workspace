using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class BinaryTree
    {
        public void Main()
        {
            TreeNode root = new TreeNode(1);
            root.left = new TreeNode(2);
            root.left.right = new TreeNode(3);
            var ans = InorderTraversal(root);
            foreach(var num in ans)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine();
        }

        public IList<int> InorderTraversal(TreeNode root)
        {
            List<int> ans = new List<int>();
            InOrderTraverse(root, ref ans);
            IList<int> tempaAns = ans;
            return tempaAns;
        }

        public void InOrderTraverse(TreeNode root, ref List<int> ans)
        {
            if(root != null)
            {
                InOrderTraverse(root.left, ref ans);
                ans.Add(root.val);
                InOrderTraverse(root.right, ref ans);
            }
        }
    }
}
 