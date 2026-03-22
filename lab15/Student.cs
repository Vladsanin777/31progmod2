using System;
using System.IO;
using System.Text;
using Human;

namespace Student;

struct StudentBase<TContainer> : HumanBase<TContainer>
    where TContainer : unmanaged
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
            string _group) :
        base(firstName, secondName, surname)
    {
        m_course = course;
        m_studyBuilding = studyBuilding;
        m_group = _group;
    }
    ~StudentBase() { }
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
    public override string toString()
    {
        base.toString();
        return $"{getCourse()} {getStudyBuilding()} {getGroup()}";
    }
}
