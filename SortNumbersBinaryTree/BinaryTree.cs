using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortNumbersBinaryTree
{
    public class BinaryTree
    {
        private int arrayLength;
        private string filePathOutput;

        // Class containing left and
        // right child of current 
        // node and key value
        public class Node
        {
            public int key;
            public Node left, right;

            public Node(int item)
            {
                key = item;
                left = right = null;
            }
        }

        // Root of BST
        public Node root;

        // Constructor
        public BinaryTree(int arrayLength, string filePathOutput)
        {
            root = null;
            this.arrayLength = arrayLength;
            this.filePathOutput = filePathOutput;
        }

        // This method mainly
        // calls insertRec()
        public void insert(int key)
        {
            root = insertRec(root, key);
        }

        /* A recursive function to 
          insert a new key in BST */
        Node insertRec(Node root, int key)
        {

            /* If the tree is empty,
                return a new node */
            if (root == null)
            {
                root = new Node(key);
                return root;
            }

            /* Otherwise, recur
                down the tree */
            if (key < root.key)
                root.left = insertRec(root.left, key);
            else if (key > root.key)
                root.right = insertRec(root.right, key);

            /* return the root */
            return root;
        }

        // A function to do 
        // inorder traversal of BST
        public void inorderRec(Node root)
        {
 
            if (root != null)
            {
                inorderRec(root.left);
                Console.Write(root.key + " ");
                AppendToFile(root.key.ToString());
                inorderRec(root.right);
            }
           
        }
        public void treeins(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                insert(arr[i]);
            }

        }

        public void AppendToFile(string number)
        {
            using (StreamWriter w = File.AppendText(filePathOutput))
            {
                w.WriteLine(number);
            }
        }
    }
}
