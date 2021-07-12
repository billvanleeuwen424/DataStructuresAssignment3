using System;

namespace Assignment4
{
    class Program
    {
        static void Main(string[] args)
        {
            MaxHeap<int> intHeap = new MaxHeap<int>(5);
            BinarySearchTree intTree = new BinarySearchTree();
            Node root = null;

            Random rand = new Random(5);

            int[] intarray = new int[25];

            for (int i = 0; i <25; i++)
            {
                int add = rand.Next(25);
                intHeap.addToHeap(add);
                root = intTree.insert(root, add);


                intarray[i] = add;
            }

            Node searchTest = intTree.Search(root, 6);
            Node searchTestSibling = intTree.GetSibling(searchTest);
            Node searchTestAunt = intTree.GetAunt(searchTest);
            Console.WriteLine(searchTestAunt.value);
        }
    }
}
