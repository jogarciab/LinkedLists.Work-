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

        if (string.Compare(data.ToString(), _head.Data!.ToString()) < 0) // Insert at start
        {
            newNode.Next = _head;
            _head.Previous = newNode;
            _head = newNode;
            return;
        }

        while (current.Next != null && current.Next.Data!.CompareTo(data) < 0) // Find the correct position 
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

    public void SortDescending(T data)
    {
        if (_head == null) return;
        var current = _head;
        while (current != null)
        {
            var next = current.Next;
            while (next != null)
            {
                if (current.Data!.CompareTo(next.Data) < 0)
                {
                    var temp = current.Data;
                    current.Data = next.Data;
                    next.Data = temp;
                }
                next = next.Next;
            }
            current = current.Next;
        }
    }

    public string ShowModes()
    {
        if (_head == null)
            return "No Data";

        var current = _head;

        T currentValue = current.Data!;
        int currentCount = 1;
        int maxCount = 1;

        List<T>  modes = new List<T>();

        current = current.Next;

        while (current != null)
        {
            if (current.Data!.CompareTo(currentValue) == 0)
            {
                currentCount++;
            }
            else
            {
                if (currentCount > maxCount)
                {
                    modes.Clear();
                    modes.Add(currentValue);
                    maxCount = currentCount;
                }
                else if (currentCount == maxCount)
                {
                    modes.Add(currentValue);
                }
                currentValue = current.Data;
                currentCount = 1;
            }
            current = current.Next;
        }

        if (currentCount > maxCount)
        {
            modes.Clear();
            modes.Add(currentValue);

        }
        else if (currentCount == maxCount)
        {
            modes.Add(currentValue);
        }

        return string.Join(", ", modes);
    }

    public void ShowGraphic()
    { }

    public bool Exists(T data)
    {
        var current = _head;

        while (current != null)
        {
            if (current.Data!.CompareTo(data) == 0)
            {
                return true;
            }

            current = current.Next;
        }
        return false;
    }

    public bool RemoveOccurrence(T data)
    { 
        if (_head == null) return false;

        var current = _head;

        while (current != null)
        {
            if (current.Data!.CompareTo(current.Data) == 0)
            {
                if (current == _head)
                {
                    _head = _head.Next;

                    if (_head != null)
                    {
                        _head.Previous = null;
                    }
                    else
                    {
                        _tail = null;
                    }
                }
                else if (current == _tail)
                {
                    _tail = _tail.Previous;

                    if (_tail != null)
                    {
                        _tail.Next = null;
                    }
                }
                else
                {
                    current.Previous!.Next = current.Next;
                    current.Next!.Previous = current.Previous;
                }
                return true;
            }

            current = current.Next;
        }
        return false;
    }

    public int RemoveAllOccurrences(T data)
    {
        int count = 0;
        var current = _head;

        while (current != null)
        {
            var next = current.Next;

            if (current.Data!.CompareTo(data) == 0)
            {
                if (current == _head)
                {
                    _head = _head.Next;

                    if (_head != null)
                    {
                        _head.Previous = null;
                    }
                    else
                    {
                        _tail = null;
                    }
                }
                else if (current == _tail)
                {
                    _tail = _tail.Previous;

                    if (_tail != null)
                    {
                        _tail.Next = null;
                    }
                }
                else
                {
                    current.Previous!.Next = current.Next;
                    current.Next!.Previous = current.Previous;
                }
                count++;
            }
            current = next;
        }
        return count;
    }
}
