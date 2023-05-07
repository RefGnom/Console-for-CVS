using System;

namespace Clones;

public class Stack<T>
{
    private class Node
    {
        public T Value { get; private set; }
        public Node Previous { get; private set; }

        public Node(T value, Node previous)
        {
            Value = value;
            Previous = previous;
        }
    }

    private Node first;
    private Node last;
    private int count;

    public int Count => count;

    public Stack() { }

    private Stack(Node first, Node last, int count)
    {
        this.first = first;
        this.last = last;
        this.count = count;
    }

    public void Push(T value)
    {
        var item = new Node(value, last);
        if (first == null)
        {
            first = last = item;
        }
        else
        {
            last = item;
        }
        count++;
    }

    public T Peek()
    {
        if (first == null)
            throw new InvalidOperationException();
        return last.Value;
    }

    public T Pop()
    {
        T result;
        if (first == null)
        {
            throw new InvalidOperationException();
        }
        else if (last.Previous == null)
        {
            result = last.Value;
            first = last = null;
        }
        else
        {
            result = last.Value;
            last = last.Previous;
        }
        count--;
        return result;
    }

    public Stack<T> Copy()
    {
        return new Stack<T>(first, last, count);
    }
}