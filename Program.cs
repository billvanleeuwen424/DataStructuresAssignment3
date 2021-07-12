using System;

namespace Assignment4
{
    class Program
    {
        static void Main(string[] args)
        {
            MaxHeap<int> intHeap = new MaxHeap<int>(5);

            Random rand = new Random(5);

            int[] intarray = new int[25];

            for (int i = 0; i <25; i++)
            {
                int add = rand.Next(25);

                intHeap.addToHeap(add);

                intarray[i] = add;
            }
            intHeap.HeapSort();

        }
    }
}
