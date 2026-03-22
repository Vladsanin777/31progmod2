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

class HumanBase : HumanInterface
{
    private string m_firstName;
    private string m_secondName;
    private string m_surname;

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

    public override int GetHashCode()
    {
        return HashCode.Combine(m_firstName, m_secondName, m_surname);
    }

    public override bool Equals(object? obj)
    {
        if (obj is not HumanBase other) return false;

        return getFirstName() == other.getFirstName() && 
               getSecondName() == other.getSecondName() && 
               getSurname() == other.getSurname();
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
    public override string ToString()
    {
        return $"{getFirstName()} {getSecondName()} {getSurname()}";
    }
}
