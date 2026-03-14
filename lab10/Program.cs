using System;

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
}
class Student : HumanBase
{
    private byte m_course;
    private string m_studyBuilding;
    private string m_group;
    public Student(byte course, string studyBuilding, string _group, string firstName, string secondName, string surname) :
        base(firstName, secondName, surname)
    {
        m_course = course;
        m_studyBuilding = studyBuilding;
        m_group = _group;
    }
    ~Student() { }
    public byte getCourse()
    {
        return m_course;
    }
    public string getStudyBuilding()
    {
        return m_studyBuilding;
    }
    public string getGroup()
    {
        return m_group;
    }
    public void setCourse(byte course)
    {
        m_course = course;
    }
    public void setStudyBuilding(string studyBuilding)
    {
        m_studyBuilding = studyBuilding;
    }
    public void setGroup(string group)
    {
        m_group = group;
    }
    public string toString()
    {
        return $"{getCourse()} {getStudyBuilding()} {getGroup()}";
    }
    static void Main() { }
}
