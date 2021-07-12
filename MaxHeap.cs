using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4
{
    class MaxHeap<T> : IEnumerable where T : IComparable
    {
        public T[] array;
        private int count;

        public MaxHeap(int size)
        {
            array = new T[size];
            count = 0;
        }

        /// <summary>
        /// insert an item into the heap. Will grow the array if too small, will recalculate items position.
        /// </summary>
        /// <param name="item"></param>
        public void addToHeap(T item)
        {
            //if the heap is empty, put in first item
            if (count == 0)
            {
                array[0] = item;
            }
            else
            {
                array[count] = item;

                RecalculatePositionUp(count);
            }

            count++;

            if (count >= array.Length)
            {
                Grow();
            }
        }


        /// <summary>
        /// private method, recursively recalculates an item passed postion
        /// </summary>
        /// <param name="index"></param>
        private void RecalculatePositionUp(int index)
        {
            int parentIndex = (index - 1) / 2;

            if (array[index].CompareTo(array[parentIndex]) > 0) //if the parent index is less, swap
            {
                Swap(parentIndex, index);   //parentindex is now the index of the original value

                if (parentIndex != 0)    //if we're not at the root, check again
                {
                    RecalculatePositionUp(parentIndex);
                }
            }
        }

        /// <summary>
        /// recursively recalculates an items passed postion
        /// </summary>
        /// <param name="index"></param>
        private void RecalculatePositionDown(int index)
        {
            int leftChildIndex = 2 * index + 1;
            int rightChildIndex = 2 * index + 2;
            int largestChildIndex;

            if (leftChildIndex >= count) //check if its potential child index is out of the heap
            {
                largestChildIndex = index;  //set the largest index to itself
            }
            else if (rightChildIndex >= count)   //maybe the left is inside bounds, and right is outside??
            {
                largestChildIndex = leftChildIndex;
            }
            else
            {
                if (array[rightChildIndex].CompareTo(array[leftChildIndex]) > 0)    //is right child larger than left
                {
                    largestChildIndex = rightChildIndex;
                }
                else
                {
                    largestChildIndex = leftChildIndex;
                }
            }

            if (array[index].CompareTo(array[largestChildIndex]) < 0)   //is the new entry smaller than the largest child?
            {
                Swap(index, largestChildIndex);
                RecalculatePositionDown(largestChildIndex);
            }


        }

        /// <summary>
        /// swaps two index positions passed.
        /// </summary>
        /// <param name="position1"></param>
        /// <param name="position2"></param>
        private void Swap(int position1, int position2)
        {
            T first = array[position1];
            array[position1] = array[position2];
            array[position2] = first;
        }

        /// <summary>
        /// increases the arrays size by 1
        /// </summary>
        private void Grow()
        {
            int newLength = array.Length + 1;

            T[] newArray = new T[newLength];

            for (int i = 0; i < array.Length; i++)
            {
                newArray[i] = array[i];
            }

            array = newArray;
        }

        /// <summary>
        /// removes the top item of the heap, and recalulates the items position
        /// </summary>
        /// <returns></returns>
        public T Pop()
        {
            T item = array[0];

            array[0] = array[count - 1];
            array[count - 1] = default(T);

            RecalculatePositionDown(0);

            count--;

            return item;
        }

        /// <summary>
        /// sorts the heapsort array and returns the array if requested.
        /// </summary>
        public T[] HeapSort()
        {
            T[] tempArray = new T[count];
            int countHolder = count;

            int i = 0;
            while(count > 0)
            {
                tempArray[i] = Pop();
                i++;
            }

            array = tempArray;
            count = countHolder;

            return array;
        }


        public IEnumerator GetEnumerator()
        {
            for (int index = 0; index < array.Length; index++)
            {
                // Yield each element 

                yield return array[index];
            }
        }
    }
}
