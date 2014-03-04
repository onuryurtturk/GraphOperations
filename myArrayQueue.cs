using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Graphs
{
    class myArrayQueue<T>
    {
        private T[] items;
        private int front, back;
        private int count;
        
        public myArrayQueue(int size)
        {
            items = new T[size];
            front = 0;
            back = 0;
            count = 0;

        }
        public myArrayQueue()
        {
            items = new T[10];
            front = 0;
            back = 0;
            count = 0;
        }
        public void Enqueue(T item)    
        {
            if (isFull())
                throw new Exception("Queue is full!");
            count++;
            items[back] = item;
            back = (back+1) % items.Length;
        }
        public T Dequeue()
        {
            if (isEmpty())
                throw new Exception("Queue is empty!");
            count--;
            T ritem= items[front];
            front=(front+1) % items.Length;
            return ritem;
        }
        public bool isEmpty()
        { return count == 0; }
        public bool isFull()
        { return count==items.Length; }

        public void Display()
        {
            for (int i = front; i != back; i = ((i+1) % items.Length))
                Console.Write("{0}", items[i]);
        }
    }
}
