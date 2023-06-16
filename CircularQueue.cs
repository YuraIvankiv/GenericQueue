using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    internal class CircularQueue<T>
    {
        private T[] elements;
        private int front;
        private int rear;
        private int count;
        public int Count => count;
        public bool IsEmpty => count == 0;
        public bool IsFull => count == elements.Length;
        public CircularQueue(int capacity)
        {
            elements = new T[capacity];
            front = 0;
            rear = -1;
            count = 0;
        }
        public void Enqueue(T item)
        {
            if (IsFull)
            {
                throw new InvalidOperationException("The circular queue is full.");
            }

            rear = (rear + 1) % elements.Length;
            elements[rear] = item;
            count++;
        }
        public T Dequeue()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("The circular queue is empty.");
            }

            T item = elements[front];
            elements[front] = default(T); 

            front = (front + 1) % elements.Length;
            count--;

            return item;
        }
        public T Peek()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("The circular queue is empty.");
            }

            return elements[front];
        }
        public void Clear()
        {
            Array.Clear(elements, 0, elements.Length);
            front = 0;
            rear = -1;
            count = 0;
        }
    }
}
