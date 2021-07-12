using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTreeLab
{
    class Node
    {
        public int value;
        public Node left;
        public Node right;
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
            }
            else
            {
                root.right = insert(root.right, v);
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
            Console.WriteLine( root.value.ToString());
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
            while(queue.Count > 0)
            {
                i++;
                root = queue.Dequeue();

                if (root != null)
                {
                    queue.Enqueue(root.left);
                    queue.Enqueue(root.right);

                    Console.WriteLine("loop iterations: " + i);
                    Console.WriteLine(root.value.ToString());
                }
            }
        }

        public string findSmallest(Node root)
        {
            string returnString = "";

            if(root.left == null)
            {
                returnString = root.value.ToString();
            }
            else
                returnString = findSmallest(root.left);

            return returnString;
        }

    }
}
