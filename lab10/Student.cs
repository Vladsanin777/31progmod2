using System;
using System.IO;
using System.Text;
using Human;

namespace Student;

class StudentBase : HumanBase
{
    private byte m_course;
    private string m_studyBuilding;
    private string m_group;

    public StudentBase() : base() {
        m_course = 0;
        m_studyBuilding = "";
        m_group = "";
    }

    public StudentBase(string firstName, 
            string secondName, string surname,
            byte course, string studyBuilding, 
            string group) :
        base(firstName, secondName, surname)
    {
        m_course = course;
        m_studyBuilding = studyBuilding;
        m_group = group;
    }

    ~StudentBase() { }

    public override int GetHashCode()
    {
        return HashCode.Combine(m_course, m_studyBuilding, m_group);
    }

    public override bool Equals(object? obj)
    {
        if (obj is not StudentBase other) return false;

        return base.Equals(other) && getCourse() == other.getCourse() && 
               getStudyBuilding() == other.getStudyBuilding() && 
               getGroup() == other.getGroup();
    }

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
    public override string ToString()
    {
        return $"{base.ToString()} {getCourse()} {getStudyBuilding()} {getGroup()}";
    }
}
