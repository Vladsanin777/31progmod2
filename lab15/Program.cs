using System;
using Human;
using Student;

class Program {
    static void Main() {
        DoublyLinkedList<HumanBase> list = new DoublyLinkedList<HumanBase>();
        HumanBase human1 = new HumanBase("ivan", "ivanov", "ivanovich");
        HumanBase human2 = new HumanBase("iliay", "iliaynov", "iliaynovich");
        StudentBase student1 = new StudentBase("student", "stu", "stuch", 3, "fh", "jk");
        StudentBase student2 = new StudentBase("student", "stu", "stuch", 3, "fh", "jk");
        list.AddFirst(human1);
        list.AddLast(human2);
        list.AddFirst(student1);
        StudentBase? student3 = list.Find(student2) as StudentBase;
        if (student3 != null) {
            Console.WriteLine(student3);
            student1.setFirstName("stud");
            Console.WriteLine(student3);
        }
    }
}
