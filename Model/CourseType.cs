using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class CourseType:BaseEntity
    {
        private string courseName;

        public string CourseName { get => courseName; set => courseName = value; }

    }


}
