using System;

namespace StudentSpace
{
    public class Student 
    {
        public string name;
        public string classRoom;
        public double cgpa;

        public Student(string Sname, string SclassRoom, double Scgpa)
        {
            name = Sname;
            classRoom = SclassRoom;
            cgpa = Scgpa;
        }

        //object method
        public bool hasHonor()
        {
            if(cgpa >= 3.5)
            {
                return true;
            }
            return false;
        }
    }
}
