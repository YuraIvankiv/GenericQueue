using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    internal class PriorityQueue<T>
    {
        private List<T> elements;
        private IComparer<T> comparer;
        public int Count => elements.Count;
        public bool IsEmpty => elements.Count == 0;
        public PriorityQueue() : this(Comparer<T>.Default) { }
        public PriorityQueue(IComparer<T> comparer)
        {
            this.elements = new List<T>();
            this.comparer = comparer;
        }
        public void Enqueue(T item)
        {
            elements.Add(item);
            int childIndex = elements.Count - 1;

            while (childIndex > 0)
            {
                int parentIndex = (childIndex - 1) / 2;

                if (comparer.Compare(elements[childIndex], elements[parentIndex]) >= 0)
                    break;

                Swap(childIndex, parentIndex);
                childIndex = parentIndex;
            }
        }
        public T Peek()
        {
            if (elements.Count == 0)
                throw new InvalidOperationException("The priority queue is empty.");

            return elements[0];
        }
        public void Clear()
        {
            elements.Clear();
        }
        public T Dequeue()//Метод робив з допомогою JPT
        {
            if (elements.Count == 0)
                throw new InvalidOperationException("The priority queue is empty.");

            T firstItem = elements[0];
            int lastIndex = elements.Count - 1;
            elements[0] = elements[lastIndex];
            elements.RemoveAt(lastIndex);
            int currentIndex = 0;
            while (true)
            {
                int leftChildIndex = 2 * currentIndex + 1;
                int rightChildIndex = 2 * currentIndex + 2;

                if (leftChildIndex >= elements.Count)
                    break;

                int smallerChildIndex = leftChildIndex;
                if (rightChildIndex < elements.Count && comparer.Compare(elements[rightChildIndex], elements[leftChildIndex]) < 0)
                    smallerChildIndex = rightChildIndex;

                if (comparer.Compare(elements[currentIndex], elements[smallerChildIndex]) <= 0)
                    break;

                Swap(currentIndex, smallerChildIndex);
                currentIndex = smallerChildIndex;
            }
            return firstItem;
        }
        private void Swap(int index1, int index2)
        {
            T temp = elements[index1];
            elements[index1] = elements[index2];
            elements[index2] = temp;
        }
    }
}
  
