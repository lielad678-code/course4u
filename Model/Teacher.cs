using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Teacher:User
    {
        private int salary;
        private int teachingCourseID;
        public int Salary { get => salary; set => salary = value; }
        public int TeachingCourseID { get => teachingCourseID; set => teachingCourseID = value; }
    }
}
