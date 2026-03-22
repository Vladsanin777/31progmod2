using System;
using System.IO;
using System.Text;

namespace Human;

interface HumanInterface
{
    public string getFirstName();
    public string getSecondName();
    public string getSurname();
    public void setFirstName(string firstName);
    public void setSecondName(string secondName);
}

struct HumanBase : HumanInterface
{
    private string m_firstName;
    private string m_secondName;
    private string m_surname;
    private Node<HumanBase> m_node;

    public HumanBase() {
        m_firstName = "";
        m_secondName = "";
        m_surname = "";
    }

    public HumanBase(string firstName, string secondName, string surname)
    {
        m_firstName = firstName;
        m_secondName = secondName;
        m_surname = surname;
    }
    ~HumanBase() { }

    public void setNext(ref Node node) {
        m_node.setNext(node);
    }

    public void setPrev(ref Human<TContainer> human) {
        m_node.setPrev(human);
    }

    public ref Human<TContainer> getNext() {
        return ref m_node.getNext();
    }

    public ref Human<TContainer> getPrev() {
        return ref m_node.getPrev();
    }

    public string getFirstName()
    {
        return m_firstName;
    }
    public string getSecondName()
    {
        return m_secondName;
    }
    public string getSurname()
    {
        return m_surname;
    }
    public void setFirstName(string firstName)
    {
        m_firstName = firstName;
    }
    public void setSecondName(string secondName)
    {
        m_secondName = secondName;
    }
    public void setSurname(string surname)
    {
        m_surname = surname;
    }
    public virtual string toString()
    {
        return $"{getFirstName()} {getSecondName()} {getSurname()}";
    }
}
