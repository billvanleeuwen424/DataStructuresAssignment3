using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4
{
    class Node
    {
        public int value;
        public Node left;
        public Node right;
        public Node parent;
    }

    class BinarySearchTree
    {
        public Node insert(Node root, int v)
        {
            if (root == null)
            {
                root = new Node();
                root.value = v;
            }


            // insertion logic, if the value (v )is < root, insert to the root.left
            // otherwise it's >=, so insert to the right
            else if (v < root.value)
            {

                root.left = insert(root.left, v);
                root.left.parent = root;
            }
            else
            {

                root.right = insert(root.right, v);
                root.right.parent = root;
            }

            return root;
        }
        // Lab:  Take the code from here, and implement 3 different traversals  as strings
        // public string traverse (Node root)

        public void traverse(Node root)
        {
            if (root == null)
            {
                return;
            }
            Console.WriteLine(root.value.ToString());
            traverse(root.left);
            traverse(root.right);


        }
        // For students to implement in the lab 
        // note that in order, pre order and post order are all just rearranging the order
        // of the traverse method basically
        public string inOrder(Node root)
        {
            if (root == null)
            {
                return "";
            }

            string returnString = "";

            returnString += inOrder(root.left);

            returnString += (root.value.ToString() + ", ");

            returnString += inOrder(root.right);

            return returnString;
        }

        public string preOrder(Node root)
        {
            if (root == null)
            {
                return "";
            }

            string returnString = "";

            returnString += (root.value.ToString() + ", ");

            returnString += preOrder(root.left);

            returnString += preOrder(root.right);

            return returnString;
        }

        public string postOrder(Node root)
        {
            if (root == null)
            {
                return "";
            }

            string returnString = "";

            returnString += postOrder(root.left);

            returnString += postOrder(root.right);

            returnString += (root.value.ToString() + ", ");


            return returnString;
        }

        public void breadthFirst(Node root)
        {
            //build queue
            Queue<Node> queue = new Queue<Node>();

            //put the root into it
            queue.Enqueue(root);

            int i = 0;
            //continue until no more nodes
            while (queue.Count > 0)
            {
                i++;
                root = queue.Dequeue();

                if (root != null)
                {
                    queue.Enqueue(root.left);
                    queue.Enqueue(root.right);

                    Console.WriteLine(root.value.ToString());
                }
            }
        }

        public string findSmallest(Node root)
        {
            string returnString = "";

            if (root.left == null)
            {
                returnString = root.value.ToString();
            }
            else
                returnString = findSmallest(root.left);

            return returnString;
        }


        public Node Search(Node root, int item)
        {
            Node returnNode = new Node();

            if (root.value == item)
            {
                return root;
            }
            else if (root.left != null && item < root.value)
            {
                root = Search(root.left, item); 
            }
            else if (root.right != null && item > root.value)
            {
                    root = Search(root.right, item);
            }
            else
                root = returnNode;  //null node

            return root;
        }

        public Node GetSibling(Node root)
        {
            Node sibling = new Node();

            Node parent = root.parent;

            if (parent.left == root && parent.right != null)
                sibling = parent.right;
            else if (parent.right == root && parent.left != null)
                sibling = parent.left;

            return sibling;
        }

        public Node GetAunt(Node root)
        {
            Node aunt = new Node();

            Node parent = root.parent;
            Node grandParent = parent.parent;

            if (grandParent.left == parent && grandParent.right != null)
                aunt = grandParent.right;
            else if (grandParent.right == parent && grandParent.left != null)
                aunt = grandParent.left;

            return aunt;
        }

        public void Delete(Node toDelete)
        {

        }
    }
}
