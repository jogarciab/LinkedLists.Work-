using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleList;

public class DoubleLinkedList<T> where T : IComparable<T>
{
    private Node<T>? _head;
    private Node<T>? _tail;

    public DoubleLinkedList()
    {
        _head = null;
        _tail = null;
    }

    override public string ToString() // Method to display the list forward
    {
        var current = _head;
        var result = string.Empty;
        while (current != null)
        {
            result += $"{current.Data} -> ";
            current = current.Next;
        }
        result += "null";
        return result;
    }

    public string ToStringReverse() // Method to display the list in reverse order
    {
        var current = _tail;
        var result = string.Empty;
        while (current != null)
        {
            result += $"{current.Data} -> ";
            current = current.Previous;
        }
        result += "null";
        return result;
    }

    public void Add(T data)
    {
        var newNode = new Node<T>(data);

        if (_head == null) // List is empty
        {
            _head = newNode;
            return;
        }
        
        Node<T> current = _head;

        if (string.Compare(data.ToString(), _head.Data.ToString()) < 0) // Insert at start
        {
            newNode.Next = _head;
            _head.Previous = newNode;
            _head = newNode;
            return;
        }

        while (current.Next != null && current.Next.Data.CompareTo(data) < 0) // Find the correct position 
        {
            current = current.Next;
        }

        newNode.Next = current.Next; // Insert node

        if (current.Next != null)
        {
            current.Next.Previous = newNode;
        }
        else
        {
            _tail = newNode; 
        }
        current.Next = newNode;
        newNode.Previous = current;
    }
}
