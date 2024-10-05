using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.BinaryTrees
{
    public class BinaryTreeByStriver
    {
        public void Main()
        {
            TreeNode root = new TreeNode(10);
            //root.left = new TreeNode(2);
            //root.right = new TreeNode(3);
            //root.left.left = new TreeNode(4);
            //root.left.right = new TreeNode(5);
            //root.right.left = new TreeNode(6);
            //root.right.right = new TreeNode(7);

            InsertInBinarySearchTree(root, 20);
            InsertInBinarySearchTree(root, 5);
            InsertInBinarySearchTree(root, 4);
            InsertInBinarySearchTree(root, 21);
            InsertInBinarySearchTree(root, 6);

            //DeleteNodeInBinarySearchTree(root, 6);
            //LevelOrderTraversalIterative(root);
            //int totalCount = CountElementInTree(root);
            //int height = HeightOfTree(root);
            //Console.WriteLine(height);
            //PreOrderTraversalIterative(root);
            //bool flag = SearchInBinarySearchTree(root, 90);
            //Console.WriteLine(flag);

            AllTraversalInOneGo(root);
        }

        public void PreOrderTraversalRecursive(TreeNode root)
        {
            if(root != null)
            {
                Console.WriteLine(root.val);
                PreOrderTraversalRecursive(root.left);
                PreOrderTraversalRecursive(root.right);
            }
        }

        public void PreOrderTraversalIterative(TreeNode root)
        {
            if (root == null) return;

            Stack<TreeNode> storage = new Stack<TreeNode>();
            storage.Push(root);

            while (storage.Count > 0)
            {
                TreeNode current = storage.Pop();
                Console.WriteLine(current.val); // Visit the node (ROOT)

                // Push right first, so left is processed first (stack is LIFO)
                if (current.right != null) 
                    storage.Push(current.right);

                if (current.left != null) 
                    storage.Push(current.left);
            }
        }

        public void InOrderTraversalRecursive(TreeNode root)
        {
            if (root != null)
            {
                InOrderTraversalRecursive(root.left);
                Console.WriteLine(root.val);
                InOrderTraversalRecursive(root.right);
            }
        }

        public void InOrderTraversalIterative(TreeNode root)
        {
            if (root == null)
            {
                return;
            }

            Stack<TreeNode> storage = new Stack<TreeNode>();
            TreeNode temp = root;
            while (temp != null || storage.Count > 0)
            {
                // first push all left elements
                while (temp != null)
                {
                    storage.Push(temp);
                    temp = temp.left;
                }

                temp = storage.Pop();
                Console.WriteLine(temp.val);

                temp = temp.right;
            }
        }

        public void PostOrderTraversalRecursive(TreeNode root)
        {
            if (root != null)
            {
                PostOrderTraversalRecursive(root.left);
                PostOrderTraversalRecursive(root.right);
                Console.WriteLine(root.val);
            }
        }

        public void PostOrderTraversalIterative(TreeNode root)
        {
            // Use a stack to simulate the recursion process
            Stack<TreeNode> storage = new Stack<TreeNode>();
            TreeNode lastVisited = null; // To track the last visited node

            while (root != null || storage.Count > 0)
            {
                // Step 1: Go as far left as possible
                if (root != null)
                {
                    storage.Push(root); // Push current node to stack
                    root = root.left;    // Move to left child
                }
                else
                {
                    // Peek the top node without popping it
                    TreeNode peekNode = storage.Peek();

                    // Step 2: Check if there is a right subtree to process
                    if (peekNode.right != null && lastVisited != peekNode.right)
                    {
                        root = peekNode.right; // Move to the right subtree
                    }
                    else
                    {
                        // If no right child, or the right child has already been processed
                        Console.WriteLine(peekNode.val); // Visit (print) the node
                        lastVisited = storage.Pop();     // Mark this node as last visited
                    }
                }
            }
        }

        public void PostOrderIterative(TreeNode root)
        {
            if (root == null)
                return;

            Stack<TreeNode> stack = new Stack<TreeNode>();
            Stack<TreeNode> output = new Stack<TreeNode>();

            stack.Push(root);

            while (stack.Count > 0)
            {
                TreeNode current = stack.Pop();
                output.Push(current);

                if (current.left != null)
                    stack.Push(current.left);

                if (current.right != null)
                    stack.Push(current.right);
            }

            while (output.Count > 0)
            {
                TreeNode current = output.Pop();
                Console.Write(current.val + " ");
            }
        }

        public void AllTraversalInOneGo(TreeNode root)
        {
            /* rule insert root as root, 1
                    if num == 1:
                        add value to the Pre-order
                        increment the num and re-add to the stack 
                        if left is not null then push it to stack with num = 1
                    if num == 2:
                        Add value to In-Order
                        increment the value and re-add to the stack
                        if right is not null then push it to the stack with num = 2;
                    if num == 3:
                        add value to the Post-Order
            */

            Stack<Tuple<TreeNode, int>> storage = new Stack<Tuple<TreeNode, int>>();
            storage.Push(new Tuple<TreeNode, int>(root, 1));
            List<int> preOrder = new List<int>();
            List<int> inOrder = new List<int>();
            List<int> postOrder = new List<int>();

            while (storage.Count > 0)
            {
                var top = storage.Pop();
                if (top.Item2 == 1)
                {
                    preOrder.Add(top.Item1.val);
                    storage.Push(new Tuple<TreeNode, int>(top.Item1, 2));
                    if (top.Item1.left != null)
                    {
                        storage.Push(new Tuple<TreeNode, int>(top.Item1.left, 1));
                    }
                }
                else if (top.Item2 == 2)
                {
                    inOrder.Add(top.Item1.val);
                    storage.Push(new Tuple<TreeNode, int>(top.Item1, 3));
                    if (top.Item1.right != null)
                    {
                        storage.Push(new Tuple<TreeNode, int>(top.Item1.right, 1));
                    }
                }
                else
                {
                    postOrder.Add(top.Item1.val);
                }
            }

            Console.WriteLine("Pre Order Traversal: ");
            foreach (var item in preOrder)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine("\nIn Order Traversal: ");
            foreach (var item in inOrder)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine("\nPost Order Traversal: ");
            foreach (var item in postOrder)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();

        }

        public void LevelOrderTraversalIterative(TreeNode root)
        {
            if(root == null)
            {
                return;
            }

            Queue<TreeNode> storage = new Queue<TreeNode>();
            storage.Enqueue(root);

            while(storage.Count > 0)
            {
                var top = storage.Dequeue();
                Console.WriteLine(top.val);

                if(top.left != null)
                {
                    storage.Enqueue(top.left);
                }

                if(top.right != null)
                {
                    storage.Enqueue(top.right);
                }
            }

            return;
        }
        
        public bool SearchInBinarySearchTree(TreeNode root, int key)
        {
            bool flag = false;
            if(root == null)
            {
                return flag;
            }

            while(root != null)
            {
                if (root.val == key)
                {
                    return true;
                }
                else if (root.val < key)
                {
                    root = root.right;
                }
                else
                {
                    root = root.left;
                }
            }

            return flag;
        }

        public void InsertInBinarySearchTree(TreeNode root, int val)
        {
            TreeNode parent = null;
            while(root != null)
            {
                parent = root;
                if(root.val == val)
                {
                    return;
                }
                else if(root.val < val)
                {
                    root = root.right;
                }
                else if(root.val > val)
                {
                    root = root.left;
                }
            }

            TreeNode newNode = new TreeNode(val);
            if(parent != null)
            {
                if(parent.val < val)
                {
                    parent.right = newNode;
                }
                else
                {
                    parent.left = newNode;
                }
            }
            else
            {
                root = newNode;
            }
        }

        public bool DeleteNodeInBinarySearchTree(TreeNode root, int key)
        {
            if(root == null)
            {
                return false;
            }

            var curr = root;
            TreeNode parent = root;

            while(curr != null && curr.val != key)
            {
                parent = curr;
                
                if(curr.val < key)
                {
                    curr = curr.right;
                }
                else
                {
                    curr = curr.left;
                }
            }

            if(curr == null)
            {
                return false;
            }

            if (curr.left != null && curr.right != null) // handling 2 childs
            {
                var temp = curr.left; // choosing max element from left subtree
                var tempParent = curr;

                while(temp.right != null)
                {
                    tempParent = temp;
                    temp = temp.right;
                }
                parent.val = temp.val;
                tempParent.right = null;
            }
            else if (curr.left != null && curr.right == null) // handling one child that is left
            {
                parent.left = curr.left;
            } 
            else if (curr.right != null && curr.left == null) // handling one child that is right
            {
                parent.right = curr.right;
            }
            else // no child 
            {
                if(parent.right.val == key)
                {
                    parent.right = null;
                }
                else
                {
                    parent.left = null;
                }
            }

            return true;
        }

        public int CountElementInTree(TreeNode root)
        {
            if(root == null)
            {
                return 0;
            }

            return 1 + CountElementInTree(root.left) + CountElementInTree(root.right);
        }

        public int HeightOfTree(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }

            return 1 + Math.Max(HeightOfTree(root.left), HeightOfTree(root.right));
        }

        public int CheckBalancedTree(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }

            int leftHeight = CheckBalancedTree(root.left);
            int rightHeight = CheckBalancedTree(root.right);

            if (Math.Abs(leftHeight - rightHeight) > 1)
            {
                return -1; // unbalanced
            }

            return leftHeight - rightHeight; // balanced 
        }

        public int DiameterOfTree(TreeNode root, ref int max)
        {
            if (root == null)
            {
                return 0;
            }

            int leftHeight = DiameterOfTree(root.left, ref max);
            int rightHeight = DiameterOfTree(root.right, ref max);

            max = Math.Max(max, leftHeight + rightHeight);

            return 1 + Math.Max(leftHeight, rightHeight);
        }

        public int MaximumPathSum(TreeNode root, ref int maxi)
        {
            if (root == null)
            {
                return 0;
            }

            int leftSum = Math.Max(0, MaximumPathSum(root.left, ref maxi));
            int rightSum = Math.Max(0, MaximumPathSum(root.right, ref maxi));

            maxi = Math.Max(leftSum + rightSum + root.val, maxi);

            return root.val + Math.Max(leftSum, rightSum);
        }

        public bool CheckIfTwoTreeAreSame(TreeNode root1, TreeNode root2)
        {
            if(root1 == null || root2 == null)
            {
                return root1 == root2;
            }
            
            return root1.val == root2.val   // validating using pre-order traversal
                && CheckIfTwoTreeAreSame(root1.left, root2.left) 
                && CheckIfTwoTreeAreSame(root1.right, root1.right);
        }

        public IList<IList<int>> ZigzagLevelOrder(TreeNode root)
        {
            IList<IList<int>> ans = new List<IList<int>>();
            if (root == null)
            {
                return ans;
            }
            Queue<TreeNode> storage = new Queue<TreeNode>();
            storage.Enqueue(root);
            bool reverse = false;

            while (storage.Count > 0)
            {
                int n = storage.Count;
                int[] printValues = new int[n];
                for (int i = 0; i < n; i++)
                {
                    var top = storage.Dequeue();
                    int idx = reverse ? n - i - 1 : i;
                    printValues[idx] = top.val;

                    if (top.left != null)
                    {
                        storage.Enqueue(top.left);
                    }

                    if (top.right != null)
                    {
                        storage.Enqueue(top.right);
                    }
                }

                reverse = !reverse;
                ans.Add(printValues);
            }

            return ans;
        }

        #region Boundary Order Traversal
        public void BoundaryOrderTraversal(TreeNode root)
        {
            // left boundary excluding leaf nodes
            // leaf nodes
            // right boundary excluding leaf nodes in reverse order
            Console.WriteLine(root.val);
            PrintLeftBoundary(root);
            PrintLeafNodes(root);
            PrintRightBoundary(root);
        }

        private void PrintRightBoundary(TreeNode root)
        {
            root = root.right;
            while (root != null)
            {
                if (!IsLeafNode(root))
                {
                    Console.WriteLine(root.val);
                }

                if (root.right != null)
                {
                    root = root.right;
                }
                else
                {
                    root = root.left;
                }
            }
        }

        private void PrintLeafNodes(TreeNode root)
        {
            // root left right - preOrder Traversal

            if (root != null)
            {
                if (IsLeafNode(root))
                {
                    Console.WriteLine(root.val);
                }
                PrintLeafNodes(root.left);
                PrintLeafNodes(root.right);
            }
        }

        private void PrintLeftBoundary(TreeNode root)
        {
            root = root.left;
            while (root != null)
            {
                if (!IsLeafNode(root))
                {
                    Console.WriteLine(root.val);
                }

                if (root.left != null)
                {
                    root = root.left;
                }
                else
                {
                    root = root.right;
                }

            }
        }

        public bool IsLeafNode(TreeNode node)
        {
            return node.left == null && node.right == null;
        }
        #endregion

        #region IsSymmetric Iterative
        public bool IsSymmetric(TreeNode root)
        {
            if (root == null)
            {
                return false;
            }

            var leftSubTree = new List<int>();
            IsSymmetricHelpLeft(root.left, ref leftSubTree);

            var rightSubTree = new List<int>();
            IsSymmetricHelpRight(root.right, ref rightSubTree);

            if (leftSubTree.Count != rightSubTree.Count)
            {
                return false;
            }

            for (int i = 0; i < leftSubTree.Count; i++)
            {
                if (rightSubTree[i] != leftSubTree[i])
                {
                    return false;
                }
            }

            return true;
        }

        private void IsSymmetricHelpLeft(TreeNode root, ref List<int> subTree)
        {
            if (root == null)
            {
                subTree.Add(-1);
                return;
            }

            subTree.Add(root.val);
            IsSymmetricHelpLeft(root.left, ref subTree);
            IsSymmetricHelpLeft(root.right, ref subTree);
        }

        private void IsSymmetricHelpRight(TreeNode root, ref List<int> subTree)
        {
            if (root == null)
            {
                subTree.Add(-1);
                return;
            }

            subTree.Add(root.val);
            IsSymmetricHelpRight(root.right, ref subTree);
            IsSymmetricHelpRight(root.left, ref subTree);
        }

        #endregion

        public bool RootToNodePath(TreeNode root, int val, ref List<int> path)
        {
            if (root == null)
            {
                return false;
            }

            path.Add(root.val);

            if (root.val == val)
            {
                return true;
            }

            if (RootToNodePath(root.left, val, ref path) == true || RootToNodePath(root.right, val, ref path) == true)
            {
                return true;
            }

            // backtrack
            path.RemoveAt(path.Count - 1);

            return false;
        }

        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            if (root == null)
            {
                return root;
            }

            if (root == p || root == q)
            {
                return root;
            }

            var leftNode = LowestCommonAncestor(root.left, p, q);
            var rightNode = LowestCommonAncestor(root.right, p, q);

            if (leftNode != null && rightNode != null)
            {
                return root;
            }
            else if (leftNode != null)
            {
                return leftNode;
            }

            return rightNode;
        }

        public int WidthOfBinaryTree(TreeNode root)
        {
            // max width of binary tree at any level, also considering missing nodes.
            /*
                        1
                      /   \
                    X*2   X*2+1
             */

            Queue<Tuple<TreeNode, int>> storage = new Queue<Tuple<TreeNode, int>>();
            storage.Enqueue(new Tuple<TreeNode, int>(root, 0));
            int ans = -1;

            while (storage.Count > 0)
            {
                int n = storage.Count;
                int firstElement = 0, secondElement = 0;
                int minElement = storage.First().Item2;

                for (int i = 0; i < n; i++)
                {
                    var top = storage.Dequeue();
                    var idx = top.Item2 - minElement;
                    if (i == 0)
                    {
                        firstElement = idx;
                    }
                    else if (i == n - 1)
                    {
                        secondElement = idx;
                    }

                    if (top.Item1.left != null)
                    {
                        storage.Enqueue(new Tuple<TreeNode, int>(top.Item1.left, idx * 2));
                    }

                    if (top.Item1.right != null)
                    {
                        storage.Enqueue(new Tuple<TreeNode, int>(top.Item1.right, idx * 2 + 1));
                    }
                }

                ans = Math.Max(ans, secondElement - firstElement + 1);
            }

            return ans;
        }

        public IList<int> DistanceK(TreeNode root, TreeNode target, int k)
        {
            if (k == 0)
            {
                return new List<int> { target.val };
            }

            Dictionary<int, TreeNode> childParentMappings = new Dictionary<int, TreeNode>();

            // Step 1: create child parent mappings
            Queue<TreeNode> storage = new Queue<TreeNode>();
            storage.Enqueue(root);

            while (storage.Count > 0)
            {
                int n = storage.Count;
                for (int i = 0; i < n; i++)
                {
                    var top = storage.Dequeue();

                    if (top.left != null)
                    {
                        storage.Enqueue(top.left);
                        childParentMappings.Add(top.left.val, top);
                    }

                    if (top.right != null)
                    {
                        storage.Enqueue(top.right);
                        childParentMappings.Add(top.right.val, top);
                    }
                }
            }

            // go to TOP LEFT and RIGHT 

            storage.Clear(); // now storage will contains the elemnts at each kth level, at 0th only target element will be present
            storage.Enqueue(target);
            HashSet<int> visited = new HashSet<int>(); // visited elements of the tree

            while (storage.Count > 0)
            {
                int n = storage.Count;
                k--;
                for (int i = 0; i < n; i++)
                {
                    var top = storage.Dequeue();

                    // parent
                    if (childParentMappings.ContainsKey(top.val) && !visited.Contains(childParentMappings[top.val].val))
                    {
                        visited.Add(childParentMappings[top.val].val);
                        storage.Enqueue(childParentMappings[top.val]);
                    }

                    // left child
                    if (top.left != null && !visited.Contains(top.left.val))
                    {
                        visited.Add(top.left.val);
                        storage.Enqueue(top.left);
                    }

                    // right child
                    if (top.right != null && !visited.Contains(top.right.val))
                    {
                        visited.Add(top.right.val);
                        storage.Enqueue(top.right);
                    }
                }

                if (k == 0)
                {
                    break;
                }
            }

            IList<int> ans = new List<int>();
            while (storage.Count > 0)
            {
                var ele = storage.Dequeue().val;
                if (ele != target.val)
                {
                    ans.Add(ele);
                }
            }
            return ans;
        }

        public int AmountOfTime(TreeNode root, int start)
        {
            // Using Level order traversal to create child parent mappings
            Dictionary<TreeNode, TreeNode> childParentMappings = new Dictionary<TreeNode, TreeNode>();
            Queue<TreeNode> storage = new Queue<TreeNode>();
            storage.Enqueue(root);

            TreeNode startNode = null;
            while (storage.Count > 0)
            {
                int n = storage.Count;
                for (int i = 0; i < n; i++)
                {
                    var top = storage.Dequeue();

                    if (top.val == start)
                    {
                        startNode = top;
                    }

                    if (top.left != null)
                    {
                        childParentMappings.Add(top.left, top);
                        storage.Enqueue(top.left);
                    }

                    if (top.right != null)
                    {
                        childParentMappings.Add(top.right, top);
                        storage.Enqueue(top.right);
                    }
                }
            }

            HashSet<int> visited = new HashSet<int>(); // so we not compute a node more than one time.
            storage.Enqueue(startNode);
            visited.Add(startNode.val);
            int ans = -1;

            while (storage.Count > 0)
            {
                int n = storage.Count;
                for (int i = 0; i < n; i++)
                {
                    var top = storage.Dequeue();

                    // parent - check if curr node is a child of any node and that node is not visited
                    if (childParentMappings.ContainsKey(top) && !visited.Contains(childParentMappings[top].val))
                    {
                        storage.Enqueue(childParentMappings[top]);
                        visited.Add(childParentMappings[top].val);
                    }

                    // left node
                    if (top.left != null && !visited.Contains(top.left.val))
                    {
                        storage.Enqueue(top.left);
                        visited.Add(top.left.val);
                    }

                    // right node
                    if (top.right != null && !visited.Contains(top.right.val))
                    {
                        storage.Enqueue(top.right);
                        visited.Add(top.right.val);
                    }
                }
                ans++;
            }

            return ans;
        }

        // Count nodes in complete binary tree under O(N)
        public int CountNodes(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }

            int leftHeight = FindLeftHeight(root);
            int rightHeight = FindRightHeight(root);

            if (leftHeight == rightHeight)
            {
                return (1 << leftHeight) - 1; // 2 pow N - 1
            }

            return 1 + CountNodes(root.left) + CountNodes(root.right);
        }

        private int FindRightHeight(TreeNode root)
        {
            int count = 0;
            while (root != null)
            {
                count++;
                root = root.right;
            }
            return count;
        }

        private int FindLeftHeight(TreeNode root)
        {
            int count = 0;
            while (root != null)
            {
                count++;
                root = root.left;
            }
            return count;
        }

        // End

        // construct a Binary Tree from preorder and Inorder Traversal
        public TreeNode BuildTree(int[] preorder, int[] inorder)
        {
            // Create dictionary to quick lookup inOrder element index
            Dictionary<int, int> inorderIdxMappings = new Dictionary<int, int>();
            for (int i = 0; i < inorder.Length; i++)
            {
                inorderIdxMappings[inorder[i]] = i;
            }

            TreeNode root = BuildTreeHelper(preorder, 0, preorder.Length - 1, inorder, 0, inorder.Length - 1, inorderIdxMappings);

            return root;
        }
        private TreeNode BuildTreeHelper(int[] preorder, int pStart, int pEnd, int[] inorder, int iStart, int iEnd, Dictionary<int, int> inorderIdxMappings)
        {
            if (pStart > pEnd || iStart > iEnd)
            {
                return null;
            }

            // make root - preOrder is ROOT LEFT RIGHT -> so root always be root first element
            TreeNode root = new TreeNode(preorder[pStart]);

            // need to find the inorder index to identity the left part and right part of the tree
            int rootIdx = inorderIdxMappings[preorder[pStart]];

            // inorder is LEFT ROOT RIGHT, so above rootIdx we have ROOT, now we have to find only the left part, using this we can identify the right part
            int leftElementsInOrder = rootIdx - iStart;

            // only pass the elements which needs to be a part of left subtree
            root.left = BuildTreeHelper(preorder, pStart + 1, pStart + leftElementsInOrder, inorder, iStart, rootIdx - 1, inorderIdxMappings);

            // only pass the elements which needs to be a part of right subtree
            root.right = BuildTreeHelper(preorder, pStart + 1 + leftElementsInOrder, pEnd, inorder, rootIdx + 1, iEnd, inorderIdxMappings);

            // return root created at every iteration, which will later be attached to left or right of the subtree.
            return root;
        }

        // END

        // Construct Binary Tree from Inorder and Postorder Traversal
        public TreeNode BuildTreeTwo(int[] inorder, int[] postorder)
        {
            Dictionary<int, int> inorderIdxMappings = new Dictionary<int, int>();
            for (int i = 0; i < inorder.Length; i++)
            {
                inorderIdxMappings[inorder[i]] = i;
            }

            TreeNode root = BuildTreeHelperTwo(inorder, 0, inorder.Length - 1, postorder, 0, postorder.Length - 1, inorderIdxMappings);

            return root;
        }
        private TreeNode BuildTreeHelperTwo(int[] inorder, int iStart, int iEnd, int[] postorder, int pStart, int pEnd, Dictionary<int, int> inorderIdxMappings)
        {
            if (iStart > iEnd || pStart > pEnd)
            {
                return null; // leaf nodes
            }

            TreeNode root = new TreeNode(postorder[pEnd]);
            int inorderIdx = inorderIdxMappings[postorder[pEnd]];
            int remainingElements = inorderIdx - iStart;

            root.left = BuildTreeHelperTwo(inorder, iStart, inorderIdx - 1, postorder, pStart, pStart + remainingElements - 1, inorderIdxMappings);
            root.right = BuildTreeHelperTwo(inorder, inorderIdx + 1, iEnd, postorder, pStart + remainingElements, pEnd - 1, inorderIdxMappings);

            return root;
        }

        // END

        // Start 
        TreeNode prevProcessedNode = null;
        public void FlattenPreOrderRecursive(TreeNode curr)
        {
            /*
             * The "linked list" should use the same TreeNode class 
             * where the right child pointer points to the next node in the list and 
             * the left child pointer is always null.
             * The "linked list" should be in the same order as a pre-order traversal of the binary tree.
             * PreOrder -> ROOT LEFT RIGHT
             */

            if (curr == null)
            {
                return;
            }

            // we need to traverse in the opp. PreOrder -> RIGHT LEFT ROOT
            FlattenPreOrderRecursive(curr.right);
            FlattenPreOrderRecursive(curr.left);

            curr.right = prevProcessedNode;
            curr.left = null;
            prevProcessedNode = curr;
        }
        // End

        public void FlattenPreOrderIterative(TreeNode root)
        {
            if (root == null)
            {
                return;
            }

            Stack<TreeNode> storage = new Stack<TreeNode>();
            storage.Push(root);

            while (storage.Count > 0)
            {
                var top = storage.Pop();

                // we need ans in PreOrder -> ROOT LEFT RIGHT
                // so we need to traverse in RIGHT LEFT ROOT

                if (top.right != null)
                {
                    storage.Push(top.right);
                }

                if (top.left != null)
                {
                    storage.Push(top.left);
                }

                if (storage.Count > 0)
                {
                    top.right = storage.Peek();
                    top.left = null;
                }
            }
        }

        public TreeNode BstFromPreorder(int[] preorder)
        {
            // Approach: 
            int idx = 0;
            return BstFromPreorderHelper(preorder, ref idx, int.MaxValue);
        }

        private TreeNode BstFromPreorderHelper(int[] preorder, ref int idx, int maxValue)
        {
            if (idx == preorder.Length || preorder[idx] >= maxValue)
            {
                return null!;
            }

            var root = new TreeNode(preorder[idx++]);

            root.left = BstFromPreorderHelper(preorder, ref idx, root.val);
            root.right = BstFromPreorderHelper(preorder, ref idx, maxValue);

            return root;
        }

        public void RecoverTree(TreeNode root)
        {
            // Intution: Traverse InOrder then we get the sorted value and check if any value is not in sorted condition then these are the swapped values
            // Case1: Nodes are beside one another, carry a middle pointer which will handle this case
            // Case2: Nodes are not beside one another, then swap values of first and second

            TreeNode first = null;
            TreeNode middle = null;
            TreeNode second = null;
            TreeNode prev = new TreeNode(int.MinValue);
            RecoverTreeHelper(root, ref first, ref middle, ref second, ref prev);

            if (first != null && second != null)
            {
                int temp = first.val;
                first.val = second.val;
                second.val = temp;
            }
            else if (first != null && middle != null)
            {
                int temp = middle.val;
                middle.val = first!.val;
                first.val = temp;
            }
        }

        private void RecoverTreeHelper(TreeNode curr, ref TreeNode? first, ref TreeNode? middle, ref TreeNode? second, ref TreeNode prev)
        {
            if (curr != null)
            {
                RecoverTreeHelper(curr.left, ref first, ref middle, ref second, ref prev);
                if (prev != null && (curr.val < prev.val))
                {
                    if (first == null)
                    {
                        first = prev;
                        middle = curr;
                    }
                    else
                    {
                        second = curr;
                    }
                }
                prev = curr;
                RecoverTreeHelper(curr.right, ref first, ref middle, ref second, ref prev);
            }
        }
    }

    // serialize and deserialize binary tree
    public class Codec
    {
        // Encodes a tree to a single string.
        public string serialize(TreeNode root)
        {
            StringBuilder sb = new StringBuilder();
            if (root == null)
            {
                return sb.ToString();
            }
            Queue<TreeNode?> storage = new Queue<TreeNode?>();
            storage.Enqueue(root);

            while (storage.Count > 0)
            {
                int n = storage.Count;
                for (int i = 0; i < n; i++)
                {
                    var top = storage.Dequeue();

                    if (top == null)
                    {
                        sb.Append("#,");
                        continue; // when curr node is null, do not check for it's left and right node
                    }
                    else
                    {
                        sb.Append(top.val + ",");
                    }

                    // even if left or right is null, enqueue them to queue
                    storage.Enqueue(top.left);
                    storage.Enqueue(top.right);
                }
            }

            return sb.ToString(0, sb.Length - 1);
        }

        // Decodes your encoded data to tree.
        public TreeNode deserialize(string data)
        {
            if (string.IsNullOrEmpty(data))
            {
                return null;
            }

            string[] dataArray = data.Split(',');
            TreeNode root = new TreeNode(Convert.ToInt32(dataArray[0]));

            // whenever I find a non null value, make a node and enqueue to the queue, so we can handle it's left and right child later.
            Queue<TreeNode> storage = new Queue<TreeNode>();
            storage.Enqueue(root);
            int idx = 1;

            while (storage.Count > 0)
            {
                int n = storage.Count;
                for (int i = 0; i < n; i++)
                {
                    var top = storage.Dequeue();

                    if (dataArray[idx] != "#")
                    {
                        top.left = new TreeNode(Convert.ToInt32(dataArray[idx]));
                        storage.Enqueue(top.left);
                    }
                    idx++;

                    if (dataArray[idx] != "#")
                    {
                        top.right = new TreeNode(Convert.ToInt32(dataArray[idx]));
                        storage.Enqueue(top.right);
                    }
                    idx++;
                }
            }

            return root;
        }
    }
}