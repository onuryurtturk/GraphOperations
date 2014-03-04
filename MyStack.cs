using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Graphs
{
    class MyStack<T>
    {
        private T[] items;
        private int top;
        public MyStack()
        {
            top = -1;
            items=new T[20];
        }
        public MyStack(int size)
        {
            top = -1;
            items = new T[size];
        }
        public void Push(T item)
        {
            if (isFull())
                throw new Exception("Stack is full");
            items[++top] = item;
        }
        public T Pop()
        {
            if (isEmpty())
                throw new Exception("Stack is empty");
            return items[top--];
        }
        public T Peek()
        {
            if (isEmpty())
                throw new Exception("Stack is empty");
            return items[top];
        }
        public bool isEmpty()
        { return top == -1; }
        public bool isFull()
        { return top == items.Length - 1; }
        public int Count()
        { return top + 1; }
    }

}
