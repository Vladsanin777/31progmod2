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
    public override void serialize(BinaryWriter writer) {
        base.serialize(writer);
        writer.Write(getCourse());
        writer.Write(getStudyBuilding());
        writer.Write(getGroup());
    }
    public override void serialize(Stream stream) {
        using (BinaryWriter writer = new BinaryWriter(stream, Encoding.UTF8, false))
        {
            serialize(writer);
        }
    }
    public override void serialize(string fileName) {
        using (Stream stream = File.Open(fileName, FileMode.Create))
        {
            serialize(stream);
        }
    }
    public override void deserialize(BinaryReader reader) {
        base.deserialize(reader);
        setCourse(reader.ReadByte());
        setStudyBuilding(reader.ReadString());
        setGroup(reader.ReadString());
    }
    public override void deserialize(Stream stream) {
        using (BinaryReader reader = new BinaryReader(stream, Encoding.UTF8, false))
        {
            deserialize(reader);
        }
    }
    public override void deserialize(string fileName) {
        using (Stream stream = File.Open(fileName, FileMode.Open, FileAccess.Read))
        {
            deserialize(stream);
        }
    }
    public override string ToString()
    {
        base.toString();
        return $"{getCourse()} {getStudyBuilding()} {getGroup()}";
    }
}
