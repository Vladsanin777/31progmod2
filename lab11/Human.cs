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

abstract class HumanBase : HumanInterface
{
    private string m_firstName;
    private string m_secondName;
    private string m_surname;

    public HumanBase(string firstName, string secondName, string surname)
    {
        m_firstName = firstName;
        m_secondName = secondName;
        m_surname = surname;
    }
    ~HumanBase() { }
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
    public virtual void serialize(BinaryWriter writer) {
        writer.Write(getFirstName());
        writer.Write(getSecondName());
        writer.Write(getSurname());
    }
    public virtual void serialize(Stream stream) {
        using (BinaryWriter writer = new BinaryWriter(stream, Encoding.UTF8, false))
        {
            serialize(writer);
        }
    }
    public virtual void serialize(string fileName) {
        using (Stream stream = File.Open(fileName, FileMode.Create))
        {
            serialize(stream);
        }
    }
    public virtual void deserialize(BinaryReader reader) {
        setFirstName(reader.ReadString());
        setSecondName(reader.ReadString());
        setSurname(reader.ReadString());
    }
    public virtual void deserialize(Stream stream) {
        using (BinaryReader reader = new BinaryReader(stream, Encoding.UTF8, false))
        {
            deserialize(reader);
        }
    }
    public virtual void deserialize(string fileName) {
        using (Stream stream = File.Open(fileName, FileMode.Create))
        {
            deserialize(stream);
        }
    }
    public virtual string toString()
    {
        return $"{getFirstName()} {getSecondName()} {getSurname()}";
    }
}
