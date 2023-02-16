using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture_7_notes_assignment
{
    public class Student
    {
        //fields
        public string FirstName;
        public string LastName;
        public int CSIGrade;
        public int GenEdGrade;

        public Student(string firstName, string lastName, int cSIGrade, int genEdGrade)
        {
            FirstName = firstName;
            LastName = lastName;
            CSIGrade = cSIGrade;
            GenEdGrade = genEdGrade;
        }
    }
}
