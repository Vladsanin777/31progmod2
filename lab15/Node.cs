using System;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;


public class DoublyLinkedList<T>
{
    private class Node
    {
        private Node? m_previous;
        private object? m_data;
        private Node? m_next;

        public Node(T? data) {
            m_data = data;
        }

        public void setData(T? data) {
            m_data = data;
        }

        public T? getData() {
            return (T?)m_data;
        }

        public void setNext(Node? next) {
            m_next = next;
        }

        public Node? getNext() {
            return m_next;
        }

        public void setPrevious(Node? previous) {
            m_previous = previous;
        }

        public Node? getPrevious() {
            return m_previous;
        }
    }
    private Node? m_head;
    private Node? m_tail;
    private long m_count;

    private void setCount(long count) {
        m_count = count;
    }

    public long getCount() {
        return m_count;
    }

    public T? getHead() {
        return m_head!.getData();
    }

    public T? getTail() {
        return m_tail!.getData();
    }

    private void setHead(Node? head) {
        m_head = head;
    }

    private void setTail(Node? tail) {
        m_tail = tail;
    }

    public void AddLast(T data)
    {
        Node newNode = new Node(data);

        if (m_head == null)
            m_head = newNode;
        else if (m_tail != null) {
            m_tail.setNext(newNode);
            newNode.setPrevious(m_tail);
        }
        m_tail = newNode;
        m_count++;
    }

    public void AddFirst(T data)
    {
        Node newNode = new Node(data);
        Node? temp = m_head;

        newNode.setNext(temp);
        m_head = newNode;

        if (m_count == 0)
        {
            m_tail = m_head;
        }
        else if (temp != null) {
            temp.setPrevious(newNode);
        }
        
        m_count++;
    }

    public bool Remove(T data)
    {
        Node? current = FindNode(data);
        if (current != null) {
            if (current.getPrevious() != null)
                current.getPrevious()!.setNext(current.getNext());
            else m_head = current.getNext();

            if (current.getPrevious() != null)
                current.getNext()!.setPrevious(current.getPrevious());

            else m_tail = current.getPrevious();

            m_count--;
            return true;
        }
        return false;
    }

    public T? Find(T data)
    {
        Node? nodeTemp = FindNode(data);
        return nodeTemp != default ? nodeTemp.getData() : default;
    }

    private Node? FindNode(T data)
    {
        Node? current = m_head;
        
        while (current != null)
        {
            if (current.getData()!.Equals(data))
            {
                return current;
            }
            current = current.getNext();
        }
        
        return default;
    }
}
