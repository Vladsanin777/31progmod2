using System;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;

unsafe struct Node<TContainer>
    where TContainer : unmanaged
{
    private TContainer * m_prev;
    private TContainer * m_next;

    public Node() {
        m_prev = null;
        m_next = null;
    }

    public ref TContainer getPrev() {
        return ref * m_prev;
    }

    public void setPrev(ref TContainer container) {
        m_prev = (TContainer*)Unsafe.AsPointer(ref container);
    }

    public ref TContainer getNext() {
        return ref * m_next;
    }

    public void setNext(ref TContainer container) {
        m_next = (TContainer*)Unsafe.AsPointer(ref container);
    }
}
